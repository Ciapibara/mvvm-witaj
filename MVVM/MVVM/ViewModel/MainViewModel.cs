
using System.Collections.ObjectModel;
using System.ComponentModel;

using MVVM.Model;

namespace SystemOceniania.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> students { get; set; }
        public Student selectedStudent { get; set; }

        public double TheGrade { get; set; }
        public Command StudentSelectedCmd { get; }

        public MainViewModel()
        {
            students =
            [
                new Student() { Id = 1, Name = "Jan", Surname = "Kowalski", },
                new Student() { Id = 2, Name = "Adam", Surname = "Kaczyński", },
                new Student() { Id = 3, Name = "Anna", Surname = "Nowak", }
            ];

            selectedStudent = students[0];
            StudentSelectedCmd = new Command<Student>(StudentPressed);

        }

        public void StudentPressed(Student student)
        {
            if (student != null)
                selectedStudent = student;

            Application.Current.MainPage.DisplayAlert("Wybrana osoba", $"Witaj {student.Name}!", "OK" );
            

            OnPropertyChanged(nameof(selectedStudent));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
