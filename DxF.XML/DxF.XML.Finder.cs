using System.Xml.Linq;

namespace DxF.XML.Finder
{
    public class XReader : IDisposable
    {
        private XDocument XDoc { get; set; }
        private XElement RootElement { get; set; }

        public XReader(MemoryStream memoryStream)
        {
            XDoc = XDocument.Load(memoryStream);
            RootElement = XDoc.Root;
        }

        public string GetNode(params string[] SearchKey)
        {
            List<XElement> XML_Root = RootElement.Elements().ToList();

            string[] ValueIndex = SearchKey[0].Replace("]", "").Split('[');
            int Index = 0;
            foreach (XElement xElement in XML_Root)
            {
                if (ValueIndex.Length == 1)
                {
                    if (xElement.Name.LocalName == SearchKey[0].Split('.')[0])
                    {
                        if (SearchKey.Length == 1)
                            return GetNodeReturn(xElement, SearchKey[0]);
                        else
                            return GetNode(xElement.Elements().ToList(), SearchKey.Skip(1).ToArray());
                    }
                }
                else
                {
                    if (xElement.Name.LocalName == ValueIndex[0].Split('.')[0] && Index == Convert.ToInt32(ValueIndex[1]))
                    {
                        if (SearchKey.Length == 1)
                            return GetNodeReturn(xElement, SearchKey[0]);
                        else
                            return GetNode(xElement.Elements().ToList(), SearchKey.Skip(1).ToArray());

                    }

                    if (xElement.Name.LocalName == ValueIndex[0].Split('.')[0])
                        Index++;
                }
            }

            return string.Empty;
        }
        private string GetNode(List<XElement> xElements, params string[] SearchKey)
        {
            string[] ValueIndex = SearchKey[0].Replace("]", "").Split('[');
            int Index = 0;
            foreach (XElement xElement in xElements)
            {
                if (ValueIndex.Length == 1)
                {
                    if (xElement.Name.LocalName == SearchKey[0].Split('.')[0])
                    {
                        if (SearchKey.Length == 1)
                            return GetNodeReturn(xElement, SearchKey[0]);
                        else
                            return GetNode(xElement.Elements().ToList(), SearchKey.Skip(1).ToArray());
                    }
                }
                else
                {
                    if (xElement.Name.LocalName == ValueIndex[0].Split('.')[0] && Index == Convert.ToInt32(ValueIndex[1]))
                    {
                        if (SearchKey.Length == 1)
                            return GetNodeReturn(xElement, SearchKey[0]);
                        else
                            return GetNode(xElement.Elements().ToList(), SearchKey.Skip(1).ToArray());
                    }

                    if (xElement.Name.LocalName == ValueIndex[0].Split('.')[0])
                        Index++;
                }
            }

            return string.Empty;
        }
        private string GetNodeReturn(XElement xElement, string SearchKey)
        {
            string[] _SearchKey = SearchKey.Split('.');

            string Result;
            if (_SearchKey.Length == 1)
                Result = xElement.Value;
            else
                Result = xElement.Attribute(_SearchKey[1]).Value;

            return Result;
        }
        public int GetNodeCount(params string[] SearchKey)
        {
            int result = 0;

            List<XElement> XML_Root = RootElement.Elements().ToList();

            foreach (XElement xElement in XML_Root)
            {
                if (xElement.Name.LocalName == SearchKey[0])
                {
                    if (SearchKey.Length == 1)
                        result++;
                    else
                        result = GetNodeCount(xElement.Elements().ToList(), SearchKey.Skip(1).ToArray());
                }
            }

            return result;
        }
        private int GetNodeCount(List<XElement> xElements, params string[] SearchKey)
        {
            int result = 0;
            foreach (XElement xElement in xElements)
            {
                if (xElement.Name.LocalName == SearchKey[0])
                {
                    if (SearchKey.Length == 1)
                        result = xElement.Elements().ToList().Count;
                    else
                        result = GetNodeCount(xElement.Elements().ToList(), SearchKey.Skip(1).ToArray());
                }
            }

            return result;
        }

        public void Dispose()
        {
            XDoc = null;
            RootElement = null;

            GC.Collect();
        }
    }
}
