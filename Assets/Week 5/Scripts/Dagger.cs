using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
   public float speed = 5f; 
    Rigidbody2D rb;
    float MaxTime = 5f;
    float TimePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

   
    // Update is called once per frame
    void Update()
    {

        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        TimePassed += Time.deltaTime; //increments timepassed time
        if (TimePassed >= MaxTime) //checks when time passed gets to 5 seconds for dagger to disappear or get destoryed. 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 3, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
