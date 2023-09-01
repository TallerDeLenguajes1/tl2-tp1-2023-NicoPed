namespace CadeteriaHrms;

public class Cadeteria{
    private string nombreCadeteria;
    private string telefonoCadeteria;
    private List<Cadete> listadoCadetes;
    private List <Pedido> listadoPedido;
    public List<Cadete> ListadoCadetes { get => listadoCadetes;  }
    public string NombreCadeteria { get => nombreCadeteria; set => nombreCadeteria = value; }
    public string TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value; }
    public List<Pedido> ListadoPedido { get => listadoPedido;  }

    //AgregarPedido, AgregarCadete, ReasignarPedido, EliminarPedido, CambiarEstado, DevolverCadete
    // public void CambiarPedidoDeEstado(int numeroPedido){
    //     Cadete cadeteAsignado = BuscarCadeteEncargadoDelPedido(numeroPedido);
    //     if (cadeteAsignado != null)
    //     {
    //         cadeteAsignado.CambiarPedidoDeEstado(numeroPedido);
    //     }else
    //     {
    //         Mensajes.PedidoNoEncontrado();
    //     }
    // }
    // public void EliminarPedido(int numeroPedido){
    //     Cadete cadeteAsignado = BuscarCadeteEncargadoDelPedido(numeroPedido);
    //     if (cadeteAsignado == null)
    //     {
    //         Mensajes.PedidoNoEncontrado();
    //     }else
    //     {
    //         Pedido pedidoAEliminar = BuscarPedidoDeUnCadete(numeroPedido,cadeteAsignado);
    //         cadeteAsignado.eliminarPedido(pedidoAEliminar);
    //         pedidoAEliminar.CancelarPedido();
    //     } 
    // }
    // public void ReasignarPedido(int numeroPedido, int idDelNuevoCadete){
    //     Cadete cadeteViejo = BuscarCadeteEncargadoDelPedido(numeroPedido);
    //     if (cadeteViejo == null)
    //     {
    //         Mensajes.PedidoNoEncontrado();
    //     }else
    //     {
    //         Pedido pedidoAReasignar = BuscarPedidoDeUnCadete(numeroPedido,cadeteViejo);
    //         Cadete cadeteAsignado;
    //         do
    //         {
    //             cadeteAsignado = DevolverCadete(idDelNuevoCadete);
    //             if (cadeteAsignado == null)
    //             {
    //                 idDelNuevoCadete = PedirIdCadete();
    //             }
    //         } while (cadeteAsignado == null);
    //         cadeteAsignado.AgregarPedido(pedidoAReasignar);
    //         cadeteViejo.eliminarPedido(pedidoAReasignar);
    //     }
    // }
    // public Pedido BuscarPedidoDeUnCadete(int numeroPedido, Cadete cadete){
    //     Pedido pedidoBuscado;
    //     pedidoBuscado = cadete.ListadoPedido.FirstOrDefault(pedido => pedido.NroPedido == numeroPedido);
    //     return pedidoBuscado;
    // }
    // public Cadete BuscarCadeteEncargadoDelPedido(int numeroPedido){
    //     Cadete cadeteBuscado = null;
    //     foreach (var cadete in ListadoCadetes)
    //     {
    //         //buscar pedido
    //         Pedido pedidoBuscado = BuscarPedidoDeUnCadete(numeroPedido,cadete);
    //         if (pedidoBuscado != null)
    //         {
    //             cadeteBuscado = cadete;
    //             break;
    //         }
    //     }
    //     return cadeteBuscado;
    // }
    public float JornalACobrar(){
        float aCobrar = 500;
        return aCobrar;
    }
    public void AgregarCadete(int IdCadete, string NombreCadete, string DireccionCadete, string TelefonoCadete){
        Cadete nuevoCadete = new Cadete(IdCadete,NombreCadete,DireccionCadete,TelefonoCadete);
        ListadoCadetes.Add(nuevoCadete);
    }
    public void CargarCadetes(List <Cadete> listadoCadetes){
        ListadoCadetes.AddRange(listadoCadetes);
    }
    public Cadeteria(string Nombre, string Telefono){
        NombreCadeteria = Nombre;
        TelefonoCadeteria = Telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedido = new List<Pedido>();
    }
    private Cadete DevolverCadete(int idCadete){
        return ListadoCadetes.FirstOrDefault(cadete => cadete.IdCadete == idCadete);
    }
    public void AgregarPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia, int idCadete){
        Pedido nuevoPedido = new Pedido(numeroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
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