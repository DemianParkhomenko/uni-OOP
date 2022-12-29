namespace Lab2;

public delegate bool ValidateGetFromPlayer<T>(T input);

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

  protected void printWinnerLoser(Account winner, Account loser)
  {
    Console.WriteLine($"Winner: {winner.Name}({winner.Email})."
       + $" Loser: {loser.Name}({loser.Email})");
  }

  void writeTryAgainMessage()
  {
    Console.WriteLine("❌ Invalid input. Let's try again...");
  }

  void askFor(string whatToEnter, Account player)
  {
    Console.WriteLine($"{player.Name} enter " + whatToEnter + "...");
  }

  T getFromPlayer<T>(Account account, ValidateGetFromPlayer<T> validate)
  {
    try
    {
      string line = Console.ReadLine() ?? "";
      T input = (T)Convert.ChangeType(line, typeof(T));
      if (validate(input)) return input;
      writeTryAgainMessage();
      return getFromPlayer<T>(account, validate);
    }
    catch
    {
      writeTryAgainMessage();
      return getFromPlayer<T>(account, validate);
    }
  }

  protected T askAndGetFromPlayer<T>(string whatToEnter, Account player, ValidateGetFromPlayer<T> validate)
  {
    askFor(whatToEnter, player);
    return getFromPlayer<T>(player, validate);
  }
}

