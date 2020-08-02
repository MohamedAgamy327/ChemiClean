using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using API.DTO.Product;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductsController(IMapper mapper,IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet("{page:int}/{size:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductForGetDTO>>> Get(int page, int size, [FromQuery(Name = "term")] string term)
        {
            List<ProductForGetDTO> products = _mapper.Map<List<ProductForGetDTO>>(await _productRepository.GetAsync(page, size, term).ConfigureAwait(true));
            int count = await _productRepository.GetCountAsync(term).ConfigureAwait(true);
            return Ok(new ProductPagingDTO { Count = count, Products = products });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductForGetDTO>>> Get()
        {
            List<ProductForGetDTO> products = _mapper.Map<List<ProductForGetDTO>>(await _productRepository.GetAsync().ConfigureAwait(true));
            return Ok(products);
        }
    }
}