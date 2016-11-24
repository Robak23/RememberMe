using System;
using UnityEngine;
using System.Collections;
using System.Xml;

public class GameFlow : MonoBehaviour
{
    public GameObject AIPlayer;
    public GameObject Player;
    public GameObject Logo;

    private XmlDocument _saveFile;

    private GameObject _aiPlayer;
    private GameObject _player;
    private GameObject _logo;

    private bool _playerSpawned;

    void Start ()
	{
	    LoadSaveFile();
        _aiPlayer = new GameObject();
        _player = new GameObject();
        ShowMainMenu();
    }

    private void LoadSaveFile()
    {
        _saveFile = new XmlDocument();
        _saveFile.Load("StaticFiles/SaveFile.xml");
        
    }

    private void DeactivateBoardAnimation()
    {
        var boardElements = GameObject.FindGameObjectsWithTag("Board");
        foreach (var boardElement in boardElements)
        {
            boardElement.GetComponentInChildren<Animator>().SetBool("Active", false);
        }
    }

    void Update ()
    {
        if (_aiPlayer == null && !_playerSpawned)
        {
            DeactivateBoardAnimation();
            SpawnPlayer();
        }
    }

    public void StartButtonClicked(GameObject button)
    {
        button.gameObject.SetActive(false);
        Destroy(_logo.gameObject);
        SpawnBoard();
        SpawnAIPlayer();
    }

    private void SpawnPlayer()
    {
        _playerSpawned = true;
        _player = (GameObject) Instantiate(Player, new Vector3(0, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
        var save = _saveFile["Save"];
        _player.GetComponentInChildren<Renderer>().material.mainTexture = Resources.Load<Texture>(save["Texture"].InnerText);
    }

    private void SpawnAIPlayer()
    {
        _aiPlayer = (GameObject)Instantiate(AIPlayer, new Vector3(0, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
        var aiPlayerPath = _aiPlayer.GetComponent<AIPlayPath>();
        aiPlayerPath.Initialize(gameObject.GetComponent<SpawnBoard>().PathWay);
        aiPlayerPath.PauseTime = 500; // change depending on level
        _aiPlayer.GetComponent<AIPlayPath>().StartPlayingPath = true;
    }

    private void SpawnBoard()
    {
        var save = _saveFile["Save"];
        gameObject.GetComponent<SpawnBoard>().Spawn(Convert.ToInt32(save["Level"].InnerText));
    }

    private void ShowMainMenu()
    {
       _logo = (GameObject)Instantiate(Logo, new Vector3(-7, 3f, 0), new Quaternion(0f, 0f, 0f, 0f));
    }
}
