using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public enum DeviceStatus
    {
        [Display(Name = "In Use")]
        InUse,

        [Display(Name = "Broken")]
        Broken,

        [Display(Name = "Under Maintenance")]
        UnderMaintenance
    }
}