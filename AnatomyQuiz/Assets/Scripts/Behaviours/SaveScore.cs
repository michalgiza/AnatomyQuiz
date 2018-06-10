using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour {

    public InputField PlayerName;
    public GameObject SaveScoreBoard;
    public GameObject EndGameBoard;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI NewHighScore;
    private PlayerResultList playerResultList;


    private int score;

    

    public void ShowSaveScoreWindow()
    {
        SaveScoreBoard.SetActive(true);
        EndGameBoard.SetActive(false);
        score = Singleton.QuizManager.score;
        Score.text +=  score;
        if(GetMax(score))
        {
            NewHighScore.text +="Gratulacje! Ustanowiles nowy rekord!";
        }
        else
        {
            NewHighScore.text += "";
        }
        
    }

    public void SaveScoreToXml()
    {
        
        DateTime today = DateTime.Now;
        string path = @"FileXML\highScore.xml";
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(Path.GetFullPath(path));

        XmlElement xResult = xdoc.CreateElement("Result");
        XmlElement xPlayerName = xdoc.CreateElement("PlayerName");
        XmlElement xDateTime = xdoc.CreateElement("Date");
        XmlElement xScore = xdoc.CreateElement("Score");

        xPlayerName.InnerText = PlayerName.text;
        xDateTime.InnerText = String.Format("{0}-{1}-{2}",today.Day,today.Month,today.Year);
        xScore.InnerText = score.ToString();

        xResult.AppendChild(xPlayerName);
        xResult.AppendChild(xDateTime);
        xResult.AppendChild(xScore);

        xdoc.DocumentElement.AppendChild(xResult);
        xdoc.Save(Path.GetFullPath(path));

        SceneManager.LoadScene("MenuScene");
    }
    public bool GetMax(int score)
    {
        string path = @"FileXML\highScore.xml";
        XDocument doc = XDocument.Load(Path.GetFullPath(path));
        var reslutsArray = doc.Descendants("Result").Select(x => new PlayerResult
        {
            PlayerName = x.Element("PlayerName").Value,
            Date = x.Element("Date").Value,
            Score = Convert.ToInt32(x.Element("Score").Value)

        }).Max(x => x.Score);

        if (score <= reslutsArray)
            return false;
        else
            return true;
    }

}
