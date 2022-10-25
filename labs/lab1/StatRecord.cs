namespace Lab1
{
  class StatRecord
  {
    public string OpponentName { get; }
    public int Rating { get; }
    public bool IsWin { get; }

    public StatRecord(string opponentName, int rating, bool isWin)
    {
      OpponentName = opponentName;
      Rating = rating;
      IsWin = isWin;
    }
  }
}
