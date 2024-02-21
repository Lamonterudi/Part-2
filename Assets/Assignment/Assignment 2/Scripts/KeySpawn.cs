using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
   
    Rigidbody2D rb;

    public GameObject KeyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //starts key prefab size at 0 
        transform.localScale = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
        //instantiates key prefab 
        KeyPrefab = Instantiate(KeyPrefab);
        KeyPrefab.transform.position = transform.position;

    }


    // Update is called once per frame
    void Update()
    {
       //checks when time passed gets to 5 seconds for dagger to disappear or get destoryed. 
    }
}
