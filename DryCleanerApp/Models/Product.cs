using System.ComponentModel.DataAnnotations.Schema;

namespace EcomMVC.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int FeatureId { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public float MRP { get; set; }
        public float Discount { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string CustomDetails { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CategoryID { get; set; }
        public int OrganisationID { get; set; }
        public int SellerID { get; set; }
        public string CategoryName { get; set; }
        public string SellerName { get; set; }
        public string UnitName { get; set; }
        public bool IsMandatory { get; set; }
        public bool OutOfStock { get; set; }
        public bool Disabled { get; set; }
        public int TotalOrdered { get; set; }
        public int DrugIndex { get; set; }
        public string ItemVariants { get; set; }
        public int VariantGroup { get; set; }
        public float Stock { get; set; }
        public string MultiImagesString { get; set; }
        public string MultiImages { get; set; }
        public bool AutoOutOfStock { get; set; }
        public float DiscountPercentage { get; set; }
        public string SearchKeywords { get; set; }
        public float UserWiseDiscountPercentage { get; set; }
        public float UserWiseDiscount { get; set; }
        public float ProductDiscount { get; set; }
        public float FinalPrice { get; set; }
        public float PurchasePrice { get; set; }

        //Review Section

        public int RatingCount { get; set; }

        public int ReviewCount { get; set; }

        public float AverageRating { get; set; }

        public bool IsCombo { get; set; }
        public string CurrentVariantData { get; set; }
        public string VariantSpecificData { get; set; }
        public int VariantsCount { get; set; }
        public int OtherVariantCount { get; set; }
        public float ProductWeight { get; set; }
        public string SellerPriceConfig { get; set; }
        public string ResellingPriceConfig { get; set; }
        public float CGST { get; set; }
        public float SGST { get; set; }
        public string ModificationNotificationConfig { get; set; }


        public int ParentSellerId { get; set; }
        public int ParentProductId { get; set; }

        public Category Category { get; set; }
    }
}
