using System;
using System.Linq;

namespace DigiBank.Infra.CrossCutting.Utilities
{
    public class StringRandom
    {
        public static string GerarCodigoAutenticacao()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();

            string NumeroTransaca = new string(Enumerable.Repeat(chars, 15).Select(s => s[random.Next(s.Length)]).ToArray());

            return NumeroTransaca;

}
    }
}
