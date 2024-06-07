namespace Patterns.Observer.Interfaces
{
    public interface ISubject <T>
    {
        public void AddObserver(IObserver<T> observer);
        public void RemoveObserver(IObserver<T> observer);
        public void NotifyObservers();

    }
}


