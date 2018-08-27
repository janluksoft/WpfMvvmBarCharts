using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using WpfProj.Model;

namespace WpfProj.ViewModel
{

    class CAppCommand
    {
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddRowCommand { get; set; }
        public RelayCommand MessageCommand { get; set; }
        public RelayCommand MessageCommandString { get; set; }

        #region - Constructor ------------------
        public CAppCommand(CDriverUser xSelDriverUser, 
            ObservableCollection<CDriverUser> xDriverUsers)
        {
            DeleteCommand = new RelayCommand(o => OnDelete(xSelDriverUser, xDriverUsers), o => CanDelete(xSelDriverUser));
            AddRowCommand = new RelayCommand(o => OnAdd(xSelDriverUser, xDriverUsers), o => CanDelete(xSelDriverUser));
            MessageCommand = new RelayCommand(o => OnMessage(xSelDriverUser), o => CanMessage(xSelDriverUser));
            MessageCommandString = new RelayCommand(ArgString);
        }

        #endregion ----------

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
            var u = new CDriverUser { Name = "Peter", Surname = "Thomas" };
            xDriverUsers.Add(u);
        }


        #endregion ---------------------

        #region - DEF MessageCommand ------------------
        private void ArgString(object obj)
        {
            string ast = obj as string;
            MessageBox.Show($"Button, Arg: {ast}");
        }
        private void OnMessage(object user)
        {
            var u = user as CDriverUser;
            MessageBox.Show($"Button, FirstName: {u.Surname}");
            //Users.Remove(u);
        }
        private bool CanMessage(object user)
        {
            var u = user as CDriverUser;
            return true;
            return u != null;
        }
        #endregion ---------------------

    }
}
