using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HangmanProject.Models
{
  public class Player
  {
    private string _name;
    private int _score;
    private int _id;

    private static List<Player> _players = new List<Player>();

    public void SetName(string name)
    {
      _name = name;
    }

    public void SetScore(int score)
    {
      _score = score;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetScore()
    {
      return _score;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      _players.Add(this);
      _id = _players.Count;
    }

    public static List<Player> GetPlayers()
    {
      return _players;
    }

    public Player Find(int id)
    {
      return _players[id-1];
    }


  }
}
