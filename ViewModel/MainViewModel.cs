using DesktopContactsAppMVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DesktopContactsAppMVVM.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace DesktopContactsAppMVVM.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {

        //Necessary for INotify interface
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;

                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowNewContactWindowCommand { get; set; }

        public ICommand SelectedItemChangedCommand { get; set; }


        public MainViewModel()
        {

            ReadDatabase();

            ShowNewContactWindowCommand = new RelayCommand(ShowNewContactWindow, CanShowNewContactWindow);

            SelectedItemChangedCommand = new RelayCommand(ShowDetailsWindow, CanShowDetailsWindow);
        }

        private void ShowDetailsWindow(object obj)
        {
            Contact selectedContact = (Contact)obj;

                if (selectedContact != null)
                {
                    var mainWindow = obj as Window;
                    ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                    contactDetailsWindow.Owner = mainWindow;
                    contactDetailsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    contactDetailsWindow.ShowDialog();

                    ReadDatabase();
                }
        }



        private void ShowNewContactWindow(object obj)
        {

            var mainWindow = obj as Window;

            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.Owner = mainWindow;
            newContactWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newContactWindow.ShowDialog();

            ReadDatabase();

        }


        //DRead database into Observable collection
        private void ReadDatabase()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                List<Contact> contactsList = conn.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
                Contacts = new ObservableCollection<Contact>(contactsList);
                
            }

        }




        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // Can set conditions if wanted
        private bool CanShowDetailsWindow(object obj)
        {
            return true;
        }

        private bool CanShowNewContactWindow(object obj)
        {
            return true;
        }

    }
}
