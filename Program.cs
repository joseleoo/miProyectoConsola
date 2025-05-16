// Interfaz del Observador
public interface IObserver
{
    void Update(string weatherAlert);
}

// Observadores concretos (apps de usuarios)
public class WeatherApp : IObserver
{
    private string user;

    public WeatherApp(string user)
    {
        this.user = user;
    }

    public void Update(string weatherAlert)
    {
        Console.WriteLine($"{user} recibió alerta: {weatherAlert}");
    }
}

// Sujeto (Servicio meteorológico)
public class WeatherStation
{
    private List<IObserver> observers = new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void SendAlert(string alert)
    {
        foreach (var observer in observers)
        {
            observer.Update(alert);
        }
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        WeatherStation station = new WeatherStation();

        IObserver app1 = new WeatherApp("Usuario A");
        IObserver app2 = new WeatherApp("Usuario B");

        station.Subscribe(app1);
        station.Subscribe(app2);

        station.SendAlert("🌧️ Tormenta eléctrica en camino");
        station.SendAlert("☀️ Ola de calor prevista para mañana");
    }
}
