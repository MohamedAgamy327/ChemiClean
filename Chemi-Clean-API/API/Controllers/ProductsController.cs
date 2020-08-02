using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.UnitOfWork;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _contractRepository;
        public ProductsController(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository contractRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contractRepository = contractRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductForGetDTO>>> Get()
        {
            List<ProductForGetDTO> contracts = _mapper.Map<List<ProductForGetDTO>>(await _contractRepository.GetAsync().ConfigureAwait(true));
            return Ok(contracts);
        }

        [HttpGet("download")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Download()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    new System.Uri("http://www.delaval.dk/ImageVaultFiles/id_6409/cf_5/DeLavalMastitisTestCMT.pdf"),
                    "D:\\1.pdf"
                );
            }
            return Ok();
        }
    }
}