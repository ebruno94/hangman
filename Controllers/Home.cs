using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HangmanProject.Models;

namespace HangmanProject.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
