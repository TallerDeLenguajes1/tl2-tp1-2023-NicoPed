namespace CadeteriaHrms;

public static class Mensajes{
    public static void malIngresoIdCadete(){
        Console.WriteLine("╔═══════════════════════╗");
        Console.WriteLine("║ »Cadete no encontrado«║");
        Console.WriteLine("║ »  Ingrese otro id  « ║");
        Console.WriteLine("╚═══════════════════════╝");
        Console.Write("Ingrese » ");

    }
    public static void PedidoNoEncontrado(){
        Console.WriteLine("╔══════════════════════╗");
        Console.WriteLine("║ »Pedido inexistente« ║");
        Console.WriteLine("╚══════════════════════╝");
        Console.Write("Ingrese » ");

    }    public static void CadeteNoEncontrado(){
        Console.WriteLine("╔══════════════════════╗");
        Console.WriteLine("║ »cadete inexistente« ║");
        Console.WriteLine("╚══════════════════════╝");
        Console.Write("Ingrese » ");

    }
}