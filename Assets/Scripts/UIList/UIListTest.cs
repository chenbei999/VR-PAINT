using System;
using System.Collections;
using System.Collections.Generic;
using UIBase;
using UnityEngine;
using UnityEngine.UI;

public class UIListTest : UIList
{
    public Camera screenCamera;

    public void OnScreen()
    {
        UIListDataTest data = new UIListDataTest();
        data.date = DateTime.Now.ToString("HH:mm:ss fff");
        data.texture = CreateScreenTexture(screenCamera.targetTexture);

        GameData.Instance.textureList.Add(data);
    }

    private Texture CreateScreenTexture(RenderTexture rt)
    {
        RenderTexture activeRT = RenderTexture.active;
        RenderTexture.active = rt;

        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();

        RenderTexture.active = activeRT;

        return tex;
    }

    private void OnEnable()
    {
        UpdateList<UIListDataTest>(GameData.Instance.textureList);
    }
}


public class UIListDataTest
{
    public string date;
    public Texture texture;
}