
namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ��Ʒ����չ
    /// </summary>
    public static class GiftCardExtensions
    {
        /// <summary>
        /// ��ȡ��Ʒ��ʣ����
        /// </summary>
        /// <returns>��Ʒ��ʣ����</returns>
        public static decimal GetGiftCardRemainingAmount(this GiftCard giftCard)
        {
            decimal result = giftCard.Amount;

            foreach (var gcuh in giftCard.GiftCardUsageHistory)
                result -= gcuh.UsedValue;

            if (result < decimal.Zero)
                result = decimal.Zero;

            return result;
        }

        /// <summary>
        /// ��Ʒ���Ƿ���Ч
        /// </summary>
        /// <param name="giftCard">���￨</param>
        /// <returns></returns>
        public static bool IsGiftCardValid(this GiftCard giftCard)
        {
            if (!giftCard.IsGiftCardActivated)
                return false;

            decimal remainingAmount = giftCard.GetGiftCardRemainingAmount();
            if (remainingAmount > decimal.Zero)
                return true;

            return false;
        }
    }
}
