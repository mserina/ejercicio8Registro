using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio6Registro.servicios
{
    internal class OperacionImplementacion : OperacionInterfaz
    {

        public void verArchivo(string archivo)
        {
            string texto;
            using (StreamReader sr = new StreamReader(archivo))
            {
                texto = sr.ReadToEnd();
                Console.WriteLine(texto);
            }
        }

        public string[] modificarLineaEspecifica(string archivo, string[] lineas)
        {
            Console.WriteLine("Inserte la linea que quiera modificar");
            int lineaAModificar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserte el texto por el que lo quiera sustituir");
            string texto = Console.ReadLine();


            lineas = File.ReadAllLines(archivo);

            try { 

                if (lineaAModificar >= 0 && lineaAModificar <= lineas.Length)
                {
                    //ERROR 1:C --> NO COGE LA LINEA NUEVA POR LA QUE LA QUIERO CAMBIAR
                    lineas[lineaAModificar - 1] = texto;
                

                }
                else
                {
                    Console.WriteLine("ERROR[]: Ha seleccionado una linea fuera de rango");
                }
            }
            catch (IOException ex) 
            {
                Console.WriteLine("Error IO: " + ex.Message);
            }


            return lineas;
        }

        public string[] modificarPosicion(string archivo, string[] lineas)
        {
            Console.WriteLine("Inserte la linea que quiera modificar");
            int lineaAModificar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insertar la posicion de la linea");
            int posicionLinea = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserte el texto por el que lo quiera sustituir");
            string texto = Console.ReadLine();


            try
            {
                lineas = File.ReadAllLines(archivo);
                if (lineaAModificar >= 0 && lineaAModificar <= lineas.Length)
                {
                    string lineaSeleccionada = lineas[lineaAModificar - 1];

                    //IMPORTANTE: LA SEGUND ACONDICIOND EL IF PARA REGULAR LAS POSICIONES SE DEBE HACER NO CON EL TAMAÑO DE LAS LINEAS DE FICHERO, SI NO CON LA LINEA ESPECIFICA, POR ESO
                    //EN EL IF ANTERIOR SE CREA UN STRING QUE CONTENGA DICHA LINEA
                    if (posicionLinea >= 0 && posicionLinea <= lineaSeleccionada.Length)
                    {

                        string nuevaLinea = lineaSeleccionada.Insert(posicionLinea, texto);
                        lineas[lineaAModificar - 1] = nuevaLinea;
                         
                    }
                    else
                    {
                        Console.WriteLine("ERROR[]: La posicion que ha insertado no existe");
                     
                    }

                }
                else
                {
                    Console.WriteLine("ERROR[]: Ha seleccionado una linea fuera de rango");
                }



            }
            catch (IOException e)
            {
                Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
            }


            return lineas;
        }

        public void guardarArchivo(string archivo, string[] lineas)
        {

            File.WriteAllLines(archivo, lineas);

        }

    }

}
