using System.ComponentModel.DataAnnotations;

namespace Api_AngularCrud.Model
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsFreasher { get; set; }
    }
}

