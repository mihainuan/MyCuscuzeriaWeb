using Microsoft.AspNetCore.Mvc;
using MyCuscuzeriaWebAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace MyCuscuzeriaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/Users/ListarUsuarios
        [HttpGet]
        [Route("ListarUsuarios")]
        public List<UserViewModel> ListarUsuarios()
        {
            return new UserViewModel().ListUsers();
        }

        // GET api/Users/ListarUsuarios/5
        [HttpGet("{id}")]
        [Route("ListarUsuario/{id}")]
        public UserViewModel ListaUsuario(int id)
        {
            return new UserViewModel().ListOneUser(id);
        }

        // POST api/Users/RegistrarUsuario
        [HttpPost]
        [Route("RegistrarUsuario")]
        public ReturnAllServices RegistrarUsuario([FromBody]UserViewModel dados)
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
