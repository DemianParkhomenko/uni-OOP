namespace Lab2;
public class DefaultAccountCreator : AccountCreator
{
  protected override Balance createMainBalance(decimal? initialPoints, decimal? multiplier)
  {
    return new Balance(initialPoints ?? DEFAULT_INITIAL_POINTS_MAIN_BALANCE,
    DEFAULT_MIN_POINTS_MAIN_BALANCE,
    multiplier ?? DEFAULT_MULTIPLIER);
  }

  protected override Balance createTrainingBalance(decimal? initialPoints, decimal? multiplier)
  {
    return new Balance(initialPoints ?? DEFAULT_INITIAL_POINTS_TRAINING_BALANCE,
    DEFAULT_MIN_POINTS_TRAINING_BALANCE,
    multiplier ?? DEFAULT_MULTIPLIER);
  }

  public override Account createAccount(string name, string email, AccountTypes accountType)
  {
    if (accountType == AccountTypes.premium)
    {
      return new Account(name, email,
      createMainBalance(PREMIUM_INITIAL_POINTS_MAIN_BALANCE, PREMIUM_MULTIPLIER),
      createTrainingBalance(PREMIUM_INITIAL_POINTS_TRAINING_BALANCE, PREMIUM_MULTIPLIER));
    }
    return new Account(name, email, createMainBalance(null, null), createTrainingBalance(null, null));
  }
}
