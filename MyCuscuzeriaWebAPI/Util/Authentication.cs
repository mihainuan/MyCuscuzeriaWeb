using Microsoft.AspNetCore.Http;
using System;

namespace MyCuscuzeriaWeb.Util
{
    public class Authentication
    {
        public static string Token = "igH2wNmuyMO9e0Qv4FYl8StHdbQ9TFvO";
        public static string Auth_Fail = "Falha na Autenticação. Token Inválido!";

        private static IHttpContextAccessor contextAccessor;

        public Authentication(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Authenticate()
        {
            try
            {
                string receivedToken = contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (String.Equals(Token, receivedToken) == false)
                {
                    throw new Exception(Auth_Fail);
                }
            }
            catch
            {
                throw new Exception(Auth_Fail);
            }
        }

    }
}