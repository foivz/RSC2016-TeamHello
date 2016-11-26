using System.ComponentModel.DataAnnotations;

namespace QuizApp.Database.Model.Base
{
    public class ModelBase
    {
        [Key]
        public int ID { get; set; }
    }
}
