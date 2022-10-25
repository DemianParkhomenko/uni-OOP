namespace Lab1
{
  static class Game
  {
    public static void Random(GameAccount account1, GameAccount account2)
    {
      var random = new Random();
      int rating = random.Next(1, 100);
      if (random.Next(0, 2) == 0)
      {
        giveAwards(account1, account2, rating);
      }
      else
      {
        giveAwards(account2, account1, rating);
      }
    }

    static void giveAwards(GameAccount winner, GameAccount loser, int rating)
    {
      try
      {
        loser.LoseGame(winner.UserName, rating);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        writeFailedGameMessage(winner.UserName, loser.UserName, rating);
        return;
      }
      try
      {
        winner.WinGame(loser.UserName, rating);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        writeFailedGameMessage(winner.UserName, loser.UserName, rating);
        loser.CancelLastGame();
      }
    }

    static void writeFailedGameMessage(string winnerName, string loserName, int rating)
    {
      Console.Write($"Can not play a game with rating {rating} "
            + $"between winner: {winnerName} and loser: {loserName}\n"
            + $"Cancel rating change for two opponents\n");
    }
  }

}
