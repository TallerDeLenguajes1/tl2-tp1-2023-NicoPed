namespace CadeteriaHrms;

public class CSVHelper{

    public string leerArchivo(string nombreDelArchivo){
        var stringArchivo = "";
        using (StreamReader lector = new StreamReader(nombreDelArchivo))
        {
            stringArchivo = lector.ReadToEnd();
            lector.Close();
            lector.Dispose();
        }
        return stringArchivo;
    }
    public void guardarCadetes(string nombreDelArchivo, List<Cadete> listaCadetes){
        if (!File.Exists(nombreDelArchivo))
        {
            File.Create(nombreDelArchivo).Close();
        }
        using (StreamWriter escritor = new StreamWriter(nombreDelArchivo))
        {
                foreach (var cadete in listaCadetes)
                {
                    escritor.WriteLine($"{cadete.IdCadete};{cadete.NombreCadete};{cadete.DireccionCadete};{cadete.TelefonoCadete}");
                }
        }
    }
}