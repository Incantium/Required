# [RequireStatus](../Runtime/RequireStatus.cs)

Enum in `Incantium.Attributes` | Assembled in [`Incantium.Required`](../README.md)

## Description

RequireStatus is an enum determining if the property field is set, missing, or unable to be referenced. The following
options are available:

- Found: The required field is correctly set and there is no issue.
- Missing: The required field is empty, and a warning should be displayed.
- Unable: The targeting required field cannot be required in its current state.

## Variables

### :green_book: `RequireStatus` Found

The required field has been set.

### :green_book: `RequireStatus` Missing

The required field has not been set.

### :green_book: `RequireStatus` Unable

The required field is non-referencable and cannot be set.
