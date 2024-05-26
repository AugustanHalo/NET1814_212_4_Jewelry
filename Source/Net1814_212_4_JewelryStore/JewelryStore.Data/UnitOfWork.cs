using JewelryStore.Data.Repository;

namespace JewelryStore.Data
{
    public class UnitOfWork
    {
        private OrderItemRepository _orderItem;
        public UnitOfWork()
        {
            
        }

        public OrderItemRepository OrderItemRepository
        {
            get
            {
                return _orderItem ??= (_orderItem = new OrderItemRepository());
            }
        }

    }
}
