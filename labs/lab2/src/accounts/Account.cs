namespace Lab2;
public enum BalanceTypes
{
  main,
  training
}

public class Account
{

  Stats stats;
  public string Name { get; set; }
  public string Email { get; }

  public Account(string name, string email, Balance main, Balance training)
  {
    Name = name;
    Email = email;
    stats = new Stats(main, training);
  }

  public void History()
  {
    InteractWithPlayer.WriteAccountHistory(this, stats);
  }

  public void onWin(BalanceTypes balanceType, decimal points, string opponentName)
  {
    stats.Add(new Stat(opponentName, points, isWin: true, balanceType));
  }

  public void onLose(BalanceTypes balanceType, decimal points, string opponentName)
  {
    stats.Add(new Stat(opponentName, points, isWin: false, balanceType));
  }
}
