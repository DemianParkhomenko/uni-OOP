namespace Lab2;
public class Balance
{
  decimal minimalPoints;
  public decimal Multiplier { get; set; }
  public decimal Points
  {
    get;
    protected set;
  }

  string throwIfNegativeMessage = "Game points cannot be negative";
  public Balance(decimal initialPoints, decimal minimalPoints, decimal multiplier)
  {
    Points = initialPoints;
    this.minimalPoints = minimalPoints;
    Multiplier = multiplier;
  }

  public virtual void Add(decimal points)
  {
    Utils.throwIfNegative(points, throwIfNegativeMessage);
    Points += points * Multiplier;
  }

  public virtual void Subtract(decimal points)
  {
    Utils.throwIfNegative(points, throwIfNegativeMessage);
    decimal nextPoints = Points - points;
    if (nextPoints >= minimalPoints) Points = nextPoints;
  }

}
