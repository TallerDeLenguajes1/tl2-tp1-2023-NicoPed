namespace CadeteriaHrms;
enum Estado
{
    Pendiente,
    Entregado,
    Cancelado
}
public class Pedido
{
    private int nroPedido;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    internal Estado Estado { get => estado; set => estado = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public int NroPedido { get => nroPedido; set => nroPedido = value; }

    public Pedido (int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferenciaDireccion) {
        estado = Estado.Pendiente;
        NroPedido = numeroPedido;
        Observacion = observacionPedido;
        cliente = new Cliente(nombreCliente,direccionCliente,telefonoCliente,datoDeReferenciaDireccion);
    }
    public string verDireccionCliente(){
        string? direccion;
        direccion = cliente.Direccion + "-" + cliente.DatosReferencia;
        return direccion;
    }
    public string verDatosCliente(){
        string? datos;
        datos = cliente.Nombre + "-" + cliente.Telefono;
        return datos;
    }
}

