using System.Collections.Generic;
using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class Client : BaseIdentity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public IList<Address> Address { get; set; } = new List<Address>();

        public IList<Telephone> Telephone { get; set; } = new List<Telephone>();
        public IList<Order> Order {get; set;} = new List<Order>();
    }
}