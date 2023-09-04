namespace CadeteriaHrms;
    class Informe
    {
        public void mostrarInforme(Cadeteria cadeteri){
            var pediosRealizados = from pedi in cadeteri.ListadoPedido
                                    where pedi.Estado == Estado.Entregado
                                    select pedi;
                                    
            int cantidadDePedidosDeHoy = pediosRealizados.Count();
            Console.WriteLine("====================================");
            foreach (var cadete in cadeteri.ListadoCadetes)
            {
                int idCadete = cadete.IdCadete;
                float aCobrar = cadeteri.JornalACobrar(idCadete);
                int pedidosRealizadosCadete = Convert.ToInt32(aCobrar / constantes.CobroPorEnvio);
                Console.WriteLine("Nombre del Cadete: "+cadete.NombreCadete);
                Console.WriteLine("Id del Cadete: "+cadete.IdCadete);
                Console.WriteLine("Pedidos realizados: "+pedidosRealizadosCadete);
                Console.WriteLine("Envios promedio del cadete del día de hoy : "+ pedidosRealizadosCadete * 100 / cantidadDePedidosDeHoy);
                Console.WriteLine("Total a cobrar: "+aCobrar);
                Console.WriteLine("====================================");
            }
        }
    
    }
