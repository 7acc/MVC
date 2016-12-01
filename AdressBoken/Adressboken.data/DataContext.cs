using Adressboken.data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adressboken.data
{
    class DataContext : DbContext
    {
        public DbSet<Adress> Adresses{ get; set; }
    }
}
