namespace Lab2
{
  public class WhoIsLuckierGame : Game
  {

    public override void Play(Account account1, Account account2,
    BalanceTypes balanceType, decimal points)
    {
      Console.WriteLine("Who is luckier game");
      if (base.randomBool())
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
