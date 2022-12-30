namespace Lab2;

public class TicTacToeGame : Game
{
  const int boardSize = 3;

  string[,] board = new string[boardSize, boardSize];

  string zero = "O";
  string cross = "️X";

  bool everyIsString(string str, string[] arr)
  {
    return Array.TrueForAll(arr, (v) => str.Equals(v));
  }

  protected bool isWinner(string crossOrZero)
  {
    var rows = new string[boardSize];
    var columns = new string[boardSize];
    var mainDiagonal = new string[boardSize];
    var sideDiagonal = new string[boardSize];

    for (int i = 0; i < boardSize; i++)
    {
      for (int j = 0; j < boardSize; j++)
      {
        rows[j] = board[i, j];
        columns[j] = board[j, i];
        if (i + j == boardSize - 1) mainDiagonal[j] = board[i, j];
        if (i == j) sideDiagonal[j] = board[i, j];
      }
      if (
      everyIsString(crossOrZero, rows) ||
      everyIsString(crossOrZero, columns) ||
      everyIsString(crossOrZero, mainDiagonal) ||
      everyIsString(crossOrZero, sideDiagonal)
      )
      {
        return true;
      }
    }
    return false;
  }

  void writeBoard()
  {
    int field = 1;
    for (int i = 0; i < boardSize; i++)
    {
      for (int j = 0; j < boardSize; j++, field++)
      {
        string toPrint = string.IsNullOrEmpty(board[i, j]) ? $"{field}" : board[i, j];
        bool isCross = toPrint.Equals(cross);
        bool isZero = toPrint.Equals(zero);

        ConsoleColor color = isCross ? ConsoleColor.White :
        isZero ? ConsoleColor.Magenta : ConsoleColor.DarkGray;

        InteractWithPlayer.Write("|   ");
        InteractWithPlayer.Write($"{toPrint}   ", color);
        if (j == boardSize - 1)
        {
          InteractWithPlayer.Write($"|");
          InteractWithPlayer.Write("\n\n");
        }
      }
    }
  }

  protected void fulfilField(Account account, string zeroOrCross)
  {
    int enteredField = InteractWithPlayer.AskAndGetFromPlayer<int>(
    $"a number of empty field. You are {zeroOrCross}",
    account,
    (int input) => input >= 1 && input <= Math.Pow(boardSize, 2)
    );

    int i = (enteredField - 1) / boardSize;
    int j = (enteredField - 1) % boardSize;
    if (string.IsNullOrEmpty(board[i, j]))
    {
      board[i, j] = zeroOrCross;
    }
    else
    {
      InteractWithPlayer.WriteTryAgainMessage();
      InteractWithPlayer.Write("This field is taken\n");
      fulfilField(account, zeroOrCross);
    }
  }

  // return true when isWinner here
  protected bool move(Account whoMoves, string symbolOfWhoMoves,
  Account opponent, BalanceTypes balanceType, decimal points)
  {
    fulfilField(whoMoves, symbolOfWhoMoves);
    writeBoard();

    if (isWinner(symbolOfWhoMoves))
    {
      InteractWithPlayer.WriteWinnerLoser(winner: whoMoves, loser: opponent);
      rewardPlayers(balanceType, points, winner: whoMoves, loser: opponent);
      return true;
    }
    return false;
  }

  protected void moves(Account account1, string symbolPlayer1,
  Account account2, string symbolPlayer2, BalanceTypes balanceType, decimal points)
  {
    if (move(
       whoMoves: account1,
       symbolOfWhoMoves: symbolPlayer1,
       account2, balanceType, points)) return;

    if (move(whoMoves: account2,
      symbolOfWhoMoves: symbolPlayer2,
      account1, balanceType, points)) return;

    moves(account1, symbolPlayer1, account2, symbolPlayer2, balanceType, points);
  }

  public override void Play(Account account1, Account account2,
  BalanceTypes balanceType, decimal points)
  {
    InteractWithPlayer.WriteGameName($"✏️  Tic-Tac-Toe Game ✏️");
    writeBoard();
    if (base.randomBool())
    {
      moves(account1, cross, account2, zero, balanceType, points);
    }
    else
    {
      moves(account2, cross, account1, zero, balanceType, points);
    }
  }
}
