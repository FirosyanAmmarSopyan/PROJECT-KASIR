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

        namespace PROJECT_KASIR
    {
        public partial class Form2 : Form
        {
            SqlConnection koneksi = new SqlConnection("Data Source=NOTFOUND-404\\FIROZDB;Initial Catalog=Dbkasir;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            public Form2()
            {
                InitializeComponent();
                bersihkan();
                readdata();
            }

            void bersihkan()
        //UNTUK MEMBERSIHKAN ATAU REFRESH, JANGAN LUPA FUNCTION DIPANGGIL DI PUBLIC FORMNYA
        {
            textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "";
            }

            void readdata()
            //UNTUK READ DATA YANG ADA DI DALAM DATABASE, JANGAN LUPA FUNCTION DIPANGGIL DI PUBLIC FORMNYA
            {
                try
                {
                    cmd.Connection = koneksi;
                    adapter.SelectCommand = cmd;
                    cmd.CommandText = "select * from Table_Barang";
                    DataSet ds = new DataSet();
                    if (adapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    koneksi.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        private void button1_Click(object sender, EventArgs e)
            //UNTUK MENGINPUT DATA BARU ATAU MEMBUAT DATA BARU
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi Kolom Terlebih Dahulu");
            }
            else
            {
                try{
                    cmd.Connection = koneksi;
                    adapter.SelectCommand = cmd;
                    cmd.CommandText = "INSERT INTO Table_Barang VALUES ('" +textBox1.Text+ "', '"+ textBox2.Text+"', '"+ textBox3.Text+"', '"+ textBox4.Text+"', '"+ textBox5.Text+"', '"+ textBox6.Text+"')";
                    DataSet ds = new DataSet();
                    if (adapter.Fill(ds,"Table_Barang") > 0 ) {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Data Berhasil Di input");
                    readdata();
                    bersihkan();
                    koneksi.Close();
                }
                catch(Exception ex){
                    MessageBox.Show("data Gagal Di Input");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            //MEMUNCULKAN ISI DATA DI TEXTBOX APABILA DIKLIK SALAH SATU ROWNYA
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["kodebarang"].Value.ToString();
                textBox2.Text = row.Cells["namabarang"].Value.ToString();
                textBox3.Text = row.Cells["harga Jual"].Value.ToString();
                textBox4.Text = row.Cells["Harga Beli"].Value.ToString();
                textBox5.Text = row.Cells["Jumlah Barang"].Value.ToString();
                textBox6.Text = row.Cells["Satuan Barang"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi Kolom Terlebih Dahulu");
            }
            else
            {
                try
                {
                    cmd.Connection = koneksi;
                    adapter.SelectCommand = cmd;
                    cmd.CommandText = "UPDATE Table_Barang SET kodebarang = '" + textBox1.Text + "', namabarang = '" + textBox2.Text + "',Harga_Jual = '" + textBox3.Text + "',Harga_Beli = '" + textBox4.Text + "',Jumlah_Barang = '" + textBox5.Text + "',Satuan_Barang = '" + textBox6.Text + "' where Kode_Barang='" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (adapter.Fill(ds, "Table_Barang") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Update Data Berhasil!");
                    readdata();
                    bersihkan();
                    koneksi.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("data Gagal Di Input");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Yakin Ingin Menghapus "+textBox2.Text+"?","HAPUS DATA!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try { 
                cmd.Connection = koneksi;
                adapter.SelectCommand = cmd;
                cmd.CommandText = "DELETE FROM Table_Barang WHERE kodebarang = '" + textBox1.Text+"'";
                DataSet ds = new DataSet();
                if (adapter.Fill(ds, "Table_Barang") > 0)
                {
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Table_Barang";
                }
                MessageBox.Show("Hapus Data Berhasil ! ");
                readdata();
                bersihkan();
                koneksi.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
  }

        