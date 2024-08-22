namespace Domain.Commands;
public record UpdateComplianceAndStandardsCommand : ComplianceAndStandardsCommand, ICommand<bool>;
