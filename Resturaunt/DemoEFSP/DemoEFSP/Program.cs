using Extension;

class Program
{
    static void Main(string[] args)
    {
        DomainEntity entity = new DomainEntity();
        entity.FirstName = "Test";
        entity.LastName = "TestL";
        string full = entity.FullName();
        System.Console.WriteLine("Full name of entity is {0}", full);

        string s = "We are having fun!!!";

        int i = s.WordCount();
        
        System.Console.WriteLine("Word count of s is {0}", i);

    }
}

