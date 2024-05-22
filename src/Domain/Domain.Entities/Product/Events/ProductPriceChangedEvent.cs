﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record ProductPriceChangedEvent(Product Product, decimal OldPrice, decimal NewPrice) : BaseEvent;