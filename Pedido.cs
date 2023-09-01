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
    private int idCadete;
    internal Estado Estado { get => estado;  }
    public string Observacion { get => observacion;  }
    public int NroPedido { get => nroPedido;  }
    public int IdCadete { get => idCadete; }

    public Pedido (int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia) {
        estado = Estado.Pendiente;
        nroPedido = numeroPedido;
        observacion = observacionPedido;
        cliente = new Cliente(nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
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
     public bool CambiarPedidoDeEstado(){
        if (estado != Estado.Cancelado)
        {
            estado = Estado.Entregado;
            return true;
        }
        return false;
    }
    public void CancelarPedido(){
        estado = Estado.Cancelado;
    }
}

