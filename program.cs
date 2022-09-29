using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


/// <summary>
/// Developed by L.  27-09-2022
/// Do not forget install Nuget Newtonsoft
/// Based on https://zetcode.com/csharp/getpostrequest/
/// </summary>
 
    class Program
    {
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

                using (WebResponse response = request.GetResponse())
                {
                    // GetResponse returns a web response containing the response to the request
                    using (WebResponse webResponse = request.GetResponse())
                    {
                        // Reading data
                        StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                        json = reader.ReadToEnd();
                    }                   
                }

                // Desealizer List !!!
                listaProvincias = JsonConvert.DeserializeObject<List<Provincia>>(json);

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
    }


    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string Descripcion { get; set; }

    }


 
