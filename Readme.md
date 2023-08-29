# ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
*Composición*
Cliente-Pedidos
Cadete-Cadeteria 
*Agregación*
Pedidos-Cadete

# ¿Quémétodos considera que debería tener la clase Cadetería y la clase Cadete?
*Cadeteria*
AgregarPedido, AgregarCadete, ReasignarPedido, EliminarPedido, CambiarEstado, DevolverCadete, buscarCadeteEncargado, BuscarPedidoDeUnCadete
*Cadete*
AgregarPedido, CantidadDePedidos, cambiarEstado

# Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.
*Cadeteria*
Todos publicos, exepto ListadoCadete
*Cadete*
Todos publicos, exepto ListadoPedido
*Pedidos*
Todos publicos, exepto Cliente y Estado
*Cliente*
Todos Publico

# ¿Cómo diseñaría los constructores de cada una de las clases?
Pues En cada Clase pedir todos los datos por parametros, eso si, a las clases que tienen otra clase ( otro objeto ) inicializarlos primero

# ¿Sele ocurre otra forma que podría haberse realizado el diseño de clases?
Y este diseño es bastante malo la verdad... Hace muy engorroso el hecho de la toma de pedido. Mejoraría las relaciones por ejempli uniendo el cliente con la cadetería para tener un listado de clientes y hacerlo más rapido
Serviría de mucho que en Pedido aparezca el cadete asignado para hacer más fácil la busqueda y la obtención del cadete que esta asignado a ese pedido