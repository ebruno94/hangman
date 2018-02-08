using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HangmanProject.Models;

namespace HangmanProject.Controllers
{
  public class PlayerController : Controller
  {

    [HttpGet("/Player/Form")]
    public ActionResult Form()
    {
      return View();
    }

    [HttpPost("/Player/Create")]
    public ActionResult Create()
    {
      Player myPlayer1 = new Player();
      Player myPlayer2 = new Player();
      myPlayer1.SetName(Request.Form["player1Name"]);
      myPlayer2.SetName(Request.Form["player2Name"]);
      Game.SetCurrentPlayer(myPlayer1);
      myPlayer1.Save();
      myPlayer2.Save();
      Game.SetPlayers(Player.GetPlayers());
      return View("../Game/Form", myPlayer1);
    }
  }
}
