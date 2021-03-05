namespace ExplicitInterfaces.Contract
{
    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string GetName();
    }
}