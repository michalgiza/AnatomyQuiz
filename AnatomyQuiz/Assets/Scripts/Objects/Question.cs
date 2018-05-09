using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Question
{
    [XmlElement("Tresc")]
    public string question;
    [XmlElement("AnswerA")]
    public string answerA;
    [XmlElement("AnswerB")]
    public string answerB;
    [XmlElement("AnswerC")]
    public string answerC;
    [XmlElement("AnswerD")]
    public string answerD;
    [XmlElement("PoprawnaOdpowiedz")]
    public string correctAnswerSign;
    
    public PossibleAnswer correctAnswer;
    
    public MainSubject subjectOfAQuestion;

    public enum PossibleAnswer
    {
        A,
        B,
        C,
        D
    }

    public enum MainSubject
    {
        Brain,
        Heart,
        RespiratorySystem,
        ExcretorySystem,
        DigestiveSystem
    }
}
