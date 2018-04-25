using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

public class QuestionList : MonoBehaviour
{
    public Question[] questions;
    // Use this for initialization
    void Start ()
    {
        //należay zmienić ścieżkę na waszą lokalną
        ReadXmlFile(@"E:\git_projekty\anatomyQuiz\AnatomyQuiz\AnatomyQuiz\AnatomyQuiz\Questions\plik.xml");
        Singleton.QuizManager.questions = this.questions;
	}

    //
    private void ReadXmlFile(string path)
    {
        XDocument doc = XDocument.Load(path);
        var questionsArray = doc.Descendants("Question").Select(x => new Question
        {
            question = x.Element("Tresc").Value,
            answerA = x.Element("AnswerA").Value,
            answerB = x.Element("AnswerB").Value,
            answerC = x.Element("AnswerC").Value,
            answerD = x.Element("AnswerD").Value,
            correctAnswerSign=x.Element("PoprawnaOdpowiedz").Value

        }).ToArray();
        StringToEnum(questionsArray);
         questions = questionsArray;
    }

    //
    private void StringToEnum(Question [] questionsArray)
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
    }

