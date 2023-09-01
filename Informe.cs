namespace CadeteriaHrms
{
    class Informe
    {
        private int montoTotalGanado;
        private int totalEnvios;
        private double promedioEnviosXCadete;
        private Cadeteria cadeteria ;
        public int MontoTotalGanado { get => montoTotalGanado; set => montoTotalGanado = value; }
        public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
        public double PromedioEnviosXCadete { get => promedioEnviosXCadete; set => promedioEnviosXCadete = value; }
        public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }

        public Informe(Cadeteria cadeteria)
        {
            Cadeteria = cadeteria;
            foreach (Cadete cadete in Cadeteria.ListadoCadetes)
            {
                foreach (Pedido pedido in cadete.ListadoPedido)
                {
                    if (pedido.Estado == Estado.Entregado)
                    {
                        TotalEnvios++;
                    }
                }
            }
            MontoTotalGanado = TotalEnvios*500;
            if (Cadeteria.ListadoCadetes.Count != 0)
            {
                PromedioEnviosXCadete = TotalEnvios/Cadeteria.ListadoCadetes.Count;
            }
        }

        

        public void MostrarInforme(){
            Console.WriteLine("--------Informe de la Cadeteria "+ Cadeteria.NombreCadeteria + "--------");
            Console.WriteLine("Cantidad de Envios REALIZADOS: "+ TotalEnvios);
            Console.WriteLine("Promedio de Envios por cadete: "+PromedioEnviosXCadete);
            Console.WriteLine("Monto total generado: "+ MontoTotalGanado);
            Console.WriteLine("");
            Console.WriteLine("INFORMACION POR CADETES");
            
            foreach (Cadete cadete in Cadeteria.ListadoCadetes)
            {
                Console.WriteLine("");
                Console.WriteLine("[Cadete "+cadete.NombreCadete+"\nID: "+ cadete.IdCadete+"]");
                Console.WriteLine("Cantidad de Pedidos Entregados: "+ cadete.PedidosRealizados);
                Console.Write("Nros de los Pedidos EnCamino: ");
                foreach (Pedido pedido in cadete.ListadoPedido)
                {
                    if (pedido.Estado == Estado.Pendiente)
                    {
                        Console.Write(pedido.NroPedido+" | ");
                    }
                }
                Console.WriteLine("");
                Console.Write("Nros de los pedidos Entregados: ");
                foreach (Pedido pedido in cadete.ListadoPedido)
                {
                    if (pedido.Estado == Estado.Entregado)
                    {
                        Console.Write(pedido.NroPedido+" | ");
                    }
                }
            }
        }
    }
    
}