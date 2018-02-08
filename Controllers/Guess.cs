using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HangmanProject.Models;

namespace HangmanProject.Controllers
{
  public class GuessController : Controller
  {
    [HttpPost("/Guess/Create")]
    public ActionResult Create()
    {
      Guess myGuess = new Guess();
      myGuess.SetGuessChar(Request.Form["newGuess"]);
      myGuess.Save();
      Game.SetGuesses(Guess.GetGuesses());
      if (Game.GetDashString().Count != 0 && Game.GetOldDashString().Count != 0)
      {
        Game.AddStrike(Game.IfIncorrectGuess());
      }
      if (Game.GetDashString().Count != 0)
      {
        Game.SetOldDashString(Game.GetDashString());
      }
      Game.SetDashString();
      Game.SetWin();
      Game.SetLose();
      return View("../Game/Info");
    }
  }
}
