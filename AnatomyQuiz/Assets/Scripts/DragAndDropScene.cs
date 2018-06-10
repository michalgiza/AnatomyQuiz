using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragAndDropScene : MonoBehaviour {
    Component[] component;
    protected GameObject canvasGame;
    protected GameObject canvasTutorial;
    static string modeTypeStatic = null;
    static bool firstEntry;
    static Sprite[] bodyElementsSprites, systemsSprites;
    static List<Image> imgSystem;
    List<int> elements = new List<int>();
    Sprite[] images = new Sprite[3];
    bool filled, matchedRight;
    bool showNote = false;
    public void ButtonClick(string modeType)
    {
        firstEntry = true;
        modeTypeStatic = modeType;
        SceneManager.LoadScene("DragDropScene");
    }

    public void messageButtonClick()
    {
        SceneManager.LoadScene("InitDragAndDropScene");
    }

    public void messageReturnButtonClick()
    {
        SceneManager.LoadScene("InitDragAndDropScene");
    }
    public void TutorialOkButtonClick()
    {
        component.Where(x => x.name.ToString() == "canvasGame").ToList()[0].gameObject.SetActive(true);
        component.Where(x => x.name.ToString() == "canvasTutorial").ToList()[0].gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
    
        if (modeTypeStatic != null)
        {
            component = GetComponentsInChildren(typeof(Canvas), true);
            Image[] imgComponent2 = GetComponentsInChildren<Image>(true);
            imgSystem = imgComponent2.Where(x => x.name.ToString() == "imgSystem").ToList();
            imgSystem[0].color = new Color32(255, 255, 255, 0);

            if (firstEntry)
            {
                component.Where(x => x.name.ToString() == "messageCanvas").ToList()[0].gameObject.SetActive(false);
                component.Where(x => x.name.ToString() == "canvasGame").ToList()[0].gameObject.SetActive(false);
                component.Where(x => x.name.ToString() == "canvasTutorial").ToList()[0].gameObject.SetActive(true);
            }
          
            switch (modeTypeStatic)
            {
                    case "szkieletowy":
                        SelectOrgansForDragAndDrop("szkieletowy");
                        break;
                    case "nerwowy":
                        SelectOrgansForDragAndDrop("nerwowy");
                        break;
                    case "krazenia":
                        SelectOrgansForDragAndDrop("krazenia");
                        break;
                    case "oddechowy":
                        SelectOrgansForDragAndDrop("oddechowy");
                        break;
                    case "pokarmowy":
                        SelectOrgansForDragAndDrop("pokarmowy");
                        break;
            }
        }
	}

    // Update is called once per frame
    void Update () {

        MyImage[] imgComponent = GetComponentsInChildren<MyImage>(true);

        if (showNote)
        {
            showTeachingNote(modeTypeStatic);
            showNote = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (DragAndDropManager.matchArray.Length != 0)
            {
                filled = true;
                for (int i = 0; i < 3; i++)
                    if (DragAndDropManager.matchArray[i] == 0)
                        filled = false;

                if (filled)
                {
                    matchedRight = true;
                    for (int i = 0; i < 3; i++)
                    {

                        String name = "snapPoint" + (i + 1).ToString();
                        List<MyImage> snapPoint = imgComponent.Where(x => x.name.ToString() == name).ToList();
                        if (DragAndDropManager.matchArray[i] == i + 1)
                        {
                            snapPoint[0].color = new Color32(0, 255, 0, 100);
                        }
                        else
                        {
                            snapPoint[0].color = new Color32(255, 0, 0, 100);
                            matchedRight = false;
                        }
                    }
                    if (matchedRight)
                    {
                        imgSystem[0].color = new Color32(255, 255, 255, 255);
                        matchedRight = false;
                        showNote = true;
                        for (int i = 0; i < 3; i++)
                            DragAndDropManager.matchArray[i] = 0;

                    }
                }
            }
        }
    }

    private void showTeachingNote(string modeType)
    {
        component.Where(x => x.name.ToString() == "messageCanvas").ToList()[0].gameObject.SetActive(true);

        Text[] txtComponent = GetComponentsInChildren<Text>(true);
       

        var variable = XDocument
           .Load(@"..\ciekawostki.xml")
           .Root
           .Descendants("element")
           .Where(x => x.Element("uklad").Value == modeType)
           .Select(x => x).ToList();
        int count = variable.Count();
        System.Random rand1 = new System.Random();

        int temp = rand1.Next(1, count + 1);
        var parameters = variable.Where(x => x.Element("nr").Value == temp.ToString()).Select(x=> x.Element("tresc").Value).ToList();

        txtComponent.Where(x => x.name.ToString() == "messageText").ToList()[0].text = parameters[0].ToString();

       
  
        
    }

    void SelectOrgansForDragAndDrop(string TypeOfSystem)
    {
        
        systemsSprites = Resources.LoadAll<Sprite>("Sprites");
        List<Sprite> systemSprite = systemsSprites.Where(x => x.name.ToString() == TypeOfSystem).ToList();

        imgSystem[0].sprite = systemSprite[0];


        bodyElementsSprites = Resources.LoadAll<Sprite>("Sprites/" + TypeOfSystem + "Elementy");
        MyImage[] imgComponent = GetComponentsInChildren<MyImage>(true);

        List<MyImage> snapPoint1 = imgComponent.Where(x => x.name.ToString() == "snapPoint1").ToList();
        List<MyImage> snapPoint2 = imgComponent.Where(x => x.name.ToString() == "snapPoint2").ToList();
        List<MyImage> snapPoint3 = imgComponent.Where(x => x.name.ToString() == "snapPoint3").ToList();
        List<MyImage> imgOrgan1 = imgComponent.Where(x => x.name.ToString() == "imgOrgan1").ToList();
        List<MyImage> imgOrgan2 = imgComponent.Where(x => x.name.ToString() == "imgOrgan2").ToList();
        List<MyImage> imgOrgan3 = imgComponent.Where(x => x.name.ToString() == "imgOrgan3").ToList();


        var variable = XDocument
            .Load(@"..\uklady.xml")
            .Root
            .Descendants("element")
            .Where(x => x.Element("uklad").Value == TypeOfSystem)
            .Select(x => x).ToList();

        int count = variable.Count();
        int temp = 0;
        System.Random rand1 = new System.Random();
        temp = rand1.Next(1, count+1);
        elements.Add(temp);

        for (int i = 1; i <= 2; i++)
        {
            temp = rand1.Next(1, count);
            int result = elements.Find(x => x == temp);
            if (result == 0)
                elements.Add(temp);
            else
                i--;
        }

        for (int i = 0; i <= 2; i++)
        {
            var parameters = variable.Where(x => x.Element("nr").Value == elements[i].ToString()).ToList();
            var posX = parameters.Select(x => x.Element("posX").Value).ToList();
            var posY = parameters.Select(x => x.Element("posY").Value).ToList();
            var width = parameters.Select(x => x.Element("width").Value).ToList();
            var height = parameters.Select(x => x.Element("height").Value).ToList();
            List<Sprite> img = bodyElementsSprites.Where(x => x.name.ToString() == elements[i].ToString()).ToList();

            switch (i)
            {
                case 0:
                    //snapPoint1[0].ElementNum = elements[i];
                    snapPoint1[0].gameObject.transform.position = new Vector3(344 / 2 + float.Parse(posX[0]), 612 / 2 + float.Parse(posY[0]));
                    imgOrgan1[0].sprite = img[0];
                    imgOrgan1[0].rectTransform.sizeDelta = new Vector2(float.Parse(width[0]), float.Parse(height[0]));
                    
                    //imgOrgan1[0].ElementNum = elements[i];
                    imgOrgan1[0].enabled = false;
                    imgOrgan1[0].enabled = true;
                    break;
                case 1:
                    //snapPoint2[0].ElementNum = elements[i];
                    snapPoint2[0].gameObject.transform.position = new Vector3(344 / 2 + float.Parse(posX[0]), 612 / 2 + float.Parse(posY[0]));
                    imgOrgan2[0].sprite = img[0];
                    imgOrgan2[0].rectTransform.sizeDelta = new Vector2(float.Parse(width[0]), float.Parse(height[0]));

                    //imgOrgan2[0].ElementNum = elements[i];
                    imgOrgan2[0].enabled = false;
                    imgOrgan2[0].enabled = true;
                    break;
                case 2:
                    //snapPoint3[0].ElementNum = elements[i];
                    snapPoint3[0].gameObject.transform.position = new Vector3(344 / 2 + float.Parse(posX[0]), 612 / 2 + float.Parse(posY[0]));
                    imgOrgan3[0].sprite = img[0];
                    imgOrgan3[0].rectTransform.sizeDelta = new Vector2(float.Parse(width[0]), float.Parse(height[0]));
                
                    //imgOrgan3[0].ElementNum = elements[i];
                    imgOrgan3[0].enabled = false;
                    imgOrgan3[0].enabled = true;
                    break;
            }
        }
    }
}
