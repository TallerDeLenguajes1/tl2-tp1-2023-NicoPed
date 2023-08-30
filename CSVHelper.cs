namespace CadeteriaHrms;

public class CSVHelper{
    public List<string[]> LeerArchivo(string nombreDelArchivo, char caracter)
        {
            FileStream MiArchivo = new FileStream(nombreDelArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea = "";
            List<string[]> LecturaDelArchivo = new List<string[]>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(caracter);
                LecturaDelArchivo.Add(Fila);
            }

            return LecturaDelArchivo;
        }
    // public string[] leerArchivo(string nombreDelArchivo){
    //     string[] stringArchivo;
    //     using (StreamReader lector = new StreamReader(nombreDelArchivo))
    //     {
    //         stringArchivo = lector.ReadToEnd();
    //         lector.Close();
    //         lector.Dispose();
    //     }
    //     return stringArchivo;
    // }
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