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

    
    public Cadeteria(string Nombre, string Telefono){
        NombreCadeteria = Nombre;
        TelefonoCadeteria = Telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedido = new List<Pedido>();
    }
    public void EliminarPedido(int numeroPedido){
        var pedidoACambiar = BuscarPedido(numeroPedido);
        if (pedidoACambiar != null)
        {
            if (pedidoACambiar.CancelarPedido()){
                pedidoACambiar.IdCadete = pedidoACambiar.CadeteDefault;
            }
            
        }else
        {
            Mensajes.PedidoNoEncontrado();
        }
    }
    public void CambiarPedidoDeEstado(int numeroPedido){
        var pedidoACambiar = BuscarPedido(numeroPedido);
        if (pedidoACambiar != null)
        {
            pedidoACambiar.CambiarPedidoDeEstado();
        }else
        {
            Mensajes.PedidoNoEncontrado();
        }
    }
    public Cadete buscarCadete(int idCadete){
        Cadete cadeteBuscado;
        cadeteBuscado = listadoCadetes.FirstOrDefault(cade => cade.IdCadete == idCadete);
        return cadeteBuscado;
    }
    public Pedido BuscarPedido(int numeroPedido){
        Pedido pedidoBuscado;
        pedidoBuscado = ListadoPedido.FirstOrDefault(pedido => pedido.NroPedido == numeroPedido);
        return pedidoBuscado;
    }
    public void asignarCadeteAPedido(int numeroPedido, int idDelCadete){
        var pedioAsignar = BuscarPedido(numeroPedido);
        if (pedioAsignar != null)
        {
            if (buscarCadete(idDelCadete) != null)
            {
                pedioAsignar.IdCadete = idDelCadete;
            }else
            {
                Mensajes.CadeteNoEncontrado();
            }
        }else{
            Mensajes.PedidoNoEncontrado();
        }
    }

    public float JornalACobrar(int idCadete){
        float aCobrar = constantes.CobroPorEnvio;
        var pedidosRealizados = from pedi in listadoPedido 
        where pedi.IdCadete == idCadete && pedi.Estado == Estado.Entregado 
        select pedi;
        aCobrar *= pedidosRealizados.Count();
        return aCobrar;
    }
    
    public void AgregarCadete(int IdCadete, string NombreCadete, string DireccionCadete, string TelefonoCadete){
        Cadete nuevoCadete = new Cadete(IdCadete,NombreCadete,DireccionCadete,TelefonoCadete);
        ListadoCadetes.Add(nuevoCadete);
    }
    public void CargarCadetes(List <Cadete> listadoCadetes){
        ListadoCadetes.AddRange(listadoCadetes);
    }
    public void AgregarPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia){
        Pedido nuevoPedido = new Pedido(numeroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
        listadoPedido.Add(nuevoPedido);
    }
}
    // private int PedirIdCadete(){
    //     int id = 9999;
    //     string? stringId;
    //     Mensajes.malIngresoIdCadete();
    //     stringId = Console.ReadLine();
    //     if (! int.TryParse(stringId, out id))
    //     {
    //         id = 9999;
    //     } 
    //     return id;
    // }
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