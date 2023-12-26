using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplicationAGBlazor_01
{
    public class Individuo
    {
        public List<int> cromosoma_Curso { get; set; } = new List<int>();
        public List<int> cromosoma_Profesor { get; set; } = new List<int>();
        public List<int> cromosoma_Materia { get; set; } = new List<int>();
        public List<int> cromosoma_Dia { get; set; } = new List<int>();
        public List<int> cromosoma_Hora { get; set; } = new List<int>();
        public List<int> cromosoma_Aula { get; set; } = new List<int>();

        public List<categoria> GenomaS { get; set; } = new List<categoria>();

        //public double Aptitud { get; set; }
        public double AptitudCurso { get; set; }
        public double AptitudProfesor { get; set; }
        public double AptitudMateria { get; set; }
        public double AptitudDia { get; set; }
        public double AptitudHora { get; set; }
        public double AptitudAula { get; set; }

        public int NumeroDeDias { get; set; }
        public int NumeroDePeriodos { get; set; }
        public int NumeroDeCursos { get; set; }
        public int NumeroDeProfesores { get; set; }
        public int NumeroDeMaterias { get; set; }
        public int NumeroDeAulas { get; set; }


        public double aptitud_curso = -1;
        public double aptitud_profesor = -1;
        public double aptitud_materia = -1;
        public double aptitud_dia = -1;
        public double aptitud_hora = -1;
        public double aptitud_aula = -1;

        private Herramientas h1 = new Herramientas();
        private List<categoria> genomaS = new List<categoria>();


        public List<string> Esqueleto { get; set; }
        public List<string> Generado { get; set; }

        public List<AuxProfesorPeriodo> listade_Profesor_Periodo { get; set; } = new List<AuxProfesorPeriodo>();
        public List<AuxProfesorMateria> listade_Profesor_Materia { get; set; } = new List<AuxProfesorMateria>();

        public List<int> Cromosoma { get; set; }
        public double aptitud { get; set; } = -1;

        public Individuo()
        {
            // Constructor
        }

        ~Individuo()
        {
            // Destructor
        }

        public void CalcularAptitud(int numeroDeDias, int numeroDePeriodos, int numeroDeCursos, int numeroDeProfesores,
            int numeroDeMaterias, int numeroDeAulas)
        {
            SetAptitudCurso(1.0); //Siempre será uno por ser un parámetro controlado por la institución

            int fitnes_ideal_curso_x_dia_x_periodo = numero_de_cursos * numero_de_dias * numero_de_periodos; // 2x5x7 = 70


        }

        public void SetAptitud(double aptitud_)
        {
            aptitud = aptitud_;
        }

        public List<int> getCromosomaCurso()
        {
            return cromosoma_Curso;
        }

        public List<int> getCromosomaAula()
        {
            return cromosoma_Aula;
        }

        public List<int> getCromosomaDia()
        {
            return cromosoma_Dia;
        }

        public List<int> getCromosomaHora()
        {
            return cromosoma_Hora;
        }

        public List<int> getCromosomaMateria()
        {
            return cromosoma_Materia;
        }

        public List<int> getCromosomaProfesor()
        {
            return cromosoma_Profesor;
        }

        public List<categoria> getGenomaSFinal()
        {
            return genomaS;
        }

        public void IniTablaProfesorMateria(int numero_de_profesores, int numero_de_materias)
        {
            // Esto es auxiliar es una lista de id de la tabla profesor materia
            List<AuxProfesorMateria> lista_de_Profesor_Materia = new List<AuxProfesorMateria>();
            int cont = 0;
            for (int i = 0; i < numero_de_profesores; i++)
            {
                for (int j = 0; j < numero_de_materias; j++)
                {
                    AuxProfesorMateria aux1 = new AuxProfesorMateria
                    {
                        idMateria = (j + 1).ToString(),
                        idProfesor = (i + 1).ToString()
                    };
                    lista_de_Profesor_Materia.Add(aux1);
                    cont++;
                }
            }
        }

        public void CrearCromosomaCurso(int cromosomaCurso, int limiteSuperiorCurso)
        {
            if (cromosomaCurso <= limiteSuperiorCurso)
            {
                cromosoma_Curso = h1.ConvierteEnteroBinario8Bits(cromosomaCurso);
            }
            else
            {
                Console.WriteLine("Error, supera el límite");
            }
        }

        public void CrearCromosomaProfesor(int cromosomaProfesor, int limiteSuperiorProfesor)
        {
            if (cromosomaProfesor <= limiteSuperiorProfesor)
            {
                cromosoma_Profesor = h1.ConvierteEnteroBinario8Bits(cromosomaProfesor);
            }
            else
            {
                Console.WriteLine("Error, supera el límite");
            }
        }

        public void CrearCromosomaMateria(int cromosomaMateria, int limiteSuperiorMateria)
        {
            if (cromosomaMateria <= limiteSuperiorMateria)
            {
                cromosoma_Materia = h1.ConvierteEnteroBinario8Bits(cromosomaMateria);
            }
            else
            {
                Console.WriteLine("Error, supera el límite");
            }
        }

        public void CrearCromosomaDia(int cromosomaDia, int limiteSuperiorDia)
        {
            if (cromosomaDia <= limiteSuperiorDia)
            {
                cromosoma_Dia = h1.ConvierteEnteroBinario8Bits(cromosomaDia);
            }
            else
            {
                Console.WriteLine("Error, supera el límite");
            }
        }

        public void CrearCromosomaHora(int cromosomaHora, int limiteSuperiorHora)
        {
            if (cromosomaHora <= limiteSuperiorHora)
            {
                cromosoma_Hora = h1.ConvierteEnteroBinario8Bits(cromosomaHora);
            }
            else
            {
                Console.WriteLine("Error, supera el límite");
            }
        }

        public void CrearCromosomaAula(int cromosomaAula, int limiteSuperiorAula)
        {
            if (cromosomaAula <= limiteSuperiorAula)
            {
                cromosoma_Aula = h1.ConvierteEnteroBinario8Bits(cromosomaAula);
            }
            else
            {
                Console.WriteLine("Error, supera el límite");
            }
        }

        public categoria MutarGen(int pos)
        {
            DateTime tiempoActual = DateTime.Now;
            int semilla = tiempoActual.Second + tiempoActual.Minute * 60 + tiempoActual.Hour * 3600 +
                tiempoActual.Day * 86400 + (tiempoActual.Month + 1) * 2592000 + tiempoActual.Year * 31104000;

            Random rand = new Random(semilla);

            categoria ca = genomaS[pos];
            int numeroComoEntero = int.Parse(ca.valor);

            int newNumero = rand.Next(1, numeroComoEntero + 1);

            ca.codigoGenetico = h1.ConvierteEnteroBinario8Bits(newNumero);
            ca.valor = newNumero.ToString();

            return ca;
        }

        public int SizeGenomaS()
        {
            return genomaS.Count;
        }

        int numero_de_dias;
        int numero_de_periodos;
        int numero_de_cursos;
        int numero_de_profesores;
        int numero_de_materias;
        int numero_de_aulas;

        public List<int> posicion_del_curso_en_vector { get; set; } = new List<int>();// { get; set; }
        public List<int> posicion_del_dia_en_vector { get; set; } = new List<int>();
        public List<int> posicion_del_hora_en_vector { get; set; } = new List<int>();
        public List<int> posicion_del_aula_en_vector { get; set; } = new List<int>();

        public void CrearGenomaS(int numero_de_dias_, int numero_de_periodos_, int numero_de_cursos_, int numero_de_profesores_,
     int numero_de_materias_, int numero_de_aulas_)
        {
            SetTodosLosProfesoryPeriodo(numero_de_profesores_, numero_de_dias_, numero_de_periodos_);

            numero_de_dias = numero_de_dias_;
            numero_de_periodos = numero_de_periodos_;
            numero_de_cursos = numero_de_cursos_;
            numero_de_profesores = numero_de_profesores_;
            numero_de_materias = numero_de_materias_;
            numero_de_aulas = numero_de_aulas_;

            // Genera una semillar basada en fecha,hora,minuto y segundo
            DateTime tiempoActual = DateTime.Now;
            int semilla = tiempoActual.Second + tiempoActual.Minute * 60 + tiempoActual.Hour * 3600 +
                tiempoActual.Day * 86400 + (tiempoActual.Month + 1) * 2592000 + tiempoActual.Year * 31104000;
            Thread.Sleep(100);
            Random rand = new Random(semilla);

            int cantidad_cromosomas = numero_de_dias * numero_de_periodos;

            int posv = 0;
            bool saludAula = false;
            bool saludProfesor = false;
            bool saludAulaProfesor = false;
            bool saludDiaPeriodoAula = false;

            bool saludProfesorPeriodo = false;
            bool saludProfesorMateria = false;

            int ContLimite = 0;
            List<int> dia_x_periodo = new List<int>();
            int resCorrect = 0;

            while (resCorrect < 3 & !saludDiaPeriodoAula)//!saludAula & !saludProfesor & !saludAulaProfesor & !saludDiaPeriodoAula & !saludProfesorPeriodo)//!saludAula && 
            {
                // Obtener la fecha y hora actuales
                tiempoActual = DateTime.Now;
                // Crear una semilla basada en el tiempo actual
                semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                              tiempoActual.Hour * 10000 + tiempoActual.Second;
                

                rand = new Random(semilla);


                posv = 0;
                genomaS.Clear();
                posicion_del_curso_en_vector.Clear();
                posicion_del_dia_en_vector.Clear();
                posicion_del_hora_en_vector.Clear();
                posicion_del_aula_en_vector.Clear();
                dia_x_periodo.Clear();
                for (int nc = 0; nc < numero_de_cursos; nc++)
                {
                    int datosCurso = nc + 1;// rand() % numero_de_cursos + 1;
                    int limitiCurso = numero_de_cursos; // rand() % 20 + 1;
                    CrearCromosomaCurso(datosCurso, limitiCurso);
                    List<int> cromoCursoAux = getCromosomaCurso();

                    categoria c1;
                    c1.titulo = "Curso"; //Concepto de curso 4,5,6 secundaria-- 
                    c1.codigoGenetico = cromoCursoAux;
                    c1.valor = datosCurso.ToString(); //Nota es el valor que se usa en crearCromosoalXXX( 'valor' , Limte)
                    SetCromosomaEnGenomaS(c1);

                    SetPosicionDelCursoEnVector(posv);

                    for (int i = 0; i < cantidad_cromosomas; i++)
                    {
                        //lugar fisico donde se pasan clases
                        int datosAula = rand.Next() % numero_de_aulas + 1;
                        int limitiAulas = numero_de_aulas; // rand() % 20 + 1;
                        CrearCromosomaAula(datosAula, limitiAulas);
                        List<int> cromoAulaAux = getCromosomaAula();
                        categoria c2;
                        c2.titulo = "Aula";
                        c2.codigoGenetico = cromoAulaAux;
                        c2.valor = datosAula.ToString(); //Nota es el valor que se usa en crearCromosoalXXX( 'valor' , Limte)
                        SetCromosomaEnGenomaS(c2);
                        posv++;
                        SetPosicionDelAulaEnVector(posv);

                        int datosDias = rand.Next() % numero_de_dias + 1;
                        int limitiDias = numero_de_dias; // rand() % 20 + 1;
                        CrearCromosomaDia(datosDias, limitiDias);
                        List<int> cromoDiaAux = getCromosomaDia();
                        categoria c3;
                        c3.titulo = "Dia";
                        c3.codigoGenetico = cromoDiaAux;
                        c3.valor = datosDias.ToString(); //Nota es el valor que se usa en crearCromosoalXXX( 'valor' , Limte)
                        SetCromosomaEnGenomaS(c3);
                        posv++;
                        SetPosicionDelDiaEnVector(posv);

                        int datosPeriodos = rand.Next() % numero_de_periodos + 1;
                        int limitiPeriodos = numero_de_periodos; // rand() % 20 + 1;
                        CrearCromosomaHora(datosPeriodos, limitiPeriodos);
                        List<int> cromoHoraAux = getCromosomaHora();
                        categoria c4;
                        c4.titulo = "Hora";
                        c4.codigoGenetico = cromoHoraAux;
                        c4.valor = datosPeriodos.ToString(); //Nota es el valor que se usa en crearCromosoalXXX( 'valor' , Limte)
                        SetCromosomaEnGenomaS(c4);
                        posv++;
                        SetPosicionDeHoraEnVector(posv);

                        string fecha = c2.valor + c3.valor + c4.valor;
                        int fecha_aux = int.Parse(fecha);// std::stoi(fecha);
                        dia_x_periodo.Add(fecha_aux);

                        //cantidad de materias que puede dar el colegio   MAT-1 MAT-2 ...
                        int datosMaterias = rand.Next() % numero_de_materias + 1;
                        int limitiMaterias = numero_de_materias; // rand() % 20 + 1;
                        CrearCromosomaMateria(datosMaterias, limitiMaterias);
                        List<int> cromoMateriaAux = getCromosomaMateria();
                        categoria c5;
                        c5.titulo = "Materia";
                        c5.codigoGenetico = cromoMateriaAux;
                        c5.valor = datosMaterias.ToString(); //Nota es el valor que se usa en crearCromosoalXXX( 'valor' , Limte)
                        SetCromosomaEnGenomaS(c5);
                        posv++;
                        int datosProfesores = rand.Next() % numero_de_profesores + 1;

                        //////////////////////////////////////////////////////////


                        //Poner un control de un profesor 

                        //////////////////////////////////////////////////////////

                        int limitiProfesores = numero_de_profesores; // rand() % 20 + 1;
                        CrearCromosomaProfesor(datosProfesores, limitiProfesores);
                        List<int> cromoProfesorAux = getCromosomaProfesor();
                        categoria c6;
                        c6.titulo = "Profesor";
                        c6.codigoGenetico = cromoProfesorAux;
                        c6.valor = datosProfesores.ToString(); //Nota es el valor que se usa en crearCromosoalXXX( 'valor' , Limte)
                        SetCromosomaEnGenomaS(c6);
                        posv++;
                    }
                    posv++;
                }

                var duplicate = dia_x_periodo.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).FirstOrDefault();
                if (duplicate != 0)
                {
                    saludDiaPeriodoAula = false;
                }
                else
                {
                    saludDiaPeriodoAula = true;
                }


                //calcularAptitud(numero_de_dias, numero_de_periodos, numero_de_cursos, numero_de_profesores, numero_de_materias, numero_de_aulas);
                saludAula = SaludCromosomasAula();
                saludProfesor = SaludCromosomasProfesor();
                saludAulaProfesor = SaludCromosomasAulaDiaHoraProfesor();
                //saludProfesorPeriodo = SaludCromosomasProfesorPeriodo();  //<-----------------TO DO
                //saludProfesorMateria = SaludCromosomasProfesorMateria();  //<-----------------TO DO
                // salud de proferos Materia()
                // salud de curso Materia()

                resCorrect = 0;
                if (saludAula)
                {
                    resCorrect++;
                }
                if (saludProfesor)
                {
                    resCorrect++;
                }
                if (saludAulaProfesor)
                {
                    resCorrect++;
                }
                //////if (saludProfesorPeriodo)//hoy
                //////{
                //////    resCorrect++;
                //////}
                //////if (saludDiaPeriodoAula)
                //////{
                //////    resCorrect++;
                //////}

                ////if (saludAula)// == 1)
                ////{
                ////    int sss = 0;
                ////}

                ////if (saludProfesor)// == 2)
                ////{
                ////    int sss = 0;
                ////}

                ////if (saludAulaProfesor)// == 3)
                ////{
                ////    int sss = 0;
                ////}

                ////if (saludProfesorPeriodo)// == 4)
                ////{
                ////    int sss = 0;
                ////}

                ContLimite++;
                //std::cout << ContLimite;
                if (ContLimite >= 2500)
                {
                    break;
                }
            }
            //int borrar = 0;
        }

        public void SetGenomaS(int pos, categoria valor)
        {
            genomaS[pos] = valor;
        }

        public void SetGenomaS(List<categoria> genomaS_)
        {
            genomaS = genomaS_;
        }

        public void SetCromosomaEnGenomaS(categoria cromosomaS_)
        {
            genomaS.Add(cromosomaS_);
        }

        public categoria GetCromosomaEnGenomaS(int posicionS_)
        {
            if (posicionS_ >= 0 && posicionS_ < genomaS.Count)
            {
                return genomaS[posicionS_];
            }
            return new categoria();
        }

        public void SetPosicionDelCursoEnVector(int valor_)
        {
            this.posicion_del_curso_en_vector.Add(valor_);
        }

        public List<int> GetPosicionDelCursoEnVector()
        {
            return posicion_del_curso_en_vector;
        }

        public void SetPosicionDelDiaEnVector(int valor_)
        {
            posicion_del_dia_en_vector.Add(valor_);
        }

        public List<int> GetPosicionDelDiaEnVector()
        {
            return posicion_del_dia_en_vector;
        }

        public void SetPosicionDeHoraEnVector(int valor_)
        {
            posicion_del_hora_en_vector.Add(valor_);
        }

        public List<int> GetPosicionDeHoraEnVector()
        {
            return posicion_del_hora_en_vector;
        }

        public void SetPosicionDelAulaEnVector(int valor_)
        {
            posicion_del_aula_en_vector.Add(valor_);
        }

        public List<int> GetPosicionDelAulaEnVector()
        {
            return posicion_del_aula_en_vector;
        }

        public int CantidadDeCursos()
        {
            List<int> posAux = GetPosicionDelCursoEnVector();
            int sum = 0;
            int num = 0;
            foreach (int i in posAux)
            {
                categoria cateAux = GetGenomaS(i);
                num = int.Parse(cateAux.valor);
                sum += num;
            }
            return sum;
        }

        public int CantidadDeCursosEntero()
        {
            List<int> posAux = GetPosicionDelCursoEnVector();
            int sum = 0;
            int num = 0;
            foreach (int i in posAux)
            {
                categoria cateAux = GetGenomaS(i);
                num = int.Parse(cateAux.valor);
                sum += num;
            }
            return sum;
        }

        public void SetAptitudCurso(double aptitud_curso_)
        {
            aptitud_curso = aptitud_curso_;
        }

        public double GetAptitudCurso()
        {
            return aptitud_curso;
        }

        public void SetAptitudDia(double aptitud_dia_)
        {
            aptitud_dia = aptitud_dia_;
        }

        public double GetAptitudDia()
        {
            return aptitud_dia;
        }

        public void SetAptitudHora(double aptitud_hora_)
        {
            aptitud_hora = aptitud_hora_;
        }

        public double GetAptitudHora()
        {
            return aptitud_hora;
        }

        public int CantidadDiaHoraAulaRepetidos(categoria objetivo_)
        {
            int count = genomaS.Count(c => c.codigoGenetico == objetivo_.codigoGenetico && c.titulo == objetivo_.titulo && c.valor == objetivo_.valor);
            return count;
        }

        private categoria GetGenomaS(int index)
        {
            if (index >= 0 && index < genomaS.Count)
            {
                return genomaS[index];
            }
            return new categoria();
        }

        public categoria getGenomaS(int pos)
        {
            return genomaS[pos];
        }

        public void SetTodosLosProfesoryPeriodo(int numero_de_profesores_, int numero_de_dias_, int numero_de_periodos_)
        {
            // Obtener la fecha y hora actuales
            DateTime tiempoActual = DateTime.Now;
            // Crear una semilla basada en el tiempo actual
            int semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                          tiempoActual.Hour * 10000 + tiempoActual.Second;
            Random rnd = new Random(semilla);

            int numero_periodos = numero_de_dias_ * numero_de_periodos_;

            //Random rnd = new Random();
            for (int i = 0; i < numero_de_profesores_; i++)
            {
                int aux = rnd.Next(1, numero_de_periodos_ + 1);
                int ini_hora = 1;
                int fin_hora = 0;

                //while (ini_hora >= fin_hora)
                //{
                //    ini_hora = rnd.Next(1, numero_de_periodos_ + 1);
                //    fin_hora = rnd.Next(1, numero_de_periodos_ + 1);
                //}

                ini_hora = 1;
                fin_hora = numero_de_periodos_;

                AuxProfesorPeriodo profesorPeriodo = new AuxProfesorPeriodo
                {
                    id_profesor = (i + 1).ToString(),
                    ini_hora = ini_hora.ToString(),
                    fin_hora = fin_hora.ToString(),
                    id_periodo = "0"
                };

                listade_Profesor_Periodo.Add(profesorPeriodo);
            }
        }

        public bool SaludCromosomasAula()
        {
            List<AuxAulaDiaHora> vector_AuxAulaDiaHora = new List<AuxAulaDiaHora>();

            for (int i = 0; i < posicion_del_aula_en_vector.Count - 2; i++)
            {
                if (genomaS[i].titulo == "Aula" && genomaS[i + 1].titulo == "Dia" && genomaS[i + 2].titulo == "Hora")
                {
                    AuxAulaDiaHora aux = new AuxAulaDiaHora
                    {
                        aula = genomaS[i].valor,
                        dia = genomaS[i + 1].valor,
                        hora = genomaS[i + 2].valor
                    };

                    vector_AuxAulaDiaHora.Add(aux);
                }
            }

            List<AuxAulaDiaHora> repeatedElements = new List<AuxAulaDiaHora>();

            for (int i = 0; i < vector_AuxAulaDiaHora.Count; i++)
            {
                for (int j = i + 1; j < vector_AuxAulaDiaHora.Count; j++)
                {
                    if (vector_AuxAulaDiaHora[i].Equals(vector_AuxAulaDiaHora[j]))
                    {
                        repeatedElements.Add(vector_AuxAulaDiaHora[i]);
                        break; // No es necesario seguir buscando más duplicados de este elemento.
                    }
                }
            }

            if (repeatedElements.Any())
            {
                //Console.WriteLine(" Se encontraron Aulas en la misma hora, dia y curso repetidos:");
                //foreach (var element in repeatedElements)
                //{
                //    Console.WriteLine("a: " + element.Aula + ", b: " + element.Dia + ", c: " + element.Hora);
                //}
                return false;
            }
            else
            {
                //Console.WriteLine("No tiene elementos repetidos (hora, dia y curso).");
            }

            return true;
        }

        public bool SaludCromosomasProfesor()
        {
            List<AuxAulaHoraProfesor> vector_AuxAulaHoraProfesor = new List<AuxAulaHoraProfesor>();

            for (int i = 0; i < posicion_del_aula_en_vector.Count - 4; i++)
            {
                if (genomaS[i].titulo == "Aula" && genomaS[i + 1].titulo == "Dia" &&
                    genomaS[i + 2].titulo == "Hora" && genomaS[i + 4].titulo == "Profesor")
                {
                    AuxAulaHoraProfesor aux = new AuxAulaHoraProfesor
                    {
                        dia = genomaS[i + 1].valor,
                        hora = genomaS[i + 2].valor,
                        profesor = genomaS[i + 4].valor
                    };

                    vector_AuxAulaHoraProfesor.Add(aux);
                }
            }

            List<AuxAulaHoraProfesor> repeatedElements = new List<AuxAulaHoraProfesor>();

            for (int i = 0; i < vector_AuxAulaHoraProfesor.Count; i++)
            {
                for (int j = i + 1; j < vector_AuxAulaHoraProfesor.Count; j++)
                {
                    if (vector_AuxAulaHoraProfesor[i].Equals(vector_AuxAulaHoraProfesor[j]))
                    {
                        repeatedElements.Add(vector_AuxAulaHoraProfesor[i]);
                        break; // No es necesario seguir buscando más duplicados de este elemento.
                    }
                }
            }

            if (repeatedElements.Any())
            {
                //Console.WriteLine(" Se encontraron Aulas en la misma hora, dia y Profesor repetidos:");
                //foreach (var element in repeatedElements)
                //{
                //    Console.WriteLine("a: " + element.Aula + ", b: " + element.Dia + ", c: " + element.Hora);
                //}
                return false;
            }
            else
            {
                //Console.WriteLine("No tiene elementos repetidos (hora, dia y Profesor).");
            }

            return true;
        }

        public bool SaludCromosomasAulaDiaHoraProfesor()
        {
            List<AuxAulaDiaHoraProfesor> vector_AulaDiaHoraProfesor = new List<AuxAulaDiaHoraProfesor>();

            for (int i = 0; i < posicion_del_aula_en_vector.Count - 4; i++)
            {
                if (genomaS[i].titulo == "Aula" && genomaS[i + 1].titulo == "Dia" &&
                    genomaS[i + 2].titulo == "Hora" && genomaS[i + 4].titulo == "Profesor")
                {
                    AuxAulaDiaHoraProfesor aux = new AuxAulaDiaHoraProfesor
                    {
                        aula = genomaS[i + 0].valor,
                        dia = genomaS[i + 1].valor,
                        hora = genomaS[i + 2].valor,
                        profesor = genomaS[i + 4].valor
                    };

                    vector_AulaDiaHoraProfesor.Add(aux);
                }
            }

            List<AuxAulaDiaHoraProfesor> repeatedElements = new List<AuxAulaDiaHoraProfesor>();

            for (int i = 0; i < vector_AulaDiaHoraProfesor.Count; i++)
            {
                for (int j = i + 1; j < vector_AulaDiaHoraProfesor.Count; j++)
                {
                    if (vector_AulaDiaHoraProfesor[i].Equals(vector_AulaDiaHoraProfesor[j]))
                    {
                        repeatedElements.Add(vector_AulaDiaHoraProfesor[i]);
                        break; // No es necesario seguir buscando más duplicados de este elemento.
                    }
                }
            }

            if (repeatedElements.Any())
            {
                //Console.WriteLine(" Se encontraron Aulas en la misma hora, dia, aula y Profesor repetidos:");
                //foreach (var element in repeatedElements)
                //{
                //    Console.WriteLine("a: " + element.Aula + ", b: " + element.Dia + ", c: " + element.Hora);
                //}
                return false;
            }
            else
            {
                //Console.WriteLine("No tiene elementos repetidos (hora, dia, aula y Profesor).");
            }

            return true;
        }

        public bool SaludCromosomasProfesorPeriodo()
        {
            List<AuxAulaDiaHoraProfesor> vector_AulaDiaHoraProfesor = new List<AuxAulaDiaHoraProfesor>();

            int profesor_fuera_horario = 0;

            for (int i = 0; i < posicion_del_aula_en_vector.Count - 4; i++)
            {
                if (genomaS[i].titulo == "Aula" && genomaS[i + 1].titulo == "Dia" &&
                    genomaS[i + 2].titulo == "Hora" && genomaS[i + 4].titulo == "Profesor")
                {
                    AuxAulaDiaHoraProfesor aux = new AuxAulaDiaHoraProfesor
                    {
                        aula = genomaS[i + 0].valor,
                        dia = genomaS[i + 1].valor,
                        hora = genomaS[i + 2].valor,
                        profesor = genomaS[i + 4].valor
                    };

                    vector_AulaDiaHoraProfesor.Add(aux);

                    string id_buscado = genomaS[i + 4].valor;
                    AuxProfesorPeriodo encontrado = new AuxProfesorPeriodo();
                    // Buscar el elemento con id_profesor = "125"
                    foreach (var elemento in listade_Profesor_Periodo)
                    {
                        if (elemento.id_profesor == id_buscado)
                        {
                            encontrado = elemento;
                            break; // Salir del bucle si se encuentra el elemento
                        }
                    }
                    if ((int.Parse(encontrado.ini_hora) <= int.Parse(aux.hora)) &&
                        (int.Parse(aux.hora) <= int.Parse(encontrado.fin_hora)))
                    {
                        profesor_fuera_horario++;
                    }
                }
            }

            if (profesor_fuera_horario > 0)
            {
                //Console.WriteLine(" Se encontro un choque fuera de horario de un profesor");
                return false;
            }
            else
            {
                //Console.WriteLine(" No hay fuera de horario");
                return true;
            }
        }

        public void PrintIndividuo()
        {
            Console.WriteLine("\n\n");

            // Código para llenar la lista 'cursos'

            List<List<List<categoria>>> cursos = new List<List<List<categoria>>>();

            for (int nc = 0; nc < numero_de_cursos; nc++)
            {
                List<List<categoria>> semanas = new List<List<categoria>>();
                for (int np = 0; np < numero_de_periodos; np++)
                {
                    List<categoria> num_horas = new List<categoria>();
                    for (int nd = 0; nd < numero_de_dias; nd++)
                    {
                        categoria ct = new categoria
                        {
                            titulo = "dia = " + nd + " - periodo = " + np,
                            valor = "dia = " + nd + " - periodo = " + np
                        };
                        num_horas.Add(ct);
                    }
                    semanas.Add(num_horas);
                }
                cursos.Add(semanas);
            }

            List<List<List<categoria>>> cursosAux = new List<List<List<categoria>>>(cursos);

            int curso_aux = 0;
            foreach (int pos_Curso in posicion_del_curso_en_vector)
            {
                Console.WriteLine("pos_Curso = " + pos_Curso);

                //for (int i = 0; i < posicion_del_curso_en_vector[1] - 1; i = i + 5)
                for (int i = 0; i < posicion_del_curso_en_vector[0] - 1; i = i + 5)
                {
                    categoria c0 = genomaS[pos_Curso + i + 1]; //Aula
                    categoria c1 = genomaS[pos_Curso + i + 2]; //Dia
                    categoria c2 = genomaS[pos_Curso + i + 3]; //Hora
                    categoria c3 = genomaS[pos_Curso + i + 4]; //Materia
                    categoria c4 = genomaS[pos_Curso + i + 5]; //Profesor

                    Console.WriteLine(i + "---" + c0.titulo + c0.valor + "  " + c1.titulo + c1.valor + "  " + c2.titulo + c2.valor + "  " + c3.titulo + c3.valor + "  " + c4.titulo + c4.valor);

                    string aux01 = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                    categoria auxC = new categoria();
                    auxC.titulo = aux01;
                    cursos[curso_aux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1] = auxC;

                    // Actualizar el título en 'cursos'
                    //cursos[curso_aux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1].titulo = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;

                    // Código para llenar la lista 'esqueleto'
                    // Añadir los elementos al listado 'esqueleto'
                    // ...

                }
                curso_aux++;
                Console.WriteLine("\n\n\n");
            }

            int contT = 1;
            for (int nc = 0; nc < numero_de_cursos; nc++)
            {
                Console.WriteLine("\n\n----------CURSO  " + nc + "---------");
                for (int np = 0; np < numero_de_periodos; np++)
                {
                    string aux_linea_semana = "";
                    string aux_punteada = "";
                    for (int nd = 0; nd < numero_de_dias; nd++)
                    {
                        aux_linea_semana += cursos[nc][np][nd].titulo + "  ||  ";
                        aux_punteada += "----------------------------";
                    }
                    Console.WriteLine(aux_punteada);
                    Console.WriteLine(aux_linea_semana);
                }
            }
        }

        public string PrintIndividuoString()
        {
            string salida = "";
            Console.WriteLine("\n\n");

            // Código para llenar la lista 'cursos'

            List<List<List<categoria>>> cursos = new List<List<List<categoria>>>();

            for (int nc = 0; nc < numero_de_cursos; nc++)
            {
                List<List<categoria>> semanas = new List<List<categoria>>();
                for (int np = 0; np < numero_de_periodos; np++)
                {
                    List<categoria> num_horas = new List<categoria>();
                    for (int nd = 0; nd < numero_de_dias; nd++)
                    {
                        categoria ct = new categoria
                        {
                            titulo = "dia = " + nd + " - periodo = " + np,
                            valor = "dia = " + nd + " - periodo = " + np
                        };
                        num_horas.Add(ct);
                    }
                    semanas.Add(num_horas);
                }
                cursos.Add(semanas);
            }

            List<List<List<categoria>>> cursosAux = new List<List<List<categoria>>>(cursos);

            int curso_aux = 0;
            foreach (int pos_Curso in posicion_del_curso_en_vector)
            {
                Console.WriteLine("pos_Curso = " + pos_Curso);

                //for (int i = 0; i < posicion_del_curso_en_vector[1] - 1; i = i + 5)
                for (int i = 0; i < posicion_del_curso_en_vector[0] - 1; i = i + 5)
                {
                    categoria c0 = genomaS[pos_Curso + i + 1]; //Aula
                    categoria c1 = genomaS[pos_Curso + i + 2]; //Dia
                    categoria c2 = genomaS[pos_Curso + i + 3]; //Hora
                    categoria c3 = genomaS[pos_Curso + i + 4]; //Materia
                    categoria c4 = genomaS[pos_Curso + i + 5]; //Profesor

                    Console.WriteLine(i + "---" + c0.titulo + c0.valor + "  " + c1.titulo + c1.valor + "  " + c2.titulo + c2.valor + "  " + c3.titulo + c3.valor + "  " + c4.titulo + c4.valor);

                    string aux01 = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                    categoria auxC = new categoria();
                    auxC.titulo = aux01;
                    cursos[curso_aux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1] = auxC;

                    // Actualizar el título en 'cursos'
                    //cursos[curso_aux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1].titulo = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;

                    // Código para llenar la lista 'esqueleto'
                    // Añadir los elementos al listado 'esqueleto'
                    // ...

                }
                curso_aux++;
                Console.WriteLine("\n\n\n");
            }

            //int contT = 1;
            for (int nc = 0; nc < numero_de_cursos; nc++)
            {
                salida = salida + "\n\n----------CURSO  " + nc + "---------";

                for (int np = 0; np < numero_de_periodos; np++)
                {
                    string aux_linea_semana = "";
                    string aux_punteada = "";
                    for (int nd = 0; nd < numero_de_dias; nd++)
                    {
                        aux_linea_semana += cursos[nc][np][nd].titulo + "  ||  ";
                        aux_punteada += "----------------------------";
                    }
                    Console.WriteLine(aux_punteada);
                    salida = salida + aux_punteada + "\n";
                    Console.WriteLine(aux_linea_semana);
                    salida = salida + aux_linea_semana + "\n";
                }
            }

            return salida;
        }


        public int CalculaAptitudIndividuo()
        {
            List<List<List<categoria>>> cursos = new List<List<List<categoria>>>();
            for (int nc = 0; nc < numero_de_cursos; nc++)
            {
                List<List<categoria>> semanas = new List<List<categoria>>();
                for (int np = 0; np < numero_de_periodos; np++)
                {
                    List<categoria> numHoras = new List<categoria>();
                    for (int nd = 0; nd < numero_de_dias; nd++)
                    {
                        categoria ct = new categoria();
                        ct.titulo = "xx";
                        ct.valor = "xx";
                        numHoras.Add(ct);
                    }
                    semanas.Add(numHoras);
                }
                cursos.Add(semanas);
            }

            List<List<List<categoria>>> cursosAux = new List<List<List<categoria>>>(cursos);


            int cursoAux = 0;
            foreach (int posCurso in posicion_del_curso_en_vector)
            {
                int cantCurso = posicion_del_curso_en_vector.Count();
                
                if (cantCurso == 1)
                {
                    foreach (int posAula in posicion_del_aula_en_vector)
                    {
                        categoria c0 = genomaS[posAula + 0 + 1-1]; // Aula
                        categoria c1 = genomaS[posAula + 0 + 2-1]; // Dia
                        categoria c2 = genomaS[posAula + 0 + 3-1]; // Hora
                        categoria c3 = genomaS[posAula + 0 + 4-1]; // Materia
                        categoria c4 = genomaS[posAula + 0 + 5-1]; // Profesor


                        string aux01 = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                        categoria auxC = new categoria();
                        auxC.titulo = aux01;
                        cursos[cursoAux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1] = auxC;
                    }
                    cursoAux++;
                }else
                {
                    for (int i = 0; i < posicion_del_curso_en_vector[1] - 1; i = i + 5)
                    {
                        categoria c0 = genomaS[posCurso + i + 1]; // Aula
                        categoria c1 = genomaS[posCurso + i + 2]; // Dia
                        categoria c2 = genomaS[posCurso + i + 3]; // Hora
                        categoria c3 = genomaS[posCurso + i + 4]; // Materia
                        categoria c4 = genomaS[posCurso + i + 5]; // Profesor
                        string aux01 = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                        categoria auxC = new categoria();
                        auxC.titulo = aux01;
                        cursos[cursoAux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1] = auxC;
                        //cursos[cursoAux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1].titulo = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                    }
                    cursoAux++;
                }

                ////////for (int i = 0; i < posicion_del_curso_en_vector[1] - 1; i = i + 5)                
                ////////{
                ////////    categoria c0 = genomaS[posCurso + i + 1]; // Aula
                ////////    categoria c1 = genomaS[posCurso + i + 2]; // Dia
                ////////    categoria c2 = genomaS[posCurso + i + 3]; // Hora
                ////////    categoria c3 = genomaS[posCurso + i + 4]; // Materia
                ////////    categoria c4 = genomaS[posCurso + i + 5]; // Profesor
                ////////    string aux01 = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                ////////    categoria auxC = new categoria();
                ////////    auxC.titulo = aux01;
                ////////    cursos[cursoAux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1] = auxC;
                ////////    //cursos[cursoAux][int.Parse(c2.valor) - 1][int.Parse(c1.valor) - 1].titulo = "____________" + c0.valor + " " + c1.valor + " " + c2.valor + " " + c3.valor + " " + c4.valor;
                ////////}
                ////////cursoAux++;
            }

            int contErrores = 0;
            for (int nc = 0; nc < numero_de_cursos; nc++)
            {
                for (int np = 0; np < numero_de_periodos; np++)
                {
                    for (int nd = 0; nd < numero_de_dias; nd++)
                    {
                        if (cursos[nc][np][nd].titulo.Equals("xx"))
                        {
                            contErrores++;
                        }
                    }
                }
            }

            int aptitudColegio = (numero_de_cursos * numero_de_periodos * numero_de_dias) - contErrores;

            SetAptitud(aptitudColegio);

            return 0;
        }

        public bool SaludCromosomasProfesorMateria()
        {
            return false;
        }

        public double getAptitud()
        {
            return aptitud;
        }

    }



    public struct categoria
    {
        public string titulo;
        public List<int> codigoGenetico;
        public string valor;
    }

    public struct AuxAulaDiaHora
    {
        public string aula;
        public string dia;
        public string hora;
    }

    public struct AuxAulaHoraProfesor
    {
        public string dia;
        public string hora;
        public string profesor;
    }

    public struct AuxAulaDiaHoraProfesor
    {
        public string aula;
        public string dia;
        public string hora;
        public string profesor;
    }

    public struct AuxProfesorPeriodo
    {
        public string id_profesor;
        public string id_periodo;
        public string ini_hora;
        public string fin_hora;
    }

    public struct AuxProfesorMateria
    {
        public string idProfesor;
        public string idMateria;
    }
}
