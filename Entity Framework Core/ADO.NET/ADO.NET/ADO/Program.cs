using System;
using System.Data.SqlClient;

namespace ADO
{
    class Program
    {
        const string SqlConnectionString = "Server=.;Database=MinionsDB;Integrated Sequrity=true";

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                string createDatabase = "CREATE DATABASE MinionsDB";

                using (var command = new SqlCommand(createDatabase, connection))
                {
                    command.ExecuteNonQuery();
                }


                    var createTableStatements = GetCreateTableStatements();
            }
        }

        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
                {
                    "CREATE TABLE Countries(Id INT PRIMARY KEY,Name VARCHAR(50))",
                    "CREATE TABLE Towns(Id INT PRIMARY KEY,Name VARCHAR(50),CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                    "CREATE TABLE Minions(Id INT PRIMARY KEY,Name VARCHAR(50),Age INT,TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                    "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY,Name VARCHAR(50))",
                    "CREATE TABLE Villains(	Id INT PRIMARY KEY,	Name VARCHAR(50),	EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                    "CREATE TABLE MinionsVilians(MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id) CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId ,VillainId))"
                };

                return result;
        }
    }
}
