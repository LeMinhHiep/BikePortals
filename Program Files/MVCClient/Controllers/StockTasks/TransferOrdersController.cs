using System.Net;
using System.Web.Mvc;
using System.Text;

using RequireJsNet;

using MVCModel.Models;
using MVCBase.Enums;
using MVCCore.Services.StockTasks;
using MVCClient.Builders.StockTasks;
using MVCClient.ViewModels.StockTasks;
using MVCDTO.StockTasks;


namespace MVCClient.Controllers.SalesTasks
{
    public class TransferOrdersController : GenericViewDetailController<TransferOrder, TransferOrderDetail, TransferOrderViewDetail, TransferOrderDTO, TransferOrderPrimitiveDTO, TransferOrderDetailDTO, TransferOrderViewModel>
    {
        public TransferOrdersController(ITransferOrderService TransferOrderService, ITransferOrderViewModelSelectListBuilder TransferOrderViewModelSelectListBuilder)
            : base(TransferOrderService, TransferOrderViewModelSelectListBuilder)
        {
        }

        public override void AddRequireJsOptions()
        {
            base.AddRequireJsOptions();

            StringBuilder commodityTypeIDList = new StringBuilder();
            commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Vehicles);
            commodityTypeIDList.Append(","); commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Parts);
            commodityTypeIDList.Append(","); commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Consumables);

            RequireJsOptions.Add("commodityTypeIDList", commodityTypeIDList.ToString(), RequireJsOptionsScope.Page);
        }

    }

}