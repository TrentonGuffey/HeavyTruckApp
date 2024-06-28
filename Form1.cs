using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace HeavyTruckApp
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-G0671EM\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly CustomQueries customQueries;

        public Form1()
        {
            InitializeComponent();
            customQueries = new CustomQueries();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();

            PopulateTableNames();
            
        }
        private void ConnectToDatabase()
        {
            using SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connection Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void PopulateTableNames()
        {
            List<string> tableNames = GetTableNames();
            tableNames.Sort();

            comboBox1.DataSource = tableNames;
            comboBox2.DataSource = tableNames;
            comboBox3.DataSource = tableNames;  

        }   

        private List<string> GetTableNames()
        {
            List<string> tableNames = new List<string>();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");

                foreach (DataRow row in schema.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    tableNames.Add(tableName);
                }
            }
            return tableNames;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog newEdiBrowse = new();

            if (newEdiBrowse.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = newEdiBrowse.FileName;
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string csvFilePath = textBox1.Text;
            string fileName = Path.GetFileNameWithoutExtension(csvFilePath);
            string tableName = fileName;

            bool tableCreated = CustomQueries.CreateAndLoadTableFromCSV(connectionString, csvFilePath, tableName);

            if (tableCreated)
            {
                MessageBox.Show("Table was created successfully!");

                // Clear textBox1
                textBox1.Clear();

                // Refresh the table names
                PopulateTableNames(); // Call your method to populate table names again
            }
            else
            {
                MessageBox.Show("Error occurred while creating the table.");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string plannedJobsTableName = comboBox2.SelectedItem.ToString();
            int lowerBound = int.Parse(textBox2.Text);
            int upperBound = int.Parse(textBox7.Text);

            bool uploadSuccess = CustomQueries.InsertPlannedJoblist(connectionString, plannedJobsTableName, lowerBound, upperBound);

            if (uploadSuccess)
            {
                MessageBox.Show("Lines uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox2.Clear();
                textBox7.Clear();
            }
            else
            {
                MessageBox.Show("Failed to upload lines.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = comboBox1.SelectedItem.ToString();

                DataTable result = CustomQueries.StatusQuery(connectionString, tableName);

                dataGridView1.DataSource = result;

                dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current cell is in a valid row and column
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the cell value is not null
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Check if the current column corresponds to the MSTX.Status column
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Status")
                    {
                        // Get the value of the Status cell
                        string status = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                        // Set the background color of the current row based on the value of Status
                        switch (status)
                        {
                            case "Shipped":
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LawnGreen;
                                break;
                            case "Planned":
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                                break;
                            default:
                                // Set the default background color (white) if no match is found
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                break;
                        }
                    }
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string tableName = comboBox3.SelectedItem.ToString();
            int lowerBound = int.Parse(textBox5.Text);
            int upperBound = int.Parse(textBox6.Text);

            bool updateSuccess = CustomQueries.UpdateStatusToShipped(connectionString, tableName, lowerBound, upperBound);

            if (updateSuccess)
            {
                MessageBox.Show("Status updated to 'Shipped' successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
