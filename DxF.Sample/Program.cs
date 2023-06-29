
// Create an XmlReader instance
using DxF.XML.Finder;

using (MemoryStream xmlStream = new MemoryStream(File.ReadAllBytes("Sample.xml")))
{
    using (XReader xmlReader = new XReader(xmlStream))
    {
        // Get the total number of 'book' nodes
        int countBook = xmlReader.GetNodeCount("book");

        for (int i = 0; i < countBook; i++)
        {
            // Retrieve the value of specific nodes for each book
            string authorValue = xmlReader.GetNode("book[" + i + "]", "author");
            string titleValue = xmlReader.GetNode("book[" + i + "]", "title");
            string genreValue = xmlReader.GetNode("book[" + i + "]", "genre");
            string priceValue = xmlReader.GetNode("book[" + i + "]", "price");
            string publish_dateValue = xmlReader.GetNode("book[" + i + "]", "publish_date");
            string descriptionValue = xmlReader.GetNode("book[" + i + "]", "description");

            // Print the book details
            Console.WriteLine("----Book " + i + "--------");
            Console.WriteLine("Author: " + authorValue);
            Console.WriteLine("Title: " + titleValue);
            Console.WriteLine("Genre: " + genreValue);
            Console.WriteLine("Price: " + priceValue);
            Console.WriteLine("Publish Date: " + publish_dateValue);
            Console.WriteLine("Description:");
            Console.WriteLine(descriptionValue);
        }
    }
}

Console.ReadLine();