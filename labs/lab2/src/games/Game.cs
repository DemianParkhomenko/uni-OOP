namespace Lab2;

public delegate bool ValidatePlayerInput<T>(T input);

public abstract class Game
{
  protected Random random = new Random();

  abstract public void Play(Account account1, Account account2,
  BalanceTypes balanceType, decimal points);


  virtual protected void rewardPlayers(BalanceTypes balanceType, decimal points,
                  Account winner, Account loser)
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

  protected bool randomBool()
  {
    return random.Next(2) == 0;
  }

  protected void writeWinnerLoser(Account winner, Account loser)
  {
    Console.WriteLine($"Winner: {winner.Name}({winner.Email})."
       + $" Loser: {loser.Name}({loser.Email})");
  }

}

