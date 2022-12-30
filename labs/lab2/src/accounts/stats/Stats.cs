namespace Lab2;
public class Stats
{
  List<Stat> storage = new();
  Balance mainBalance;
  Balance trainingBalance;

  public List<Stat> Storage
  {
    get
    {
      return new List<Stat>(storage);
    }
  }

  public int TotalPlayedGames
  {
    get
    {
      return storage.Count;
    }
  }

  public Stats(Balance main, Balance training)
  {
    mainBalance = main;
    trainingBalance = training;
  }

  void updateBalance(Balance balance, Stat stat)
  {
    if (stat.IsWin)
    {
      balance.Add(stat.Points);
    }
    else
    {
      balance.Subtract(stat.Points);
    }
  }

  public void Add(Stat stat)
  {
    if (stat.BalanceType == BalanceTypes.main)
    {
      updateBalance(mainBalance, stat);
    }
    if (stat.BalanceType == BalanceTypes.training)
    {
      updateBalance(trainingBalance, stat);
    }
    storage.Add(stat);
  }

  public decimal PointsOnBalance(BalanceTypes balanceType)
  {
    if (balanceType == BalanceTypes.main) return mainBalance.Points;
    if (balanceType == BalanceTypes.training) return trainingBalance.Points;
    throw new Exception("Invalid type of balance");
  }
}
