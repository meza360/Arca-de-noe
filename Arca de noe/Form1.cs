using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Arca_de_noe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MiLogin Log = new MiLogin();


        //variables
        OleDbCommand comando;
        OleDbConnection conexion;
        OleDbDataAdapter adaptador;
        DataTable tabla;

        double gran = 185.00;
        double med = 175.00;
        double peq = 150.00;
        double a = 345;
        double b = 323;
        double c = 123;
        double d = 543;
        double f = 234;
        double g = 112;
        double h = 231;
        dynamic gg = 0;
        dynamic sede;
        dynamic xx;
        dynamic xy;
        dynamic producto;
        dynamic cantidad1;
        int cantidad2;
        double total1 = 0;
        double total2;
        double total3;
        int aaa;




        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                gservicios.Visible = false;
                gfactura.Visible = false;
                g1.Visible = false;
                gdatos.Visible = false;
                gregistro.Visible = false;
                lbtotal.Text = "0";
                conexion = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Arca.mdb");
                conexion.Open();
                adaptador = new OleDbDataAdapter("Select Producto,Existencias,Precio from Productos",conexion);
                tabla = new DataTable();
                adaptador.Fill(tabla);
                view1.DataSource = tabla;
                MessageBox.Show("Ordenador listo :)");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.Signup(txt1.Text, txt2.Text, txt3.Text, txt1, txt2, txt3, gregistro);
            gregistro.Visible = false;
            ginicio.Visible = true;
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tt = txt4.Text;
            if (Log.LogAdmin(txt4.Text, txt5.Text, txt4, txt5, ginicio))
            {
                //g1.Text = tt;
                gregistro.Visible = true;
                checkBox1.Checked = false;
            }
            if (Log.LogUsuario(txt4.Text, txt5.Text, txt4, txt5, ginicio))
            {
                g1.Text = tt;
                g1.Visible = true;
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                File.OpenRead(txt4.Text);
                var st = new StreamReader(txt4.Text);
                string ff = st.ReadLine();
                txt5.Text = ff;
            }
            else if(checkBox1.Checked == false)
            {
                txt5.Clear();
            }
        }

        private void g1_Enter(object sender, EventArgs e)
        {

        }

        private void g2_Enter(object sender, EventArgs e)
        {

        }

        private void comboprod_SelectedIndexChanged(object sender, EventArgs e)
        {

             producto = comboprod.SelectedItem;
             xx = comboprod.SelectedIndex;
             //produccalc(int.Parse(gg));

        }

        private void combocant1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cantidad1 = combocant1.SelectedIndex;
            gg = combocant1.SelectedItem;
            produccalc(int.Parse(gg));
        }

        public void produccalc(int cantidad)
        {
            if (xx == 0)
            {
                total1 = (a * cantidad);
                lbtotal.Text = total1.ToString();
            }
            if (xx == 1)
            {
                total1 = (b * cantidad);
                lbtotal.Text = total1.ToString();
            }
            if (xx == 2)
            {
                total1 = (c * cantidad);
                lbtotal.Text = total1.ToString();
            }
            if (xx == 3)
            {
                total1 = (d * cantidad);
                lbtotal.Text = total1.ToString();
            }
            if (xx == 4)
            {
                total1 = (f * cantidad);
                lbtotal.Text = total1.ToString();
            }

            if (xx == 5)
            {
                total1 = (f * cantidad);
                lbtotal.Text = total1.ToString();
            }

            if (xx == 6)
            {
                total1 = (g * cantidad);
                lbtotal.Text = total1.ToString();
            }

            if (xx == 7)
            {
                total1 = (h * cantidad);
                lbtotal.Text = total1.ToString();
            }
            if (xx == 8)
            {
                total1 = (f * cantidad);
                lbtotal.Text = total1.ToString();
            }


        }

        private void btcompra_Click(object sender, EventArgs e)
        {
            g1.Visible = false;
            gdatos.Visible = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btservicio_Click(object sender, EventArgs e)
        {
            if (txtnit.Text == "" || txtnombre.Text == "")
            {
                MessageBox.Show("No deje campos vacios por favor");
                txtnombre.Text = "";
                txtnit.Text = "";
            }
            else
            {
                try
                {
                    comando = new OleDbCommand("INSERT INTO Facturaciones VALUES('" + fechapick.Value + "','" + sede + "','" + txtnombre.Text + "','" + txtnit.Text + "'," + total1 + ")",conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Se isnerto en la db correctamente");
                    txtnombre.Text = "";
                    txtnit.Text = "";
                    gdatos.Visible = false;
                    gfactura.Visible = true;
                    listBox1.Items.Add("Fecha: " + fechapick.Value);
                    listBox1.Items.Add("Sede: " + sede);
                    listBox1.Items.Add("Cliente: " + txtnombre.Text);
                    listBox1.Items.Add("Nit : " + txtnit.Text);
                    listBox1.Items.Add("Total: " + total1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sede = combosede.SelectedItem;
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdgrooming.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                rdperro.Checked = false;
                rdgato.Checked = false;
            }
        }

        private void rdcompra_CheckedChanged(object sender, EventArgs e)
        {
            if (rdcompra.Checked == true)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                rdgrande.Checked = false;
                rdmediano.Checked = false;
                rdpeque.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            total2 = 0;
            if (rdgrande.Checked == true)
            {
                total2 = gran;
                total1 += total2;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdmediano_CheckedChanged(object sender, EventArgs e)
        {
            total2 = 0;
            if (rdmediano.Checked == true)
            {
                total2 = med;
                total1 += total2;
            }
        }

        private void rdpeque_CheckedChanged(object sender, EventArgs e)
        {
            total2 = 0;
            if (rdpeque.Checked == true)
            {
                total2 = peq;
                total1 += total2;
            }
                 
        }

        private void rdperro_CheckedChanged(object sender, EventArgs e)
        {
            total3 = 0;
            if (rdperro.Checked == true)
            {
                total3 = 3000;
                total1 += total3;
            }
        }

        private void rdgato_CheckedChanged(object sender, EventArgs e)
        {
            total3 = 0;
            if (rdgato.Checked == true)
            {
                total3 = 3200;
                total1 += total3;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gdatos.Visible = true;
            gservicios.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ginicio.Visible = true;
            gregistro.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            gfactura.Visible = false;
            ginicio.Visible = true;
            total1 = 0;
            total2 = 0;
            total3 = 0;
            cantidad2 = 0;
        }

        private void btservicios_Click(object sender, EventArgs e)
        {
            gservicios.Visible = true;
            g1.Visible = false;
        }

    }
}
