using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsAppMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        static string databaseName = "Contacts.db";
        static string folderPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //public static string directory =  + @"\Text Files\";
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
