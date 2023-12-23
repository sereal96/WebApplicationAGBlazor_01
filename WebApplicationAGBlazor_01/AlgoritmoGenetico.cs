using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAGBlazor_01
{
    public class AlgoritmoGenetico
    {
        private int poblacionTamano;
        private double gradoDeMuatacion;
        private double crossoverRate;
        private int elitismoCont;
        private int tamanoDeTorneo;

        public AlgoritmoGenetico()
        {
        }

        public AlgoritmoGenetico(int poblacionTamano_, double gradoDeMuatacion_, double crossoverRate_, int elitismoCont_, int tamanoDeTorneo_)
        {
            poblacionTamano = poblacionTamano_;
            gradoDeMuatacion = gradoDeMuatacion_;
            crossoverRate = crossoverRate_;
            elitismoCont = elitismoCont_;
            tamanoDeTorneo = tamanoDeTorneo_;
        }

        public Individuo SelectParent_Random(Poblacion population_)
        {
            // Obtener la fecha y hora actuales
            DateTime tiempoActual = DateTime.Now;
            // Crear una semilla basada en el tiempo actual
            int semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                          tiempoActual.Hour * 10000 + tiempoActual.Second;
            Random rnd = new Random(semilla);

            rnd.Next(0, population_.Size() + 1);

            List<Individuo> individuals = population_.GetPobladores();
            int hasar = rnd.Next(0, population_.Size() + 1);
            while (hasar >= individuals.Count)
            {
                hasar = rnd.Next(0, population_.Size() + 1);
            }
            return individuals[hasar];
        }

        public Individuo SelectParent_RouletteWheel(Poblacion population_)
        {
            // Obtener la fecha y hora actuales
            DateTime tiempoActual = DateTime.Now;
            // Crear una semilla basada en el tiempo actual
            int semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                          tiempoActual.Hour * 10000 + tiempoActual.Second;
            Random rnd = new Random(semilla);

            List<Individuo> individuals = population_.GetPobladores();
            double populationFitness = population_.GetAptitudPoblacion();
            double rouletteWheelPosition = rnd.NextDouble() * populationFitness;

            double spinWheel = 0;
            foreach (Individuo individual in individuals)
            {
                spinWheel += individual.getAptitud();
                if (spinWheel >= rouletteWheelPosition)
                {
                    return individual;
                }
            }
            return individuals[population_.Size() - 1];
        }

        public Individuo SelectParent_TournamentSelection(Poblacion population_)
        {
            // Obtener la fecha y hora actuales
            DateTime tiempoActual = DateTime.Now;
            // Crear una semilla basada en el tiempo actual
            int semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                          tiempoActual.Hour * 10000 + tiempoActual.Second;
            Random rnd = new Random(semilla);


            Poblacion tournament = new Poblacion(tamanoDeTorneo);

            Poblacion poblacionAux = new Poblacion();
            poblacionAux = population_;
            poblacionAux.Shuffle(); //verificar


            bool sw_completo = false;
            int i = 0;
            int a = 0;
            int b = 0;
            while (!sw_completo)
            {
                a = new Random().Next(0, poblacionAux.Size() + 1);
                if (a >= 0 && a <= (poblacionAux.Size() - 1))
                {
                    if (a == b)
                    {
                        a = rnd.Next(1, poblacionAux.Size());
                    }
                }
                else
                {
                    a--;
                }
                b = a;
                Individuo tournamentIndividual = poblacionAux.GetPobladorPorCelda(a);
                if (tournamentIndividual.getAptitud() >= -1) // Ajusta la lógica según sea necesario
                {
                    tournament.SetPoblador(i, tournamentIndividual);
                    i++;
                }
                if (i == tamanoDeTorneo)
                {
                    sw_completo = true;
                }
            }
            return tournament.GetIndividuoMasApto(tournament.Size() - 1);
        }

        public Poblacion CrossoverPopulation_1(Poblacion population_, int selecion_padre)
        {
            //Random rnd = new Random();

            // Obtener la fecha y hora actuales
            DateTime tiempoActual = DateTime.Now;
            // Crear una semilla basada en el tiempo actual
            int semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                          tiempoActual.Hour * 10000 + tiempoActual.Second;

            Random rnd = new Random(semilla);


            Poblacion newPopulation = new Poblacion(population_.Size());

            for (int populationIndex = 0; populationIndex < population_.Size(); populationIndex++)
            {
                Individuo parent1 = population_.GetPobladorPorCelda(populationIndex);
                double r = rnd.NextDouble();
                if (crossoverRate > r && populationIndex > elitismoCont)
                {
                    Individuo offspring = parent1;

                    Individuo parent2;
                    switch (selecion_padre)
                    {
                        case 1:
                            parent2 = SelectParent_Random(population_);
                            break;
                        case 2:
                            parent2 = SelectParent_RouletteWheel(population_);
                            break;
                        case 3:
                            parent2 = SelectParent_TournamentSelection(population_);
                            break;
                        default:
                            parent2 = SelectParent_Random(population_);
                            break;
                    }

                    // Resto del código de crossover adaptado según sea necesario
                    // ...
                    //Genera una semillar basada en fecha,hora,minuto y segundo
                    //std::time_t tiempoActual = std::time(0);
                    //std::tm tiempoInfo;
                    //// Usar std::localtime_s para obtener la información de tiempo actual
                    //localtime_s(&tiempoInfo, &tiempoActual);
                    //unsigned int semilla = tiempoInfo.tm_sec + tiempoInfo.tm_min * 60 + tiempoInfo.tm_hour * 3600 +
                    //    tiempoInfo.tm_mday * 86400 + (tiempoInfo.tm_mon + 1) * 2592000 + (tiempoInfo.tm_year + 1900) * 31104000;
                    //srand(semilla);

                    // Obtener la fecha y hora actuales
                    tiempoActual = DateTime.Now;
                    // Crear una semilla basada en el tiempo actual
                    semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                                  tiempoActual.Hour * 10000 + tiempoActual.Second;

                    Random rand = new Random(semilla);

                    // Loop over genome
                    List<int> auxCursoVector = parent1.GetPosicionDelCursoEnVector();
                    int geneIndex = 0;
                    while (geneIndex < parent1.SizeGenomaS())
                    {

                        //}
                        //for (int geneIndex = 0; geneIndex < parent1.sizeGenomaS(); geneIndex++)
                        //{


                        //auto iterador = std::find(auxCursoVector.begin(), auxCursoVector.end(), geneIndex);


                        if (!auxCursoVector.Contains(geneIndex))
                        {
                            //if (iterador == auxCursoVector.end())
                            //{
                            // Use half of parent1's genes and half of parent2's genes
                            r = ((double)rand.NextDouble());
                            if (0.5 > r)
                            {
                                offspring.SetGenomaS(geneIndex + 0, parent1.getGenomaS(geneIndex + 0));
                                offspring.SetGenomaS(geneIndex + 1, parent1.getGenomaS(geneIndex + 1));
                                offspring.SetGenomaS(geneIndex + 2, parent1.getGenomaS(geneIndex + 2));
                                offspring.SetGenomaS(geneIndex + 3, parent1.getGenomaS(geneIndex + 3));
                                offspring.SetGenomaS(geneIndex + 4, parent1.getGenomaS(geneIndex + 4));
                            }
                            else
                            {
                                offspring.SetGenomaS(geneIndex + 0, parent2.getGenomaS(geneIndex + 0));
                                offspring.SetGenomaS(geneIndex + 1, parent2.getGenomaS(geneIndex + 1));
                                offspring.SetGenomaS(geneIndex + 2, parent2.getGenomaS(geneIndex + 2));
                                offspring.SetGenomaS(geneIndex + 3, parent2.getGenomaS(geneIndex + 3));
                                offspring.SetGenomaS(geneIndex + 4, parent2.getGenomaS(geneIndex + 4));
                            }
                            geneIndex = geneIndex + 4;
                            //offspring.CalculaAptitudIndividuo();
                        }
                        else
                        {
                            offspring.SetGenomaS(geneIndex, parent1.getGenomaS(geneIndex));
                        }
                        geneIndex++;
                    }
                    offspring.CalculaAptitudIndividuo();

                    // Add offspring to new population
                    newPopulation.SetPoblador(populationIndex, offspring);


                }
                else
                {
                    newPopulation.SetPoblador(populationIndex, parent1);
                }
            }
            newPopulation.CalculaAptitudPoblacion();
            return newPopulation;
        }

        public Poblacion MutatePopulation(Poblacion population_)
        {
            Poblacion newPopulation = new Poblacion(population_.Size());

            for (int populationIndex = 0; populationIndex < population_.Size(); populationIndex++)
            {
                // Obtener la fecha y hora actuales
                DateTime tiempoActual = DateTime.Now;
                // Crear una semilla basada en el tiempo actual
                int semilla = tiempoActual.Year * 10000 + tiempoActual.DayOfYear * 100 + tiempoActual.Month * 10 +
                              tiempoActual.Hour * 10000 + tiempoActual.Second;

                Random rand = new Random(semilla);

                Individuo individuoMutacion = population_.GetIndividuoMasApto(populationIndex);

                if (populationIndex > elitismoCont)
                {
                    // Loop over individual's genes
                    for (int geneIndex = 0; geneIndex < individuoMutacion.SizeGenomaS(); geneIndex++)
                    {
                        //// Skip mutation if this is an elite individual
                        //if (populationIndex > elitismoCont)
                        //{
                        // Does this gene need mutation?
                        if (gradoDeMuatacion > rand.Next())
                        {
                            categoria cat = individuoMutacion.MutarGen(geneIndex);
                            // Swap for new gene
                            individuoMutacion.SetGenomaS(geneIndex, cat);// setGene(geneIndex, randomIndividual.getGene(geneIndex));
                        }
                        //}
                    }
                }

                newPopulation.SetPoblador(populationIndex, individuoMutacion);
            }

            return newPopulation;
        }
    }
}
