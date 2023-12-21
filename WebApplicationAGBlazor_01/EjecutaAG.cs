using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAGBlazor_01
{
    public class EjecutaAG
    {

        private readonly IConfiguration _configuration;

        public EjecutaAG(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool MiFuncionEnBackend()
        {
            string connectionString = _configuration.GetValue<string>("ConnectionStrings:myconn");

            // Lógica que deseas ejecutar en el backend
            // Puede ser cualquier cosa que necesites realizar


            Poblacion poblacion = new Poblacion();
            int poblacionTamano = 100;// 100;

            Obtener_datos_bd obtenerDatosBd = new Obtener_datos_bd(_configuration);
            int numero_de_dias = obtenerDatosBd.consulta_bd(1);
            int numero_de_periodos = obtenerDatosBd.consulta_bd(2);
            int numero_de_cursos = obtenerDatosBd.consulta_bd(3);
            int numero_de_profesores = obtenerDatosBd.consulta_bd(4);
            int numero_de_materias = obtenerDatosBd.consulta_bd(5);
            int numero_de_aulas = obtenerDatosBd.consulta_bd(6);

            //////////////////////////////////////////////////Tablas aqui////////////////////////////////////////////////////////////////////
            DataTable aux_Tabla_dias = obtenerDatosBd.consultaObtieneTabla(1);
            DataTable aux_Tabla_periodos = obtenerDatosBd.consultaObtieneTabla(2);
            DataTable aux_Tabla_cursos = obtenerDatosBd.consultaObtieneTabla(3);
            DataTable aux_Tabla_profesores = obtenerDatosBd.consultaObtieneTabla(4);
            DataTable aux_Tabla_materias = obtenerDatosBd.consultaObtieneTabla(5);
            DataTable aux_Tabla_aulas = obtenerDatosBd.consultaObtieneTabla(6);


            Herramientas h1 = new Herramientas();
            numero_de_cursos = h1.obtenerCantidadDeElementosDeDataTable(aux_Tabla_cursos);  //<---ESTO SOLO ES PARA TENER UN NUMERO MANEJABLE DE CURTOS Y TEST --QUITAR ANTES DE ENTREGAR FINAL!!!!! 
            numero_de_materias = h1.obtenerCantidadDeElementosDeDataTable2(aux_Tabla_materias);//<---ESTO SOLO ES PARA TENER UN NUMERO MANEJABLE DE CURTOS Y TEST --QUITAR ANTES DE ENTREGAR FINAL!!!!! 

            //////////////////////////////////////////////////Tablas aqui/  ///////////////////////////////////////////////////////////////////

            // Simulación de una colección de objetos con los datos de horarios
            List<object> individuos = new List<object>
                {
                    new { id_horario = 1, gestion = 2023, id_dia = 1, id_periodo = 1, id_materia = 1, id_profesor = 1, id_aula = 1, id_curso = 1 },
                    new { id_horario = 2, gestion = 2023, id_dia = 1, id_periodo = 1, id_materia = 2, id_profesor = 2, id_aula = 2, id_curso = 2 },
                    new { id_horario = 3, gestion = 2023, id_dia = 1, id_periodo = 1, id_materia = 3, id_profesor = 3, id_aula = 3, id_curso = 3 },
                    // Agrega más objetos según tus necesidades
                };

            //obtenerDatosBd.insert_bd_horario(individuos);


            poblacion.GeneradorDePoblacion(poblacionTamano, numero_de_dias, numero_de_periodos, numero_de_cursos, numero_de_profesores, numero_de_materias, numero_de_aulas);
            poblacion.CalculaAptitudPoblacion();

            double gradoDeMuatacion = 0.01;// mutationRate = 0.01;
            double crossoverRate = 0.9;
            int elitismoCont = 2;// elitismCount = 2;
            int tamanoDeTorneo = 25;// tournamentSize = 5;
            AlgoritmoGenetico ag = new AlgoritmoGenetico(poblacionTamano, gradoDeMuatacion, crossoverRate, elitismoCont, tamanoDeTorneo);

            // Keep track of current generation
            int generation = 1;
            int cantidad_de_generaciones = 100;
            // Start evolution loop
            // TODO: Add termination condition
            while (generation <= cantidad_de_generaciones)//(ga.isTerminationConditionMet(generation, 1000) == false && ga.isTerminationConditionMet(population) == false)
            {
                // Apply crossover
                poblacion = ag.CrossoverPopulation_1(poblacion, 3);
                //std::cout << "generacion " << std::to_string(generation) << " aptitud poblacion = " << std::to_string(poblacion.getAptitudPoblacion()) << "\n";

                // TODO: Apply mutation                    

                // TODO: Evaluate population
                poblacion.CalculaAptitudPoblacion();

                // Increment the current generation
                generation++;
            }

            poblacion.OrdenarPoblacionDecendente();

            string aux = poblacion.GetPobladorPorCelda(0).PrintIndividuoString();// poblacion.Size() - 1).PrintIndividuoString();

            Individuo respuestaIndividuoFinal = poblacion.GetPobladorPorCelda(0);// poblacion.Size() - 1);

            //realiza la traduccion 
            List<categoria> genomaFin = respuestaIndividuoFinal.getGenomaSFinal();
            List<string> textoTest = new List<string>();
            string text_id_curso = "";
            int añoActual = DateTime.Now.Year;
            foreach (categoria valor in genomaFin)
            {
                string pos = valor.valor;
                int pos_en_lista = int.Parse(pos) - 1;

                string text_id_aula = "";
                string text_id_dia = "";
                string text_id_periodo_Hora = "";
                string text_id_materia = "";
                string text_id_periodo = "";

                if (valor.titulo.Equals("Curso"))
                {
                    text_id_curso = aux_Tabla_cursos.Rows[pos_en_lista].ItemArray[0].ToString();
                    //textoTest.Add(text_id_curso);
                }
                else
                {
                    if (valor.titulo.Equals("Aula"))
                    {
                        text_id_aula = aux_Tabla_aulas.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_aula);
                    }
                    if (valor.titulo.Equals("Dia"))
                    {
                        text_id_dia = aux_Tabla_dias.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_dia);
                    }
                    if (valor.titulo.Equals("Hora"))
                    {
                        text_id_periodo_Hora = aux_Tabla_periodos.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_periodo_Hora);
                    }
                    if (valor.titulo.Equals("Materia"))
                    {
                        text_id_materia = aux_Tabla_materias.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_materia);
                    }
                    if (valor.titulo.Equals("Profesor"))
                    {
                        text_id_periodo = aux_Tabla_profesores.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_periodo);
                    }

                    if (textoTest.Count == 5)
                    {
                        //realiza la incercion
                        obtenerDatosBd.insert_bd_horario(añoActual.ToString(), text_id_curso, textoTest[0], textoTest[1], textoTest[2], textoTest[3], textoTest[4]);
                        textoTest.Clear();
                    }
                }


            }

            return true;
        }
    }
}
