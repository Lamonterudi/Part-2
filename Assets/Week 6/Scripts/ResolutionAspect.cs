using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAspect : MonoBehaviour
{
    public int width;
    public int height;
    // Start is called before the first frame update
    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }
    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }
    public void SetRes()
    {
        Screen.SetResolution(width, height, false);
    }
}