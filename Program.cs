using CadeteriaHrms;
internal class Program
{
    private static void Main(string[] args)
    {
    int opcion;
        var AyudanteCSV = new AccesoCSV();
        Cadeteria cadeteriaHermanos;
        List<Cadete> listadoCadetes;
        Informe nuevoInforme= new Informe();
        Pedido pedidoAux;
        string? nombreCliente,telefonoCliente,direccionCliente,datoDeReferencia,observacionExtra, stringIdCadete, stringIdPedido;
        int numeroPedido = 0, idCadete, idpedido = 9999;
        cadeteriaHermanos = AyudanteCSV.leerArchivoCadeteria("CadeteriaHrms.csv"); 

        listadoCadetes = AyudanteCSV.leerArchivoCadetes("CadetesInscriptos.csv");
        cadeteriaHermanos.CargarCadetes(listadoCadetes);
        Console.WriteLine(cadeteriaHermanos.mostrarCadetes());
        Console.WriteLine(cadeteriaHermanos.mostrarDatosCadeteria());
        do
        {
            Console.WriteLine("\nBienvenido al Sistema de Gestión de Pedidos");
            Console.WriteLine("1. Dar de alta pedido");
            Console.WriteLine("2. Cambiar estado de pedido a ENTREGADO");
            Console.WriteLine("3. Asignar pedido a un cadete");
            Console.WriteLine("4. Cambiar estado de pedido a CANCELADO");
            Console.WriteLine("5. Reasignar pedido a otro cadete");
            Console.WriteLine("6. Mostrar Informe");
            Console.WriteLine("7. Buscar Pedido");
            Console.WriteLine("8. Mostrar Cadetes");
            Console.WriteLine("9. Mostrar Pedidos");
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
                    if(cadeteriaHermanos.AgregarPedido(numeroPedido,observacionExtra,nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia)){
                        Console.WriteLine("Pedido dado de alta correctamente");
                    }else
                    {
                        Console.WriteLine("Algo salio mal");
                    };
                    break;
                case 2:
                    Console.WriteLine("Ingrese que pedido quiere dar como Entregado");
                    do
                    {
                        stringIdPedido = Console.ReadLine();
                    } while (!int.TryParse(stringIdPedido, out idpedido));
                    if(cadeteriaHermanos.CambiarPedidoDeEstado(idpedido)){
                        Console.WriteLine("Pedido Marcado Como Entregado");
                    }else
                    {
                        Console.WriteLine("Algo salio mal");
                    }
                    break;
                case 5:
                case 3:
                    Console.WriteLine("Ingrese el numero de pedido que quiere asignar");
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
                    if(cadeteriaHermanos.asignarCadeteAPedido(numeroPedido,idCadete)){
                        Console.WriteLine("Asignado correctamente");
                    }else
                    {
                        Console.WriteLine("Algo salio mal");
                    }
                    break;
                case 4:
                    Console.WriteLine("Ingrese que pedido quiere dar como CANCELADO");
                    do
                    {
                        stringIdPedido = Console.ReadLine();
                    } while (!int.TryParse(stringIdPedido, out idpedido));
                    if (cadeteriaHermanos.EliminarPedido(idpedido)) 
                    {
                        Console.WriteLine("Cancelado correctamente");
                    }else
                    {
                        Console.WriteLine("Error al eliminar"); 
                    }
                    break;
                case 6:
                    nuevoInforme.mostrarInforme(cadeteriaHermanos);
                    break;
                case 7:
                    Console.WriteLine("Ingrese el numero de pedido que quiere buscar");
                    Console.Write("Ingrese: ");
                    do
                    {
                        stringIdPedido = Console.ReadLine();
                    } while (!int.TryParse(stringIdPedido, out idpedido));
                    pedidoAux =cadeteriaHermanos.BuscarPedido(idpedido); 
                    if (pedidoAux != null)
                    {
                        pedidoAux.DatosDelPedido();
                    }else
                    {
                        Mensajes.PedidoNoEncontrado();
                    }
                    break;
                case 8:
                    cadeteriaHermanos.mostrarCadetes();
                    break;
                case 9:
                    cadeteriaHermanos.mostrarPedidos();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        } while (opcion != 0);
    nuevoInforme.mostrarInforme(cadeteriaHermanos);
    }
}