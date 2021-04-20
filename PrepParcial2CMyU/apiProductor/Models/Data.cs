namespace apiProductor.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        public int MessageID { get; set; }
        [Required]
        public double Temperature { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime TempDate { get; set; }
        [Required]
        public double Humidity { get; set; }

    }
}
