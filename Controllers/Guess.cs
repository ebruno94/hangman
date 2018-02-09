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
      Game.SetDashString();
      if (Game.GetOldDashString().Count != 0)
      {
        Game.AddStrike(Game.IfIncorrectGuess());
      }
      else
      {
        int index = Game.GetDashString().Count;
        List<string> tempList = new List<string>();
        for (int i = 0; i < index; i ++)
        {
          tempList.Add("_");
        }
        Game.SetOldDashString(tempList);
        Game.AddStrike(Game.IfIncorrectGuess());
      }
      Game.SetOldDashString(Game.GetDashString());
      Game.SetWin();
      Game.SetLose();
      return View("../Game/Info");
    }
  }
}
