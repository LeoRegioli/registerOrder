using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class OrderItens : BaseIdentity
    {
        public int ProductCode { get; set; }
        private decimal _totalValue;
        public decimal TotalValue { get { return _totalValue; } private set { _totalValue = CalcTotalValueProduct(); } }
        public int Quantity { get; set; }

        public Product Product { get; set; }

        private decimal CalcTotalValueProduct() => Quantity * Product.UnitaryValue;
    }
}