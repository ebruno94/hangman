using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HangmanProject.Models;

namespace HangmanProject.Controllers
{
  public class GameController : Controller
  {

    [HttpPost("/Game/Create")]
    public ActionResult Create()
    {
      Game.SetCurrentWord(Request.Form["currentWord"]);
      Game myGame = new Game();
      Game.SetDashString(); 
      return View("Info", myGame);
    }
  }
}
