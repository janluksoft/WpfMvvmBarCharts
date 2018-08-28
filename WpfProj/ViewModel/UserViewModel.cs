using WpfProj.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfProj.ViewModel
{
    internal class CDriverUsersViewModel
    {
        public ObservableCollection<CDriverUser> driverUsers { get; set; }
        public CDriverUser selectedDriverUser { get; set; }

        //---- One Row only ----------------------
        public ObservableCollection<CDriverUser> newDriverUserOne { get; set; }
        public CDriverUser newDriverUser { get; set; }


        public CDriverUsersViewModel()
        {
            driverUsers = LoadUsers();
            newDriverUserOne = LoadNewUsers();
            CreateCommands();
        }

        private ObservableCollection<CDriverUser> LoadUsers()
        {
            var users = new ObservableCollection<CDriverUser>
            {
              new CDriverUser {Id=1, Name="Fernando", Surname="Alonso", LapTimeSec= 72.3f, PitTimeSec= 3.21f },
              new CDriverUser {Id=2, Name="Lewis", Surname="Hamilton",  LapTimeSec= 73.1f, PitTimeSec= 3.15f },
              new CDriverUser {Id=3, Name="Sebastian", Surname="Vettel",LapTimeSec= 64.7f, PitTimeSec= 3.21f },
              new CDriverUser {Id=4, Name="Valtteri", Surname="Bottas ",LapTimeSec= 115.3f, PitTimeSec= 4.30f },
              new CDriverUser {Id=5, Name="Kimi", Surname="Raikkonen",  LapTimeSec= 92.3f, PitTimeSec= 6.42f },
              new CDriverUser {Id=6, Name="Felipe", Surname="Massa",    LapTimeSec= 132.2f, PitTimeSec= 2.86f },
            };

            return (users);
        }

        private ObservableCollection<CDriverUser> LoadNewUsers()
        {
            var users = new ObservableCollection<CDriverUser>
            {
              new CDriverUser { Id = 1, Name = "Sergio", Surname = "Perez", LapTimeSec = 82.25f, PitTimeSec = 4.22f },
            };
            return (users);

        }

        #region - Commands ---------------------------
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddRowCommand { get; set; }
        public RelayCommand MessageCommand { get; set; }
        public RelayCommand MessageCommandString { get; set; }


        private void CreateCommands()
        {
            DeleteCommand = new RelayCommand(o => OnDelete(selectedDriverUser, driverUsers), o => CanDelete(selectedDriverUser));
            AddRowCommand = new RelayCommand(o => OnAdd(newDriverUserOne[0], driverUsers), o => true);
            MessageCommand = new RelayCommand(o => OnMessage(selectedDriverUser), o => CanMessage(selectedDriverUser));
            MessageCommandString = new RelayCommand(ArgString);
        }

        #region - DEF DeleteCommand ------------------
        private void OnDelete(object user, ObservableCollection<CDriverUser> xDriverUsers)
        {
            var u = user as CDriverUser;
            xDriverUsers.Remove(u);
        }
        private bool CanDelete(object user)
        {
            var u = user as CDriverUser;
            return u != null;
        }

        private void OnAdd(object user, ObservableCollection<CDriverUser> xDriverUsers)
        {
            var xu = user as CDriverUser;
            int iCount = xDriverUsers.Count;
            int idLast = xDriverUsers[iCount - 1].Id;
            var u = new CDriverUser {Id = (idLast+ 1), Name = xu.Name, Surname = xu.Surname, 
                LapTimeSec = xu.LapTimeSec, PitTimeSec = xu.PitTimeSec };
            xDriverUsers.Add(u);
        }

        #endregion ---------------------

        #region - DEF MessageCommand ----------------
        private void ArgString(object obj)
        {
            string ast = obj as string;
            MessageBox.Show($"Button, Arg: {ast}");
        }
        private void OnMessage(object user)
        {
            var u = user as CDriverUser;
            MessageBox.Show($"Actual Row: FullName:{u.FullName}");
        }
        private bool CanMessage(object user)
        {
            var u = user as CDriverUser;
            return u != null;
        }
        #endregion ---------------------

        #endregion - Commands -------------

    }

}
