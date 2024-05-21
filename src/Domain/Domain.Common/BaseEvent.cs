using MediatR;

namespace Domain.Infrastructure;

public abstract record BaseEvent : INotification;
