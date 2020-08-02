using System.Collections.Generic;

namespace API.DTO.Product
{
    public class ProductPagingDTO
    {
        public int Count { get; set; }
        public List<ProductForGetDTO> Products { get; set; }
    }
}
