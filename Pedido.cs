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
    private float precio;
    public global::System.Int32 NroPedido { get => nroPedido; set => nroPedido = value; }
    public global::System.String Observacion { get => observacion; set => observacion = value; }
    internal Estado Estado { get => estado; set => estado = value; }

    public Pedido (int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferenciaDireccion) {
        estado = Estado.Pendiente;
        nroPedido = numeroPedido;
        observacion = observacionPedido;
        cliente = new Cliente(nombreCliente,direccionCliente,telefonoCliente,datoDeReferenciaDireccion);
    }
}

