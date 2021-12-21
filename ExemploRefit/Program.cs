using Refit;
using System;
using System.Threading.Tasks;

namespace ExemploRefit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu CEP: ");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine($"Consultando informações do CEP: {cepInformado}");

                var address = await cepClient.GetAddressAsync(cepInformado);
                Console.Write($"\nLogradouro: {address.Logradouro} " +
                    $"\nBairro: {address.Bairro} " +
                    $"\nUF: {address.Uf} " +
                    $"\nDDD: {address.DDD}");

            } catch (Exception e)
            {
                Console.WriteLine("Erro nma consulta do cep: "+ e.Message);
            }
        }
    }
}
