using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Device Name is required.")]
        [StringLength(150, ErrorMessage = "Device Name cannot exceed 150 characters.")]
        [Display(Name = "Device Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Device Code is required.")]
        [StringLength(50, ErrorMessage = "Device Code cannot exceed 50 characters.")]
        [Display(Name = "Device Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public DeviceCategory Category { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public DeviceStatus Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Entry")]
        public DateTime DateOfEntry { get; set; } = DateTime.Now;
    }
}