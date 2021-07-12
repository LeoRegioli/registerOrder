using System.Collections.Generic;
using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class Product : BaseIdentity
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal UnitaryValue { get; set; }

        public IList<OrderItens> OrderItens { get; set; } = new List<OrderItens>();
    }
}