namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LocalUrl { get; set; }

    }
}
