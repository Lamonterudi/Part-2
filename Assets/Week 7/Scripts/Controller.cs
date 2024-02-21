using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
  public static SelectPlayer CurrentSelection {  get; private set; } // will make football players be picked 1 at a time get is public

    public static void SetCurrentSelection(SelectPlayer player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
                }

        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }
}
