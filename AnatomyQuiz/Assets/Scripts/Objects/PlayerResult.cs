using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerResult
{
    [XmlElement("PlayerName")]
    public string PlayerName { get; set; }
    [XmlElement("Date")]
    public string Date { get; set; }
    [XmlElement("Score")]
    public int Score { get; set; }
	
}
