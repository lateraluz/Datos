/// <summary>
/// Developed by L.  27-09-2022
/// Updated          27-02-2024 (using System.Text.Json)  
/// </summary>
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace appConsoleAPI
{
    internal class Program
    {
        // Don't forget to import System.Text.Json from Nuget
        static void Main(string[] args)
        {
            string json = "";
            List<Provincia> listaProvincias = null;
            string urlJSON = " https://raw.githubusercontent.com/lateraluz/datos/main/provincias.json";
            try
            {
                // Creates a GET request to fetch  
                WebRequest request = WebRequest.Create(urlJSON);
                // Verb GET
                request.Method = "GET";

                // GetResponse returns a web response containing the response to the request
                using (WebResponse webResponse = request.GetResponse())
                {
                    // Reading data
                    StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                    json = reader.ReadToEnd();
                }

                // Desealizer List !!!
                listaProvincias = JsonSerializer.Deserialize<List<Provincia>>(json);

                Console.WriteLine($"Respuesta de {urlJSON}\n");

                foreach (var provincia in listaProvincias)
                {
                    Console.WriteLine($"{provincia.IdProvincia} {provincia.Descripcion}");
                }

                Console.ReadKey();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }

        }

        public class Provincia
        {
            public int IdProvincia { get; set; }
            public string Descripcion { get; set; }

        }

    }
}
