# XmlReaderLibrary

![DxF XML](https://github.com/ksomaz/DxF.XML/assets/18247823/a815216f-1029-432e-86cd-3fe819e2fb64)

XmlReaderLibrary is a lightweight and easy-to-use XML reader library for .NET 7.0. This library provides convenient methods for reading, analyzing, and extracting data from XML documents.

## Features

- Simple API for loading and reading XML documents.
- Finding specific nodes and retrieving their values using XPath expressions.
- Flexible and extensible structure for processing multiple XML documents.

## Installation

You can add XmlReaderLibrary to your project via NuGet. Use the following command to install the NuGet package:

```bash
https://www.nuget.org/packages/DxF.XML
```

```bash
dotnet add package DxF.XML --version 1.0.0
```

Usage
Here are some basic usage examples of XmlReaderLibrary:

```bash
// Create an XmlReader instance
using DxF.XML.Finder;

MemoryStream xmlStream = new MemoryStream(File.ReadAllBytes("sample.xml"));
XmlReader xmlReader = new XmlReader(xmlStream);

// Retrieve the value of a specific node
string nodeValue = xmlReader.GetNode("rootNode", "subNode", ...);

// Get the number of child nodes for a specific node
int subNodeCount = xmlReader.GetNodeCount("rootNode");

// Dispose the XML reader
xmlReader.Dispose();

```

Contributing
We welcome contributions of any kind! If you have feedback, bug reports, or suggestions, please share them in the GitHub Issues section.

License
This project is licensed under the MIT License.
