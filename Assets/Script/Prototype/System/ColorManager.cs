using UnityEngine;

[System.Serializable]
public class ColorManager
{
    // Components
    private SkinnedMeshRenderer playerRenderer;
    private MeshRenderer objectsRenderer;

    // Attributes
    [SerializeField] private ObjectColor currentColor;

    public void Initialize(SkinnedMeshRenderer rend)
    {
        playerRenderer = rend; // Set the mesh renderer
        UpdateSkinnedMeshColor();
    }

    public void InitializeObjectRenderer(MeshRenderer rend)
    {
        objectsRenderer = rend;
        UpdateMeshColor();
    }

    public void UpdateSkinnedMeshColor()
    {
        if (playerRenderer == null)
        {
            return;
        }

        switch (currentColor)
        {
            case ObjectColor.BLUE:
                playerRenderer.material.SetColor("_Color", Color.blue);
                break;
            case ObjectColor.GREEN:
                playerRenderer.material.SetColor("_Color", Color.green);
                break;
            case ObjectColor.MAGENTA:
                Color magentaMaterial = new Color32(85, 47, 150, 255);
                ColorUtility.TryParseHtmlString("#4f2194", out magentaMaterial);
                playerRenderer.material.SetColor("_Color", magentaMaterial);
                break;
            case ObjectColor.RED:
                playerRenderer.material.SetColor("_Color", Color.red);
                break;
            case ObjectColor.YELLOW:
                Color yellowMaterial = new Color32(255, 195, 76, 255);
                ColorUtility.TryParseHtmlString("#ffc337", out yellowMaterial);
                playerRenderer.material.SetColor("_Color", yellowMaterial);
                break;
        }
    }

    public void UpdateMeshColor()
    {
        if (objectsRenderer == null)
        {
            return;
        }

        switch (currentColor)
        {
            case ObjectColor.BLUE:
                objectsRenderer.material.SetColor("_Color", Color.blue);
                break;
            case ObjectColor.GREEN:
                objectsRenderer.material.SetColor("_Color", Color.green);
                break;
            case ObjectColor.MAGENTA:
                Color magentaMaterial = new Color32(85, 47, 150, 255);
                ColorUtility.TryParseHtmlString("#4f2194", out magentaMaterial);
                objectsRenderer.material.SetColor("_Color", magentaMaterial);
                break;
            case ObjectColor.RED:
                objectsRenderer.material.SetColor("_Color", Color.red);
                break;
            case ObjectColor.YELLOW:
                Color yellowMaterial = new Color32(255, 195, 76, 255);
                ColorUtility.TryParseHtmlString("#ffc337", out yellowMaterial);
                objectsRenderer.material.SetColor("_Color", yellowMaterial);
                break;
        }
    }

    public void SwapObjectColors(ColorManager obj1, ColorManager obj2)
    {
        ObjectColor temp = obj1.GetCurrentColor();
        obj1.SetCurrentColor(obj2.GetCurrentColor());
        obj2.SetCurrentColor(temp);
    }

    #region Getters and Setters
    public ObjectColor GetCurrentColor()
    {
        return currentColor;
    }

    public void SetCurrentColor(ObjectColor val)
    {
        currentColor = val;
        UpdateSkinnedMeshColor();
        UpdateMeshColor();
    }
    #endregion
}