namespace Toss.Inventory.Domain.Entities.Events;
public record ProductComplianceAndStandardsUpdatedDomainEvent(Guid ProductId, ComplianceAndStandards ComplianceAndStandards) : BaseEvent;
