using MyCuscuzeriaWeb.Util;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public void RegisterUser()
        {
            DAL objDAL = new DAL();

            //$ -> interpolação de strings
            string stringSql = $"insert into clients(Name,Password,Email,CreatedAt,LastOrder,UrlImg,Phone)" +
                               $"values ('{Username}','{Password}','{Email}', '{CreatedAt.ToLocalTime()}','{LastOrder.ToLocalTime()}','{UrlImg}','{Phone}')";

            objDAL.ExecutaComandoSQL(stringSql);



        }
    }
}

