namespace WebApplication_Kaido09.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MVCList")]
    public partial class MVCList
    {

        // ID
        public int ID { get; set; }

        // 完了チェック
        public bool DoneFlg { get; set; }

        // やること
        [DisplayName("やること")]
        [Required]
        [StringLength(50)]
        public string TodoName { get; set; }

        // 期日
        [DisplayName("期日")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DeadLine { get; set; }

        // 備考
        [DisplayName("備考")]
        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
