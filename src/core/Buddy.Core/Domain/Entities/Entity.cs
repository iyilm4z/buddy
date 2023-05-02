﻿using System;

namespace Buddy.Domain.Entities;

[Serializable]
public abstract class Entity
{
    public int Id { get; protected set; }

    public override string ToString() => $"[{GetType().Name} {Id}]";
}