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
    public partial class FmrUsuario : Form
    {
        public FmrUsuario()
        {
            InitializeComponent();
        }
        ClsAcciones acciones = new ClsAcciones();
        Clsconexion conexion = new Clsconexion();
        ClsValidaciones valid = new ClsValidaciones();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string rolSeleccionado = cmbRol.Text;
            try
            {
                
                if (string.IsNullOrWhiteSpace(cmbRol.Text))
                {
                    MessageBox.Show("Por favor, selecciona un rol de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                conexion.abrir();

                SqlCommand cmd = new SqlCommand("InsertarUsuarioSistema", conexion.sc);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Nombre", txtNombreUsuario.Text);
                cmd.Parameters.AddWithValue("@Rol", cmbRol.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }
    }
}
