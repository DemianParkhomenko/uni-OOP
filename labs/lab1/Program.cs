namespace Lab1
{
  class Program
  {
    static void Main(string[] args)
    {
      GameAccount account1 = new GameAccount("John");
      GameAccount account2 = new GameAccount("Jane");
      int gamesCount = 4;
      for (int i = 0; i < gamesCount; i++)
      {
        Game.Random(account1, account2);
      }
      account1.WriteStats();
      account2.WriteStats();
    }
  }
}
