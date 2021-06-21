namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Display(Name ="ID")]
        public int ID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Đơn giá")]
        public int? UnitCost { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Hình ảnh")]
        [StringLength(50)]
        public string Image { get; set; }

        [Display(Name = "Chi tiết")]
        [StringLength(100)]
        public string Description { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string Status { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
