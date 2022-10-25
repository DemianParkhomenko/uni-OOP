namespace Lab1
{
  class GameAccount
  {
    List<StatRecord> _stats = new();

    static readonly int _minimalRating = 1;
    decimal _currentRating = _minimalRating;
    decimal _previousRating = _minimalRating;

    public string UserName { get; set; }

    public decimal CurrentRating { get { return _currentRating; } }

    public decimal GamesCount { get { return _stats.Count(); } }

    public GameAccount(string username)
    {
      UserName = username;
    }

    public void WinGame(string opponentName, decimal rating)
    {
      throwIfNegativeRating(rating);
      updateRating(_currentRating + rating);
      _stats.Add(new StatRecord(opponentName, rating, true));
    }

    public void LoseGame(string opponentName, decimal rating)
    {
      throwIfNegativeRating(rating);
      if (_currentRating - rating < _minimalRating)
      {
        updateRating(_minimalRating);
      }
      else
      {
        updateRating(_currentRating - rating);
      }
      _stats.Add(new StatRecord(opponentName, rating, false));
    }

    public void CancelLastGame()
    {
      if (_stats.Count() == 0)
        return;
      var lastRecord = _stats.Last();
      if (lastRecord.IsWin)
        updateRating(_currentRating - lastRecord.Rating);
      else if (_previousRating != _minimalRating)
        updateRating(_currentRating + lastRecord.Rating);

      _stats.RemoveAt(_stats.Count() - 1);
    }

    public List<StatRecord> GetStats()
    {
      return _stats.ConvertAll(stat =>
                 new StatRecord(stat.OpponentName, stat.Rating, stat.IsWin));
    }

    public void WriteStats()
    {
      Console.WriteLine("----------------Stats----------------");
      Console.WriteLine($"User: {UserName}");
      Console.WriteLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
      Console.WriteLine($"Games count:{GamesCount}");
      Console.WriteLine($"Current rating:{CurrentRating}");
      Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Index", "Rating", "Result", "Opponent");
      for (int i = 0; i < _stats.Count; i++)
      {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}", i, _stats[i].Rating,
                         _stats[i].IsWin ? "Win" : "Lose", _stats[i].OpponentName);
      }
    }

    void updateRating(decimal newRating)
    {
      _previousRating = _currentRating;
      _currentRating = newRating;
    }

    void throwIfNegativeRating(decimal rating)
    {
      if (rating < 0)
        throw new ArgumentOutOfRangeException("Rating", "Game rating cannot be negative");
    }
  }
}
