using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// 通过循环当前正在执行的AppDomain中的程序集来查找Nop所需的类型的类。 
    /// 只调查名称与特定模式匹配的程序集，
    /// 并始终调查由<see cref ="AssemblyNames"/>引用的可选组件列表。
    /// </summary>
    public class AppDomainTypeFinder : ITypeFinder
    {
        #region 字段
        /// <summary>
        /// 忽略反射错误
        /// </summary>
        private bool ignoreReflectionErrors = true;
        /// <summary>
        /// 加载AppDomain程序集
        /// </summary>
        private bool loadAppDomainAssemblies = true;
        /// <summary>
        /// 程序集跳过加载模式
        /// </summary>
        private string assemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";
        /// <summary>
        /// 程序及限制加载模式
        /// </summary>
        private string assemblyRestrictToLoadingPattern = ".*";
        /// <summary>
        /// 程序集名称集合
        /// </summary>
        private IList<string> assemblyNames = new List<string>();

        #endregion

        #region 属性

        /// <summary>
        /// 要在其中查找类型的应用程序域
        /// </summary>
        public virtual AppDomain App
        {
            get { return AppDomain.CurrentDomain; }
        }

        /// <summary>
        /// 获取或设置Nop是否应在加载Nop类型时迭代应用程序域中的程序集。 加载这些组件时会应用加载模式。
        /// </summary>
        public bool LoadAppDomainAssemblies
        {
            get { return loadAppDomainAssemblies; }
            set { loadAppDomainAssemblies = value; }
        }

        /// <summary>
        /// 获取或设置程序集加载的启动程序以及在AppDomain中加载的程序集。
        /// </summary>
        public IList<string> AssemblyNames
        {
            get { return assemblyNames; }
            set { assemblyNames = value; }
        }

        /// <summary>
        /// 获取我们知道不需要调查的dll的模式。
        /// </summary>
        public string AssemblySkipLoadingPattern
        {
            get { return assemblySkipLoadingPattern; }
            set { assemblySkipLoadingPattern = value; }
        }

        /// <summary>
        /// 获取或设置将要调查的dll模式。 为了便于使用，默认情况下，所有默认值都匹配，
        /// 但为了提高性能，您可能需要配置包含程序集和您自己的程序集的模式。
        /// </summary>
        /// <remarks>
        /// 如果你改变这个以便Nop程序集未被调查
        /// （例如，通过不包括“^ Nop | ...”之类的东西，你可能会破坏核心功能。
        /// </remarks>
        public string AssemblyRestrictToLoadingPattern
        {
            get { return assemblyRestrictToLoadingPattern; }
            set { assemblyRestrictToLoadingPattern = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof(T), onlyConcreteClasses);
        }
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <param name="assignTypeFrom">查找类型</param>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(assignTypeFrom, GetAssemblies(), onlyConcreteClasses);
        }
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="assemblies">程序集</param>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof (T), assemblies, onlyConcreteClasses);
        }
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <param name="assignTypeFrom">查找类型</param>
        /// <param name="assemblies">程序集</param>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            var result = new List<Type>();
            try
            {
                foreach (var a in assemblies)
                {
                    Type[] types = null;
                    try
                    {
                        types = a.GetTypes();
                    }
                    catch
                    {
                        //Entity Framework 6 doesn't allow getting types (throws an exception)
                        if (!ignoreReflectionErrors)
                        {
                            throw;
                        }
                    }
                    if (types != null)
                    {
                        foreach (var t in types)
                        {
                            if (assignTypeFrom.IsAssignableFrom(t) || (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, assignTypeFrom)))
                            {
                                if (!t.IsInterface)
                                {
                                    if (onlyConcreteClasses)
                                    {
                                        if (t.IsClass && !t.IsAbstract)
                                        {
                                            result.Add(t);
                                        }
                                    }
                                    else
                                    {
                                        result.Add(t);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }
            return result;
        }

        /// <summary>
        /// 获取与当前实现相关的程序集。
        /// </summary>
        /// <returns>
        /// 应该由Nop工厂加载的程序集列表。
        /// </returns>
        public virtual IList<Assembly> GetAssemblies()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();

            if (LoadAppDomainAssemblies)
                AddAssembliesInAppDomain(addedAssemblyNames, assemblies);
            AddConfiguredAssemblies(addedAssemblyNames, assemblies);

            return assemblies;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 迭代AppDomain中的所有程序集，如果它的名称与配置的模式相匹配，则将其添加到我们的列表中。
        /// </summary>
        /// <param name="addedAssemblyNames">已添加的程序集名称</param>
        /// <param name="assemblies">程序集</param>
        private void AddAssembliesInAppDomain(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (Matches(assembly.FullName))
                {
                    if (!addedAssemblyNames.Contains(assembly.FullName))
                    {
                        assemblies.Add(assembly);
                        addedAssemblyNames.Add(assembly.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// 添加专门配置的程序集。
        /// </summary>
        /// <param name="addedAssemblyNames">程序集名称</param>
        /// <param name="assemblies">程序集</param>
        protected virtual void AddConfiguredAssemblies(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            foreach (string assemblyName in AssemblyNames)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                if (!addedAssemblyNames.Contains(assembly.FullName))
                {
                    assemblies.Add(assembly);
                    addedAssemblyNames.Add(assembly.FullName);
                }
            }
        }

        /// <summary>
        /// 检查DLL是否是不需要调查的DLL之一。
        /// </summary>
        /// <param name="assemblyFullName">
        /// 要检查的程序集的名称。
        /// </param>
        /// <returns>
        /// 如果应该将程序集加载到Nop中，则为true。
        /// </returns>
        public virtual bool Matches(string assemblyFullName)
        {
            return !Matches(assemblyFullName, AssemblySkipLoadingPattern)
                   && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }

        /// <summary>
        /// 检查DLL是否是不需要调查的DLL之一。
        /// </summary>
        /// <param name="assemblyFullName">
        /// 要匹配的程序集名称。
        /// </param>
        /// <param name="pattern">
        /// 要与程序集名称匹配的正则表达式模式。
        /// </param>
        /// <returns>
        /// 如果模式与程序集名称匹配，则为真。
        /// </returns>
        protected virtual bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        ///确保提供的文件夹中的匹配程序集已加载到应用程序域中。
        /// </summary>
        /// <param name="directoryPath">
        /// 包含dll以加载到应用程序域中的目录的物理路径。
        /// </param>
        protected virtual void LoadMatchingAssemblies(string directoryPath)
        {
            var loadedAssemblyNames = new List<string>();
            foreach (Assembly a in GetAssemblies())
            {
                loadedAssemblyNames.Add(a.FullName);
            }

            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            foreach (string dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    var an = AssemblyName.GetAssemblyName(dllPath);
                    if (Matches(an.FullName) && !loadedAssemblyNames.Contains(an.FullName))
                    {
                        App.Load(an);
                    }

                    //old loading stuff
                    //Assembly a = Assembly.ReflectionOnlyLoadFrom(dllPath);
                    //if (Matches(a.FullName) && !loadedAssemblyNames.Contains(a.FullName))
                    //{
                    //    App.Load(a.FullName);
                    //}
                }
                catch (BadImageFormatException ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 类型实现是否通用？
        /// </summary>
        /// <param name="type"></param>
        /// <param name="openGeneric"></param>
        /// <returns></returns>
        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }catch
            {
                return false;
            }
        }

        #endregion
    }
}
