namespace Domain.Entities.Catalog.Events;
public record ProductComplianceAndStandardsUpdatedDomainEvent(string ProductId, ComplianceAndStandards ComplianceAndStandards) : BaseEvent;
