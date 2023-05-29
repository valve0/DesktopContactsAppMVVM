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
using System.Windows.Shapes;
using DesktopContactsAppMVVM.Models;
using DesktopContactsAppMVVM.ViewModel;
using SQLite;

namespace DesktopContactsAppMVVM
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            ContactDetailsViewModel contactDetailsViewModel = new ContactDetailsViewModel(contact);
            this.DataContext = contactDetailsViewModel;
        }

    }
}
