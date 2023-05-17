
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models

{
    public class PizzaModel
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [Column(TypeName ="text")]
        public string Description { get; set; }
        [MaxLength(300)]
        public string ImgSource { get; set; }

        public float Price { get; set; }

        public PizzaModel(string name, string description, string imgSource, float price) 
        { 
            Name = name; 
            Description = description; 
            ImgSource = imgSource; 
            Price = price; 
        }
    }
}
