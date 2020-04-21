using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp9
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Shop.db";
        //static string dbDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string dbDirPath = @".\";
        public static string DbPath = System.IO.Path.Combine(dbDirPath, databaseName);
    }
}
