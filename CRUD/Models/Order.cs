using System;
using System.Collections.Generic;
using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class Order : BaseIdentity
    {
        public DateTime OrderDate { get; set; }
        private int _orderNumber;
        public int OrderNumber { get { return _orderNumber; } set { _orderNumber = ID; } }
        public decimal TotalValue { get { return CalcTotalValue(); } }
        public decimal FreightValue { get; set; }

        public Client Client { get; set; }
        public IList<OrderItens> OrderItens { get; set; } = new List<OrderItens>();

        private decimal CalcTotalValue()
        {
            decimal sum = 0;
            foreach (var aux in OrderItens)
                sum += aux.TotalValue;

            return sum;
        }
    }
}