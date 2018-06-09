using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddQuestion : MonoBehaviour {

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


        Question question = new Question()
        {
            correctAnswerSign = CorrectAnswerIntToString(correctAnswerInt),
            question = Content.text,
            answerA = AnswearA.text,
            answerB = AnswearB.text,
            answerC = AnswearC.text,
            answerD = AnswearD.text
        };

        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(Path.GetFullPath(path));

        XmlElement xelement = xdoc.CreateElement("Question");
        XmlElement xTresc = xdoc.CreateElement("Tresc");
        XmlElement xAnswerA = xdoc.CreateElement("AnswerA");
        XmlElement xAnswerB = xdoc.CreateElement("AnswerB");
        XmlElement xAnswerC = xdoc.CreateElement("AnswerC");
        XmlElement xAnswerD = xdoc.CreateElement("AnswerD");
        XmlElement xCorrectAnswer = xdoc.CreateElement("PoprawnaOdpowiedz");


        xTresc.InnerText = question.question;
        xAnswerA.InnerText = question.answerA;
        xAnswerB.InnerText = question.answerB;
        xAnswerC.InnerText = question.answerC;
        xAnswerD.InnerText = question.answerD;
        xCorrectAnswer.InnerText = question.correctAnswerSign;

        xelement.AppendChild(xTresc);
        xelement.AppendChild(xAnswerA);
        xelement.AppendChild(xAnswerB);
        xelement.AppendChild(xAnswerC);
        xelement.AppendChild(xAnswerD);
        xelement.AppendChild(xCorrectAnswer);

        xdoc.DocumentElement.AppendChild(xelement);
        xdoc.Save(Path.GetFullPath(path));

        SceneManager.LoadScene("MenuScene");



    }
    // 
    public string CorrectAnswerIntToString(int index)
    {
        string signCorrectAnswer = null;
        switch(index)
        {
            case 0: signCorrectAnswer = "A"; break;
            case 1: signCorrectAnswer="B"; break;
            case 2: signCorrectAnswer="C"; break;
            case 3: signCorrectAnswer="D"; break;
        }

        return signCorrectAnswer;
    }

    //
    public void ClickButtonOk()
    {
        DialogBox.SetActive(false);
    }

}
