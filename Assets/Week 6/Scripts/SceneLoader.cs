using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update() //put it in update for it to 
    {
        if (Input.GetKeyDown("s"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; //makes scene not go greater than adding one in the build settings 

            SceneManager.LoadScene(2); // % modular leaves remainder 
            if (currentSceneIndex == 2)
            {
                SceneManager.LoadScene(1);
            }

        }
    }
}
