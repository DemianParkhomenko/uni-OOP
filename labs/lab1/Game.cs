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
        account1.WinGame(account2.UserName, rating);
        account2.LoseGame(account1.UserName, rating);
      }
      else
      {
        account1.LoseGame(account2.UserName, rating);
        account2.WinGame(account1.UserName, rating);
      }
    }
  }
}
