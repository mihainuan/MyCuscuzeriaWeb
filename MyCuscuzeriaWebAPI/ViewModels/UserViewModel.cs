using MyCuscuzeriaWeb.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyCuscuzeriaWebAPI.ViewModels
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

        //public virtual OrderViewModel Order { get; set; }


        /// <summary>
        /// Registrar um novo usuário
        /// </summary>
        public void RegisterUser()
        {
            DAL objDAL = new DAL();

            //$ -> interpolação de strings
            string stringSql = $"insert into clients(Name,Password,Email,CreatedAt,LastOrder,UrlImg,Phone)" +
                               $"values ('{Username}','{Password}','{Email}', '{CreatedAt.ToLocalTime()}','{LastOrder.ToLocalTime()}','{UrlImg}','{Phone}')";

            objDAL.ExecutaComandoSQL(stringSql);

        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns></returns>
        public List<UserViewModel> ListUsers()
        {
            List<UserViewModel> lista = new List<UserViewModel>();
            UserViewModel item;

            DAL objDAL = new DAL();

            string querySql = "select * from clients order by UserId asc";
            DataTable dados = objDAL.RetornaDataTable(querySql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new UserViewModel()
                {
                    UserId = int.Parse(dados.Rows[i]["UserId"].ToString()),
                    Username = dados.Rows[i]["Name"].ToString(),
                    Password = dados.Rows[i]["Password"].ToString(),
                    Email = dados.Rows[i]["Email"].ToString(),
                    Phone = dados.Rows[i]["Phone"].ToString(),
                    CreatedAt = DateTime.Parse(dados.Rows[i]["CreatedAt"].ToString()),
                    LastOrder = DateTime.Parse(dados.Rows[i]["LastOrder"].ToString()),
                    UrlImg = dados.Rows[i]["UrlImg"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public UserViewModel ListOneUser(int userId)
        {
            UserViewModel item;
            DAL objDAL = new DAL();

            string querySql = $"select * from clients where UserId = {userId}";
            DataTable dados = objDAL.RetornaDataTable(querySql);

            item = new UserViewModel()
            {
                UserId = int.Parse(dados.Rows[0]["UserId"].ToString()),
                Username = dados.Rows[0]["Name"].ToString(),
                Password = dados.Rows[0]["Password"].ToString(),
                Email = dados.Rows[0]["Email"].ToString(),
                Phone = dados.Rows[0]["Phone"].ToString(),
                CreatedAt = DateTime.Parse(dados.Rows[0]["CreatedAt"].ToString()),
                LastOrder = DateTime.Parse(dados.Rows[0]["LastOrder"].ToString()),
                UrlImg = dados.Rows[0]["UrlImg"].ToString()
            };

            return item;
        }
    }
}

