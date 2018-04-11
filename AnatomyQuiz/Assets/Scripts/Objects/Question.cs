using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
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
