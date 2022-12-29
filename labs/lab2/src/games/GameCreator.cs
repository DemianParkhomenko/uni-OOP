namespace Lab2
{
  public enum Games
  {
    GuessNumber,
    WhoIsLuckier
  }

  public class GameCreator
  {
    public Game Create(Games gameToCreate)
    {
      switch (gameToCreate)
      {
        case Games.GuessNumber: return new GuessNumberGame();
        case Games.WhoIsLuckier: return new WhoIsLuckierGame();
        default: return new WhoIsLuckierGame();
      }
    }

    public List<Game> AllGames()
    {
      var list = new List<Game>();
      foreach (Games game in Enum.GetValues(typeof(Games)))
      {
        list.Add(Create(game));
      }
      return list;
    }
  }
}
