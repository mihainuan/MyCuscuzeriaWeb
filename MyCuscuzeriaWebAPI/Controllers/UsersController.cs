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
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
                return new UserViewModel().ListUsers();
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro no ListarUsuarios. -> " + ex.Message;
                return null;
            }
        }

        // GET api/Users/ListarUsuarios/5
        [HttpGet("ListarUsuario/{id}")]
        public UserViewModel ListaUsuario(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
                return new UserViewModel().ListOneUser(id);
            }

            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro no ListaUsuario. -> " + ex.Message;
                return null;
            }
        }

        // POST api/Users/RegistrarUsuario
        [HttpPost]
        [Route("RegistrarUsuario")]
        public ReturnAllServices RegistrarUsuario([FromBody]UserViewModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.CreatedAt = DateTime.Now.AddYears(-2);
                dados.LastOrder = DateTime.Now;

                dados.RegisterUser();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }

            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro no RegistrarUsuario. -> " + ex.Message;
            }
            return retorno;
        }

        // PUT api/Users/AtualizarUsuario/5
        [HttpPut("AtualizarUsuario/{id}")]
        public ReturnAllServices AtualizarUsuario(int id, [FromBody]UserViewModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.CreatedAt = DateTime.Now.AddYears(-4);
                dados.LastOrder = DateTime.Now.AddYears(20);

                dados.UpdateUser(id);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }

            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro na AtualizarUsuario. -> " + ex.Message;
            }
            return retorno;
        }

        // DELETE api/Users/DeletarUsuario/5
        [HttpDelete("DeletarUsuario/{id}")]
        public ReturnAllServices DeletarUsuario(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                new UserViewModel().DeletarUsuario(id);
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }

            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro na DeletarUsuario. -> " + ex.Message;
            }
            return retorno;
        }
    }
}
