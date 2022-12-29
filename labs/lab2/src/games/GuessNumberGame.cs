namespace Lab2
{
  public class GuessNumberGame : Game
  {
    const int MAX_X = 1000;

    public override void Play(Account account1, Account account2,
    BalanceTypes balanceType, decimal points)
    {
      Console.WriteLine("Guess a number game");
      int x = base.random.Next(MAX_X);
      int xFromAccount1 = getConsoleIntFromPlayer(account1);
      int xFromAccount2 = getConsoleIntFromPlayer(account2);

      int abs1 = Math.Abs(x - xFromAccount1);
      int abs2 = Math.Abs(x - xFromAccount2);
      if (abs1 == abs2)
      {
        Console.WriteLine("Wow, a draw. Let's play again");
        Play(account1, account2, balanceType, points);
        return;
      }
      if (abs1 < abs2)
      {
        rewardPlayers(balanceType, points, account1, account2);
        printWinnerLoser(x, account1, account2);
      }
      else
      {
        rewardPlayers(balanceType, points, account2, account1);
        printWinnerLoser(x, account2, account1);
      }
    }

    int getConsoleIntFromPlayer(Account account)
    {
      Console.WriteLine($"Player: {account.Name}. Enter a positive number less than {MAX_X}...");
      try
      {
        int x = Convert.ToInt32(Console.ReadLine());
        if (x > MAX_X)
        {
          Console.WriteLine("Too big number. Try again...");
          throw (new Exception("Too big number"));
        }
        return x;
      }
      catch
      {
        int x = getConsoleIntFromPlayer(account);
        return x;
      }
    }

    void printWinnerLoser(int x, Account winner, Account loser)
    {
      Console.WriteLine($"Number was: {x}. {winner.Name}({winner.Email}) is a winner. {loser.Name}({loser.Email}) is a loser");
    }
  }
}
