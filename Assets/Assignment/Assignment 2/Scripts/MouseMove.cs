using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to change scenes when game is over
using JetBrains.Annotations; //makes eventsystem in unity accessible 
public class MouseMove : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    Vector2 destination;
    Vector2 PlayerMovement;
    public float speed = 2;
    public float health;
    bool gameOver = false; 



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //sets the health amount when player
        health = PlayerPrefs.GetFloat("difficultySetting");
        Debug.Log(health); //Used this to check if health value was changing after player chooses difficult or easy mode.

    }
    private void FixedUpdate()
    {

        PlayerMovement = destination - (Vector2)transform.position; //changed transform into vector 2
        if (PlayerMovement.magnitude < 0.1)
        {
            PlayerMovement = Vector2.zero;
        }
        rb.MovePosition(rb.position + PlayerMovement.normalized * speed * Time.deltaTime); //normalized makes the smaller version of vector or limitation
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //will make player not move when pressing on the uI
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //adds parameters/conditions for animation clips and idle states 
        if (PlayerMovement.x != 0 || PlayerMovement.y != 0)
        {
            animator.SetFloat("Horizontal", PlayerMovement.x);
            animator.SetFloat("Vertical", PlayerMovement.y);
        }

        animator.SetFloat("Speed", PlayerMovement.sqrMagnitude);
    }
    public void playerDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, health);
        //this will make the player go to game over screen since health goes to 0 
        if (health == 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(7); 
        }
    }
   

}
