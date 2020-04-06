using UnityEngine;

[System.Serializable]
public class ColorManager
{
    // Components
    private MeshRenderer renderer;

    // Attributes
    [SerializeField] private ObjectColor currentColor = ObjectColor.YELLOW;

    public void Initialize(MeshRenderer rend)
    {
        renderer = rend; // Set the mesh renderer
        UpdateMeshColor();
    }

    public void UpdateMeshColor()
    {
        if (renderer == null)
        {
            return;
        }

        switch (currentColor)
        {
            case ObjectColor.BLUE:
                renderer.material.SetColor("_Color", Color.blue);
                break;
            case ObjectColor.GREEN:
                renderer.material.SetColor("_Color", Color.green);
                break;
            case ObjectColor.MAGENTA:
                Color magentaMaterial = new Color32(85, 47, 150, 255);
                renderer.material.SetColor("_Color", magentaMaterial);
                break;
            case ObjectColor.RED:
                renderer.material.SetColor("_Color", Color.red);
                break;
            case ObjectColor.YELLOW:
                Color yellowMaterial = new Color32(255, 200, 80, 255);
                renderer.material.SetColor("_Color", yellowMaterial);
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
        UpdateMeshColor();
    }
    #endregion
}