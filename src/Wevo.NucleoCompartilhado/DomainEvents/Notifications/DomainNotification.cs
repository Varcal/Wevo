﻿using System;
using Wevo.NucleoCompartilhado.DomainEvents.Core;

namespace Wevo.NucleoCompartilhado.DomainEvents.Notifications
{
    public class DomainNotification: Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }
    }
}
