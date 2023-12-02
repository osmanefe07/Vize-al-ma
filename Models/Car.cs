using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VizeÇalışma.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Marka { get; set; }


        public string Model { get; set; }


        public int Price { get; set; }


        public string Description { get; set; }


        public bool Status { get; set; }



    }
}
