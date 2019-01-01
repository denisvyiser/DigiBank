using System;

namespace DigiBank.Application.ModelsDTO
{
    public class LoginTokenDTO
    {
        public string TokenKey { get; set; }

        public DateTime DataExpira { get; set; }
    }
}
