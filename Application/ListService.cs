namespace Application;

public class ListService
{
    static public string ListToString(List<char> list) {
        string result = string.Empty;
        foreach (char item in list)
        {
            result += item;
        }
        return result;
    }
}