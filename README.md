# smartpropertygrid-net6-samples

This repository contains 2 sample apps that allow you to play with the capabilities of the [Smart PropertyGrid for .Net 6 and up](https://visualhint.com/propertygrid) library.

**Smart PropertyGrid** trial version is available on [nuget.org](https://www.nuget.org/packages/VisualHint.SmartPropertyGrid-net6.Trial). For customers, the product is downloadable from a private NuGet feed.

Note that the sample projects reference the Trial package. Change to the Release package if needed.

The [documentation](https://docs.visualhint.com/spg) can be found on the VisualHint web site.

## Quickstart

This sample code is to be used along the last section of the documentation.

## PropertyGridShowRoom

This sample uses 2 PropertyGrids to showcase what it's possible to do when filling a grid manually. All of the features you see can of course be achieved when using SelectedObject, only in a different manner.

## PropertyGridShowRoom-FluentSelectedObject

Fills the grid as the previous sample does, but uses only SelectedObject and the new Fluent API to heavily customize each property.

## PropertiesStates

This samples shows how to create a simple attribute to set the initial expanded state of properties. It also demonstrates how to save a snapshot of properties states so that they can be reapplied later on another target instance.
