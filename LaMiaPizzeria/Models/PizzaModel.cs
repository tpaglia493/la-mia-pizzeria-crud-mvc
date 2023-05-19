
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaMiaPizzeria.Models.CustomValidationAttributes;

namespace LaMiaPizzeria.Models

{
    public class PizzaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Questo campo è obbligatorio!")]
        [StringLength(25, ErrorMessage ="Il nome non può essere più lungo di 25 caratteri!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio!")]
        [StringLength(135, ErrorMessage = "La descrizione non può essere più lunga di 135 caratteri!")]
        public string Description { get; set; }

        [Url]
        [Required(ErrorMessage = "Questo campo è obbligatorio!")]
        [StringLength(300, ErrorMessage = "L'indirizzo URL non può essere più lungo di 300 caratteri!")]
        public string ImgSource { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio!")]
        [NoGifts]
        [NoNegative]
        [NoPriceForPoors]
        public float Price { get; set; }

        public PizzaModel() { }

        public PizzaModel(string name, string description, string imgSource, float price) 
        { 
            Name = name; 
            Description = description; 
            ImgSource = imgSource; 
            Price = price; 
        }
    }
}
