using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Daekage_Server.Models;
using Daekage_Server.Services;

namespace Daekage_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticesController : ControllerBase
    {
        private readonly NoticeService _noticeService;

        public NoticesController(NoticeService noticeService)
        {
            _noticeService = noticeService;
        }

        [HttpGet]
        public ActionResult<List<Notice>> Get() =>
            _noticeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetNotice")]
        public ActionResult<Notice> Get(string id)
        {
            var notice = _noticeService.Get(id);

            if (notice == null)
            {
                return NotFound();
            }

            return notice;
        }

        [HttpPost]
        public ActionResult<Notice> Create(Notice notice)
        {
            _noticeService.Create(notice);

            return CreatedAtRoute("GetNotice", new { id = notice.Id }, notice);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Notice noticeIn)
        {
            if (_noticeService.Get(id) == null)
            {
                return NotFound();
            }

            _noticeService.Update(id, noticeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            if (_noticeService.Get(id) == null)
            {
                return NotFound();
            }

            _noticeService.Remove(id);

            return NoContent();
        }
    }
}
