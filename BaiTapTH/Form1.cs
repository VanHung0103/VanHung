using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace BaiTapTH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        private void view()
        {
            conn.Close();
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT * FROM HocSinh");


                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtSinhVien = new DataTable();
                adapter.Fill(dtSinhVien);
                dataGridView1.DataSource = dtSinhVien; /// gvHsinh = name cua data gridview
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            view();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ket noi
                conn.Open();
                string sqlStr = string.Format($"INSERT INTO HocSinh VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}','{dateTimePicker1.Value.ToString("yyyy/MM/dd")}')");

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("them thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("them that bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string SQL = string.Format("DELETE FROM HocSinh WHERE Ten = '{0}' and Diachi = '{1}' and Cmnd = '{2}' and NgaySinh = '{3}' ", textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xoa thanh cong");
                    view();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoa that bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string SQL = string.Format("UPDATE HocSinh SET Ten = '{0}' and Diachi = '{1}' and Cmnd = '{2}' WHERE NgaySinh= '{3}'", textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sua thanh cong");
                    view();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sua that bai" + ex);
            }
            finally
            {
                conn.Close();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            DataRowView dataRow = (DataRowView)data.CurrentRow.DataBoundItem;
            textBox1.Text = dataRow["Ten"].ToString();
            textBox2.Text = dataRow["Diachi"].ToString();
            textBox3.Text = dataRow["Cmnd"].ToString();
            DateTime dateTime;
            DateTime.TryParse(dataRow["NgaySinh"].ToString(), out dateTime);
            dateTimePicker1.Value = dateTime;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
