using System;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ���ﳵ
    /// </summary>
    public partial class ShoppingCartItem : BaseEntity
    {
        /// <summary>
        /// ��ȡ�������̵��ʶ
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�����ù��ﳵ���ͱ�ʶ��
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ������XML��ʽ�Ĳ�Ʒ����
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�����ļ۸�
        /// </summary>
        public decimal CustomerEnteredPrice { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ��ȡ���������޲�Ʒ�Ŀ�ʼ���ڣ�������������޲�Ʒ����Ϊnull��
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// ��ȡ���������޲�Ʒ�Ľ������ڣ�������������޲�Ʒ����Ϊnull��
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����µ����ں�ʱ��
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ��־����
        /// </summary>
        public ShoppingCartType ShoppingCartType
        {
            get
            {
                return (ShoppingCartType)this.ShoppingCartTypeId;
            }
            set
            {
                this.ShoppingCartTypeId = (int)value;
            }
        }

        /// <summary>
        ///��ȡ�����ò�Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ���ﳵ��Ŀ�Ƿ�����ͻ�
        /// </summary>
        public bool IsFreeShipping
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsFreeShipping;
                return true;
            }
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ���ﳵ��Ŀ�Ƿ�������
        /// </summary>
        public bool IsShipEnabled
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsShipEnabled;
                return false;
            }
        }

        /// <summary>
        /// ��ȡ������˷�
        /// </summary> 
        public decimal AdditionalShippingCharge
        {
            get
            {
                decimal additionalShippingCharge = decimal.Zero;
                var product = this.Product;
                if (product != null)
                    additionalShippingCharge = product.AdditionalShippingCharge * Quantity;
                return additionalShippingCharge;
            }
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ���ﳵ��Ŀ�Ƿ���˰
        /// </summary>
        public bool IsTaxExempt
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsTaxExempt;
                return false;
            }
        }
    }
}
