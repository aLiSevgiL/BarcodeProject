using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FirebirdSql.EntityFrameworkCore.Firebird;
using FirebirdSql.EntityFrameworkCore.Firebird.Extensions;
using Entities;
using FirebirdSql.Data.FirebirdClient;

namespace DataAccess.Concrete
{
    public class FirebirdContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var firebirdConnectionString = @"database=localhost:C:\cumhur\DataServer\Data\Mayteks\EB01DATA.GDB;user=SYSDBA;password=masterkey";
            optionsBuilder.UseFirebird(firebirdConnectionString);
        }








    }
}
