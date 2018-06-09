using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class XmlDocumentRepository :  IXmlDocumentRepository
{ 
    public XDocument LoadXml(string path)
    {
        return XDocument.Load(Path.GetFullPath(path));
    }
    
    public void Save(string path, XmlDocument xdoc)
    {
        xdoc.Save(Path.GetFullPath(path));
    }

    public XmlDocument LoadXmlDocument(string path)
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(Path.GetFullPath(path));

        return xdoc;
    }
    
}
