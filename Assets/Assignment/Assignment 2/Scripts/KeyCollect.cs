using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;

public class KeyCollect : MonoBehaviour
{
    public AnimationCurve keySpawn;
    float keySpawnTimer;
    public SpriteRenderer sr;
   
    void Start()
    {
        //starts key size at 0
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    { 
       //lerps the size of the key so it slowly increases at the start of the game
            keySpawnTimer += 0.3f * Time.deltaTime;
            float interpolation = keySpawn.Evaluate(keySpawnTimer);
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one , interpolation);

        
   
    }

    public void OnTriggerEnter2D()
    {
        //check for collision 
        Debug.Log("Im being triggered");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(8);
    }
    }

 


