using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class Address : BaseIdentity
    {
        public string Street { get; set; }
        public string CEP { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string UF { get; set; }

        //Relationship
        public Client Client { get; set; }
    }
}