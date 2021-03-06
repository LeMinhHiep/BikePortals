﻿using System.ComponentModel.DataAnnotations;

namespace MVCClient.ViewModels.Helpers
{
    public interface ICommodityAutoCompleteViewModel
    {        
        int CommodityID { get; set; }
        [Display(Name = "Mã hàng")]
        string CommodityCode { get; set; }
        [Display(Name = "Tên hàng")]
        string CommodityName { get; set; }
    }
}
