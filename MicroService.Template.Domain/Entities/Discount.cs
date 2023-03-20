using MicroService.Template.Domain.Commons;
using MicroService.Template.Domain.Enums;

namespace MicroService.Template.Domain.Entities
{
    public class Discount: BaseAuditableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Percent{get;set;}

        public DiscountStatus Status{get;set;}
    }
}