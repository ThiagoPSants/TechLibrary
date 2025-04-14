using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Users.Register;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestUserJson request)
        
        {
           var useCase = new RegisterUserUseCase();

           var response = useCase.Execute(request);

            return Created(string.Empty, response); 
            
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Delete();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Get();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Put();


        }

        [HttpPost("Noname")]
        public IActionResult Create2()
        {
            return Created();
        }
    }
}
