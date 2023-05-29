using DesktopContactsAppMVVM.Models;
using SQLite;
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
using DesktopContactsAppMVVM.ViewModel;

namespace DesktopContactsAppMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contactsListView.Items.Filter = FilterMethod;


        }

        //Filter cannot work with names that are Null
        private bool FilterMethod(object obj)
        {
            var contact = (Contact)obj;

            return contact.Name.Contains(searchTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
