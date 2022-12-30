namespace Lab2;

public class WhoIsLuckierGame : Game
{

  public override void Play(Account account1, Account account2,
  BalanceTypes balanceType, decimal points)
  {
    InteractWithPlayer.WriteGameName("🎲 Who is luckier game 🎲");
    if (base.randomBool())
    {
      InteractWithPlayer.WriteWinnerLoser(winner: account1, loser: account2);
      rewardPlayers(balanceType, points, winner: account1, loser: account2);
    }
    else
    {
      InteractWithPlayer.WriteWinnerLoser(winner: account2, loser: account1);
      rewardPlayers(balanceType, points, winner: account2, loser: account1);
    }
  }
}
