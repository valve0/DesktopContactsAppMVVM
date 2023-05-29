using DesktopContactsAppMVVM.Controls;
using DesktopContactsAppMVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using DesktopContactsAppMVVM.Commands;

namespace DesktopContactsAppMVVM.ViewModel
{
    public class NewContactViewModel
    {

        public ICommand NewContactCommand { get; set; }

        public ICommand BackCommand { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }



        public NewContactViewModel()
        {

            NewContactCommand = new RelayCommand(AddContact, CanAddContact);
            BackCommand = new RelayCommand(Back, CanBack);

        }

        private bool CanBack(object obj)
        {
            return true;
        }

        private void Back(object obj)
        {
            var win = obj as Window;
            win.Close();
        }

        private bool CanAddContact(object obj)
        {
            return true;
        }

        private void AddContact(object obj)
        {
            // Save a contact

            var win = obj as Window;
            //Check to see if name is Null

            if (Name != null)
            {

            
            
            //Create objects with inputted details
            Contact contact = new Contact()
            {
                Name = Name,
                Email = Email,
                PhoneNumber = PhoneNumber
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            win.Close();

            }
            else
            {

                MessageBox.Show("Please provide a name for the contact", "", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

    }
}
