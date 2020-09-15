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

namespace Maths2Science
{
    public partial class Login : Form
    {


        private SqlConnection con;
        private SqlDataAdapter adapt;
        private SqlCommand com;
        private DataSet ds;
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\timon\OneDrive\Maths2Science\Maths2Science\Maths2ScienceData.mdf;Integrated Security=True";


        private SqlDataAdapter adapt2;
        private SqlCommand com2;
        private DataSet ds2;

        private SqlDataAdapter adapt3;
        private SqlCommand com3;
        private DataSet ds3;

        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(conStr);
            adapt = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "' and SecurityClearance = '" + "admin" + "'", con);
            DataTable dt = new DataTable();
            ds = new DataSet();

            adapt.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Administrator a = new Administrator();
                a.ShowDialog();
            }
            else
            {
                adapt2 = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "' and SecurityClearance = '" + "tutor" + "'", con);
                DataTable dt2 = new DataTable();
                ds2 = new DataSet();

                adapt2.Fill(dt2);
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Tutors t = new Tutors();
                    t.ShowDialog();
                }
                else
                {
                    adapt3 = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "' and SecurityClearance = '" + "student" + "'", con);
                    DataTable dt3 = new DataTable();
                    ds3 = new DataSet();

                    adapt3.Fill(dt3);
                    if (dt3.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        Students s = new Students();
                        s.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUser.Clear();
                    }

                }
            }


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


