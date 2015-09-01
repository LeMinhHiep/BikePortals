using System.Web.Mvc;
using System.Collections.Generic;

using MVCClient.ViewModels.Helpers;
using MVCDTO.StockTasks;

namespace MVCClient.ViewModels.StockTasks
{
    public class TransferOrderViewModel : TransferOrderDTO, IViewDetailViewModel<TransferOrderDetailDTO>, IPreparedPersonDropDownViewModel, IApproverDropDownViewModel, IWarehouseAutoCompleteViewModel, ILocationAutoCompleteViewModel
    {
        public IEnumerable<SelectListItem> PreparedPersonDropDown { get; set; }
        public IEnumerable<SelectListItem> ApproverDropDown { get; set; }
    } 

}