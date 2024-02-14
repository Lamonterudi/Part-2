using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextscene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1)% SceneManager.sceneCountInBuildSettings; //makes scene not go greater than adding one in the build settings 
        SceneManager.LoadScene(nextSceneIndex); // % modular leaves remainder 
}

}
