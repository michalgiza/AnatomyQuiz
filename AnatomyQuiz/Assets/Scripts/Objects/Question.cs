using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Question
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    
    public string answerD;
    
    public string correctAnswerSign;
    public int mainSubjectSign;
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
        NervousSystem = 1,
        CirculatorySystem = 2,
        RespiratorySystem = 3,
        AlimentarySystem = 4,
        SkeletalSystem= 5
    }
}
