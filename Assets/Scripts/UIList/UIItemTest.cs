using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIBase;
using UnityEngine.UI;

public class UIItemTest : UIItem
{
    public RawImage rawImage;
    public Text dateText;
    
    public override void OnUpdateItem<T>(int index, T itemData)
    {
        UIListDataTest data = itemData as UIListDataTest;
        rawImage.texture = data.texture;
        dateText.text = data.date;
    }
}