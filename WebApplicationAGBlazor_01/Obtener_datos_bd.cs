using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace WebApplicationAGBlazor_01
{
    public class Obtener_datos_bd
    {
        private readonly string connectionString;

        public Obtener_datos_bd(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration.GetValue<string>("ConnectionStrings:myconn");
        }
        public IConfiguration Configuration { get; }

        public int consulta_bd(int opc)
        {
            string cadena = "";

            switch (opc)
            {
                case 1: cadena = "vnumero_dias"; break;
                case 2: cadena = "vnumero_periodos"; break;
                case 3: cadena = "vnumero_cursos"; break;
                case 4: cadena = "vnumero_profesores"; break;
                case 5: cadena = "vnumero_materias"; break;
                case 6: cadena = "vnumero_aulas"; break;
            }
            // Ejemplo de consulta SELECT
            string selectQuery = "SELECT * FROM " + cadena;
            DataTable result = ExecuteQuery(selectQuery);
            int dias = 0;
            foreach (DataRow row in result.Rows)
            {
                dias = Convert.ToInt32(row[0]);
            }
            return dias;
        }

        public DataTable consultaObtieneTabla(int opc)
        {
            string cadena = "";

            switch (opc)
            {
                case 1: cadena = "colegio.dia"; break;
                case 2: cadena = "colegio.periodo"; break;
                case 3: cadena = "colegio.curso"; break;
                case 4: cadena = "colegio.profesor"; break;
                case 5: cadena = "colegio.materia"; break;
                case 6: cadena = "colegio.aula"; break;
            }
            // Ejemplo de consulta SELECT
            string selectQuery = "SELECT * FROM " + cadena;
            DataTable result = ExecuteQuery(selectQuery);

            return result;
        }

        public DataTable consultaObtieneHorario()
        {
            string selectQuery = "SELECT d.nombre AS dia, p.nombre AS periodo, p.hora_inicio, p.hora_fin, a.número AS aula,pr.nombre AS profesor, m.nombre AS materia, c.nombre AS curso FROM colegio.horario_prueba h JOIN colegio.dia d ON h.id_dia = d.id_dia JOIN colegio.periodo p ON h.id_periodo = p.id_periodo JOIN colegio.aula a ON h.id_aula = a.id_aula JOIN colegio.profesor pr ON h.id_profesor = pr.id_profesor JOIN colegio.materia m ON h.id_materia = m.id_materia JOIN colegio.curso c ON h.id_curso = c.id_curso WHERE d.nombre IN('Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes') order by curso, periodo, dia";
            DataTable result = ExecuteQuery(selectQuery);

            return result;
        }

        public string insert_bd_horario(string gestion, string id_dia, string id_periodo, string id_materia, string id_profesor, string id_aula, string id_curso)//IEnumerable<object> individuos)
        {
            string tabla = "horario_prueba";// "horario_prueba";//horario

            string insertQuery = $"INSERT INTO {tabla} (gestion, id_dia, id_periodo, id_materia, id_profesor, id_aula, id_curso) VALUES ( {gestion}, {id_dia}, {id_periodo}, {id_materia}, {id_profesor}, {id_aula}, {id_curso})";
            ExecuteNonQuery(insertQuery);
            return insertQuery;
        }

        // Método para obtener el valor de un campo desde el objeto individuo
        private object ObtenerValorDesdeObjeto(object individuo, string nombreCampo)
        {
            // Implementa la lógica para obtener el valor del campo desde el objeto individuo
            // Puedes usar reflexión u otros métodos según la estructura de tu objeto
            // Aquí un ejemplo simplificado
            if (individuo != null)
            {
                var propiedad = individuo.GetType().GetProperty(nombreCampo);
                if (propiedad != null)
                {
                    return propiedad.GetValue(individuo);
                }
            }
            return null;
        }


        public DataTable ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                return dataTable;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                int rowsAffected = 0;
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                return rowsAffected;
            }
        }
    }
}
