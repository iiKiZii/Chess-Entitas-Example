﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique]
public sealed class InputComponent : IComponent
{
    public Vector2Int value;
}