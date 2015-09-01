using MVCModel.Models;
using MVCDTO.StockTasks;

namespace MVCCore.Services.StockTasks
{
    public interface ITransferOrderService : IGenericWithViewDetailService<TransferOrder, TransferOrderDetail, TransferOrderViewDetail, TransferOrderDTO, TransferOrderPrimitiveDTO, TransferOrderDetailDTO>
    {
        bool InitWarehouseBalance15AUG();
    } 
}

