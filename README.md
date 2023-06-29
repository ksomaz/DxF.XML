# XmlReaderLibrary

XmlReaderLibrary is a lightweight and easy-to-use XML reader library for .NET 7.0. This library provides convenient methods for reading, analyzing, and extracting data from XML documents.

## Features

- Simple API for loading and reading XML documents.
- Finding specific nodes and retrieving their values using XPath expressions.
- Flexible and extensible structure for processing multiple XML documents.

## Installation

You can add XmlReaderLibrary to your project via NuGet. Use the following command to install the NuGet package:

```bash
dotnet add package XmlReaderLibrary
```

Usage
Here are some basic usage examples of XmlReaderLibrary:

```bash
// Create an XmlReader instance
using Dx.Xml;

MemoryStream xmlStream = new MemoryStream(File.ReadAllBytes("sample.xml"));
IXmlReader xmlReader = new XReader(xmlStream);

// Retrieve the value of a specific node
string nodeValue = xmlReader.GetNode("rootNode.subNode.value");

// Get the number of child nodes for a specific node
int subNodeCount = xmlReader.GetNodeCount("rootNode.subNode");

// Dispose the XML reader
xmlReader.Dispose();

// Create an XmlReader instance
using Dx.Xml;

MemoryStream xmlStream = new MemoryStream(File.ReadAllBytes("sample.xml"));
IXmlReader xmlReader = new XReader(xmlStream);

// Retrieve the value of a specific node
string nodeValue = xmlReader.GetNode("rootNode.subNode.value");

// Get the number of child nodes for a specific node
int subNodeCount = xmlReader.GetNodeCount("rootNode.subNode");

// Dispose the XML reader
xmlReader.Dispose();

```

For detailed usage examples and API reference, please visit the documentation page.

Contributing
We welcome contributions of any kind! If you have feedback, bug reports, or suggestions, please share them in the GitHub Issues section.

License
This project is licensed under the MIT License.
