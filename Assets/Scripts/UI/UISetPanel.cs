using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetPanel : MonoBehaviour
{
    public Slider fireSlider;

    // Start is called before the first frame update
    void Start()
    {
        fireSlider.value = GameData.Instance.fireValue;
        fireSlider.onValueChanged.AddListener(OnChangeFireSlider);
    }

    private void OnChangeFireSlider(float value)
    {
        GameData.Instance.fireValue = value;
        GameMgr.Instance.optionFire.SetFireValue(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
