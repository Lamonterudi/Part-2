using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge;
    Vector2 direction;
    TextMeshProUGUI ScoreUi;
    public static SelectPlayer CurrentSelection { get; private set; } // will make football players be picked 1 at a time get is public
    public static int score = 0; // Static variable to hold the score


    private void Start()
    {

     
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            CurrentSelection.Move(direction);
            direction = Vector2.zero;
        }
    }
    public static void SetCurrentSelection(SelectPlayer player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }

        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }
  
   
    private void Update()
    {
        //will display the score on UI
        ShowScore.ScoreUi.text = "Score: " + score;

        if (CurrentSelection == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)CurrentSelection.transform.position).normalized * charge;
        }
    }

}