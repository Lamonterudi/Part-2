using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagMoverR : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //make daggers go at random speeds
        transform.Translate(1 * Random.Range(1, 3) * speed * Time.deltaTime, 0, 0);
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //uses send message to indicaten player has taken damage by trigger of dagger 
        collision.gameObject.SendMessage("playerDamage", 2, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}