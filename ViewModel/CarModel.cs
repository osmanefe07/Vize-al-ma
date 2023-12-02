using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VizeÇalışma.ViewModel
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marka Adı Giriniz!")]
        public string Marka { get; set; }


        [Required(ErrorMessage = "Model Adı Giriniz!")]
        public string Model { get; set; }



        [Required(ErrorMessage = "Ürün Fiyat Giriniz!")]
        public int Price { get; set; }



        [Required(ErrorMessage = "Açıklama Giriniz!")]
        public string Description { get; set; }





        public bool Status { get; set; }
    }
}
