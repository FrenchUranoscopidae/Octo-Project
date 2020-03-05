using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private ColorManager colorMgr;
    private bool canSwap = true;

    void Start()
    {
        colorMgr.Initialize(GetComponent<MeshRenderer>());
    }

    public void SwapColors(ColorManager playerColorMgr)
    {
        if (!canSwap) return; // Do nothing if we can't swap colors
        colorMgr.SwapObjectColors(playerColorMgr, colorMgr);
        StartCoroutine(SwapColorsTimer()); // Start the canSwap timer
    }

    private IEnumerator SwapColorsTimer()
    {
        canSwap = false;
        yield return new WaitForSeconds(1f);
        canSwap = true;
    }
}
