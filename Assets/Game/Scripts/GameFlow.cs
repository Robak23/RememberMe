using UnityEngine;
using System.Collections;
using System.Xml;

public class GameFlow : MonoBehaviour
{
    private XmlDocument saveFile;

	void Start ()
	{
	    LoadSaveFile();
	    ShowMainMenu();
	    
	}

    private void LoadSaveFile()
    {
        saveFile = new XmlDocument();
        saveFile.Load("StaticFiles/SaveFile.xml");
    }

    void Update ()
    {
	
	}

    private void ShowMainMenu()
    {
        throw new System.NotImplementedException();
    }
}
