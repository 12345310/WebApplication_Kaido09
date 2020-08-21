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

        // �����`�F�b�N
        public bool DoneFlg { get; set; }

        // ��邱��
        [DisplayName("��邱��")]
        [Required]
        [StringLength(50)]
        public string TodoName { get; set; }

        // ����
        [DisplayName("����")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DeadLine { get; set; }

        // ���l
        [DisplayName("���l")]
        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
