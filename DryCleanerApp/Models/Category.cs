using System.ComponentModel.DataAnnotations.Schema;

namespace EcomMVC.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public required string CategoryName { get; set; }
        public string? Icon { get; set; }
        public int SellerID { get; set; }
        public string? ParentCategoryName { get; set; }
        public int ParentCategoryID { get; set; }
    }
}
