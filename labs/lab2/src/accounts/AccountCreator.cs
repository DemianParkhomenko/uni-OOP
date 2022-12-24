namespace Lab2
{
  public enum AccountTypes
  {
    standard,
    premium
  }

  public abstract class AccountCreator
  {
    public const decimal DEFAULT_MIN_POINTS_MAIN_BALANCE = 1;
    public const decimal DEFAULT_MIN_POINTS_TRAINING_BALANCE = 1000;
    public const decimal DEFAULT_INITIAL_POINTS_MAIN_BALANCE = DEFAULT_MIN_POINTS_MAIN_BALANCE;
    public const decimal DEFAULT_INITIAL_POINTS_TRAINING_BALANCE = 5000;
    public const decimal DEFAULT_MULTIPLIER = 1;
    public const decimal PREMIUM_INITIAL_POINTS_MAIN_BALANCE = 1000;
    public const decimal PREMIUM_INITIAL_POINTS_TRAINING_BALANCE = 10000;
    public const decimal PREMIUM_MULTIPLIER = 1.5m;
    protected abstract Balance createMainBalance(decimal? initialPoints, decimal? multiplier);
    protected abstract Balance createTrainingBalance(decimal? initialPoints, decimal? multiplier);
    public abstract Account createAccount(string name, string email, AccountTypes accountType);
  }
}
