using System.ComponentModel;


namespace MVVM.Model
{
    public class Student : INotifyPropertyChanged
    {
        // Pola naszego modelu
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Zdarzenie, które służy do powiadomienia o zmianie obiektu
        public event PropertyChangedEventHandler? PropertyChanged;

        // Metoda dzięki której powiadamiamy o zmianie w naszym obiekcie
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
