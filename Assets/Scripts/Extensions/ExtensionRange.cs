using Random = System.Random;

public static class ExtensionRange
{
    public static int RandomInt(this Random random, int x, int y)
    {
        return random.Next(x, y);
    }
}
