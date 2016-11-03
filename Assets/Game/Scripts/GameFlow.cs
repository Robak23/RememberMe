using System;
using UnityEngine;
using System.Collections;
using System.Xml;

public class GameFlow : MonoBehaviour
{
    public GameObject AIPlayer;
    public GameObject Player;

    private XmlDocument saveFile;

	void Start ()
	{
	    LoadSaveFile();
	    //ShowMainMenu();
	}

    private void LoadSaveFile()
    {
        saveFile = new XmlDocument();
        saveFile.Load("StaticFiles/SaveFile.xml");
    }

    void Update ()
    {
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Play"))
        {
            SpawnBoard();
            SpawnAIPlayer();
        }
    }

    private void SpawnAIPlayer()
    {
        var aiPlayer = (GameObject)Instantiate(AIPlayer, new Vector3(0, 0, 0), new Quaternion(0f, 0f, 0f, 0f));

        aiPlayer.GetComponent<AIPlayPath>().Initialize(gameObject.GetComponent<SpawnBoard>().PathWay);
        aiPlayer.GetComponent<AIPlayPath>().StartPlayingPath = true;
    }

    private void SpawnBoard()
    {
        var save = saveFile["Save"];
        gameObject.GetComponent<SpawnBoard>().Spawn(Convert.ToInt32(save["Level"].InnerText));
    }

    private void ShowMainMenu()
    {
        throw new System.NotImplementedException();
    }
}
