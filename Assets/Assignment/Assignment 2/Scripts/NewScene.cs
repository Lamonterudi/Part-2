using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update

    // Update is called once per frame
    public void newScene()
    {
        //loads difficulty screen after players click wanna play
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(5); // % modular leaves remainder 
      

    }
    public void HardScene()
    {
        //will transition from difficulty scene to play scene if players click hard mode 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(6); // % modular leaves remainder 
        health = 1;
        //will remember difficulty setting when clicking on buttons to next scene. 
        PlayerPrefs.SetFloat("difficultySetting", health);
    }
    public void EasyScene()
    {
        //will transition from difficulty scene to play scene if players click easy mode 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(6); // % modular leaves remainder 
        health = 5;
        //will remember difficulty setting when clicking on buttons to next scene. 
        PlayerPrefs.SetFloat("difficultySetting", health);
    }
    public void Menu()
    {
        //will transition from GAME ENDING scenes to MAIN MENU scene if players click easy mode 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(4); // % modular leaves remainder 
       
       
    }
}
