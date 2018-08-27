using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProj.Model;
using WpfProj.ViewModel;

namespace WpfProj.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CDriverUsersViewModel();
            //this.DataContext = new UserViewModel();
            //CDriverUsersViewModel
        }

        private void cUserView_Loaded(object sender, RoutedEventArgs e)
        {
            //userViewModel2 = new UserViewModel();
          //  cUserView.DataContext = new UserViewModel();  //not have to be because is in MainWindow
        }
    }
}
