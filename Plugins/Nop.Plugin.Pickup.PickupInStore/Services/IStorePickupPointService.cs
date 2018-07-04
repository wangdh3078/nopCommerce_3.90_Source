using Nop.Core;
using Nop.Plugin.Pickup.PickupInStore.Domain;

namespace Nop.Plugin.Pickup.PickupInStore.Services
{
    /// <summary>
    /// Store pickup point service interface
    /// </summary>
    public partial interface IStorePickupPointService
    {
        /// <summary>
        /// Gets all pickup points
        /// </summary>
        /// <param name="storeId">�̵��ʶ��; ����0�Լ������м�¼</param>
        /// <param name="pageIndex">ҳ������</param>
        /// <param name="pageSize">ҳ���С</param>
        /// <returns>Pickup points</returns>
        IPagedList<StorePickupPoint> GetAllStorePickupPoints(int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a pickup point
        /// </summary>
        /// <param name="pickupPointId">Pickup point identifier</param>
        /// <returns>Pickup point</returns>
        StorePickupPoint GetStorePickupPointById(int pickupPointId);

        /// <summary>
        /// Inserts a pickup point
        /// </summary>
        /// <param name="pickupPoint">Pickup point</param>
        void InsertStorePickupPoint(StorePickupPoint pickupPoint);

        /// <summary>
        /// Updates a pickup point
        /// </summary>
        /// <param name="pickupPoint">Pickup point</param>
        void UpdateStorePickupPoint(StorePickupPoint pickupPoint);

        /// <summary>
        /// Deletes a pickup point
        /// </summary>
        /// <param name="pickupPoint">Pickup point</param>
        void DeleteStorePickupPoint(StorePickupPoint pickupPoint);
    }
}
