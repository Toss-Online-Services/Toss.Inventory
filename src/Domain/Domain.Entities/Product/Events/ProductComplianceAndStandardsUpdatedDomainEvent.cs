using Domain.Entities.Catalog;

namespace Domain.Entities.Product.Events;
public record ProductComplianceAndStandardsUpdatedDomainEvent(string ProductId, ComplianceAndStandards ComplianceAndStandards) : BaseEvent;
