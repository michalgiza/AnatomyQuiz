using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : BaseSingletonObject
{
    //życia, licznik pytan, punkty, po odpowiedzeniu na wszystkie pytania gratulacje
    //
    public Question[] questions;
    public bool isCorrect;
    public float timeToAnswer = 8f;
    public bool currentAnswerTimeEnd;
    public float currentQuestionTime;
    public float QuestionOffset;
    public int LivesMax = 3;
    public int LivesLeft;

    //
    public delegate void BadAnswer();
    public event BadAnswer OnBadAnswer = delegate { };

    //
    private Question currentQuestion;
    public int score;
    private List<Question> unAnsweredQuestions;

    // Use this for initialization
    protected override void InitInternal()
    {
        unAnsweredQuestions = questions.ToList();
        score = 0;
        isCorrect = false;
        currentAnswerTimeEnd = false;
        QuestionOffset = 2f;
        
    }

    
    public Question GetRandomQuestion()
    {

        if (unAnsweredQuestions.Count != 0)
        {
            int randomIndex = Random.Range(0, unAnsweredQuestions.Count - 1);
            currentQuestion = unAnsweredQuestions[randomIndex];
            unAnsweredQuestions.RemoveAt(randomIndex);
        }
        else
        {
            unAnsweredQuestions = questions.ToList();
        }

        return currentQuestion;
    }

    public void ResetUnansweredQuestions()
    {
        unAnsweredQuestions = questions.ToList();
    }
    public void AddPointsToScore(int points)
    {
        score += points;
    }

    public void RemovePointsFromScore(int points)
    {
        score -= points;
    }

    //
    public void EndGame()
    {
        score = 0;
        unAnsweredQuestions = questions.ToList();
    }

    //
    public bool CheckAnswer_AndIfItsEnd(Question.PossibleAnswer answer)
    {
        int score = (int)currentQuestionTime * 10;
        if (answer == currentQuestion.correctAnswer)
        {
            AddPointsToScore(score);
            isCorrect = true;
            return false;
        }
        else
        {
            isCorrect = false;
            OnBadAnswer();
            LivesLeft -= 1;
            if (LivesLeft == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //
    public void SetButtonsActive(bool set)
    {
        AnswerClick[] buttons = Object.FindObjectsOfType<AnswerClick>();
        foreach (AnswerClick button in buttons)
        {
            button.GetComponent<Button>().interactable = set;
        }
    }
    
}
