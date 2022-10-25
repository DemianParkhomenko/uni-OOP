namespace Lab1
{
  class GameAccount
  {
    List<StatRecord> _stats = new();

    static readonly int _minimalRating = 1;
    decimal _currentRating = _minimalRating;

    public string UserName { get; set; }

    public decimal CurrentRating { get { return _currentRating; } }

    public decimal GamesCount { get { return _stats.Count(); } }

    public GameAccount(string username)
    {
      UserName = username;
    }

    public void WinGame(string opponentName, int rating)
    {
      throwNegativeRating(rating);
      _currentRating += rating;
      _stats.Add(new StatRecord(opponentName, rating, true));
    }

    public void LoseGame(string opponentName, int rating)
    {
      throwNegativeRating(rating);
      if (_currentRating - rating < _minimalRating)
        _currentRating = _minimalRating;
      else
        _currentRating -= rating;

      _stats.Add(new StatRecord(opponentName, rating, false));
    }

    public List<StatRecord> GetStats()
    {
      return _stats.ConvertAll(stat => new StatRecord(stat.OpponentName, stat.Rating, stat.IsWin));
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

    private void throwNegativeRating(int rating)
    {
      if (rating < 0)
        throw new ArgumentOutOfRangeException("Rating", "Game rating cannot be negative");
    }
  }
}
