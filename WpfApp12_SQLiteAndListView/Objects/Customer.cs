using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12_SQLiteAndListView.Objects
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public Customer()
        {

        }

        public Customer(string name)
        {
            this.Name = name;
        }
    }
}
