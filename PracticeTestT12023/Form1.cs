using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeTestT12023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PracticeTest2023;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'practiceTest2023DataSet.Company_Details' table. You can move, or remove it, as needed.
            this.company_DetailsTableAdapter.Fill(this.practiceTest2023DataSet.Company_Details);

        }

        private void button1_Click(object sender, EventArgs e) // submit button
        {
            conn.Open(); // opens database

            // insert into Company_Details values ('Toyota, Automotive, 223, 6, 67000, Tokyo, 2/2/1922')

            string comm = "insert into Company_Details values ('" + textBox1.Text + "','" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) + "','" + Convert.ToDecimal(textBox4.Text) + "','" + Convert.ToInt32(textBox5.Text) + "','" + textBox6.Text + "','" + Convert.ToDateTime(textBox7.Text) + "')";

            // SqlCommand class

            SqlCommand objcomm = new SqlCommand(comm, conn); // created command obj

            objcomm.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Data entry done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open(); // opens database

            // select * from Company_Details

            string query = "select * from Company_Details";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataSet data = new DataSet();

            da.Fill(data);
            conn.Close();

            dataGridView1.DataSource = data.Tables[0]; // display into the datagridview
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open(); // opens database

            // select * from Company_Details where Revenue_Growth > 0

            string query = "select * from Company_Details where Revenue_Growth > 0";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataSet data = new DataSet();

            da.Fill(data);
            conn.Close();

            dataGridView1.DataSource = data.Tables[0]; // display into the datagridview
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open(); // opens database

            // select * from Company_Details where Industry = 'Automotive'

            string query = "select * from Company_Details where Industry = 'Automotive'";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataSet data = new DataSet();

            da.Fill(data);
            conn.Close();

            dataGridView1.DataSource = data.Tables[0]; // display into the datagridview
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open(); // opens database

            // select * from Company_Details where Foundation_date  between 1970-01-01 and 1979-12-12

            string query = "select * from Company_Details where Foundation_date  between '1970-01-01' and '1979-12-12'";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataSet data = new DataSet();

            da.Fill(data);
            conn.Close();

            dataGridView1.DataSource = data.Tables[0]; // display into the datagridview
        }
    }
}
