﻿namespace Domain.SeedWork;

public abstract class BaseAuditableEntity : Entity
{
    public DateTimeOffset Created { get; set; }

    public string CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string LastModifiedBy { get; set; }
}