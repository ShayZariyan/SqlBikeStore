using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Text.Json;

namespace MongoDBTcpServer
{
    class Program
    {
        private static readonly string mongoConnectionString = "mongodb://localhost:27017/";
        private static readonly string databaseName = "BikeStore";

        static async Task Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int port = 5000;
                server = new TcpListener(IPAddress.Any, port);
                server.Start();

                Console.WriteLine($"Server started on port {port}. Waiting for connections...");

                while (true)
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected.");

                    // Handle client in a separate task
                    _ = Task.Run(() => HandleClient(client));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                server?.Stop();
            }
        }

        private static async Task HandleClient(TcpClient client)
        {
            using (client)
            {
                var stream = client.GetStream();
                var buffer = new byte[1024];
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"Received request: {request}");

                // Parse the request and perform MongoDB operations
                string response = await ProcessRequest(request);

                // Send response back to client
                var responseData = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseData, 0, responseData.Length);
            }
        }

        private static async Task<string> ProcessRequest(string request)
        {
            try
            {
                // Connect to MongoDB
                var client = new MongoClient(mongoConnectionString);
                var database = client.GetDatabase(databaseName);

                // Handle different commands
                if (request.StartsWith("LoadSalesData"))
                {
                    var salesCollection = database.GetCollection<BsonDocument>("Sales");
                    var sales = await salesCollection.Find(new BsonDocument()).ToListAsync();

                    var salesData = new StringBuilder();
                    foreach (var sale in sales)
                    {
                        salesData.AppendLine(sale.ToJson());
                    }
                    return salesData.ToString();
                }
                else if (request.StartsWith("ViewCustomerSales"))
                {
                    // Example: ViewCustomerSales:FirstName LastName
                    var customerName = request.Split(':')[1];
                    var salesCollection = database.GetCollection<BsonDocument>("Sales");

                    var filter = Builders<BsonDocument>.Filter.Eq("CustomerName", customerName);
                    var sales = await salesCollection.Find(filter).ToListAsync();

                    var customerSalesData = new StringBuilder();
                    foreach (var sale in sales)
                    {
                        customerSalesData.AppendLine(sale.ToJson());
                    }
                    return customerSalesData.ToString();
                }
                else if (request.StartsWith("ViewTodaySales"))
                {
                    var today = DateTime.Today;
                    var salesCollection = database.GetCollection<BsonDocument>("Sales");

                    var filter = Builders<BsonDocument>.Filter.Gte("SaleDate", today) &
                                 Builders<BsonDocument>.Filter.Lt("SaleDate", today.AddDays(1));
                    var sales = await salesCollection.Find(filter).ToListAsync();

                    var todaySalesData = new StringBuilder();
                    foreach (var sale in sales)
                    {
                        todaySalesData.AppendLine(sale.ToJson());
                    }
                    return todaySalesData.ToString();
                }
                else if (request.StartsWith("LoadInventory"))
                {
                    var inventoryCollection = database.GetCollection<BsonDocument>("BikesInv");
                    var inventory = await inventoryCollection.Find(new BsonDocument()).ToListAsync();

                    var inventoryData = new StringBuilder();
                    foreach (var item in inventory)
                    {
                        inventoryData.AppendLine(item.ToJson());
                    }
                    return inventoryData.ToString();
                }
                else
                {
                    return "Unknown command.";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
