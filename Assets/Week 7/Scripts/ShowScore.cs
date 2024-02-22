using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class ShowScore : MonoBehaviour
{
    public static TextMeshProUGUI ScoreUi;

    void Start()
    {
        ScoreUi = gameObject.GetComponent<TextMeshProUGUI>();

    }
}