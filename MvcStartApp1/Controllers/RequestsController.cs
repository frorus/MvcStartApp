using Microsoft.AspNetCore.Mvc;
using MvcStartApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp1.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestRepository _repo;

        public RequestsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logs()
        {
            var requests = await _repo.GetRequests();
            return View(requests);
        }
    }
}
