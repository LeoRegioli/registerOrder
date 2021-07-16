using CRUD.Models.Shared;

namespace CRUD.Models
{
    public class OrderItens : BaseIdentity
    {
        public int ProductCode { get; set; }
        public decimal TotalValue { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        // private decimal CalcTotalValueProduct() => Quantity * Product.UnitaryValue;
    }
}