using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Tienda
{
    internal class ClsAcciones
    {
        Clsconexion Conexion = new Clsconexion();

        SqlDataAdapter da; //alias de data adapter

        DataTable dt;

        public void CargarDatos(DataGridView dgv, string nametable)
        {

            try
            {
                da = new SqlDataAdapter("select * from " + nametable, Conexion.sc);
                dt = new DataTable();
                da.Fill(dt); // llenamos dt con la conslta
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }
    }
}
