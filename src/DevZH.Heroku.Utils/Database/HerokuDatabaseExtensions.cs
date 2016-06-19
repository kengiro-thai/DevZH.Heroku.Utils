using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.Heroku.Utils.Database
{
    public static class HerokuDatabaseExtensions
    {
        /// <summary>
        /// To Convert DatabaseUrl to ConnectionString for Heroku Database
        /// </summary>
        /// <param name="databaseUrl">
        /// format: [database type]://[username]:[password]@[host]:[port]/[database name]
        /// </param>
        /// <param name="connectionStringFormat">A composite format string for databaseUrl. </param>
        /// <returns>A ConnectionString of Heroku Database.</returns>
        public static string GetConnectionStringFromDatabaseUrl(string databaseUrl, string connectionStringFormat = "Server={0};Port={1};Database={2};Username={3};Password={4}")
        {
            if (string.IsNullOrEmpty(databaseUrl) || string.IsNullOrEmpty(connectionStringFormat))
            {
                return null;
            }
            var url = new Uri(databaseUrl);
            var databaseType = url.Scheme;
            var userInfo = url.UserInfo.Split(new[] {':'}, 2);
            var userName = userInfo[0];
            var password = userInfo[1];
            var host = url.Host;
            var port = url.Port;
            var databaseName = url.AbsolutePath.Remove(0, 1);
            return string.Format(connectionStringFormat, host, port, databaseName, userName, password);
        }

        /// <summary>
        /// An Implement of extension method for <seealso cref="GetConnectionStringFromDatabaseUrl"/>
        /// </summary>
        public static string ToConnectionString(this string databaseUrl, string connectionStringFormat = "Server={0};Port={1};Database={2};Username={3};Password={4}")
        {
            return GetConnectionStringFromDatabaseUrl(databaseUrl, connectionStringFormat);
        }
    }
}
