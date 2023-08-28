# ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
*Composición*
Cadete-Cadeteria 
Pedidos-Cadete
*Agregación*
Cliente-Pedidos

# ¿Quémétodos considera que debería tener la clase Cadetería y la clase Cadete?
*Cadeteria*
AgregarPedido, AgregarCadete, crearPedido, ReasignarPedido, EliminarPedido, CambiarEstado, DevolverCadete
*Cadete*
AgregarPedido, CantidadDePedidos

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
Y este diseño es bastante malo. 