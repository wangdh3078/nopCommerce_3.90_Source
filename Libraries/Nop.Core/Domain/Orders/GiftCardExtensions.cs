
namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 礼品卡扩展
    /// </summary>
    public static class GiftCardExtensions
    {
        /// <summary>
        /// 获取礼品卡剩余金额
        /// </summary>
        /// <returns>礼品卡剩余金额</returns>
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
        /// 礼品卡是否有效
        /// </summary>
        /// <param name="giftCard">礼物卡</param>
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
