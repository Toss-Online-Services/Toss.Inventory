﻿namespace Domain.Entities.Catalog;
public class Tax : ValueObject
{
    public bool IsTaxExempt { get; private set; }
    public int TaxCategoryId { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsTaxExempt;
        yield return TaxCategoryId;

    }

    internal void Apply(UpdateTaxCommand tax)
    {
        IsTaxExempt = tax.IsTaxExempt;
        TaxCategoryId = tax.TaxCategoryId;

    }
}

