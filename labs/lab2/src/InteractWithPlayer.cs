namespace Lab2;

public delegate bool ValidatePlayerInput<T>(T input);

public static class InteractWithPlayer
{
  public static void WriteTryAgainMessage()
  {
    Console.WriteLine("❌ Invalid input. Let's try again...");
  }

  public static void AskFor(string whatToEnter, Account player)
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"{player.Name} enter " + whatToEnter + "...");
  }

  public static T GetFromPlayer<T>(Account account, ValidatePlayerInput<T> validate)
  {
   try
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      string line = Console.ReadLine() ?? "";
      T input = (T)Convert.ChangeType(line, typeof(T));
      if (validate(input)) return input;
      WriteTryAgainMessage();
      return GetFromPlayer<T>(account, validate);
    }
    catch
    {
      WriteTryAgainMessage();
      return GetFromPlayer<T>(account, validate);
    }
  }

  public static T AskAndGetFromPlayer<T>(string whatToEnter,
  Account player, ValidatePlayerInput<T> validate)
  {
    AskFor(whatToEnter, player);
    return GetFromPlayer<T>(player, validate);
  }

  public static void WriteGameName(string gameName)
  {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(gameName);
  }

  public static void Write<T>(T message, ConsoleColor color = ConsoleColor.Green)
  {
    Console.ForegroundColor = color;
    Console.Write($"{message}");
  }

  public static void WriteWinnerLoser(Account winner, Account loser)
  {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"🏆 Winner: {winner.Name}({winner.Email})."
       + $"❤‍🩹 Loser: {loser.Name}({loser.Email})");
  }

  public static void WriteAccountHistory(Account account, Stats stats)
  {
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine();
    Console.WriteLine($"📃 ----------------{account.Name}----------------");
    Console.WriteLine($"📅 Date: {DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy")}");
    Console.WriteLine($"🎲 Games: {stats.TotalPlayedGames}");
    Console.WriteLine($"💰 Main balance:{stats.PointsOnBalance(BalanceTypes.main)}");
    Console.WriteLine($"🫰  Training balance:{stats.PointsOnBalance(BalanceTypes.training)}");
    var storage = stats.Storage;
    if (storage.Count != 0)
    {
      Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Index", "Rating", "Result", "Opponent");
      for (int i = 0; i < storage.Count; i++)
      {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}", i, storage[i].Points,
                         storage[i].IsWin ? "Win" : "Lose", storage[i].OpponentName);
      }
    }
    Console.WriteLine();
  }

  public static void WriteExceptionMessage(string message)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
  }
}
