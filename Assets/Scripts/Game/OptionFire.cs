using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OptionFire : MonoBehaviour
{
    public GameObject openObj;
    public AudioSource ziziAudioSource;
    private Transform ziziTsfm;

    public Transform rayTsfm;
    public float rayLength = 1f;
    public ChangeFireEffect changeFireEffect;

    //public PaintCustom paintCustom;
    public GameObject paintObj;

    private void Awake()
    {
        GameData.Instance.isOpenFire = false;
        ziziTsfm = ziziAudioSource.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // add open/close fire listener
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
            grabInteractable.activated.AddListener(OnClickFire);
        
        // init fire value
        SetFireValue(GameData.Instance.fireValue);
        
        PaintCore.CwStateManager.PotentiallyStoreAllStates();
    }

    // open/close fire
    private void OnClickFire(ActivateEventArgs args)
    {
        GameData.Instance.isOpenFire = !GameData.Instance.isOpenFire;
        openObj.SetActive(GameData.Instance.isOpenFire);

        if (!GameData.Instance.isOpenFire)
        {
            OnFireRaycast(false);
        }
    }

    // set fire value
    public void SetFireValue(float value)
    {
        // change fire effect
        float scale = Mathf.Lerp(GameData.minFireScale, GameData.maxFireScale, value);
        changeFireEffect.UpdateScale(scale);

        // change paint color and radius
        //Color color = Color.white;
        //color.a = UnityEngine.Random.Range(0f, 1f);
        //color.g = UnityEngine.Random.Range(0f, 1f);
        //color.b = UnityEngine.Random.Range(0f, 1f);
        //paintCustom.ChangeColor(color);

        //float radius = Mathf.Lerp(GameData.minPaintRadius, GameData.maxPaintRadius, value);
        //paintCustom.ChangeRadius(radius);
    }

    int a = 1;
    private void Update()
    {
        // pc test
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            OnClickFire(null);
        }

        if (GameData.Instance.isOpenFire)
        {
            a++;
            Ray ray = new Ray(rayTsfm.position, rayTsfm.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
            {
                if (hit.transform.CompareTag("Target"))
                {
                    ziziTsfm.position = hit.point;
                    OnFireRaycast(true);

                    // todo: change color
                    
                    return;
                }                
            }

            OnFireRaycast(false);
        }
    }

    // check fire ray event
    private void OnFireRaycast(bool isRay)
    {
        if (isRay)
        {
            // open
            if (!ziziAudioSource.isPlaying) ziziAudioSource.Play(); // audio
            if (!paintObj.activeSelf) paintObj.SetActive(true); // paint
        }
        else
        {
            // close
            if (ziziAudioSource.isPlaying) ziziAudioSource.Stop();
            if (paintObj.activeSelf) paintObj.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        // debug ray line
        Debug.DrawRay(rayTsfm.position, rayTsfm.forward * rayLength, Color.green);
    }
}
