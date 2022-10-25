namespace Lab1
{
  class StatRecord
  {
    public string OpponentName { get; }
    public decimal Rating { get; }
    public bool IsWin { get; }

    public StatRecord(string opponentName, decimal rating, bool isWin)
    {
      OpponentName = opponentName;
      Rating = rating;
      IsWin = isWin;
    }
  }
}
