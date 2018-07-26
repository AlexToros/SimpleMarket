using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameStore
{
    public class Order
    {
        public decimal WrapCost { get { return GiftWrap ? 100 : 0; } }
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите свое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вы должны указать хотя бы один адрес")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}