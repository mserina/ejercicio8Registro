using ejercicio6Registro.servicios;


namespace ejercicio6Ficheros.controladores
{

    class Program
    {

        public static void Main(string[] args)
        {
            string rutaArchivo = "C:\\Users\\csi23-mserina\\Desktop\\REGISTRO_VC.txt";
            
            string[] lineas = null;

            bool cerrarMenu = false;

            try
            {

               lineas = File.ReadAllLines(rutaArchivo);

            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR IO: " + e.Message);
                cerrarMenu = true;
            }
            

            MenuInterfaz mi = new MenuImplementacion();
            OperacionInterfaz op = new OperacionImplementacion();
            int opcionSeleccionada = 0;

            while (!cerrarMenu)
            {

                opcionSeleccionada = mi.opcionSeleccionada();
                try
                {
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            cerrarMenu = true;
                            break;
                        case 1:

                            //METEMOS EL RESULTADO (EL MISMO ARRA STRING PERO CON MODIFICACIONES) PARA SOBREESCRIBIR EL STRING ARRAY ORIGINAL
                            lineas = op.modificarLineaEspecifica(rutaArchivo, lineas);
                            break;
                        case 2:
                            lineas = op.modificarPosicion(rutaArchivo, lineas);
                            break;
                        case 3:
                            op.verArchivo(rutaArchivo);
                            break;
                        case 4:
                            op.guardarArchivo(rutaArchivo, lineas);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("EL FICHERO NO SE ENCUENTRA DISPONIBLE");
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}