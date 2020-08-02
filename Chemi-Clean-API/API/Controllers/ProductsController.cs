using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.UnitOfWork;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using System.Net;
using API.DTO.Product;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductsController(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductForGetDTO>>> Get()
        {
            List<ProductForGetDTO> products = _mapper.Map<List<ProductForGetDTO>>(await _productRepository.GetAsync().ConfigureAwait(true));
            return Ok(products);
        }

        [HttpGet("download")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Download()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    new System.Uri("http://www.tanaco.dk/cms/modules/ContentExpress/img_repository/RTU%20Xtra,%20bic.pdf"),
                    "D:\\1.pdf"
                );
            }
            return Ok();
        }
    }
}