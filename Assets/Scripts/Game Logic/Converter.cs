public class Converter
{
    public int BoolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public bool IntToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}