using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW10.DTOs;
using HW10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW10.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IEntitySaverService entitySaverService;
        private readonly SmsSenderService smsSenderService;
        private readonly EmailSenderService emailSenderService;

        public ServicesController(IEntitySaverService entitySaverService, SmsSenderService smsSenderService, EmailSenderService emailSenderService)
        {
            this.entitySaverService = entitySaverService;
            this.smsSenderService = smsSenderService;
            this.emailSenderService = emailSenderService;
        }
        [HttpPut]
        public async Task<IActionResult> SaveEntity(EntityDTO entity)
        {
            //var entitySaver = new EntitySaverService();
            await entitySaverService.SaveEntity(entity);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessageDTO emailMessage)
        {
            await emailSenderService.SendAsync(emailMessage);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetCodeVerefication([FromForm]string phoneNumber)
        {
            await smsSenderService.SendAsync(phoneNumber);

            return Ok();
        }
    }
}