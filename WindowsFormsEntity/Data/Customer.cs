namespace WindowsFormsEntity.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [Column(Order = 0)]
        public int CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Nome { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string Sobrenome { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(250)]
        public string Cidade { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(250)]
        public string Endereco { get; set; }
    }
}
