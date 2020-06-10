using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordCloud.Application.Words;
using WordCloud.Web.Models;

namespace WordCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetContent(WordCloudDto model)
        {
            var results = await _mediator.Send(new ListWords.Query { Url = model.Url, Count = 100 });
            await _mediator.Send(new Create.Command { Words = results.Words });
            return View("~/Views/Home/Index.cshtml", results);
        }
    }
}
