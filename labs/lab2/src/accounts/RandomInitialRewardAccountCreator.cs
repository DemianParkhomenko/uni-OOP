namespace Lab2
{
  // special initialization for New Year 
  public class RandomInitialRewardAccountCreator : DefaultAccountCreator
  {
    const int MAX_INITIAL_REWARD = 10000;
    Random random = new Random();

    public override Account createAccount(string name, string email, AccountTypes accountType)
    {
      int reward = random.Next(MAX_INITIAL_REWARD);
      if (accountType == AccountTypes.premium)
      {
        return new Account(name, email,
        base.createMainBalance(PREMIUM_INITIAL_POINTS_MAIN_BALANCE + MAX_INITIAL_REWARD, null),
        base.createTrainingBalance(PREMIUM_INITIAL_POINTS_TRAINING_BALANCE + MAX_INITIAL_REWARD, null));
      }
      return new Account(name, email,
      createMainBalance(DEFAULT_INITIAL_POINTS_MAIN_BALANCE + MAX_INITIAL_REWARD / 2, null),
      createTrainingBalance(DEFAULT_INITIAL_POINTS_TRAINING_BALANCE + MAX_INITIAL_REWARD, null));
    }
  }
}
