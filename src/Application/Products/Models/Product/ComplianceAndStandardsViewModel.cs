﻿namespace Application.Products.Models.Product;
public record ComplianceAndStandardsViewModel(bool NotReturnable, string Certifications, string RegulatoryApprovals, string SafetyInformation, string EnvironmentalImpact, string RecyclingInformation)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ComplianceAndStandardsViewModel, ComplianceAndStandards>().ReverseMap();
        }
    }
}
