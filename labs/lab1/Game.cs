namespace Lab1
{
  static class Game
  {
    private static void giveAward(GameAccount winner, GameAccount loser, int rating)
    {
      try
      {
        winner.WinGame(loser.UserName, rating);
        loser.LoseGame(winner.UserName, rating);
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine($"Can not play a game with rating {rating} "
        + "between {winner.UserName} and {loser.UserName}");
        Console.WriteLine(e);
      }
    }

    public static void Random(GameAccount account1, GameAccount account2)
    {
      var random = new Random();
      int rating = random.Next(1, 100);
      if (random.Next(0, 2) == 0)
      {
        giveAward(account1, account2, rating);
      }
      else
      {
        giveAward(account2, account1, rating);
      }
    }
  }
}
