using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour {

    public InputField PlayerName;
    public GameObject SaveScoreBoard;
    public GameObject EndGameBoard;
   
    private int score;

    
       
        
    

    public void ShowSaveScoreWindow()
    {
        SaveScoreBoard.SetActive(true);
        EndGameBoard.SetActive(false);
    }

   
    public void SaveScoreToXml()
    {
        score = Singleton.QuizManager.score;
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
    
}
