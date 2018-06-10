using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

public class QuestionList : MonoBehaviour
{
    public Question[] questions;
    public IXmlDocumentDataObject xmlDocumetnDataObject;
    // Use this for initialization

     
    void Start ()
    {
        string path = @"FileXML\questions.xml";
        xmlDocumetnDataObject = new XmlDocumetnDataObject();
        questions=xmlDocumetnDataObject.GetAllQuestions(path);
        Singleton.QuizManager.questions = this.questions;
	}
    
    }

