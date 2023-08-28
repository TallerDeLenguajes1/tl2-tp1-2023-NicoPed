namespace CadeteriaHrms;

public class Cadeteria{
    private string nombreCadeteria;
    private string telefonoCadeteria;
    private List<Cadete> listadoCadeteria;

    public Cadeteria(string Nombre, string Telefono){
        nombreCadeteria = Nombre;
        telefonoCadeteria = Telefono;
        listadoCadeteria.Clear();
    }
}