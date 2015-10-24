using System.ComponentModel;

namespace MetragemRio.ViewModels
{
    public class DamViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _capacity;
        public string Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value != _capacity)
                {
                    _capacity = value;
                    NotifyPropertyChanged("Capacity");
                }
            }
        }

        private int _open;
        public int Open
        {
            get
            {
                return _open;
            }
            set
            {
                if (value != _open)
                {
                    _open = value;
                    NotifyPropertyChanged("Open");
                }
            }
        }

        private int _closed;
        public int Closed
        {
            get
            {
                return _closed;
            }
            set
            {
                if (value != _closed)
                {
                    _closed = value;
                    NotifyPropertyChanged("Closed");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
