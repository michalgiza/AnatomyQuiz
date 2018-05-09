using System;
using System.Collections;
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

    public Image answerA;
    public Image answerB;
    public Image answerC;
    public Image answerD;

    public GameObject Clock;

    //
    private Question currentQuestion;
    private Question.PossibleAnswer answer;
    private Color BaseButtonColor;
    private Color GreenColor;
    private Color RedColor;
    private float time =0;

    //
    private void Start()
    {
        Singleton.QuizManager.SetButtonsActive(false);
        currentQuestion = Singleton.QuizManager.GetRandomQuestion();
        StartCoroutine(LoadQuestions());
        Singleton.EventManager.AddListener<AnswerClick.AnswerClickResult>(AnswerCheckedBehaviour);
        BaseButtonColor = answerA.color;
        GreenColor = new Color(0, 255, 0);
        RedColor = new Color(255, 0, 0);

    }

    //
    private void Update()
    {
        if(Singleton.QuizManager.currentAnswerTimeEnd)
        {
            ReloadQuesion();
            Singleton.QuizManager.currentAnswerTimeEnd = false;
        }
    }

    //
    private void AssignAnswers(string A, string B, string C, string D)
    {
        answerA_Tekst.text = A;
        answerB_Tekst.text = B;
        answerC_Tekst.text = C;
        answerD_Tekst.text = D;
    }

    //
    private void AssignQuestion(string question)
    {
        questionTekst.text = question;
    }

    //
    private IEnumerator LoadQuestions()
    {
        AssignQuestion(currentQuestion.question);
        AssignAnswers(String.Empty, String.Empty, String.Empty, String.Empty);
        Clock.SetActive(true);

        while (time < Singleton.QuizManager.QuestionOffset)
        {
            time = time + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Singleton.QuizManager.SetButtonsActive(true);
        AssignAnswers(currentQuestion.answerA, currentQuestion.answerB, currentQuestion.answerC, currentQuestion.answerD);
        time = 0f;

    }

    //
    private void AnswerCheckedBehaviour(AnswerClick.AnswerClickResult evt)
    {
        Singleton.QuizManager.SetButtonsActive(false);
        Singleton.QuizManager.CheckAnswer(evt.answer);
        Clock.GetComponent<Counter>().StopClock(true);
        StartCoroutine(AfterAnswerBehawiour(evt));
    }

    //
    private void ReloadQuesion()
    {
        ResetColor();
        currentQuestion = Singleton.QuizManager.GetRandomQuestion();
        Clock.SetActive(false);
        StartCoroutine(LoadQuestions());
    }

    //
    private IEnumerator AfterAnswerBehawiour(AnswerClick.AnswerClickResult evt)
    {
        float timeToBlink = 3f;
        float currentTime = 0f;
        float blinkFrequency = 0.25f;
        float currentBlinkFrequency = 0f;

        while (currentTime < timeToBlink)
        {
            currentTime += Time.deltaTime;
            currentBlinkFrequency += Time.deltaTime;

            if(currentBlinkFrequency > blinkFrequency)
            {
                ChangeColors(evt);
                currentBlinkFrequency = 0f;
            }
            yield return new WaitForEndOfFrame();
        }
        ReloadQuesion();
    }

    //
    private void ChangeColors(AnswerClick.AnswerClickResult evt)
    {
        Question.PossibleAnswer correctAnswer = currentQuestion.correctAnswer;

        if(evt.answer == correctAnswer)
        {
            Blink(ButtonRelationToAnswer(evt.answer), true);
        }
        else
        {
            Blink(ButtonRelationToAnswer(evt.answer), false);
            Blink(ButtonRelationToAnswer(correctAnswer), true);
        }
    }

    //
    private void Blink(Image image, bool good)
    {
        if (good)
        {
            if (image.color == BaseButtonColor)
            {
                image.color = GreenColor;
            }
            else
            {
                image.color = BaseButtonColor;
            }
        }
        else
        {
            if (image.color == BaseButtonColor)
            {
                image.color = RedColor;
            }
            else
            {
                image.color = BaseButtonColor;
            }

        }
    }

    //
    private void ResetColor()
    {
        answerA.color = BaseButtonColor;
        answerB.color = BaseButtonColor;
        answerC.color = BaseButtonColor;
        answerD.color = BaseButtonColor;
    }

    //
    private Image ButtonRelationToAnswer(Question.PossibleAnswer answer)
    {
        switch (answer)
        {
            case Question.PossibleAnswer.A:
                return answerA;
            case Question.PossibleAnswer.B:
                return answerB;
            case Question.PossibleAnswer.C:
                return answerC;
            case Question.PossibleAnswer.D:
                return answerD;
            default:
                return null;
        }

    }

    //
    private void OnDestroy()
    {
        Singleton.EventManager.RemoveListener<AnswerClick.AnswerClickResult>(AnswerCheckedBehaviour);
    }
}
