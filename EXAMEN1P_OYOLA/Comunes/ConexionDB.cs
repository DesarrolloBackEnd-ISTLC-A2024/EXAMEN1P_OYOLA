using EXAMEN1P_OYOLA.Models;
using System.Data;
using System.Data.SqlClient;

namespace EXAMEN1P_OYOLA.Comunes
{
    public class ConexionDB
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            conexion = new SqlConnection("Server = LancelotPC\\SQLEXPRESS; Database = Furbol; Trusted_Connection = True;");
            conexion.Open();
            return conexion;
        }

        #region Futbolista
        public static List<Futbolista> GetFutbolistasActivos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_FutbolistasACTIVE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarFutbolistas(dataSet.Tables[0]);
        }

        public static Futbolista GetFutbolista(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_Futbolistas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarFutbolistas(dataSet.Tables[0])[0];
        }

        public static void PostFutbolista(Futbolista objfutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_Futbolistas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_Nombre", objfutbolista.nombre);
            cmd.Parameters.AddWithValue("@PV_Apellido", objfutbolista.apellido);
            cmd.Parameters.AddWithValue("@PI_Numero_Camisa", objfutbolista.numero_camisa);
            cmd.Parameters.AddWithValue("@PD_Fecha_Nacimiento", objfutbolista.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PD_Fecha_Retiro", objfutbolista.fecha_retiro);
            cmd.ExecuteNonQuery();
        }

        public static void PutFutbolista(int id, Futbolista objfutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_Futbolistas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID", id);
            cmd.Parameters.AddWithValue("@PV_Nombre", objfutbolista.nombre);
            cmd.Parameters.AddWithValue("@PV_Apellido", objfutbolista.apellido);
            cmd.Parameters.AddWithValue("@PI_Numero_Camisa", objfutbolista.numero_camisa);
            cmd.Parameters.AddWithValue("@PD_Fecha_Nacimiento", objfutbolista.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PD_Fecha_Retiro", objfutbolista.fecha_retiro);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteFutbolista(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_Futbolistas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID", id);
            cmd.ExecuteNonQuery();
        }

        public static List<Futbolista> llenarFutbolistas(DataTable dataTable)
        {
            List<Futbolista> lRespuesta = new List<Futbolista>();
            Futbolista objeto = new Futbolista();
            foreach (DataRow dr in dataTable.Rows)
            {
                objeto = new Futbolista();
                objeto.id =                 Convert.ToInt32(dr["ID"]);
                objeto.nombre =             dr["Nombre"].ToString();
                objeto.apellido =           dr["Apellido"].ToString();
                objeto.numero_camisa =      Convert.ToInt32(dr["Numero_Camisa"]);
                objeto.fecha_nacimiento =   Convert.ToDateTime(dr["Fecha_Nacimiento"]);
                objeto.fecha_retiro =       Convert.ToDateTime(dr["Fecha_Retiro"]);
                objeto.estado =             dr["Estado"].ToString();
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

        #endregion


        #region Historico

        public static List<HistoricoEquipo> GetHistoricoEquipo(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_HISTORICOFUTBOLISTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PI_ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarHistorico(dataSet.Tables[0]);
        }

        public static List<HistoricoEquipo> llenarHistorico(DataTable dataTable)
        {
            List<HistoricoEquipo> lRespuesta = new List<HistoricoEquipo>();
            foreach (DataRow dr in dataTable.Rows)
            {
                HistoricoEquipo objeto = new HistoricoEquipo();
                objeto.nombre = dr["Nombre"].ToString();
                objeto.apellido = dr["Apellido"].ToString();
                objeto.nombreequipo = dr["NombreEquipo"].ToString();
                objeto.fecha_inicio = Convert.ToDateTime(dr["Fecha_Inicio"].ToString());
                objeto.fecha_fin = Convert.ToDateTime(dr["Fecha_Fin"].ToString());
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }


        #endregion

    }
}
