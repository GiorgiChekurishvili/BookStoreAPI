using BookStore.DTOs.Publisher;
using BookStore.Services.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("getallpublishers")]
        public async Task<ActionResult<IEnumerable<PublisherRetrieveDTO>>> GetAllPublishers()
        {
            var data = await _publisherService.ViewAllPublishers();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet("getpublisherbyid{id}")]
        public async Task<ActionResult<PublisherRetrieveDTO>> GetPublisherById(int id)
        {
            var data = await _publisherService.ViewPublisherById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("uploadpublisher")]
        public async Task<ActionResult<PublisherDTO>> UploadPublisher(PublisherDTO publisher)
        {
            var data = await _publisherService.UploadPublisher(publisher);
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatepublisher/{id}")]
        public async Task<ActionResult<PublisherDTO>> UpdatePublisher(PublisherDTO publisher, int id)
        {
            var data = await _publisherService.UpdatePublisher(id, publisher);
            if (data != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletepublisher/{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            await _publisherService.DeletePublisherService(id);
            return Ok();
        }
    }
            
}
