using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsDataBase
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {
        }
        public DbSet<Group> Groups {  get; set;}
        public DbSet<Song> Songs { get; set; }
    }
}
