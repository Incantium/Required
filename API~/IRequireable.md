# [IRequireable](../Runtime/IRequireable.cs)

Interface in `Incantium.Attributes` | Assembled in [`Incantium.Required`](../README.md)

## Description

IRequireable is an interface that other classes can implement to be used with the [Required](Required.md) attribute.

## Notes

> **Info**: All classes that implement [Object](https://docs.unity3d.com/ScriptReference/Object.html) doesn't need this 
> interface. These types are explicitly able to require.

## Variables

### :green_book: [`RequireStatus`](RequireStatus.md) status

Use this property to return the current [status](RequireStatus.md) of the field that is required, being either set, 
missing, or unable to be required.
