namespace Lab2;

public static class Utils
{
  public static void throwIfNegative(decimal value, string errorMessage)
  {
    if (value < 0)
    {
      throw new ArgumentOutOfRangeException("value", errorMessage);
    }
  }
}
