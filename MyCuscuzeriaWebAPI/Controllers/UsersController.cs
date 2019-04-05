using Microsoft.AspNetCore.Mvc;
using MyCuscuzeriaWeb.Util;
using MyCuscuzeriaWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyCuscuzeriaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/Users
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            DAL objDAL = new DAL();

            string stringSql = "insert into clients(Name,Password,Email,CreatedAt,LastOrder,UrlImg,Phone)" +
                               "values ('new client','psswd','email@mail.com', NOW(),NOW(),'c:/img_','+1 (509) 339-3855')";
            objDAL.ExecutaComandoSQL(stringSql);


            return new string[] { "value1", "value2" };
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            DAL objDAL = new DAL();

            //$ -> interpolação de strings
            string sql = $"select * from Clients where UserId = {id}";
            DataTable dados = objDAL.RetornaDataTable(sql);

            return dados.Rows[0]["Name"].ToString();
        }

        // POST api/Users/RegistrarUsuario
        [HttpPost]
        [Route("RegistrarUsuario")]
        public ReturnAllServices RegistrarCliente([FromBody]UserViewModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.RegisterUser();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }

            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro no registro de usuário. -> " + ex.Message;
            }

            return retorno;
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
