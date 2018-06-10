using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

public class XmlDocumetnDataObject : IXmlDocumentDataObject {

    public IXmlDocumentRepository xmlDocumentRepository = new XmlDocumentRepository();
    public Question [] GetAllQuestions(string path)
    {
        var doc = xmlDocumentRepository.LoadXml(path);
        var questionsArray = doc.Descendants("Question").Select(x => new Question
        {
            question = x.Element("Tresc").Value,
            answerA = x.Element("AnswerA").Value,
            answerB = x.Element("AnswerB").Value,
            answerC = x.Element("AnswerC").Value,
            answerD = x.Element("AnswerD").Value,
            correctAnswerSign = x.Element("PoprawnaOdpowiedz").Value

        }).ToArray();
        StringToEnum(questionsArray);
        return questionsArray;
    }
    public Question[] GetQuestionsAbout(string path, Question.MainSubject mainSubject)
    {
        var doc = xmlDocumentRepository.LoadXml(path);
        var questionsArray = doc.Descendants("Question").Select(x => new Question
        {
            question = x.Element("Tresc").Value,
            answerA = x.Element("AnswerA").Value,
            answerB = x.Element("AnswerB").Value,
            answerC = x.Element("AnswerC").Value,
            answerD = x.Element("AnswerD").Value,
            correctAnswerSign = x.Element("PoprawnaOdpowiedz").Value,
            mainSubjectSign = Convert.ToInt32(x.Element("Typ").Value)

        }).Where(x=>x.mainSubjectSign ==(int)mainSubject).ToArray();
        StringToEnum(questionsArray);
        return questionsArray;
    }

    public bool GetMax(string path,int score)
    {
        var doc = xmlDocumentRepository.LoadXml(path);
        var reslutsArray = doc.Descendants("Result").Select(x => new PlayerResult
        {
            PlayerName = x.Element("PlayerName").Value,
            Date = x.Element("Date").Value,
            Score = Convert.ToInt32(x.Element("Score").Value)

        }).Max(x => x.Score);

        if (score <= reslutsArray)
            return false;
        else
            return true;
    }

    public void SaveScore(string path, string PlayerName, int score)
    {
        DateTime today = DateTime.Now;
        XmlDocument xdoc = xmlDocumentRepository.LoadXmlDocument(path);

        XmlElement xResult = xdoc.CreateElement("Result");
        XmlElement xPlayerName = xdoc.CreateElement("PlayerName");
        XmlElement xDateTime = xdoc.CreateElement("Date");
        XmlElement xScore = xdoc.CreateElement("Score");

        xPlayerName.InnerText = PlayerName;
        xDateTime.InnerText = String.Format("{0}", today.ToShortDateString());
        xScore.InnerText = score.ToString();

        xResult.AppendChild(xPlayerName);
        xResult.AppendChild(xDateTime);
        xResult.AppendChild(xScore);

        xdoc.DocumentElement.AppendChild(xResult);
        xmlDocumentRepository.Save(path, xdoc);

    }
    public void SaveNewQuestion(string path, string Content, string AnswearA, string AnswearB, string AnswearC, string AnswearD, int correctAnswerInt, int mainSubjectSign)
    {
        Question question = new Question()
        {
            correctAnswerSign = CorrectAnswerIntToString(correctAnswerInt),
            mainSubjectSign = mainSubjectSign,
            question = Content,
            answerA = AnswearA,
            answerB = AnswearB,
            answerC = AnswearC,
            answerD = AnswearD
        };

        XmlDocument xdoc = xmlDocumentRepository.LoadXmlDocument(path);

        XmlElement xelement = xdoc.CreateElement("Question");
        XmlElement xTresc = xdoc.CreateElement("Tresc");
        XmlElement xAnswerA = xdoc.CreateElement("AnswerA");
        XmlElement xAnswerB = xdoc.CreateElement("AnswerB");
        XmlElement xAnswerC = xdoc.CreateElement("AnswerC");
        XmlElement xAnswerD = xdoc.CreateElement("AnswerD");
        XmlElement xCorrectAnswer = xdoc.CreateElement("PoprawnaOdpowiedz");
        XmlElement xMainSubject = xdoc.CreateElement("Typ");

        xTresc.InnerText = question.question;
        xAnswerA.InnerText = question.answerA;
        xAnswerB.InnerText = question.answerB;
        xAnswerC.InnerText = question.answerC;
        xAnswerD.InnerText = question.answerD;
        xCorrectAnswer.InnerText = question.correctAnswerSign;
        xMainSubject.InnerText = question.mainSubjectSign.ToString();

        xelement.AppendChild(xTresc);
        xelement.AppendChild(xAnswerA);
        xelement.AppendChild(xAnswerB);
        xelement.AppendChild(xAnswerC);
        xelement.AppendChild(xAnswerD);
        xelement.AppendChild(xCorrectAnswer);
        xelement.AppendChild(xMainSubject);

        xdoc.DocumentElement.AppendChild(xelement);
        xmlDocumentRepository.Save(path, xdoc);
        
    }
    private void StringToEnum(Question[] questionsArray)
    {
        for (int i = 0; i < questionsArray.Length; i++)
        {
            switch (questionsArray[i].correctAnswerSign)
            {
                case "A":
                    questionsArray[i].correctAnswer = Question.PossibleAnswer.A;
                    break;
                case "B":
                    questionsArray[i].correctAnswer = Question.PossibleAnswer.B;
                    break;
                case "C":
                    questionsArray[i].correctAnswer = Question.PossibleAnswer.C;
                    break;
                case "D":
                    questionsArray[i].correctAnswer = Question.PossibleAnswer.D;
                    break;
            }
        }
    }
    private string CorrectAnswerIntToString(int index)
    {
        string signCorrectAnswer = null;
        switch (index)
        {
            case 0: signCorrectAnswer = "A"; break;
            case 1: signCorrectAnswer = "B"; break;
            case 2: signCorrectAnswer = "C"; break;
            case 3: signCorrectAnswer = "D"; break;
        }

        return signCorrectAnswer;
    }
}
