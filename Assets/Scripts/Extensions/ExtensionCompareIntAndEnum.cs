public static class ExtensionCompareIntAndEnum
{
    public static Players CompareWithEnum(this int value)
    {
        return (Players)value;
    }
}