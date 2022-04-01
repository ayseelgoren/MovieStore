using BusinessLayer.Concretes;
using EntitiesLayer.ViewModel.WriterModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {

        private readonly IWriterService _writerService;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _writerService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(WriterModel model)
        {
            _writerService.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateWriterModel model)
        {
            _writerService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteWriterModel model)
        {
            _writerService.Delete(model);
            return Ok();
        }
    }
}
