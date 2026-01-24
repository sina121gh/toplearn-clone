using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.DataLayer.Entities.Order
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        public bool IsFinally { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public int? DiscountId { get; set; }


        #region Relations

        [ForeignKey("UserId")]
        public User.User? User { get; set; }

        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }

        public IEnumerable<OrderDetail>? OrderDetails { get; set; }

        #endregion
    }
}
