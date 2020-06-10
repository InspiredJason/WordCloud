using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordCloud.Application.Words;

namespace WordCloud.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult<WordCountDto>> WordCount()
        {
            var model = await _mediator.Send(new List.Query());

            return View(model);
        }
    }
}