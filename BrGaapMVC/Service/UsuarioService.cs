using Newtonsoft.Json;
using RestSharp;
using static BrGaapMVC.Models.DetalheUsuarioModel;
using static BrGaapMVC.Models.UsuarioModel;

namespace BrGaapMVC.Service
{
    public class UsuarioService
    {
        public static List<Usuario>? ListaUsuario()
        {
            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();

                string urlApi = configuration.GetConnectionString("UrlApi");

                var client = new RestClient(urlApi + "todos");
                var request = new RestRequest();
                var response = client.Execute(request);

                return JsonConvert.DeserializeObject<List<Usuario>>(response.Content);
            }
            catch (System.Exception)
            {

            }
            return null;
        }

        public static DetalheUsuarioObject DetalheUsuario(int id)
        {
            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();

                string urlApi = configuration.GetConnectionString("UrlApi");


                var client = new RestClient(urlApi + "users/" + id);
                var request = new RestRequest();
                var response = client.Execute(request);

                return JsonConvert.DeserializeObject<DetalheUsuarioObject>(response.Content);
            }
            catch (System.Exception ex)
            {

            }
            return new DetalheUsuarioObject();
        }
    }
}
