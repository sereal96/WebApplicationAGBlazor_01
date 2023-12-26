using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

    
            Poblacion poblacion = new Poblacion();
            int poblacionTamano = 1000;// 00;// 100;

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
            //////////////////////////////////////////////////Tablas aqui/  ///////////////////////////////////////////////////////////////////


            //obtenerDatosBd.insert_bd_horario(individuos);


            poblacion.GeneradorDePoblacion(poblacionTamano, numero_de_dias, numero_de_periodos, numero_de_cursos, numero_de_profesores, numero_de_materias, numero_de_aulas);
            poblacion.CalculaAptitudPoblacion();

            double gradoDeMuatacion = 0.01;// mutationRate = 0.01;
            double crossoverRate = 0.9;
            int elitismoCont = 2;// elitismCount = 2;
            int tamanoDeTorneo = 10;// tournamentSize = 5;
            AlgoritmoGenetico ag = new AlgoritmoGenetico(poblacionTamano, gradoDeMuatacion, crossoverRate, elitismoCont, tamanoDeTorneo);

            // Keep track of current generation
            int generation = 1;
            int cantidad_de_generaciones = 1000;

            double aptitudAcutal = 0.0;
            double aptitudAnterior = 0.0;
            int contAptiturrepetido = 0;
            // Start evolution loop
            // TODO: Add termination condition
            while (generation <= cantidad_de_generaciones)//(ga.isTerminationConditionMet(generation, 1000) == false && ga.isTerminationConditionMet(population) == false)
            {
                // Apply crossover
                poblacion = ag.CrossoverPopulation_1(poblacion, 3);
                
                // TODO: Evaluate population
                poblacion.CalculaAptitudPoblacion();

                aptitudAcutal = poblacion.GetAptitudPoblacion();
                if (aptitudAcutal > aptitudAnterior)
                {
                    aptitudAnterior = aptitudAcutal;
                    contAptiturrepetido = 0;
                }
                else
                {
                    contAptiturrepetido++;
                }
                if (contAptiturrepetido >= 50)
                {
                    generation = cantidad_de_generaciones + 1;
                }

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

            List<string> listqry = new List<string>();

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
                }
                else
                {
                    if (valor.titulo.Equals("Aula"))//0
                    {
                        text_id_aula = aux_Tabla_aulas.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_aula);
                    }
                    if (valor.titulo.Equals("Dia"))//1
                    {
                        text_id_dia = aux_Tabla_dias.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_dia);
                    }
                    if (valor.titulo.Equals("Hora"))//2
                    {
                        text_id_periodo_Hora = aux_Tabla_periodos.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_periodo_Hora);
                    }
                    if (valor.titulo.Equals("Materia"))//3
                    {
                        text_id_materia = aux_Tabla_materias.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_materia);
                    }
                    if (valor.titulo.Equals("Profesor"))//4
                    {
                        text_id_periodo = aux_Tabla_profesores.Rows[pos_en_lista].ItemArray[0].ToString();
                        textoTest.Add(text_id_periodo);
                    }

                    if (textoTest.Count == 5)
                    {
                        //realiza la incercion
                        //string gestion, string id_dia, string id_periodo, string id_materia, string id_profesor, string id_aula, string id_curso
                        string qry = obtenerDatosBd.insert_bd_horario(añoActual.ToString(),
                            textoTest[1],
                            textoTest[2],
                            textoTest[3],
                            textoTest[4],
                            textoTest[0],
                            text_id_curso);
                        listqry.Add(qry);
                        textoTest.Clear();
                    }
                }
            }
            return true;
        }

        public bool GeneraPDF()
        {
            string connectionString = _configuration.GetValue<string>("ConnectionStrings:myconn");
            Obtener_datos_bd obtenerDatosBd = new Obtener_datos_bd(_configuration);

            DataTable aux_Tabla_dias = obtenerDatosBd.consultaObtieneHorario();

            GeneratePDFFromDataTable(aux_Tabla_dias, "../PDFdocument.pdf");

            return true;
        }

        public void GeneratePDFFromDataTable(DataTable dataTable, string filePath)
        {
            System.IO.FileStream fs = new FileStream(filePath, FileMode.Create);
            
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    document.Add(new Paragraph(item.ToString()));
                }
                document.Add(new Paragraph("")); // Agrega un salto de línea entre filas
            }

            // Filtrar las filas donde 'periodo' es igual a 'P5'

            var filasP2 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P2");
            var filasP3 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P3");
            var filasP4 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P4");
            var filasP5 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P5");
            var filasP6 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P6");
            var filasP7 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P7");

           

            EnumerableRowCollection<DataRow> filasP1 = dataTable.AsEnumerable().Where(row => row.Field<string>("periodo") == "P1");

            EnumerableRowCollection<DataRow> filasC1 = dataTable.AsEnumerable().Where(row => row.Field<string>("curso") == "PRIMERO DE PRIMARIA RED");


            // Obtener todos los elementos únicos de la columna 'periodo'
            var cursoUnicos = dataTable.AsEnumerable().Select(row => row.Field<string>("curso")).Distinct();

            string connectionString = _configuration.GetValue<string>("ConnectionStrings:myconn");
            Obtener_datos_bd obtenerDatosBd = new Obtener_datos_bd(_configuration);



            DataTable periodo = obtenerDatosBd.consultaObtieneTabla(2);
            List<string> listPeriodos = new List<string>();
            foreach (DataRow row in periodo.Rows)
            {
                string dia = row["nombre"].ToString();
                string mes = row["hora_inicio"].ToString();
                string anio = row["hora_fin"].ToString();
                listPeriodos.Add(dia);
            }

            foreach (var curso in cursoUnicos)
            {
                //var sss = curso;
                PdfPTable table1 = new PdfPTable(6);
                PdfPCell cell1 = new PdfPCell(new Phrase(curso.ToString()));
                cell1.Colspan = 6;
                cell1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table1.AddCell(cell1);
                table1.AddCell("--------");
                table1.AddCell("Lunes");
                table1.AddCell("Martes");
                table1.AddCell("Miercoles");
                table1.AddCell("Jueves");
                table1.AddCell("Viernes");
                ////EnumerableRowCollection<DataRow> filasPC1 = dataTable.AsEnumerable()
                ////    .Where(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == "P1")
                ////    .OrderBy(row => row.Field<string>("periodo"));
                foreach (string dia in listPeriodos)
                {
                    string perido = dia; // "P1";
                    bool p1LunesNoVacia = dataTable.AsEnumerable()
                        .Any(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Lunes");
                    if (p1LunesNoVacia)
                    {                        
                        EnumerableRowCollection<DataRow> p1Lunes = dataTable.AsEnumerable()
                            .Where(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Lunes");
                        foreach (var fila in p1Lunes)
                        {
                            table1.AddCell(perido +" \n " + fila["hora_inicio"].ToString() + " - " + fila["hora_fin"].ToString());
                            table1.AddCell(fila["aula"].ToString() + "\n " + fila["materia"].ToString() + " \n " + fila["profesor"].ToString());
                            break;
                        }
                    }
                    else
                    {                        
                        table1.AddCell(perido + " \n 00:00 - 00:00");
                        table1.AddCell("------------");
                    }
                    bool p1MartesNoVacia = dataTable.AsEnumerable()
                        .Any(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Martes");
                    if (p1MartesNoVacia)
                    {
                        EnumerableRowCollection<DataRow> p1Martes = dataTable.AsEnumerable()
                            .Where(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Martes");
                        foreach (var fila in p1Martes)
                        {
                            table1.AddCell(fila["aula"].ToString() + "\n " + fila["materia"].ToString() + " \n " + fila["profesor"].ToString());
                            break;
                        }
                    }
                    else { table1.AddCell("------------"); }
                    bool p1MiercolesNoVacia = dataTable.AsEnumerable()
                        .Any(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Miércoles");
                    if (p1MiercolesNoVacia)
                    {
                        EnumerableRowCollection<DataRow> p1Miercoles = dataTable.AsEnumerable()
                            .Where(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Miércoles");
                        foreach (var fila in p1Miercoles)
                        {
                            table1.AddCell(fila["aula"].ToString() + "\n " + fila["materia"].ToString() + " \n " + fila["profesor"].ToString());
                            break;
                        }
                    }
                    else { table1.AddCell("------------"); }
                    bool p1JuevesNoVacia = dataTable.AsEnumerable()
                        .Any(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Jueves");
                    if (p1JuevesNoVacia)
                    {
                        EnumerableRowCollection<DataRow> p1Jueves = dataTable.AsEnumerable()
                            .Where(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Jueves");
                        foreach (var fila in p1Jueves)
                        {
                            table1.AddCell(fila["aula"].ToString() + "\n " + fila["materia"].ToString() + " \n " + fila["profesor"].ToString());
                            break;
                        }
                    }
                    else { table1.AddCell("------------"); }
                    bool p1ViernesNoVacia = dataTable.AsEnumerable()
                        .Any(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Viernes");
                    if (p1ViernesNoVacia)
                    {
                        EnumerableRowCollection<DataRow> p1Viernes = dataTable.AsEnumerable()
                            .Where(row => row.Field<string>("curso") == curso.ToString() && row.Field<string>("periodo") == perido && row.Field<string>("dia") == "Viernes");
                        foreach (var fila in p1Viernes)
                        {
                            table1.AddCell(fila["aula"].ToString() + "\n " + fila["materia"].ToString() + " \n " + fila["profesor"].ToString());
                            break;
                        }
                    }
                    else { table1.AddCell("------------"); }
                }               
                document.Add(table1);
            }           

            document.AddAuthor("UNIR");
            document.AddCreator("UNIR");
            document.AddKeywords("PDF UNIR");
            document.AddSubject("UNIR");
            document.AddTitle("A.G. UNIR");

            document.Close();
            fs.Close();
        }
    }
}
