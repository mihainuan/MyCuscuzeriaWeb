using MyCuscuzeriaWeb.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyCuscuzeriaWeb.Models
{
    public class UserViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please informe o Username")]
        [MaxLength(100, ErrorMessage = "Máx. = {0}")]
        [MinLength(2, ErrorMessage = "Min. = {0}")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please informe uma senha")]
        [MaxLength(50, ErrorMessage = "Máx. = {0}")]
        [MinLength(1, ErrorMessage = "Min. = {0}")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Valid E-mails only")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }
        [ScaffoldColumn(false)]
        public DateTime LastOrder { get; set; }
        [ScaffoldColumn(false)]
        public string UrlImg { get; set; }

        public List<UserViewModel> ListAllUsers()
        {
            List<UserViewModel> retorno = new List<UserViewModel>();
            string json = WebAPI.RequestGET("ListarUsuarios", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
            return retorno;
        }

        public void CreateOrUpdateUser()
        {
            string jsonData = JsonConvert.SerializeObject(this);

            if (UserId == 0)
            {
                //Create
                WebAPI.RequestPOST("RegistrarUsuario", jsonData);
            }
            else
            {
                //Update
                WebAPI.RequestPUT("AtualizarUsuario", UserId.ToString(), jsonData);
            }
        }

        public UserViewModel LoadUser(int? id)
        {
            UserViewModel retorno = new UserViewModel();
            string json = WebAPI.RequestGET("ListarUsuario", id.ToString());
            retorno = JsonConvert.DeserializeObject<UserViewModel>(json);
            return retorno;
        }

    }
}