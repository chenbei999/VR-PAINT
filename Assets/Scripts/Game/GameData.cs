using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData
{
    private static GameData instance;
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }

    public bool isOpenFire;

    public float fireValue = 0.5f;
    public const float minFireScale = 0.03f;
    public const float maxFireScale = 0.1f;

    public const float minPaintRadius = 0.01f;
    public const float maxPaintRadius = 0.05f;

    public List<UIListDataTest> textureList = new List<UIListDataTest>();
}