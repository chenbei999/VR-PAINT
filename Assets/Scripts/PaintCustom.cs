using PaintCore;
using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PaintCustom : MonoBehaviour
{
    public ParticleSystem Target;
    public CwPaintSphere paintSphere;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        Target.Play();
    }

    private void OnDisable()
    {
        Target.Stop();
    }

    // change paint color
    public void ChangeColor(Color color)
    {
        paintSphere.Color = color;
    }

    // change paint radius
    public void ChangeRadius(float radius)
    {
        paintSphere.Radius = radius;
    }
}
