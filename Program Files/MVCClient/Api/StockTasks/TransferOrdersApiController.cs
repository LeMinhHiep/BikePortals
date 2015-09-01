using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


using MVCModel.Models;
using MVCDTO.StockTasks;
using MVCCore.Repositories.StockTasks;




using Microsoft.AspNet.Identity;




namespace MVCClient.Api.StockTasks
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class TransferOrdersApiController : Controller
    {
        private readonly ITransferOrderRepository transferOrderRepository;

        public TransferOrdersApiController(ITransferOrderRepository transferOrderRepository)
        {
            this.transferOrderRepository = transferOrderRepository;
        }

        public JsonResult GetTransferOrders([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<TransferOrder> saleTransfers = this.transferOrderRepository.Loading(User.Identity.GetUserId(), MVCBase.Enums.GlobalEnums.NmvnTaskID.TransferOrder).Include(w => w.Warehouse).Include(l => l.Location);

            DataSourceResult response = saleTransfers.ToDataSourceResult(request, o => new TransferOrderPrimitiveDTO
            {
                TransferOrderID = o.TransferOrderID,
                EntryDate = o.EntryDate,
                RequestedDate = o.RequestedDate,
                Reference = o.Reference,
                LocationName = o.Location.Name,
                WarehouseName = o.Warehouse.Name,
                TotalQuantity = o.TotalQuantity,
                Description = o.Description,
                Remarks = o.Remarks
            });
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SearchTransferOrders([DataSourceRequest] DataSourceRequest dataSourceRequest, int locationID, string commodityTypeIDList, string searchText)
        {
            var result = transferOrderRepository.SearchTransferOrders(locationID, commodityTypeIDList, searchText).Select(s => new
            {
                s.TransferOrderID,
                TransferOrderReference = s.Reference,
                TransferOrderEntryDate = s.EntryDate,
                TransferOrderRequestedDate = s.RequestedDate,

                s.WarehouseID,
                WarehouseCode = s.Warehouse.Code,
                WarehouseName = s.Warehouse.Name,
                WarehouseLocationName = s.Warehouse.Location.Name,
                WarehouseLocationTelephone = s.Warehouse.Location.Telephone,
                WarehouseLocationFacsimile = s.Warehouse.Location.Facsimile,
                WarehouseLocationAddress = s.Warehouse.Location.Address
            });
            return Json(result.ToDataSourceResult(dataSourceRequest), JsonRequestBehavior.AllowGet);
        }


    }
}