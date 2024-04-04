using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string server = "localhost";
string user = "root";
string password = "";
string database = "todoapi";

string connectionString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database;


app.MapGet("/", () => "Hello World!");

app.MapGet("/alvo", () => "Hello Alvo!");

// Define a route to test the database connection
app.MapGet("/testdb", async (HttpContext context) =>
{
    try
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();

            // Check if the connection is open
            if (connection.State == System.Data.ConnectionState.Open)
            {
                await context.Response.WriteAsync("Database connection successful!");
            }
            else
            {
                await context.Response.WriteAsync("Database connection failed!");
            }
        }
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsync($"Error: {ex.Message}");
    }
});

app.MapGet("/insert", async (HttpContext context) =>
{
    try
    {
        // Sample data to insert
        string todoText = "Learn MySQL with C#";
        bool completed = false;

        // SQL insert statement
        string insertSql = "INSERT INTO todos (todo_text, completed) VALUES (@todoText, @completed)";

        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();

            // Create MySqlCommand object
            using (var cmd = new MySqlCommand(insertSql, connection))
            {
                // Add parameters to the command
                cmd.Parameters.AddWithValue("@todoText", todoText);
                cmd.Parameters.AddWithValue("@completed", completed);

                // Execute the insert command
                int rowsAffected = await cmd.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    await context.Response.WriteAsync("Data inserted successfully!");
                }
                else
                {
                    await context.Response.WriteAsync("Failed to insert data!");
                }
            }
        }
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsync($"Error: {ex.Message}");
    }
});


app.MapGet("/select", async (HttpContext context) =>
{
    try
    {
        // SQL select statement
        string selectSql = "SELECT * FROM todos";

        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();

            // Create MySqlCommand object
            using (var cmd = new MySqlCommand(selectSql, connection))
            {
                // Execute the select command
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // Check if there are any rows
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            await context.Response.WriteAsync($"ID: {reader.GetInt32(0)}, Todo Text: {reader.GetString(1)}, Completed: {reader.GetBoolean(2)}\n");
                        }
                    }
                    else
                    {
                        await context.Response.WriteAsync("No data found!");
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsync($"Error: {ex.Message}");
    }
});




app.Run();
