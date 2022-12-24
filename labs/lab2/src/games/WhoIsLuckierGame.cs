namespace Lab2
{
  public class WhoIsLuckierGame : Game
  {
    Random random = new Random();

    public override void Play(Account account1, Account account2,
    BalanceTypes balanceType, decimal points)
    {
      Console.WriteLine("Who is luckier game");
      if (random.Next(0, 2) == 0)
      {
        Console.WriteLine($"{account1.Name} is luckier");
        rewardPlayers(balanceType, points, account1, account2);
      }
      else
      {
        Console.WriteLine($"{account2.Name} is luckier");
        rewardPlayers(balanceType, points, account2, account1);
      }
    }
  }
}
