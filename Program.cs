class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person("Alice", 30);
        Person person2 = new Person("Bob", 25);
        Person person3 = new Person("Leo", 26);

        person1.Greet();
        person2.Greet();
        person3.Greet();
    }
}