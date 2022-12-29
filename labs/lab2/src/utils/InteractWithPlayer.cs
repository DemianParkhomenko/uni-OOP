namespace Lab2;

public static class InteractWithPlayer
{
  static void writeTryAgainMessage()
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
      writeTryAgainMessage();
      return GetFromPlayer<T>(account, validate);
    }
    catch
    {
      writeTryAgainMessage();
      return GetFromPlayer<T>(account, validate);
    }
  }

  public static T AskAndGetFromPlayer<T>(string whatToEnter,
  Account player, ValidatePlayerInput<T> validate)
  {
    AskFor(whatToEnter, player);
    return GetFromPlayer<T>(player, validate);
  }

  public static void WriteWinnerLoser(Account winner, Account loser)
  {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Winner: {winner.Name}({winner.Email})."
       + $" Loser: {loser.Name}({loser.Email})");
  }

  public static void WriteAccountHistory(string name, Balance mainBalance,
  Balance trainingBalance, List<Stat> storage)
  {
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine();
    Console.WriteLine($"📃 ----------------{name}----------------");
    Console.WriteLine($"📅 Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    Console.WriteLine($"🎲 Games count:{storage.Count}");
    Console.WriteLine($"💰 Main balance:{mainBalance.Points}");
    Console.WriteLine($"🫰  Training balance:{trainingBalance.Points}");
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
}
