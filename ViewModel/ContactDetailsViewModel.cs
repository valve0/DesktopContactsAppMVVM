using DesktopContactsAppMVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DesktopContactsAppMVVM.Commands;

namespace DesktopContactsAppMVVM.ViewModel
{
    public class ContactDetailsViewModel
    {

        public ICommand UpdateContactCommand { get; set; }
        public ICommand DeleteContactCommand { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }


        Contact contact;
        public ContactDetailsViewModel(Contact contact)
        {

            Name = contact.Name;
            Email = contact.Email;
            PhoneNumber = contact.PhoneNumber;

            this.contact = contact;

            UpdateContactCommand = new RelayCommand(UpdateContacts, CanUpdateContacts);

            DeleteContactCommand = new RelayCommand(DeleteContact, CanDeleteContact);

        }

        private bool CanDeleteContact(object obj)
        {
            return true;
        }

        private void DeleteContact(object obj)
        {
            var win = obj as Window;
            
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            win.Close();
        }

        private bool CanUpdateContacts(object obj)
        {
            return true;
        }

        private void UpdateContacts(object obj)
        {
            if (Name != string.Empty)
            {
            
                var win = obj as Window;

                contact.Name = Name;
                contact.Email = Email;
                contact.PhoneNumber = PhoneNumber;

                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Contact>();
                    connection.Update(contact);
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
