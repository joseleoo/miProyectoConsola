public interface IAnimal
{
    public void Eat();
}
public class Program
{
    public static void Main()
    {
        var animals=new List<Animal>{
            new Dog(),
            new Cat()
        };

        foreach (var animal in animals)
        {
            animal.MakeSound();
        }

    }
}
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("sound");
    }

}
class Dog : Animal, IAnimal
{
    public void Eat()
    {
        Console.WriteLine("Eating purina");
    }

    public override void MakeSound()
    {
        Console.WriteLine("bark");
    }
}
class Cat : Animal, IAnimal
{
    public void Eat()
    {
       Console.WriteLine("eating fish");
    }

    public override void MakeSound()
    {
        Console.WriteLine("miau");
    }
}