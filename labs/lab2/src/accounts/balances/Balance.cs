namespace Lab2
{
  public class Balance
  {
    decimal minimalPoints;
    public decimal Multiplier { get; set; }
    public decimal Points
    {
      get;
      protected set;
    }

    public Balance(decimal initialPoints, decimal minimalPoints, decimal multiplier)
    {
      Points = initialPoints;
      this.minimalPoints = minimalPoints;
      Multiplier = multiplier;
    }

    virtual public void Add(decimal points)
    {
      Points += points * Multiplier;
    }

    virtual public void Subtract(decimal points)
    {
      throwIfNegative(points);
      decimal nextPoints = Points - points;
      if (nextPoints >= minimalPoints) Points = nextPoints;
    }

    protected void throwIfNegative(decimal points)
    {
      if (points < 0)
      {
        throw new ArgumentOutOfRangeException("Points", "Game points cannot be negative");
      }
    }
  }

}
