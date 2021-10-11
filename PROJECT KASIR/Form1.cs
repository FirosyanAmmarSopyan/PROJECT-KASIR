using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PROJECT_KASIR
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            String datalogin = "Data Source=NOTFOUND-404\\FIROZDB;Initial Catalog=Dblogin;Integrated Security=True";
            SqlConnection koneksi = new SqlConnection(datalogin);

            try
            {
                if (koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
                koneksi.Open();
                String sql = "select * from TB_Login where Nama = '" + textbox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, koneksi);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    MessageBox.Show("user tidak ditemukan");
                    textbox1.Focus();
                    return;
                }
                cmd.Dispose(); reader.Close();

                 sql = "select * from TB_Login where Nama = '" + textbox1.Text + "' and Kata_Sandi= '"+textbox2.Text+"'";
                 cmd = new SqlCommand(sql, koneksi);
                 reader = cmd.ExecuteReader();

                if (reader.HasRows == false) 
                {
                    MessageBox.Show("Password tidak ditemukan");
                    textbox1.Focus();
                    return;
                }
                else
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }

                cmd.Dispose(); reader.Close(); koneksi.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
