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

    public IXmlDocumentDataObject xmlDocumentDataObject = new XmlDocumetnDataObject();
    public InputField PlayerName;
    public GameObject SaveScoreBoard;
    public GameObject EndGameBoard;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI NewHighScore;
    public GameObject DialogBox;
    private PlayerResultList playerResultList;
    public Button OK;


    private int score;



    public void ShowSaveScoreWindow()
    {
        string path = @"FileXML\highScore.xml";
        SaveScoreBoard.SetActive(true);
        EndGameBoard.SetActive(false);
        score = Singleton.QuizManager.score;
        Score.text += score;
        if (xmlDocumentDataObject.GetMax(path,score))
        {
            NewHighScore.text += "Gratulacje! Ustanowiles nowy rekord!";
        }
        else
        {
            NewHighScore.text += "";
        }

    }

    public void SaveScoreToXml(string path)
    {
        path =  @"FileXML\highScore.xml";
        if (PlayerName.text == "" || PlayerName.text == null)
        {
            DialogBox.SetActive(true);
            return;
            
        }
        xmlDocumentDataObject.SaveScore(path, PlayerName.text, score);
        SceneManager.LoadScene("MenuScene");
    }


    public void ClickButtonOk()
    {
        DialogBox.SetActive(false);
    }

}
