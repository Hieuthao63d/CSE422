using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}