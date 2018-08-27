using System;
using System.ComponentModel;

namespace WpfProj.Model
{
    internal class CDriverUser : CObservable // :INotifyPropertyChanged (also)
    {

        private int _id;
        public int Id {
            get { return _id; }
            set { SetField(ref _id, value, nameof(Id)); }
        }

        private string _name;
        public string Name {
            get { return _name; }
            set { SetField(ref _name, value, nameof(Name));
                  SetFieldChanged(nameof(FullName)); }
        }

        private string _surname;
        public string Surname {
            get { return _surname; }
            set { SetField(ref _surname, value, nameof(Surname)); 
                  SetFieldChanged(nameof(FullName)); }
        }

        private float _lapTimeSec;
        public float LapTimeSec {
            get { return _lapTimeSec; }
            set { SetField(ref _lapTimeSec, value, nameof(LapTimeSec)); }
        }

        private float _pitTimeSec;
        public float PitTimeSec
        {
            get { return _pitTimeSec; }
            set { SetField(ref _pitTimeSec, value, nameof(PitTimeSec)); }
        }

        public string FullName => string.Concat(_name, " ", _surname);

    }

}
