namespace Lab2;
public class Stats
{
  List<Stat> storage = new();
  Balance mainBalance;
  Balance trainingBalance;

  public Stats(Balance main, Balance training)
  {
    mainBalance = main;
    trainingBalance = training;
  }

  public List<Stat> Storage
  {
    get
    {
      return storage;
    }
  }

  void updateBalance(Balance balance, Stat stat)
  {
    //TODO return stat.IsWin ? balance.Add(stat.Points) : balance.Subtract(stat.Points)
  }

  public void Add(Stat stat)
  {
    if (stat.BalanceType == BalanceTypes.main) mainBalance.Add(stat.Points);
    if (stat.BalanceType == BalanceTypes.training) trainingBalance.Add(stat.Points);
    storage.Add(stat);
  }


}
