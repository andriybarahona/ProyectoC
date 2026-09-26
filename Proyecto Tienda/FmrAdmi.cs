using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Tienda
{
    public partial class FmrAdmi : Form
    {
        public FmrAdmi()
        {
            InitializeComponent();
        }
        ClsAcciones acciones = new ClsAcciones();
        Clsconexion conexion = new Clsconexion();
        ClsValidaciones valid = new ClsValidaciones();
        FmrUsuario usuario = new FmrUsuario();
        private void btnusuario_Click(object sender, EventArgs e)
        {
            usuario.Show();
            this.Hide();

        }

    }
}
