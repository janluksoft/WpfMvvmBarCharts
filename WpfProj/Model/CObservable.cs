using System.ComponentModel;
using System.Collections.Generic;


namespace WpfProj.Model
{
    public abstract class CObservable_old : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public abstract class CObservable : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void SetFieldChanged( string propertyName)
        {
            OnPropertyChanged(propertyName);
        }


        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set { SetField(ref name, value, "Name"); }
        //}
    }



}
