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

        #region Properties

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

        #endregion

        #region HTTP Methods (GET/POST/PUT/DELETE)

        /// <summary>
        /// Registrar um novo usuário (POST)
        /// </summary>
        public void RegisterUser()
        {
            DAL objDAL = new DAL();

            //$ -> interpolação de strings
            string stringSql = $"insert into clients (" +
                               $" Name," +
                               $" Password," +
                               $" Email," +
                               $" CreatedAt," +
                               $" LastOrder," +
                               $" UrlImg," +
                               $" Phone)" +
                               $"values (" +
                               $"'{Username}'," +
                               $"'{Password}'," +
                               $"'{Email}'," +
                               $"'{DateTime.Parse(CreatedAt.ToString()).ToString("yyyy/MM/dd")}'," +
                               $"'{DateTime.Parse(LastOrder.ToString()).ToString("yyyy/MM/dd")}'," +
                               $"'{UrlImg}'," +
                               $"'{Phone}') ";

            objDAL.ExecutaComandoSQL(stringSql);
        }
        /// <summary>
        /// List ALL Users (GET)
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
        /// <summary>
        /// Lists ONE sigle User (GET)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Updates ONE single User (PUT)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void UpdateUser(int userId)
        {
            UserViewModel item;
            DAL objDAL = new DAL();

            string querySql = $"update clients set " +
                              $"Name = '{Username.ToString()}'," +
                              $"Password = '{Password.ToString()}'," +
                              $"Email = '{Email.ToString()}'," +
                              $"CreatedAt = '{DateTime.Parse(CreatedAt.ToString()).ToString("yyyy/MM/dd")}'," +
                              $"LastOrder = '{DateTime.Parse(LastOrder.ToString()).ToString("yyyy/MM/dd")}'," +
                              $"UrlImg = '{UrlImg.ToString()}'," +
                              $"Phone = '{Phone.ToString()}' " +
                              $"where UserId = {userId.ToString()}";

            objDAL.ExecutaComandoSQL(querySql);
        }
        /// <summary>
        /// Deletes ONE single user (DELETE)
        /// </summary>
        /// <param name="id"></param>
        public void DeletarUsuario(int id)
        {
            UserViewModel item;
            DAL objDAL = new DAL();

            string querySql = $"delete from clients " +
                              $"where UserId = {id}";

            objDAL.ExecutaComandoSQL(querySql);
        }

        #endregion

    }
}

