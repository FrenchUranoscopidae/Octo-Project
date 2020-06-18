using UnityEngine;

[System.Serializable]
public class ColorManager
{
    // Components
    public PlayerManager alienMaterial;
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
            case ObjectColor.Null:
                break;
            case ObjectColor.BLUE:
                playerRenderer.material.SetColor("_Color", Color.blue);
                break;
            case ObjectColor.GREEN:
                playerRenderer.material.SetColor("_Color", Color.green);
                break;
            case ObjectColor.MAGENTA:
                //Color magentaMaterial = new Color32(85, 47, 150, 255);
                //ColorUtility.TryParseHtmlString("#521aab", out magentaMaterial);
                playerRenderer.material.mainTexture = alienMaterial.alienMagentaTexture;
                //playerRenderer.material.SetColor("_Color", magentaMaterial);
                break;
            case ObjectColor.RED:
                playerRenderer.material.SetColor("_Color", Color.red);
                break;
            case ObjectColor.YELLOW:
                //Color yellowMaterial = new Color32(255, 195, 76, 255);
                //ColorUtility.TryParseHtmlString("#ffc337", out yellowMaterial);
                playerRenderer.material.mainTexture = alienMaterial.alienYellowTexture;
                //playerRenderer.material.SetColor("_Color", yellowMaterial);
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
            case ObjectColor.Null:
                break;
            case ObjectColor.BLUE:
                objectsRenderer.material.SetColor("_Color", Color.blue);
                break;
            case ObjectColor.GREEN:
                objectsRenderer.material.SetColor("_Color", Color.green);
                break;
            case ObjectColor.MAGENTA:
                Color magentaMaterial = new Color32(85, 47, 150, 255);
                ColorUtility.TryParseHtmlString("#7859c7", out magentaMaterial);
                objectsRenderer.material.SetColor("_Color", magentaMaterial);
                break;
            case ObjectColor.RED:
                objectsRenderer.material.SetColor("_Color", Color.red);
                break;
            case ObjectColor.YELLOW:
                Color yellowMaterial = new Color32(255, 195, 76, 255);
                ColorUtility.TryParseHtmlString("#ffbe31", out yellowMaterial);
                objectsRenderer.material.SetColor("_Color", yellowMaterial);
                break;
        }
    }

    public void SwapObjectColors(ColorManager obj)
    {
        /*ObjectColor temp = obj1.GetCurrentColor();
        obj1.SetCurrentColor(obj2.GetCurrentColor());
        obj2.SetCurrentColor(temp);*/
        
        if(obj.currentColor == ObjectColor.YELLOW)
        {
            obj.SetCurrentColor(ObjectColor.MAGENTA);
        }
        else
        {
            obj.SetCurrentColor(ObjectColor.YELLOW);
        }
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