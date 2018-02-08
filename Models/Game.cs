using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HangmanProject.Models
{
  public class Game
  {
    private static List<Player> _players = new List<Player>();
    private static List<string> _guesses = new List<string>();

    private static List<string> _oldDashString = new List<string>();
    private static bool _win = false;
    private static bool _lose = false;
    private static string _currentWord;
    private static List<string> _dashString = new List<string>();
    private static int _numStrike = 1;
    private static Player _currentPlayer;

    public static void SetWin()
    {
      _win = true;
      for (int i = 0; i < _dashString.Count; i ++)
      {
        if (_dashString[i].Equals("_"))
        {
          _win = false;
        }
      }
    }

    public static bool GetWin()
    {
      return _win;
    }

    public static void SetLose()
    {
      if (_numStrike == 7)
      {
        _lose = true;
      }
    }

    public static bool GetLose()
    {
      return _lose;
    }

    public static void SetCurrentWord(string word)
    {
      _currentWord = word;
    }

    public static string GetCurrentWord()
    {
      return _currentWord;
    }

    public static void SetNumStrike()
    {
      _numStrike ++;
    }

    public static int GetNumStrike()
    {
      return _numStrike;
    }

    public static void SetCurrentPlayer(Player currentPlayer)
    {
      _currentPlayer = currentPlayer;
    }

    public static Player GetCurrentPlayer()
    {
      return _currentPlayer;
    }

    public static void SetPlayers(List<Player> players)
    {
      _players = players;
    }

    public static List<Player> GetPlayers()
    {
      return _players;
    }

    public static void SetOldDashString(List<string> oldDashString)
    {
      _oldDashString.Clear(); 
      foreach (string dash in oldDashString)
      {
        _oldDashString.Add(dash);
      }
    }

    public static List<string> GetOldDashString()
    {
      return _oldDashString;
    }

    public static void SetDashString()
    {
      _dashString.Clear();
      List<string> guessWord = new List<string>();
      for (int i = 0; i < _currentWord.Length; i ++)
      {
        guessWord.Add((_currentWord[i]).ToString());
      }

      foreach (string letter in guessWord)
      {
        bool guessExists = false;
        foreach (string guess in _guesses)
        {
          if (letter == guess)
          {
            guessExists = true;
          }
        }
        if (guessExists)
        {
          _dashString.Add(letter);
        }
        else
        {
          _dashString.Add("_");
        }
      }
    }

    public static bool IfIncorrectGuess()
    {
      Console.WriteLine(Game._oldDashString.Count);
      Console.WriteLine(Game._dashString.Count);
      for (int i = 0; i < Game._dashString.Count; i++)
      {
        if (Game._oldDashString[i].Equals(Game._dashString[i]))
        {
          Console.WriteLine("I am the same character!");
          return true;
        }
      }
      Console.WriteLine("All Characters are different");
      return false;
    }

    public static void AddStrike(bool flag)
    {
      if (flag)
      {
        _numStrike ++;
      }
    }

    public static List<string> GetDashString()
    {
      return _dashString;
    }

    public static void SetGuesses(List<string> guesses)
    {
      _guesses = guesses;
    }

    public static List<string> GetGuesses()
    {
      return _guesses;
    }
  }
}
