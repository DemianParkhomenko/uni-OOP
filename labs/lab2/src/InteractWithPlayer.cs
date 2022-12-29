namespace Lab2;

public static class InteractWithPlayer
{
  static void writeTryAgainMessage()
  {
    Console.WriteLine("❌ Invalid input. Let's try again...");
  }

  public static void AskFor(string whatToEnter, Account player)
  {
    Console.WriteLine($"{player.Name} enter " + whatToEnter + "...");
  }

  public static T GetFromPlayer<T>(Account account, ValidatePlayerInput<T> validate)
  {
    try
    {
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

  public static T AskAndGetFromPlayer<T>(string whatToEnter, Account player, ValidatePlayerInput<T> validate)
  {
    AskFor(whatToEnter, player);
    return GetFromPlayer<T>(player, validate);
  }
}
