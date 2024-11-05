using System;
using Microsoft.Data.Sqlite;

public class DatabaseHelper
{
    private string _connectionString;

    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void EnsureUserTableExists()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS user (
                        id TEXT PRIMARY KEY,
                        name TEXT NOT NULL
                    )
                ";

            command.ExecuteNonQuery();
        }
    }

    public void CreateUser(string id, string name)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    INSERT INTO user (id, name)
                    VALUES ($id, $name)
                ";
            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$name", name);

            command.ExecuteNonQuery();
        }
    }

    public string GetUserNameById(string id)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    SELECT name
                    FROM user
                    WHERE id = $id
                ";
            command.Parameters.AddWithValue("$id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
