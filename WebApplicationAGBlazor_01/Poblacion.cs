using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAGBlazor_01
{
    public class Poblacion
    {
        private List<Individuo> pobladores = new List<Individuo>();
        private double aptitud_Poblacion;

        public Poblacion()
        {
        }

        public Poblacion(int poblacionSize)
        {
            for (int i = 0; i < poblacionSize; i++)
            {
                Individuo i1 = new Individuo();
                pobladores.Add(i1);
            }
            //pobladores = new List<Individuo>(poblacionSize);
        }

        public List<Individuo> GetPobladores()
        {
            return pobladores;
        }

        public void SetPoblador(int pos, Individuo poblador_)
        {
            pobladores[pos] = poblador_;
        }

        public void CalculaAptitudPoblacion()
        {
            double poblacion = 0.0;
            foreach (Individuo individuo in pobladores)
            {
                poblacion += individuo.getAptitud();
            }
            aptitud_Poblacion = poblacion / pobladores.Count;
        }

        public void SetAptitudPoblacion(double aptitudP)
        {
            aptitud_Poblacion = aptitudP;
        }

        public double GetAptitudPoblacion()
        {
            return aptitud_Poblacion;
        }

        public Individuo GetPobladorPorCelda(int posicion_)
        {
            return pobladores[posicion_];
        }

        public void GeneradorDePoblacion(int cantidad, int numero_de_dias_, int numero_de_periodos_, int numero_de_cursos_, int numero_de_profesores_,
            int numero_de_materias_, int numero_de_aulas_)
        {
            Random rnd = new Random();
            for (int i = 0; i < cantidad; i++)
            {
                Individuo i1 = new Individuo();
                i1.CrearGenomaS(numero_de_dias_, numero_de_periodos_, numero_de_cursos_, numero_de_profesores_, numero_de_materias_, numero_de_aulas_);
                //Console.WriteLine("individuo " + i.ToString() + " añadido.");
                i1.CalculaAptitudIndividuo();
                pobladores.Add(i1);
            }
        }

        public int Size()
        {
            return pobladores.Count;
        }

        public Individuo GetIndividuoMasApto(int offset)
        {
            // Obtener el objeto con la mejor aptitud
            Individuo mejorIndividuo = pobladores.OrderByDescending(x => x.aptitud).FirstOrDefault();
            return mejorIndividuo;

            //pobladores = pobladores.OrderBy(i => i.getAptitud()).ToList();            
            //return pobladores[offset];
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = pobladores.Count - 1; i > 0; i--)
            {
                int index = rnd.Next(i + 1);
                Individuo a = pobladores[index];
                pobladores[index] = pobladores[i];
                pobladores[i] = a;
            }
        }

        public Poblacion Shuffle2()
        {
            Random rnd = new Random();
            for (int i = pobladores.Count - 1; i > 0; i--)
            {
                int index = rnd.Next(i + 1);
                Individuo a = pobladores[index];
                pobladores[index] = pobladores[i];
                pobladores[i] = a;
            }
            return this;
        }

        public void OrdenarPoblacionDecendente()
        {
            //pobladores = pobladores.OrderByDescending(i => i.getAptitud()).ToList();

            pobladores = pobladores.OrderByDescending(x => x.aptitud).ToList();
        }
    }
}
