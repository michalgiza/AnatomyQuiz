
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject QuizSelectBoard;
    public IXmlDocumentDataObject xmlDocumentDataObject = new XmlDocumetnDataObject();
    public string path = @"FileXML\questions.xml";
    public void PlayGame()
    {
        QuizSelectBoard.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
	 public void Option()
    {
        SceneManager.LoadScene("Option");
    }
    public void HighScore()
    {

        SceneManager.LoadScene("HighScore");
    }
    public void RandomQuiz()
    {
        Singleton.QuizManager.questions = xmlDocumentDataObject.GetAllQuestions(path);
        Singleton.QuizManager.ResetUnansweredQuestions();
        SceneManager.LoadScene("QuizScene");
    }
   
    public void AlimentaryQuiz()
    {
    
        Singleton.QuizManager.questions = xmlDocumentDataObject.GetQuestionsAbout(path, Question.MainSubject.AlimentarySystem);
        Singleton.QuizManager.ResetUnansweredQuestions();
        SceneManager.LoadScene("QuizScene");
        
    }
    public void SkeletalQuiz()
    {
        Singleton.QuizManager.questions = xmlDocumentDataObject.GetQuestionsAbout(path, Question.MainSubject.SkeletalSystem);
        Singleton.QuizManager.ResetUnansweredQuestions();
        SceneManager.LoadScene("QuizScene");
       
        
    }
    public void CirculatoryQuiz()
    {
        Singleton.QuizManager.questions = xmlDocumentDataObject.GetQuestionsAbout(path, Question.MainSubject.CirculatorySystem);
        Singleton.QuizManager.ResetUnansweredQuestions();
        SceneManager.LoadScene("QuizScene");
        
    }
    public void NervousQuiz()
    {
        Singleton.QuizManager.questions = xmlDocumentDataObject.GetQuestionsAbout(path, Question.MainSubject.NervousSystem);
        Singleton.QuizManager.ResetUnansweredQuestions();
        SceneManager.LoadScene("QuizScene");
       
    }
    public void RespiratoryQuiz()
    {
        Singleton.QuizManager.questions = xmlDocumentDataObject.GetQuestionsAbout(path, Question.MainSubject.RespiratorySystem);
        Singleton.QuizManager.ResetUnansweredQuestions();
        SceneManager.LoadScene("QuizScene");
        
    }

    
}
