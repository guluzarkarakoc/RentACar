using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageControllers : ControllerBase
    {
        public ICarImageService _carImageService;

        public CarImageControllers(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

    }
   


}