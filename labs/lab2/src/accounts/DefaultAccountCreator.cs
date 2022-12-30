namespace Lab2;
public class DefaultAccountCreator : AccountCreator
{
  protected override Balance createMainBalance(
  decimal initialPoints = DEFAULT_INITIAL_POINTS_MAIN_BALANCE,
  decimal minimalPoints = DEFAULT_MIN_POINTS_MAIN_BALANCE,
  decimal multiplier = DEFAULT_MULTIPLIER)
  {
    return new Balance(initialPoints,
    DEFAULT_MIN_POINTS_MAIN_BALANCE,
    multiplier);
  }

  protected override Balance createTrainingBalance(
  decimal initialPoints = DEFAULT_INITIAL_POINTS_TRAINING_BALANCE,
  decimal minimalPoints = DEFAULT_MIN_POINTS_TRAINING_BALANCE,
  decimal multiplier = DEFAULT_MULTIPLIER
  )
  {
    return new Balance(
    initialPoints,
    minimalPoints,
    multiplier
    );
  }

  public override Account createAccount(string name, string email, AccountTypes accountType)
  {
    if (accountType == AccountTypes.premium)
    {
      return new Account(name, email,
      createMainBalance(PREMIUM_INITIAL_POINTS_MAIN_BALANCE, PREMIUM_MULTIPLIER),
      createTrainingBalance(PREMIUM_INITIAL_POINTS_TRAINING_BALANCE, PREMIUM_MULTIPLIER));
    }
    return new Account(name, email, createMainBalance(), createTrainingBalance());
  }
}
