using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IXmlDocumentDataObject
{
    Question[] GetAllQuestions(string path);
    void SaveScore(string path, string PlayerName, int score);
    bool GetMax(string path, int score);
    Question[] GetQuestionsAbout(string path, Question.MainSubject mainSubject);
    void SaveNewQuestion(string path, string Content, string AnswearA, string AnswearB, string AnswearC, string AnswearD, int correctAnswerInt, int mainSubjectSign);
}
