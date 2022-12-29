namespace Lab2;
public struct Stat
{
  public string OpponentName { get; }
  public decimal Points { get; }
  public bool IsWin { get; }
  public BalanceTypes BalanceType { get; }

  public Stat(string opponentName, decimal points, bool isWin, BalanceTypes balanceType)
  {
    OpponentName = opponentName;
    Points = points;
    IsWin = isWin;
    BalanceType = balanceType;
  }
}
