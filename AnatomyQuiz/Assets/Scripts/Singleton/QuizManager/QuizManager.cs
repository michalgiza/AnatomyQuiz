using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizManager : BaseSingletonObject
{
    //
    public Question[] questions;
    public bool isCorrect;

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

}
