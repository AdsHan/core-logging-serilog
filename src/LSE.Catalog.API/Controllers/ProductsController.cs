using LSE.Catalog.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DSC.Products.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/products
        /// <summary>
        /// Obtêm os produtos
        /// </summary>
        /// <returns>Coleção de objetos da classe Produto</returns>                
        /// <response code="200">Lista dos produtos</response>        
        /// <response code="400">Falha na requisição</response>         
        /// <response code="404">Nenhum aluno foi localizado</response>         
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAllAsync();

            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET: api/products/5
        /// <summary>
        /// Obtêm as informações do produto pelo seu Id
        /// </summary>
        /// <param name="id">Código do produto</param>
        /// <returns>Objetos da classe Produto</returns>                
        /// <response code="200">Informações do Producto</response>
        /// <response code="400">Falha na requisição</response>         
        /// <response code="404">O aluno não foi localizado</response>         
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id)
        {

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
