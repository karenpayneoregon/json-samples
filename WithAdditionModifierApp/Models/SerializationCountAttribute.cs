﻿namespace WithAdditionModifierApp.Models;

// Custom attribute to annotate the property
// we want to be incremented.
[AttributeUsage(AttributeTargets.Property)]
public class SerializationCountAttribute : Attribute
{
}