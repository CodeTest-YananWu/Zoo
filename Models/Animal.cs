using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [RegularExpression("[A-Z0-9]{6}")]
        public string AnimalID { get; set; }
        [Required]
        public AnimalType AnimalType { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public AnimalGender Gender { get; set; }

        [ForeignKey("Zookeeper")]
        public int ZookeeperID { get; set; }
        public virtual Zookeeper Zookeeper { get; set; }
    }

    public enum AnimalType
    {
        Tiger,
        Elephant,
        Giraffe,
        Monkey,
        Lion,
        Lamb,
        Wolf,
        Bat,
        Butterfly,
        Bison,
        Pig,
        Snake,
        Lima,
        Camel
    }

    public enum AnimalGender
    {
        Male,
        Female
    }
}
