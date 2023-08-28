namespace CadeteriaHrms;

public class Cadete{
    private int idCadete;
    private string nombreCadete;
    private string direccionCadete;
    private string telefonoCadete;
    private  List<Pedido> listadoPedido;
    
    private int pedidosRealizados;

    public int IdCadete { get => idCadete; set => idCadete = value; }
    public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }
    public string DireccionCadete { get => direccionCadete; set => direccionCadete = value; }
    public string TelefonoCadete { get => telefonoCadete; set => telefonoCadete = value; }
    public List<Pedido> ListadoPedido { get => listadoPedido; set => listadoPedido = value; }

    
    public Cadete (int Id, string Nombre, string Direccion, string Telefono,List<Pedido> listadoDePedido ){
        IdCadete = Id;
        NombreCadete = Nombre;
        DireccionCadete = Direccion;
        TelefonoCadete = Telefono;
        ListadoPedido.Clear();
        pedidosRealizados = 0;
    }

    public float JornalACobrar(){
        float aCobrar = 500 * pedidosRealizados;
        return aCobrar;
    } 
}