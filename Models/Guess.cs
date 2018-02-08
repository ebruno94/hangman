using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HangmanProject.Models
{
  public class Guess
  {
    private string _guessChar;
    private static List<string> _guesses = new List<string>();

    public void SetGuessChar(string guess)
    {
      _guessChar = guess;
    }

    public string GetGuessChar()
    {
      return _guessChar;
    }

    public bool Save()
    {
      if (!_guesses.Contains(_guessChar))
      {
        _guesses.Add(_guessChar);
        return true;
      }
      else
      {
        return false;
      }
    }

    public static List<string> GetGuesses()
    {
      return _guesses;
    }
  }
}
