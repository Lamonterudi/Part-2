using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public Color selectedColour;
    public Color unselectedColour;
    SpriteRenderer sr;

    // Start is called before the first frame update
    public void Start()
    {
      
        sr = GetComponent<SpriteRenderer>();
        Selected(false);

    
    }
    private void OnMouseDown()
    {
        Selected(true);
    }
    public void Selected( bool isSelected)
    {
     
            if(isSelected)
        {
            sr.color = selectedColour;

        }
        else
        {
            sr.color = unselectedColour;
        }
    }
}