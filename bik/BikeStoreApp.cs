using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bik
{
    public partial class BikeStoreApp : Form
    {
        private readonly string connectionString = "Server=SHAY\\MSSQLSERVER01;Database=BikeStore;Trusted_Connection=True;";

        public BikeStoreApp()
        {
            InitializeComponent();
            ClearGrid();
            LoadComboBoxData();
            LoadSalesData();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            ViewCustomerSales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubmitSale();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewYearlySales();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            ViewTodaySales();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }

        
        //Main Functions
        // Clear the DataGridView
        private void ClearGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        // Load data into ComboBoxes
        private void LoadComboBoxData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    comboBox1.DataSource = LoadComboBoxQuery(connection, "SELECT DISTINCT BikeType FROM Bikesinv");
                    comboBox1.DisplayMember = "BikeType";

                    
                    comboBox2.DataSource = LoadComboBoxQuery(connection, "SELECT DISTINCT Size FROM Bikesinv");
                    comboBox2.DisplayMember = "Size";

                    
                    comboBox3.DataSource = LoadComboBoxQuery(connection, "SELECT DISTINCT Color FROM Bikesinv");
                    comboBox3.DisplayMember = "Color";

                    
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("2023");
                    comboBox4.Items.Add("2024");
                    comboBox4.Items.Add("2025");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading combo box data: {ex.Message}");
                }
            }
        }

        private DataTable LoadComboBoxQuery(SqlConnection connection, string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Load all sales data
        private void LoadSalesData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT s.SaleID, 
                               c.FirstName + ' ' + c.LastName AS CustomerName, 
                               b.BikeType, 
                               b.Color, 
                               b.Size, 
                               s.Quantity, 
                               s.TotalPrice, 
                               s.SaleDate
                        FROM Sales s
                        INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                        INNER JOIN Bikesinv b ON s.BikeID = b.BikeID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable salesTable = new DataTable();
                    adapter.Fill(salesTable);

                    dataGridView1.DataSource = salesTable;
                    CustomizeGridHeaders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading sales data: {ex.Message}");
                }
            }
        }

        private void CustomizeGridHeaders()
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns["SaleID"].HeaderText = "Sale ID";
                dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
                dataGridView1.Columns["BikeType"].HeaderText = "Bike Type";
                dataGridView1.Columns["Color"].HeaderText = "Color";
                dataGridView1.Columns["Size"].HeaderText = "Size";
                dataGridView1.Columns["Quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["TotalPrice"].HeaderText = "Total Price";
                dataGridView1.Columns["SaleDate"].HeaderText = "Sale Date";
            }
        }

        // View customer's sales history
        private void ViewCustomerSales()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string customerName = $"{textBox1.Text.Trim()} {textBox4.Text.Trim()}";

                    if (string.IsNullOrWhiteSpace(customerName))
                    {
                        MessageBox.Show("Please enter a valid customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"
                        SELECT s.SaleID, 
                               c.FirstName + ' ' + c.LastName AS CustomerName, 
                               b.BikeType, 
                               b.Color, 
                               b.Size, 
                               s.Quantity, 
                               s.TotalPrice, 
                               s.SaleDate
                        FROM Sales s
                        INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                        INNER JOIN Bikesinv b ON s.BikeID = b.BikeID
                        WHERE c.FirstName + ' ' + c.LastName = @CustomerName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@CustomerName", customerName);

                    DataTable customerSalesTable = new DataTable();
                    adapter.Fill(customerSalesTable);

                    if (customerSalesTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No sales history found for this customer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearGrid();
                    }
                    else
                    {
                        dataGridView1.DataSource = customerSalesTable;
                        CustomizeGridHeaders();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading customer's sales: {ex.Message}");
                }
            }
        }

        // View today's sales
        private void ViewTodaySales()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT s.SaleID, 
                               c.FirstName + ' ' + c.LastName AS CustomerName, 
                               b.BikeType, 
                               b.Color, 
                               b.Size, 
                               s.Quantity, 
                               s.TotalPrice, 
                               s.SaleDate
                        FROM Sales s
                        INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                        INNER JOIN Bikesinv b ON s.BikeID = b.BikeID
                        WHERE CAST(s.SaleDate AS DATE) = CAST(GETDATE() AS DATE)";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable todaySalesTable = new DataTable();
                    adapter.Fill(todaySalesTable);

                    if (todaySalesTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No sales found for today.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearGrid();
                    }
                    else
                    {
                        dataGridView1.DataSource = todaySalesTable;
                        CustomizeGridHeaders();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading today's sales: {ex.Message}");
                }
            }
        }

        // View sales for the selected year
        private void ViewYearlySales()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectedYear = comboBox4.SelectedItem?.ToString();

                    if (string.IsNullOrWhiteSpace(selectedYear))
                    {
                        MessageBox.Show("Please select a year.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"
                        SELECT s.SaleID, 
                               c.FirstName + ' ' + c.LastName AS CustomerName, 
                               b.BikeType, 
                               b.Color, 
                               b.Size, 
                               s.Quantity, 
                               s.TotalPrice, 
                               s.SaleDate
                        FROM Sales s
                        INNER JOIN Customers c ON s.CustomerID = c.CustomerID
                        INNER JOIN Bikesinv b ON s.BikeID = b.BikeID
                        WHERE YEAR(s.SaleDate) = @Year";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Year", selectedYear);

                    DataTable yearSalesTable = new DataTable();
                    adapter.Fill(yearSalesTable);

                    if (yearSalesTable.Rows.Count == 0)
                    {
                        MessageBox.Show($"No sales found for the year {selectedYear}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearGrid();
                    }
                    else
                    {
                        dataGridView1.DataSource = yearSalesTable;
                        CustomizeGridHeaders();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading yearly sales: {ex.Message}");
                }
            }
        }

        private void SubmitSale()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check inventory for the selected bike
                    string inventoryQuery = @"
                SELECT BikeID, Quantity, Price 
                FROM Bikesinv 
                WHERE BikeType = @BikeType AND Color = @Color AND Size = @Size";

                    SqlCommand inventoryCommand = new SqlCommand(inventoryQuery, connection);
                    inventoryCommand.Parameters.AddWithValue("@BikeType", comboBox1.Text);
                    inventoryCommand.Parameters.AddWithValue("@Color", comboBox3.Text);
                    inventoryCommand.Parameters.AddWithValue("@Size", comboBox2.Text);

                    SqlDataReader reader = inventoryCommand.ExecuteReader();
                    if (!reader.Read())
                    {
                        MessageBox.Show("Selected bike not found in inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int bikeID = Convert.ToInt32(reader["BikeID"]);
                    int availableQuantity = Convert.ToInt32(reader["Quantity"]);
                    decimal pricePerBike = Convert.ToDecimal(reader["Price"]);
                    reader.Close();

                    if (availableQuantity < 1)
                    {
                        MessageBox.Show("Not enough stock for this bike.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insert customer
                    string customerQuery = @"
                INSERT INTO Customers (FirstName, LastName, PhoneNumber, Address) 
                VALUES (@FirstName, @LastName, @PhoneNumber, @Address); 
                SELECT SCOPE_IDENTITY();";

                    SqlCommand customerCommand = new SqlCommand(customerQuery, connection);
                    customerCommand.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                    customerCommand.Parameters.AddWithValue("@LastName", textBox4.Text.Trim());
                    customerCommand.Parameters.AddWithValue("@PhoneNumber", textBox3.Text.Trim());
                    customerCommand.Parameters.AddWithValue("@Address", textBox2.Text.Trim());
                    int customerID = Convert.ToInt32(customerCommand.ExecuteScalar());

                    // Parse and validate amount
                    if (!int.TryParse(textBox5.Text.Trim(), out int quantity) || quantity <= 0)
                    {
                        MessageBox.Show("Invalid amount entered. Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (quantity > availableQuantity)
                    {
                        MessageBox.Show("Not enough stock available. Please reduce the quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Calculate total price
                    decimal totalPrice = pricePerBike * quantity;

                    // Insert sale
                    string saleQuery = @"
                INSERT INTO Sales (CustomerID, BikeID, Quantity, TotalPrice) 
                VALUES (@CustomerID, @BikeID, @Quantity, @TotalPrice)";

                    SqlCommand saleCommand = new SqlCommand(saleQuery, connection);
                    saleCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    saleCommand.Parameters.AddWithValue("@BikeID", bikeID);
                    saleCommand.Parameters.AddWithValue("@Quantity", quantity);
                    saleCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    saleCommand.ExecuteNonQuery();

                    // Update inventory
                    string inventoryUpdateQuery = @"
                UPDATE Bikesinv 
                SET Quantity = Quantity - @Quantity 
                WHERE BikeID = @BikeID";

                    SqlCommand inventoryUpdateCommand = new SqlCommand(inventoryUpdateQuery, connection);
                    inventoryUpdateCommand.Parameters.AddWithValue("@Quantity", quantity);
                    inventoryUpdateCommand.Parameters.AddWithValue("@BikeID", bikeID);
                    inventoryUpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Sale successfully submitted!");
                    LoadSalesData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error submitting sale: {ex.Message}");
                }
            }
        }



        // Load inventory
        private void LoadInventory()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT BikeType, Color, Size, Quantity 
                        FROM Bikesinv
                        ORDER BY BikeType, Color, Size";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable inventoryTable = new DataTable();
                    adapter.Fill(inventoryTable);

                    dataGridView1.DataSource = inventoryTable;

                    // Customize headers
                    dataGridView1.Columns["BikeType"].HeaderText = "Bike Type";
                    dataGridView1.Columns["Color"].HeaderText = "Color";
                    dataGridView1.Columns["Size"].HeaderText = "Size";
                    dataGridView1.Columns["Quantity"].HeaderText = "Available Quantity";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading inventory: {ex.Message}");
                }
            }
        }


    }
}
