namespace Lab2
{
  public class Stats
  {
    List<Stat> storage = new();

    public void Add(Stat stat)
    {
      storage.Add(stat);
    }


    public void Write(string name, Balance mainBalance, Balance trainingBalance)
    {
      Console.WriteLine($"----------------{name}----------------");
      Console.WriteLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
      Console.WriteLine($"Games count:{storage.Count}");
      Console.WriteLine($"Main balance:{mainBalance.Points}");
      Console.WriteLine($"Training balance:{trainingBalance.Points}");
      if (storage.Count != 0)
      {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Index", "Rating", "Result", "Opponent");
        for (int i = 0; i < storage.Count; i++)
        {
          Console.WriteLine("{0}\t{1}\t{2}\t{3}", i, storage[i].Points,
                           storage[i].IsWin ? "Win" : "Lose", storage[i].OpponentName);
        }
      }
    }
  }
}
