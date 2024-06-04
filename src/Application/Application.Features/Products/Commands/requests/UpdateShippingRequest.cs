using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Products.Commands.CreateProduct;

namespace Domain.Entities.Product.Commands;

public record UpdateShippingRequest() : IRequest<bool>
{
    public bool IsShipEnabled { get; init; }
    public bool IsFreeShipping { get; init; }
    public bool ShipSeparately { get; init; }
    public decimal AdditionalShippingCharge { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {            
            CreateMap<UpdateShippingRequest, UpdateShippingCommand>();
        }
    }
}

