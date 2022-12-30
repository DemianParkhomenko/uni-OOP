namespace Lab2;
class Program
{
  static void Main(string[] args)
  {
    AccountCreator defaultCreator = new DefaultAccountCreator();

    Account demian = defaultCreator.createAccount(
        "Demian",
        "cucumber@gmail.com",
        AccountTypes.standard
        );

    Account john = defaultCreator.createAccount(
        "John",
        "tomato@gmail.com",
        AccountTypes.standard
        );

    GameCreator gameCreator = new GameCreator();
    var games = gameCreator.AllGames();
    foreach (Game game in games)
    {
      game.Play(demian, john, BalanceTypes.main, 100);
      demian.History();
      john.History();
    }
  }
}
