using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public GameObject kickOff;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
     rb =   GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // call the scored function in trigger
        Scored();
    }
    void Scored()
    {
        Controller.score++;
        
        transform.position = kickOff.transform.position;
        rb.velocity = Vector2.zero;
    }

}
