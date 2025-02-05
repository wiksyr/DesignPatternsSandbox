namespace ProxyViewModelDesignPattern{ 

    public class Person { 
        public string FirstName; 
        public string LastName; 
    }

    public class PersonviewModel : INotifyPropertyChanged
    {
        private readonly Person person; 

        public ProxyViewModel(Person person)
        {
            this.person = person;
        }

        public string FirstName
        {
            get  => person.FirstName; 
            set { 
                if (person.FirstName == value) return; 
                person.FirstName = value; 
                OnPropertyChanged(); 
            }
        }

        public string LastName 
        { 
            get => person.LastName;
            set 
            {
                if (person == person.LastName) return;
                person.LastName = value;
                OnPropertyChanged()
            }
        }

        public string Fullname 
        { 
            get => $"{FirstName}{LastName}"; 
            set { 
                if (value == null) { 
                    FirstName = LastName = null; 
                    return; 
                }
                var items = value.Split(); 
                if (items.Length > 0) {
                    FirstName = items[0];
                }
                if (items.Length > 1) {
                    LastName = items[1];
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; 

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null
        )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}