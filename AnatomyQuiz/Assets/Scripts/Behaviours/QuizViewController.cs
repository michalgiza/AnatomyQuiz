using System;
using System.Collections;
using System.Collections.Generic;
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


    //
    private Question currentQuestion;
    private Question.PossibleAnswer answer;
    private Color BaseButtonColor;
    private Color NewColor;

    //
    private void Start()
    {
        currentQuestion = Singleton.QuizManager.GetRandomQuestion();
        AssignStrings(currentQuestion.question, currentQuestion.answerA, currentQuestion.answerB, currentQuestion.answerC, currentQuestion.answerD);
        Singleton.EventManager.AddListener<AnswerClick.AnswerClickResult>(AnswerCheckedBehaviour);
        BaseButtonColor = answerA.color;
        NewColor = new Color(0, 255, 0);
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
    
    //
    private void AnswerCheckedBehaviour(AnswerClick.AnswerClickResult evt)
    {
        Singleton.QuizManager.CheckAnswer(evt.answer);
        StartCoroutine(AfterAnswerBehawiour(evt));
    }

    //
    private void ReloadQuesiot()
    {
        ResetColor();
        currentQuestion = Singleton.QuizManager.GetRandomQuestion();
        AssignStrings(currentQuestion.question, currentQuestion.answerA, currentQuestion.answerB, currentQuestion.answerC, currentQuestion.answerD);
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
            if(currentBlinkFrequency> blinkFrequency)
            {
                ChangeColors(evt);
                currentBlinkFrequency = 0f;
            }
            yield return new WaitForEndOfFrame();
        }
        ReloadQuesiot();
    }

    //
    private void ChangeColors(AnswerClick.AnswerClickResult evt)
    {
        Question.PossibleAnswer correctAnswer = currentQuestion.correctAnswer;

        if(evt.answer == correctAnswer)
        {
            Blink(ButtonRelationToAnswer(evt.answer));
        }
        else
        {
            Blink(ButtonRelationToAnswer(correctAnswer));
            ButtonRelationToAnswer(evt.answer).color = new Color(255,0,0);
        }
    }

    //
    private void Blink(Image image)
    {
        if(image.color == BaseButtonColor)
        {
            image.color = NewColor;
        }
        else
        {
            image.color = BaseButtonColor;
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
