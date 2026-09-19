using LocalShop.Services;
using LocalShopDataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using LocalShopDataAccessLayer.DTOs;
using LocalShopBusinessLayer.Services;
namespace LocalShop.Controllers
{
    [Route("api/LocalShop")]
    [ApiController]
    public class LocalShopController : ControllerBase
    {
        AuthService auth = new AuthService();


        [HttpPost("LoginCheck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> LoginCheck(AuthDTO.Login LoginInfo)
        {
            Person? person = await auth.LoginCheck(LoginInfo.Email.ToLower(), LoginInfo.Password);
            if (person == null)
            {
                return NotFound("Email or Password or both is not correct");
            }
            return Ok("Valid info");

        }





        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(AuthDTO.NewPerson P)
        {
            if(P== null)
            {
                return BadRequest("Not Valid info");
            }
            Person person = new Person();
            person.PersonId = 0;
            person.DateOfBirth = P.DateOfBirth;
            person.FirstName = P.FirstName;
            person.LastName = P.LastName;
            person.Phone = P.Phone;
            if(P.DateOfBirth != null)
            {
                person.DateOfBirth = P.DateOfBirth;
            }
            person.Email = P.Email.ToLower();
            person.Password = P.Password;
            await auth.Register(person);
            
                return Ok("Completed Succesuflly");
            
        }







        ProductsServices ProductsService = new ProductsServices();

        [HttpGet("ProductView'ID'")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ProductView(int ProductID)
        {
            Product? product = await ProductsService.ProductView(ProductID);
            if(product == null)
            {
                return NotFound($"No product with ID = {ProductID} ,");
            }
            return Ok(product);
        }



        [HttpGet("ProductView'Name'")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ProductView(string Name)
        {
            Product? product = await ProductsService.ProductView(Name);
            if (product == null)
            {
                return NotFound($"No product with Name = {Name} ,");
            }
            return Ok(product);
        }



        [HttpGet("ProductSmallView'ID'")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ProductllView(int ProductID)
        {
            Product? product = await ProductsService.ProductView(ProductID);
            if (product == null)
            {
                return NotFound($"No product with ID = {ProductID} ,");
            }
            ProductSmallView P = new ProductSmallView();
            P.Name = product.Name;
            P.Price = product.Price;
            P.ProductsImages = product.ProductsImages;
            P.Reviews = product.Reviews;
            return Ok(P);
        }



        [HttpGet("ProductSmallView'Name'")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ProductSmallView(string Name)
        {
            Product? product = await ProductsService.ProductView(Name);
            if (product == null)
            {
                return NotFound($"No product with Name = {Name} ,");
            }
            ProductSmallView P = new ProductSmallView();
            P.Name = product.Name;
            P.Price = product.Price;
            P.ProductsImages = product.ProductsImages;
            P.Reviews = product.Reviews;
            return Ok(P);
        }




        [HttpGet("GetSearchResults")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<List<ProductSmallView>>> GetSearchResults(string SearchInput)
        {

            
            List<Product> Products = await ProductsService.GetProductBySearch(SearchInput);
            if(Products == null)
            {
                return NotFound();
            }

            var PDTO = Products.Select(P => new ProductSmallView { Name = P.Name, Price = P.Price, ProductsImages = P.ProductsImages, Reviews = P.Reviews });
            return Ok(PDTO);
        }

        OrderServices os = new OrderServices();
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostOrderPlaced(Order order)
        {
            order = await os.PostOrder(order);
            if(order == null)
            {
                return BadRequest("Please Fill all data");
            }
            return Ok(order);
        }

    }
}
