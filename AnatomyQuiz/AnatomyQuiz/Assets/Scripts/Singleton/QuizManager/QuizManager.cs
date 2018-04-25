using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizManager : BaseSingletonObject
{
    //
    public Question[] questions;
    private Question currentQuestion;
    private int score;

    //
    private List<Question> unAnsweredQuestions;

    // Use this for initialization
    protected override void InitInternal()
    {
        unAnsweredQuestions = questions.ToList();
        score = 0;
    }

    public Question GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, unAnsweredQuestions.Count);
        currentQuestion = unAnsweredQuestions[randomIndex];
        unAnsweredQuestions.RemoveAt(randomIndex);

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
            AddPointsToScore(50);
        else
            RemovePointsFromScore(50);
    }

}
