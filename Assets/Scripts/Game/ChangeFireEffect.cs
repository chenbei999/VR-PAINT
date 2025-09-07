using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFireEffect : MonoBehaviour
{
    public Transform[] effectList;

    public void UpdateScale(float scale)
    {
        foreach(Transform effect in effectList)
        {
            if (effect == null) continue;

            effect.localScale = new Vector3(scale, scale, scale);
        }
    }
}
