using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.Heroku.Utils.Database;
using Xunit;

namespace DevZH.Heroku.Utils.Test
{
    public class HrokuDatabaseExtensionsTest
    {
        [Fact]
        public void GetConnectionStringFromDatabaseUrl()
        {
            var databaseUrl =
                "postgres://username:password@host:5432/databasename";
            var connectString = HerokuDatabaseExtensions.GetConnectionStringFromDatabaseUrl(databaseUrl);
            Assert.Equal("Server=host;Port=5432;Database=databasename;Username=username;Password=password", connectString);
        }

        [Fact]
        public void GetConnectionStringFromDatabaseUrlUsingExtension()
        {
            var databaseUrl =
                "postgres://username:password@host:5432/databasename";
            var connectString = databaseUrl.ToConnectionString();
            Assert.Equal("Server=host;Port=5432;Database=databasename;Username=username;Password=password", connectString);
        }
    }
}
