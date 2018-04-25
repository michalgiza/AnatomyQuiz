
using UnityEngine;
using UnityEngine.UI;

public class QuizViewController : MonoBehaviour
{
    //
    public Text questionTekst;
    public Text answerA_Tekst;
    public Text answerB_Tekst;
    public Text answerC_Tekst;
    public Text answerD_Tekst;

    //
    private Question currentQuestion;
    private Question.PossibleAnswer answer;

    //
    private void Start()
    {
        currentQuestion = Singleton.QuizManager.GetRandomQuestion();
        AssignStrings(currentQuestion.question, currentQuestion.answerA, currentQuestion.answerB, currentQuestion.answerC, currentQuestion.answerD);
        Singleton.EventManager.AddListener<AnswerClick.AnswerClickResult>(ReloadQuestion);
    }

    //
    private void AssignStrings(string question, string A, string B, string C, string D)
    {
        questionTekst.text = question;
        answerA_Tekst.text = A;
        answerB_Tekst.text = B;
        answerC_Tekst.text = C;
        answerD_Tekst.text = D;
    }
    

    private void ReloadQuestion(AnswerClick.AnswerClickResult evt)
    {
        Singleton.QuizManager.CheckAnswer(evt.answer);
        currentQuestion = Singleton.QuizManager.GetRandomQuestion();
        AssignStrings(currentQuestion.question, currentQuestion.answerA, currentQuestion.answerB, currentQuestion.answerC, currentQuestion.answerD);
    }

    private void OnDestroy()
    {
        Singleton.EventManager.RemoveListener<AnswerClick.AnswerClickResult>(ReloadQuestion);
    }
}
