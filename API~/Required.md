# [Required](../Runtime/Required.cs)

Class in `Incantium.Attributes` | Assembled in [`Incantium.Required`](../README.md)

Extends [`PropertyAttribute`](https://docs.unity3d.com/ScriptReference/PropertyAttribute.html)

## Description

![Required](../Images~/Required.png)

The Required attribute is a handy tool to force developers to reference an object in the field this attribute is added
to.

The main use case for the use of this attribute is to create an environment where you know for certain a field is
correctly setup within the Unity Editor. It is a common occurrence that developers forget to set field with the
correct reference.

## Example

```csharp
using Incantium.Attributes;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    [SerializeField]
    [Required]
    private Transform origin;
}
```

## Notes

> **Info**: Field with the Required attribute in prefab modes are exempt from being filled. However, this does not apply
> to the prefab once it is included in a scene.
