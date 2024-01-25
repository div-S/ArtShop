namespace Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public string Material { get; set; }

        public string ImageUrl { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int ProductCategoryId { get; set; }

        public bool IsOriginal { get; set; }

        public bool IsPrintAvailable { get; set; }

        public int Quantity { get; set; }

        public int AvailablePrintQuantity { get; set; }

    }
}
