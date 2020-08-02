using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.DTO.Contract
{
    public class ProductForFileDTO
    {
        [FromForm(Name = "Id")]
        public int Id { get; set; }

        [FromForm(Name = "file")]
        public IFormFile File { get; set; }
    }
}
