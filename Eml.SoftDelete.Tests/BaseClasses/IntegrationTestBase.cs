using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Data.SqlClient;
using Eml.SoftDelete.Data;
using Eml.SoftDelete.Data.Migrations;

namespace Eml.SoftDelete.Tests.BaseClasses
{
    public abstract class IntegrationTestBase
    {
        private const string DB_NAME = "TestDb";

        [SetUp]
        public void SetUpDatabase()
        {
            DestroyDatabase();
            CreateDatabase();
        }

        [TearDown]
        public void TearDownDatabase()
        {
            DestroyDatabase();
        }

        private static void CreateDatabase()
        {
            //Ensure local db is created in BIN folder
            var executionDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbFileName = $"{DB_NAME}.mdf";
            var fullPath = Path.Combine(executionDirectory, dbFileName);
            ExecuteSqlCommand(Master, $@"CREATE DATABASE [{DB_NAME}] ON (NAME = '{DB_NAME}', FILENAME = '{fullPath}')");

            var migration = new MigrateDatabaseToLatestVersion<DefaultDb, Configuration>();
            migration.InitializeDatabase(new DefaultDb());
        }

        private static void DestroyDatabase()
        {
            var sql = $@"SELECT [physical_name] FROM [sys].[master_files]  WHERE [database_id] = DB_ID('{DB_NAME}')";
            var fileNames = ExecuteSqlQuery(Master, sql, row => (string)row["physical_name"]);

            if (!fileNames.Any()) return;

            try
            {
                sql = $@"ALTER DATABASE [{DB_NAME}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; EXEC sp_detach_db '{DB_NAME}'";
                ExecuteSqlCommand(Master, sql);
                fileNames.ForEach(r =>
                {
                    if (File.Exists(r))
                    {
                        File.Delete(r);
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ExecuteSqlCommand(DbConnectionStringBuilder connectionStringBuilder, string commandText)
        {
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                }
            }
        }

        private static List<T> ExecuteSqlQuery<T>(DbConnectionStringBuilder connectionStringBuilder, string queryText, Func<SqlDataReader, T> read)
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = queryText;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(read(reader));
                        }
                    }
                }
            }
            return result;
        }

        private static SqlConnectionStringBuilder Master =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = "master",
                IntegratedSecurity = true
            };
    }
}
