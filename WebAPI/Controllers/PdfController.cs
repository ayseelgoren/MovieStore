using BusinessLayer.Concretes;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Utility.CreatePdf;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private IConverter _converter;
        private readonly IDirectorService _directorService;
        private readonly IMovieService _movieService;
        private readonly IOrderService _orderService;
        private ICreatePdf _createPdf;

        public PdfController(IConverter converter, 
            IDirectorService directorService, 
            IMovieService movieService, 
            IOrderService orderService, 
            ICreatePdf createPdf)
        {
            _converter = converter;
            _directorService = directorService;
            _movieService = movieService;
            _orderService = orderService;
            _createPdf = createPdf;
        }
        [HttpGet,Route("createDirector")]
        public IActionResult CreateWriterPdf()
        {
            var directors = _directorService.GetAll();
            var directorPdf = _createPdf.PdfDirector("Director", directors);
            _converter.Convert(directorPdf);
            return Ok("Successfully director created PDF document.");
        }

        [HttpGet, Route("createOrder")]
        public IActionResult CreateOrderPdf()
        {
            var orders = _orderService.GetAll();
            var orderPdf = _createPdf.PdfOrder("Order", orders);
            _converter.Convert(orderPdf);
            return Ok("Successfully orders created PDF document.");
        }

        [HttpGet, Route("createMovie")]
        public IActionResult CreateMoviePdf()
        {
            var movies = _movieService.GetAll();
            var moviePdf = _createPdf.PdfMovie("Movie", movies );
            _converter.Convert(moviePdf);
            return Ok("Successfully movies created PDF document.");
        }
    }
}
