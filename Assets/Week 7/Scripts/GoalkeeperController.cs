using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
   Rigidbody2D rb;
    public GameObject goalKeeper;
    Vector2 direction;
    public float GoalieDistance; 
    public float GoalieSpeed;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }
}
