using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerResultList : MonoBehaviour {

    public PlayerResult[] PlayerResultsList;
    public TextMeshProUGUI PlayerNameListView;
    public TextMeshProUGUI DateListView;
    public TextMeshProUGUI ScoreListView;
    string path = @"FileXML\highScore.xml";

    void Start()
    {
        string path = @"FileXML\highScore.xml";
        ReadXmlFile(path);
        ShowResults();
    }

    public void Return()
    {
        SceneManager.LoadScene("MenuScene");
    }

    //
    private void ReadXmlFile(string path)
    {
        XDocument doc = XDocument.Load(Path.GetFullPath(path));
        var reslutsArray = doc.Descendants("Result").Select(x => new PlayerResult
        {
            PlayerName = x.Element("PlayerName").Value,
            Date = x.Element("Date").Value,
            Score = Convert.ToInt32(x.Element("Score").Value)

        }).OrderBy(x => x.Score).ToArray();
        Array.Reverse(reslutsArray);
        PlayerResultsList = reslutsArray;

    }

    private void ShowResults ()
    {
        string PlayerNames=null;
        string Dates=null;
        string Scores=null;

        int countRecords = PlayerResultsList.Count();
        if(countRecords < 10)
        {
            for (int i = 0; i < countRecords; i++)
            {
                PlayerNames += string.Format("{0}. {1}", i+1,PlayerResultsList[i].PlayerName) + Environment.NewLine;
                Dates += string.Format("{0}", PlayerResultsList[i].Date) + Environment.NewLine;
                Scores += string.Format("{0}", PlayerResultsList[i].Score) + Environment.NewLine;
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                PlayerNames += string.Format("{0}. {1}",i+1, PlayerResultsList[i].PlayerName) + Environment.NewLine;
                Dates += string.Format("{0}", PlayerResultsList[i].Date) + Environment.NewLine;
                Scores += string.Format("{0}", PlayerResultsList[i].Score) + Environment.NewLine;
            }
        }
       

        PlayerNameListView.text = PlayerNames;
        DateListView.text = Dates;
        ScoreListView.text = Scores;

    }

    
}
