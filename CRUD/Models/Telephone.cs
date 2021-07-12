using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class Telephone : BaseIdentity
    {
        public string Phone { get; set; }
        public string Cellphone { get; set; }

        public Client Client { get; set; }

    }
}