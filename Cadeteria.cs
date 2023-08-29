namespace CadeteriaHrms;

public class Cadeteria{
    private string nombreCadeteria;
    private string telefonoCadeteria;
    private List<Cadete> listadoCadeteria;

    public string NombreCadeteria { get => nombreCadeteria;  }
    public string TelefonoCadeteria { get => telefonoCadeteria;  }

    //AgregarPedido, AgregarCadete, ReasignarPedido, EliminarPedido, CambiarEstado, DevolverCadete
    public void CambiarPedidoDeEstado(int numeroPedido){
        Cadete cadeteAsignado = BuscarCadeteEncargadoDelPedido(numeroPedido);
        if (cadeteAsignado != null)
        {
            cadeteAsignado.CambiarPedidoDeEstado(numeroPedido);
        }else
        {
            Mensajes.PedidoNoEncontrado();
        }
    }
    public void EliminarPedido(int numeroPedido){
        Cadete cadeteAsignado = BuscarCadeteEncargadoDelPedido(numeroPedido);
        if (cadeteAsignado == null)
        {
            Mensajes.PedidoNoEncontrado();
        }else
        {
            Pedido pedidoAEliminar = BuscarPedidoDeUnCadete(numeroPedido,cadeteAsignado);
            cadeteAsignado.eliminarPedido(pedidoAEliminar);
            pedidoAEliminar.CancelarPedido();
        } 
    }
    public void ReasignarPedido(int numeroPedido, int idDelNuevoCadete){
        Cadete cadeteViejo = BuscarCadeteEncargadoDelPedido(numeroPedido);
        if (cadeteViejo == null)
        {
            Mensajes.PedidoNoEncontrado();
        }else
        {
            Pedido pedidoAReasignar = BuscarPedidoDeUnCadete(numeroPedido,cadeteViejo);
            Cadete cadeteAsignado;
            do
            {
                cadeteAsignado = DevolverCadete(idDelNuevoCadete);
                if (cadeteAsignado == null)
                {
                    idDelNuevoCadete = PedirIdCadete();
                }
            } while (cadeteAsignado == null);
            cadeteAsignado.AgregarPedido(pedidoAReasignar);
            cadeteViejo.eliminarPedido(pedidoAReasignar);
        }
    }
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
    public void AgregarCadete(int IdCadete, string NombreCadete, string DireccionCadete, string TelefonoCadete){
        Cadete nuevoCadete = new Cadete(IdCadete,NombreCadete,DireccionCadete,TelefonoCadete);
        listadoCadeteria.Add(nuevoCadete);
    }
    public void CargarCadetes(List <Cadete> listadoCadetes){
        listadoCadeteria.AddRange(listadoCadetes);
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