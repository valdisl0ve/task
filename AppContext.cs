using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
//using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;

namespace ToDo
{
    class AppContext : DbContext
    {

          

        public DbSet<Todo_table> Todo_table { get; set; }



       // public SQLiteConnection DB_connect;
        

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = db.db");
        }




       
      


    }
}
