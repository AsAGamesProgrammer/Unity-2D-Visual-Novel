using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Xml; //Needed for XML functionality
using System.Xml.Serialization; //Needed for XML Functionality
using System.IO;
using System.Xml.Linq; //Needed for XDocument

public class LoaderScript : MonoBehaviour {

    public TextAsset dialogXml;
    public Text testText;
    public Talk storyTellerScript;

    public string[] episodeNames;

    // Use this for initialization
    void Start ()
    {
        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(dialogXml.text); // load the file.
        XmlNodeList episodeList = xmlDoc.GetElementsByTagName("episode"); // array of the level nodes.

        episodeNames = new string[episodeList.Count];  //list of episode names
        int i = 0;

        foreach (XmlNode episodeInfo in episodeList)
        {
            XmlNodeList episodeContent = episodeInfo.ChildNodes;

            foreach (XmlNode levelsItens in episodeContent) // levels itens nodes.
            {
                if (levelsItens.Name == "name")
                {
                    episodeNames[i] = levelsItens.InnerText;
                    i++;
                }

                if (levelsItens.Name == "object")
                {
                    storyTellerScript.addToDialog(levelsItens.Attributes["name"].Value, levelsItens.InnerText);
                }
            }
        }

        testText.text = episodeNames[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
