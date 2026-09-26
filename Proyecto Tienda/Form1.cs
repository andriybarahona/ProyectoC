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

namespace Proyecto_Tienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClsAcciones acciones = new ClsAcciones();
        Clsconexion conexion = new Clsconexion();
        ClsValidaciones valid = new ClsValidaciones();
        SqlCommand cmd;
        FmrMenu menu = new FmrMenu();
        FmrAdmi admi = new FmrAdmi();
        FmrSupervisor supervisor = new FmrSupervisor();



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            log(txtusuario.Text, txtpassword.Text);
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid.SoloLetras(e);
        }

        public void log(string usuario, string password)
        {
            try
            {
                conexion.abrir();

                SqlCommand cmd = new SqlCommand("select Rol from Usuario where Nombre = @Usuario and Contrasena = @pas", conexion.sc);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@pas", password);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {

                    string rolObtenido = dt.Rows[0][0].ToString();

                    MessageBox.Show("¡Inicio de sesión exitoso!\n\nBienvenido al sistema. Tu rol es: " + rolObtenido,
                                    "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dt.Rows[0][0].ToString() == "Administrador")
                    {
                        admi.Show();
                    }
                    else if (dt.Rows[0][0].ToString() == "Supervisor")
                    {
                        supervisor.Show();
                    }
                    else if (dt.Rows[0][0].ToString() == "Operador")
                    {
                        menu.Show();
                    }

                    this.Hide();



                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtpassword.Text = "";
                    txtusuario.Text = "";
                    txtusuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
