using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using PaintIn3D;
public class MaterialTextureModifier : MonoBehaviour
{
    [Header("目标材质球")]
    //public Material targetMaterial;
    public Texture texture;
    [Header("自动查找组件材质")]
    public bool autoFindMaterial = true;
    public CwPaintableMeshTexture cwPaintableMeshTexture;
    void Start()
    {
     

     
    }

    /// <summary>
    /// 将材质球的主贴图填充为纯白色
    /// </summary>
    public void FillMainTextureWithWhite()
    {
        

        // 获取主贴图
        Texture mainTexture = texture;

        // 检查贴图类型
        if (mainTexture is Texture2D texture2D)
        {
            FillTexture2DWithWhite(texture2D);
        }

    }

    /// <summary>
    /// 填充Texture2D为纯白色
    /// </summary>
    /// <param name="texture">目标贴图</param>
    private void FillTexture2DWithWhite(Texture2D texture)
    {
        
         

            // 获取贴图尺寸
            int width = texture.width;
            int height = texture.height;

            // 创建白色像素数组
            Color[] whitePixels = new Color[width * height];
            for (int i = 0; i < whitePixels.Length; i++)
            {
                whitePixels[i] = Color.white;
            }

            // 应用像素到贴图
            texture.SetPixels(whitePixels);
            texture.Apply();

            Debug.Log($"成功将贴图填充为纯白色 (尺寸: {width}x{height})");
        
    
    }

    /// <summary>
    /// 创建新的白色贴图并分配给材质球
    /// </summary>
   

    /// <summary>
    /// 创建指定尺寸的白色贴图
    /// </summary>
    /// <param name="width">宽度</param>
    /// <param name="height">高度</param>
    /// <returns>白色贴图</returns>
    public static Texture2D CreateWhiteTexture(int width, int height)
    {
        Texture2D whiteTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);

        // 填充白色像素
        Color[] whitePixels = new Color[width * height];
        for (int i = 0; i < whitePixels.Length; i++)
        {
            whitePixels[i] = Color.white;
        }

        whiteTexture.SetPixels(whitePixels);
        whiteTexture.Apply();

        return whiteTexture;
    }

    /// <summary>
    /// 在编辑器中也可以调用的方法
    /// </summary>
    [ContextMenu("填充主贴图为白色")]
    public void FillMainTextureWithWhiteContextMenu()
    {
        FillMainTextureWithWhite();
    }
}
