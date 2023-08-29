namespace CadeteriaHrms;

public class Cadeteria{
    private string nombreCadeteria;
    private string telefonoCadeteria;
    private List<Cadete> listadoCadeteria;

//AgregarPedido, AgregarCadete, ReasignarPedido, EliminarPedido, CambiarEstado, DevolverCadete
    public Pedido BuscarPedidoDeUnCadete(int numeroPedido, Cadete cadete){
        Pedido pedidoBuscado;
        pedidoBuscado = cadete.ListadoPedido.FirstOrDefault(pedido => pedido.NroPedido == numeroPedido);
        return pedidoBuscado;
    }
    public Cadete BuscarCadeteEncargadoDelPedido(int numeroPedido){
        Cadete cadeteBuscado = null;
        foreach (var cadete in listadoCadeteria)
        {
            //buscar pedido
            Pedido pedidoBuscado = BuscarPedidoDeUnCadete(numeroPedido,cadete);
            if (pedidoBuscado != null)
            {
                cadeteBuscado = cadete;
                break;
            }
        }
        return cadeteBuscado;
    }
    public void CambiarPedidoDeEstado(int numeroPedido){

    }
    public void AgregarCadete(int IdCadete, string NombreCadete, string DireccionCadete, string TelefonoCadete){
        Cadete nuevoCadete = new Cadete(IdCadete,NombreCadete,DireccionCadete,TelefonoCadete);
        listadoCadeteria.Add(nuevoCadete);
    }
    public Cadeteria(string Nombre, string Telefono){
        nombreCadeteria = Nombre;
        telefonoCadeteria = Telefono;
        listadoCadeteria.Clear();
    }
    private Cadete DevolverCadete(int idCadete){
        return listadoCadeteria.FirstOrDefault(cadete => cadete.IdCadete == idCadete);
    }
    public void AgregarPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferenciaDireccion, int idCadete){
        Pedido nuevoPedido = new Pedido(numeroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datoDeReferenciaDireccion);
        Cadete cadeteAsignado;
        do
        {
            cadeteAsignado = DevolverCadete(idCadete);
            if (cadeteAsignado == null)
            {
                idCadete = PedirIdCadete();
            }
        } while (cadeteAsignado == null);
        cadeteAsignado.AgregarPedido(nuevoPedido);
    }
    private int PedirIdCadete(){
        int id = 9999;
        string? stringId;
        Mensajes.malIngresoIdCadete();
        stringId = Console.ReadLine();
        if (! int.TryParse(stringId, out id))
        {
            id = 9999;
        } 
        return id;
    }
}