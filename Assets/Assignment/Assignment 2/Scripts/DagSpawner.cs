using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.Mathematics;

public class DagSpawner : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    float timePassed = 0;
    public GameObject daggerPrefab;
    public Transform spawnPoint;
    public float weaponDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = GetComponent<Transform>();
    }
   
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime; //increments timepassed time
        if (timePassed >= Random.Range(3 , 6)) //checks when time passed gets to 5 seconds for dagger to disappear or get destoryed. 
        {
            Instantiate(daggerPrefab, spawnPoint.position, spawnPoint.rotation);
            //    Debug.Log(timePassed);was to check instantiation
            //    sets time passed back to 0
            timePassed = 0;  
        }


    }

 
    }

