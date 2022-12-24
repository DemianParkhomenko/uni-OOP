namespace Lab2
{
  public enum BalanceTypes
  {
    main,
    training
  }

  public class Account
  {
    Balance mainBalance;
    Balance trainingBalance;

    Stats stats = new();
    public string Name { get; set; }
    public string Email { get; }

    public Account(string name, string email, Balance main, Balance training)
    {
      Name = name;
      Email = email;
      mainBalance = main;
      trainingBalance = training;
    }

    public void History()
    {
      stats.Write(Name, mainBalance, trainingBalance);
    }

    public void onWin(BalanceTypes balanceType, decimal points, string opponentName)
    {
      if (balanceType == BalanceTypes.main) mainBalance.Add(points);
      if (balanceType == BalanceTypes.training) trainingBalance.Add(points);
      stats.Add(new Stat(opponentName, points, true, balanceType));
    }

    public void onLose(BalanceTypes balanceType, decimal points, string opponentName)
    {
      if (balanceType == BalanceTypes.main) mainBalance.Subtract(points);
      if (balanceType == BalanceTypes.training) trainingBalance.Subtract(points);
      stats.Add(new Stat(opponentName, points, false, balanceType));
    }
  }
}
