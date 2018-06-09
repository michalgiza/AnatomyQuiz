using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddQuestion : MonoBehaviour {

    public IXmlDocumentDataObject xmlDocumentDataObject = new XmlDocumetnDataObject();
    public InputField Content;
	public InputField AnswearA;
	public InputField AnswearB;
	public InputField AnswearC;
	public InputField AnswearD;
    public Dropdown CorrectAnswer;
    public GameObject DialogBox;

    //
	public void GetData()
	{
        if((Content.text == "") || (AnswearD.text == "") || (AnswearC.text=="") || (AnswearB.text=="") || (AnswearA.text == "") ||
           (Content.text == null) || (AnswearD.text == null) || (AnswearC.text == null) || (AnswearB.text == null) || (AnswearA.text == null))
        {
            DialogBox.SetActive(true);
            return;
        }
        string path = @"FileXML\questions.xml";
        int correctAnswerInt = CorrectAnswer.value;

        xmlDocumentDataObject.SaveNewQuestion(path, Content.text, AnswearA.text, AnswearB.text, AnswearC.text, AnswearD.text, correctAnswerInt);
        
        SceneManager.LoadScene("MenuScene");



    }
   
    public void ClickButtonOk()
    {
        DialogBox.SetActive(false);
    }

}
