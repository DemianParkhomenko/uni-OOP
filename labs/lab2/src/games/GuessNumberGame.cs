namespace Lab2;
public class GuessNumberGame : Game
{
  const int MAX_INPUT = 1000;

  bool validateInput(int input)
  {
    return input < MAX_INPUT;
  }

  public override void Play(Account account1, Account account2,
  BalanceTypes balanceType, decimal points)
  {
    Console.WriteLine("❔ Guess a number game ❔");
    string whatToEnter = $"a positive number less than {MAX_INPUT}";
    int xFromAccount1 = base.askAndGetFromPlayer<int>(whatToEnter, account1, validateInput);
    int xFromAccount2 = base.askAndGetFromPlayer<int>(whatToEnter, account2, validateInput);

    int x = base.random.Next(MAX_INPUT);
    int abs1 = Math.Abs(x - xFromAccount1);
    int abs2 = Math.Abs(x - xFromAccount2);
    if (abs1 == abs2)
    {
      Console.WriteLine("🤯Wow, a draw. Let's play again");
      Play(account1, account2, balanceType, points);
      return;
    }
    if (abs1 < abs2)
    {
      rewardPlayers(balanceType, points, account1, account2);
      base.writeWinnerLoser(account1, account2);
    }
    else
    {
      rewardPlayers(balanceType, points, account2, account1);
      base.writeWinnerLoser(account2, account1);
    }
    Console.WriteLine($"Number was {x}");
  }
}
