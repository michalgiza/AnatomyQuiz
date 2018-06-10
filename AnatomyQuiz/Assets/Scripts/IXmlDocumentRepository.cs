
using System.Xml;
using System.Xml.Linq;


public interface IXmlDocumentRepository
{
    void Save(string path, XmlDocument xdoc);
    XmlDocument LoadXmlDocument(string path);
    XDocument LoadXml(string path);
}
