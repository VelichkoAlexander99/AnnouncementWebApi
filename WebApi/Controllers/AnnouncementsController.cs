using Domain.Models.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;
using WebApi.Services.AnnouncementService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        // GET api/announcements/
        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncements([FromQuery] QueryAnnouncementParameters query)
        {
            return Ok(await _announcementService.GetAll(query));
        }

        // GET api/announcements/5
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAnnouncement(Guid id)
        {
            var response = await _announcementService.GetById(id);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        // POST api/announcements
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] AnnouncementForCreationDto announcementDto)
        {
            var response = await _announcementService.Create(announcementDto);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        // PUT api/announcements/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAnnouncement(Guid id, [FromBody] AnnouncementForUpdateDto announcementDto)
        {
            var response = await _announcementService.Update(id, announcementDto);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        // DELETE api/announcements/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id)
        {
            var response = await _announcementService.Delete(id);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
