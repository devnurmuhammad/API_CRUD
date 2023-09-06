using System.ComponentModel.DataAnnotations;

namespace API_CRUD.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
