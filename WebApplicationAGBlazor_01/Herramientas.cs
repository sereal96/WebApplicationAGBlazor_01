using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace WebApplicationAGBlazor_01
{
    public class Herramientas
    {
        public Herramientas()
        {
            // Constructor
        }

        ~Herramientas()
        {
            // Destructor
        }

        /*
        Combierte un valor Natural a su equivalente en binario y lo regresa como lista donde cada valor ocupa un espacio en la lista
        Parámetros:
            - valor: tipo int, valor numerico que se desea comvertir
        Devuelve:
            - List<int>: la lista compuesta
        Nota:
        */
        public List<int> ConvierteEnteroBinario(int valor)
        {
            List<int> vecBinario = new List<int>();
            string binary = Convert.ToString(valor, 2).PadLeft(16, '0');
            foreach (char digit in binary)
            {
                vecBinario.Add(digit - '0');
            }
            return vecBinario;
        }

        /*
        Combierte un valor Natural a su equivalente en binario y lo regresa como lista donde cada valor ocupa un espacio en la lista
        Parámetros:
            - valor: tipo int, valor numerico que se desea comvertir
        Devuelve:
            - List<int>: la lista compuesta
        Nota:
        */
        public List<int> ConvierteEnteroBinario8Bits(int valor)
        {
            List<int> vecBinario = new List<int>();
            string binary = Convert.ToString(valor, 2).PadLeft(8, '0');
            foreach (char digit in binary)
            {
                vecBinario.Add(digit - '0');
            }
            return vecBinario;
        }

        /*
        Combierte un valor Natural a su equivalente en binario y lo regresa como lista donde cada valor ocupa un espacio en la lista
        Parámetros:
            - valor_vect: List<int> requiere una lista en la que cada casilla tiene que tener el valor 0 o 1
        Devuelve:
            - int: devuelve el valor equivalente a su número natural
        Nota:
        */
        public int ConvierteBinarioEntero(List<int> valorVect)
        {
            string result = string.Join("", valorVect);
            int integerValue = Convert.ToInt32(result, 2);
            return integerValue;
        }

        /*
        * Imprime la lista binaria
        */
        public void ImprimeListaBinaria(List<int> listaBinaria)
        {
            Console.WriteLine("Elementos de la lista (Binario):");
            foreach (int bit in listaBinaria)
            {
                Console.Write(bit + " ---- ");
            }
            Console.WriteLine();
        }

        public int obtenerCantidadDeElementosDeDataTable(DataTable tabla)
        {
            // Filtrar los datos del DataTable por id_grado igual a 1 y id_nivel igual a 1 usando LINQ
            var resultados = from row in tabla.AsEnumerable()
                             where row.Field<int>("id_grado") == 1 && row.Field<int>("id_nivel") == 1
                             select row;
            // Obtener la cantidad de elementos en los resultados
            int cantidadElementos = resultados.Count();
            return cantidadElementos;
        }
        public int obtenerCantidadDeElementosDeDataTable2(DataTable tabla)
        {
            // Filtrar los datos del DataTable por id_grado igual a 1 y id_nivel igual a 1 usando LINQ
            var resultados = from row in tabla.AsEnumerable()
                             where row.Field<string>("grado") == "1" && row.Field<string>("nivel") == "1"
                             select row;
            // Obtener la cantidad de elementos en los resultados
            int cantidadElementos = resultados.Count();
            return cantidadElementos;
        }

    }
}
