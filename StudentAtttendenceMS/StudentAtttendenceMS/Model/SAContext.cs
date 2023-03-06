using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentAtttendenceMS.Model
{
    public class SAContext : DbContext
    {
        public SAContext(DbContextOptions<SAContext> options ):base(options)
        {

        }

        public DbSet<TblFaculty> TblFaculty { get;set; }
        public DbSet<TblStudent> TblStudents { get;set;}
        public DbSet<TblAttendence> TblAttendence { get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Database=SAMSDB;Integrated Security=True");
         }

    }
}
