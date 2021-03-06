﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class SpawnBoard : MonoBehaviour
{
    public List<int> PathWay;

    public GameObject BoardCube;

    public void Spawn(int levelId)
    {
        XmlDocument levels = new XmlDocument();
        levels.Load("StaticFiles/Levels.xml");

        var level = levels.SelectSingleNode(string.Format("//*[@id='{0}']", levelId));

        // Read board size
        var boardSize = level["BoardSize"];
        int xSize = Convert.ToInt32(boardSize["x"].InnerText);
        int zSize = Convert.ToInt32(boardSize["z"].InnerText);

        // Read path
        string pathString = level["Path"].InnerText;
        PathWay = pathString.Split(',').Select(jump => Convert.ToInt32(jump)).ToList();

        // Read Texture
        string textureName = String.Format("Textures/" + level["BoardTexture"].InnerText);

        for (var i = 0; i < xSize; i++)
        {
            for (var j = 0; j < zSize; j++)
            {
                var boardElement =
                    (GameObject) Instantiate(BoardCube, new Vector3(i, -1, j), new Quaternion(0f, 0f, 0f, 0f));
                boardElement.GetComponentInChildren<Renderer>().material.mainTexture = Resources.Load<Texture>(textureName);
            }
        }
    }
}
