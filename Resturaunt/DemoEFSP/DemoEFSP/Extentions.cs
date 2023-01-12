namespace Extension;

public class DomainEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public static class DomainEntityExtensions
{
    public static string FullName(this DomainEntity value)
    {
        return $"{value.FirstName} {value.LastName}";
    }
}

public static class StringExtension
{
    // This is the extension method.
    // The first parameter takes the "this" modifier
    // and specifies the type for which the method is defined.
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
