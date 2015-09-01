using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MVCModel;
using MVCBase.Enums;

namespace MVCDTO.StockTasks
{
    public class TransferOrderPrimitiveDTO : BaseDTO, IPrimitiveEntity, IPrimitiveDTO
    {
        public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.TransferOrder; } }

        public int GetID() { return this.TransferOrderID; }
        public void SetID(int id) { this.TransferOrderID = id; }

        public int TransferOrderID { get; set; }

        [Display(Name = "Ngày yêu cầu hàng về")]
        public Nullable<System.DateTime> RequestedDate { get; set; }

        public int SourceLocationID { get; set; }
        [Required]
        [Display(Name = "Chi nhánh xuất")]
        public string LocationName { get; set; }


        public int WarehouseID { get; set; }
        [Required]
        [Display(Name = "Kho nhập")]
        public string WarehouseName { get; set; }
        public string WarehouseLocationTelephone { get; set; }
        public string WarehouseLocationFacsimile { get; set; }
        public string WarehouseLocationName { get; set; }
        public string WarehouseLocationAddress { get; set; }

        [Display(Name = "Người duyệt")]
        public int ApproverID { get; set; }

        [Display(Name = "Tổng SL")]
        public decimal TotalQuantity { get; set; }
        [Display(Name = "Diễn giải")]
        public string Description { get; set; }
        [Display(Name = "Ghi chú")]
        public string Remarks { get; set; }
    }



    public class TransferOrderDTO : TransferOrderPrimitiveDTO, IBaseDetailEntity<TransferOrderDetailDTO>
    {
        public TransferOrderDTO()
        {
            this.TransferOrderViewDetails = new List<TransferOrderDetailDTO>();
        }

        public List<TransferOrderDetailDTO> TransferOrderViewDetails { get; set; }
        public List<TransferOrderDetailDTO> ViewDetails { get { return this.TransferOrderViewDetails; } set { this.TransferOrderViewDetails = value; } }

        public ICollection<TransferOrderDetailDTO> GetDetails() { return this.TransferOrderViewDetails; }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();
            this.GetDetails().ToList().ForEach(e => { e.EntryDate = this.EntryDate; e.LocationID = this.LocationID; });
        }
    }
}
