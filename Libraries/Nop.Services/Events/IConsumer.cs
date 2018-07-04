
namespace Nop.Services.Events
{
    /// <summary>
    /// 消费者
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IConsumer<T>
    {
        void HandleEvent(T eventMessage);
    }
}
