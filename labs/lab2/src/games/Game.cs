namespace Lab2
{
  public abstract class Game
  {
    abstract public void Play(Account account1, Account account2,
    BalanceTypes balanceType, decimal points);

    virtual protected void rewardPlayers(BalanceTypes balanceType, decimal points, Account winner, Account loser)
    {
      try
      {
        winner.onWin(balanceType, points, loser.Name);
        loser.onLose(balanceType, points, winner.Name);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Exception on rewarding players", ex);
      }
    }
  }
}
