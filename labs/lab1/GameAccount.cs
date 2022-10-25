namespace Lab1
{
  class GameAccount
  {
    static readonly int minimalRating = 1;
    decimal currentRating = minimalRating;
    List<StatRecord> stats = new List<StatRecord>();

    public GameAccount(string username)
    {
      UserName = username;
    }

    public string UserName { get; set; }

    public decimal CurrentRating
    {
      get
      {
        return this.currentRating;
      }
    }

    public decimal GamesCount
    {
      get
      {
        return stats.Count();
      }
    }

    private void checkRatingForGame(int rating)
    {
      if (rating < 0)
        throw new ArgumentOutOfRangeException("Rating", "Game rating cannot be negative");
    }

    public void WinGame(string opponentName, int rating)
    {
      checkRatingForGame(rating);
      this.currentRating += rating;
      stats.Add(new StatRecord(opponentName, rating, true));
    }

    public void LoseGame(string opponentName, int rating)
    {
      checkRatingForGame(rating);
      if (this.currentRating - rating < minimalRating)
        this.currentRating = minimalRating;
      else
        this.currentRating -= rating;

      this.stats.Add(new StatRecord(opponentName, rating, false));
    }

    public List<StatRecord> GetStats()
    {
      return this.stats.ConvertAll(stat => new StatRecord(stat.OpponentName, stat.Rating, stat.IsWin));
    }

    public void WriteStats()
    {
      Console.WriteLine("----------------Stats----------------");
      Console.WriteLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
      Console.WriteLine($"User: {UserName}");
      Console.WriteLine($"Games count:{GamesCount}");
      Console.WriteLine($"Current rating:{CurrentRating}");
      Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Index", "Rating", "Result", "Opponent");
      for (int i = 0; i < stats.Count; i++)
      {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}", i, stats[i].Rating,
                         stats[i].IsWin ? "Win" : "Lose", stats[i].OpponentName);
      }
    }
  }
}
