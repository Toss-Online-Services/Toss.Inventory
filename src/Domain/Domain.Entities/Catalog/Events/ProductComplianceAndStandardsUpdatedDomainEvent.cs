namespace Domain.Entities.Catalog.Events;
public record ProductComplianceAndStandardsUpdatedDomainEvent(Guid ProductId, ComplianceAndStandards ComplianceAndStandards) : BaseEvent;
