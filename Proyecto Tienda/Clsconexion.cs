using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Tienda
{
    internal class Clsconexion
    {
        string conexion = "Data Source = ANDRIY\\SQLEXPRESS; Initial Catalog = SistemaInventario; Integrated Security = true";

        public SqlConnection sc = new SqlConnection();

        public Clsconexion()
        {
            sc.ConnectionString = conexion;
        }


        public void abrir()
        {
            try
            {
                if (sc.State == System.Data.ConnectionState.Closed)
                {
                    sc.Open();

                }
            }
            catch
            {

            }
        }

        public void cerrar()

        {
            try
            {
                if (sc.State == System.Data.ConnectionState.Open)
                {
                    sc.Close();


                }
            }
            catch
            {


            }

        }
    }
}
