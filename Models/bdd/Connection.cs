namespace S5_RH.Models.bdd;
using Npgsql;

public class Connection {

    public static NpgsqlConnection GetConnection() {
        int Port = 5432;
        string Host = "localhost";
        string User = "postgres";
        string Database = "rh2test";
        string Password = "fabien";
        // Connection String to the sql server database
        string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    Database,
                    Port,
                    Password);

        // Create a sql Connection object
        NpgsqlConnection connection = new NpgsqlConnection(connString);
        connection.Open();
        return connection;
    }

    public static string fillZero(int length, string sequence) {
        string result = "";
        for (int i = 0; i < length - sequence.Length; i++) {
            result += "0";
        }
        return result + sequence;
    }

    public static string GetSequence(string sequence) {
        using (NpgsqlConnection connection = Connection.GetConnection()) {
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT nextval('" + sequence + "')", connection)) {
                using (NpgsqlDataReader reader = command.ExecuteReader()) {
                    reader.Read();
                    return reader.GetInt32(0).ToString();
                }
            }
        }
    }
}