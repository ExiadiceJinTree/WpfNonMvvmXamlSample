using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp12_SQLiteAndListView
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private const string _dbFileName = "Shop.db";
        private const string _dbDirPath = @".\";

        public static readonly string DbFilePath = System.IO.Path.Combine(_dbDirPath, _dbFileName);
    }
}
