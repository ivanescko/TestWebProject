using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebProject.Models.Entities
{
    public class Order
    {
        [Key]
        [Display(Name = "Идентификатор заказа")]
        public int  OrderID{ get; set;}

        [Required(ErrorMessage = "Отсутствуют данные")]
        [Display(Name = "Город отправителя")]
        [Column(TypeName = "VARCHAR(30)")]
        public string SenderСity { get; set; }

        [Required(ErrorMessage = "Отсутствуют данные")]
        [Display(Name = "Адрес отправителя")]
        [Column(TypeName = "VARCHAR(255)")]
        public string SenderAddress { get; set; }

        [Required(ErrorMessage = "Отсутствуют данные")]
        [Display(Name = "Город получателя")]
        [Column(TypeName = "VARCHAR(30)")]
        public string RecipientСity { get; set; }

        [Required(ErrorMessage = "Отсутствуют данные")]
        [Display(Name = "Адрес получателя")]
        [Column(TypeName = "VARCHAR(30)")]
        public string AddressRecipient { get; set; }

        [Required(ErrorMessage = "Отсутствуют данные")]
        [Display(Name = "Вес груза")]
        [Column(TypeName = "INT(11)")]
        public int CargoWeight { get; set; }

        [Required(ErrorMessage = "Отсутствуют данные")]
        [Display(Name = "Дата забора груза")]
        [Column(TypeName = "DATE")]
        public DateTime DateOfReceiving { get; set; }
    }
}
