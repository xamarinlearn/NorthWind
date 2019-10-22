using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.API.Interfaces;
using NorthWind.API.Models; 

namespace NorthWind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        // GET http://localhost:5645/api/products HTTP 1.1
        // GET api/values

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productRepository.All);
        }

        // GET api/values/5
        // CRUD--> READ
        // api/[controller]/[id]
        //  GET http://localhost:5645/api/products/2 HTTP 1.1
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_productRepository.Find(id));
        }

        // POST api/products
        [HttpPost]
        public ActionResult Post([FromBody] Product newProduct)
        {
            // Agregar un nuevo recurso al servidor.
            try
            {
                if (newProduct == null || !ModelState.IsValid)
                {
                    return BadRequest("El tipo product es requerido.");
                }
                bool productExists = _productRepository.DoesProductExist(newProduct.ID);
                if (productExists)
                {
                    return StatusCode
                        (StatusCodes.Status409Conflict, "Producto ya existe");
                }
                _productRepository.Insert(newProduct);
            }
            catch (Exception)
            {

                return BadRequest("Producto no creado");
            }
            return Ok(newProduct);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product productToUpdate)
        {
            try
            {
                if (productToUpdate == null || !ModelState.IsValid)
                {
                    return BadRequest("El tipo product es requerido.");
                }
                Product productExists = _productRepository.Find(id);
                if (productExists == null)
                {
                    return NotFound
                        ( "Producto no  existe");
                }
                _productRepository.Update(productToUpdate);
            }
            catch (Exception)
            {

                return BadRequest("Producto no actualizado");
            }
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Product product = _productRepository.Find(id);
                if (product == null)
                {
                    return NotFound("Producto no encontrado");
                }
                _productRepository.Delete(id);
            }
            catch (Exception)
            {

                return BadRequest("No se pudo eliminar el recurso");
            }
            return NoContent();
        }
    }
}
