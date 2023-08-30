namespace CadeteriaHrms;

public  class ConversorObjetos{
        public  List<Cadete> ConversorDeCadete(List<string[]> archivoConCadetes)
        {

            List<Cadete> ListadoCadetes = new List<Cadete>();
            foreach (string[] cadete in archivoConCadetes)
            {
                Cadete nuevoCadete = new Cadete(Convert.ToInt32(cadete[0]), cadete[1], cadete[2], cadete[3]);
                ListadoCadetes.Add(nuevoCadete);
            }
            return ListadoCadetes;
        }
     
        public Cadeteria ConversorDeCadeteria(List<string[]> archivoConCadeteria)
        {
            Cadeteria nuevaCadeteria = new Cadeteria("Error","Error");
            foreach (string[] cadeteri in archivoConCadeteria)
            {
                nuevaCadeteria.NombreCadeteria = cadeteri[0];
                nuevaCadeteria.TelefonoCadeteria = cadeteri[1];
                break;
            }
              return nuevaCadeteria;
        }
}