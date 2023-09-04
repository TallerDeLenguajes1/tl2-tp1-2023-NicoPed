using CadeteriaHrms;
internal class Program
{
    private static void Main(string[] args)
    {
    int opcion;
        var conversor = new ConversorObjetos();
        var AyudanteCSV = new CSVHelper();
        Cadeteria cadeteriaHermanos;
        List<Cadete> listadoCadetes;
        List<string []> stringDeCadetes, stringCadeteria;
        string? nombreCliente,telefonoCliente,direccionCliente,datoDeReferencia,observacionExtra, stringIdCadete, stringIdPedido;
        int numeroPedido = 0, idCadete, idpedido = 9999;

        stringCadeteria = AyudanteCSV.LeerArchivo("CadeteriaHrms.csv",';');
        cadeteriaHermanos = conversor.ConversorDeCadeteria(stringCadeteria);
        stringDeCadetes = AyudanteCSV.LeerArchivo("CadetesInscriptos.csv",';');
        listadoCadetes = conversor.ConversorDeCadete(stringDeCadetes);
        cadeteriaHermanos.CargarCadetes(listadoCadetes);

        do
        {
            Console.WriteLine("\nBienvenido al Sistema de Gestión de Pedidos");
            Console.WriteLine("1. Dar de alta pedido");
            Console.WriteLine("2. Cambiar estado de pedido a ENTREGADO");
            Console.WriteLine("3. Asignar pedido a un cadete");
            Console.WriteLine("4. Cambiar estado de pedido a CANCELADO");
            Console.WriteLine("5. Reasignar pedido a otro cadete");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Escriba los datos del pedido: ");
                    Console.WriteLine("Datos del cliente: ");
                    Console.Write("Nombre:");
                    nombreCliente = Console.ReadLine();
                    Console.Write("Dirección:");
                    direccionCliente = Console.ReadLine();
                    Console.Write("Telefono:");
                    telefonoCliente = Console.ReadLine();
                    Console.Write("Datos de Referencia:");
                    datoDeReferencia = Console.ReadLine();
                    Console.Write("Observacion Extra:");
                    observacionExtra = Console.ReadLine();
                    numeroPedido ++;
                    cadeteriaHermanos.AgregarPedido(numeroPedido,observacionExtra,nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
                    break;
                case 2:
                    Console.WriteLine("Ingrese que pedido quiere dar como Entregado");
                    do
                    {
                        stringIdPedido = Console.ReadLine();
                    } while (!int.TryParse(stringIdPedido, out idpedido));
                    cadeteriaHermanos.CambiarPedidoDeEstado(idpedido);
                    break;
                case 5:
                case 3:
                    Console.WriteLine("Ingrese el numero de pedido que quiere Reasignar");
                    Console.Write("Ingrese: ");
                    do
                    {
                        stringIdPedido = Console.ReadLine();
                    } while (!int.TryParse(stringIdPedido, out idpedido));

                    Console.WriteLine("Ingrese el id del Cadete: ");
                    Console.Write("Ingrese: ");
                    do
                    {
                        stringIdCadete = Console.ReadLine();
                    } while (!int.TryParse(stringIdCadete, out idCadete));
                    cadeteriaHermanos.asignarCadeteAPedido(numeroPedido,idCadete);
                    Console.WriteLine("Saliendo del programa...");
                    break;
                case 4:
                    Console.WriteLine("Ingrese que pedido quiere dar como CANCELADO");
                    do
                    {
                        stringIdPedido = Console.ReadLine();
                    } while (!int.TryParse(stringIdPedido, out idpedido));
                    cadeteriaHermanos.EliminarPedido(idpedido);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        } while (opcion != 0);
    Informe nuevoInforme= new Informe();
    nuevoInforme.mostrarInforme(cadeteriaHermanos);
    }
}