using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : BaseSingletonObject
{
    //
    public Question[] questions;
    public bool isCorrect;
    public float timeToAnswer = 8f;
    public bool currentAnswerTimeEnd;
    public float QuestionOffset;

    //
    private Question currentQuestion;
    private int score;
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

    public void AddPointsToScore(int points)
    {
        score += points;
    }
    public void RemovePointsFromScore(int points)
    {
        score -= points;
    }

    public void EndGame()
    {
        score = 0;
        unAnsweredQuestions = questions.ToList();
    }

    public void CheckAnswer(Question.PossibleAnswer answer)
    {
        if (answer == currentQuestion.correctAnswer)
        {
            AddPointsToScore(50);
            isCorrect = true;
        }
        else
        {
            RemovePointsFromScore(50);
            isCorrect = false;
        }
    }

    public void SetButtonsActive(bool set)
    {
        AnswerClick[] buttons = Object.FindObjectsOfType<AnswerClick>();
        foreach (AnswerClick button in buttons)
        {
            button.GetComponent<Button>().interactable = set;
        }
    }

}
