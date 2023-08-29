namespace CadeteriaHrms;

public class Cadete{
    private int idCadete;
    private string nombreCadete;
    private string direccionCadete;
    private string telefonoCadete;
    private  List<Pedido> listadoPedido; //Privado ya que toda la lógica de si tiene o no pedidos el cadete es del cadete la cadetería no debe meterse en esto
    private int pedidosRealizados;

    public int IdCadete { get => idCadete; set => idCadete = value; }
    public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }
    public string DireccionCadete { get => direccionCadete; set => direccionCadete = value; }
    public string TelefonoCadete { get => telefonoCadete; set => telefonoCadete = value; }
    public List<Pedido> ListadoPedido { get => listadoPedido;  }
    public int PedidosRealizados { get => pedidosRealizados; }

    
    public Cadete (int Id, string Nombre, string Direccion, string Telefono ){
        IdCadete = Id;
        NombreCadete = Nombre;
        DireccionCadete = Direccion;
        TelefonoCadete = Telefono;
        ListadoPedido.Clear();
        pedidosRealizados = 0;
    }

    public float JornalACobrar(){
        float aCobrar = 500 * PedidosRealizados;
        return aCobrar;
    }
    public void AgregarPedido(Pedido nuevoPedido){
        listadoPedido.Add(nuevoPedido);
    }
    public int CantidadDePedidos(){
        return listadoPedido.Count();
    }
    public void eliminarPedido(Pedido PedidoAEliminar){
        listadoPedido.Remove(PedidoAEliminar);
    }
    public void CambiarPedidoDeEstado(int numeroPedido){
        Pedido pedidoACambiar = BuscarPedido(numeroPedido);
        if (pedidoACambiar.CambiarPedidoDeEstado())
        {
            pedidosRealizados ++;
        }
    }
    public Pedido BuscarPedido(int numeroPedido){
        Pedido pedidoBuscado;
        pedidoBuscado = ListadoPedido.FirstOrDefault(pedido => pedido.NroPedido == numeroPedido);
        return pedidoBuscado;
    }
}