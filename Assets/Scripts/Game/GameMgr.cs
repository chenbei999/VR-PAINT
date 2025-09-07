using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr Instance;
    public OptionFire optionFire;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        
    }

    public void OnClearPaint()
    {
        PaintCore.CwStateManager.ClearAllStates();
    }
}