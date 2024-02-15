using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations; //makes eventsystem in unity accessible 
public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;
    // public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        //refernece rigidbody
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //health = maxHealth;
        health = PlayerPrefs.GetFloat("Currenthealth",maxHealth);
        SendMessage("ProperHealth", health, SendMessageOptions.DontRequireReceiver);
       //will watch the players state so if knight is dead he will be dead in next session
       playerLifeState();
       
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position; //changed transform into vector 2
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime); //normalized makes the smaller version of vector or limitation
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject()) //will make player not move when pressing uI
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }

    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        SendMessage("TakeDamage", 1);
        // TakeDamage(1); //subtracts from functions below 
        //dont need anymore  healthBar.TakeDamage(1);
    }
    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }
    public void TakeDamage(float damage)
    {

        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        //  

        PlayerPrefs.SetFloat("Currenthealth", health);
        if (health <= 0)
        {
            animator.SetTrigger("Death");
            isDead = true;
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");   //use set trigger or setfloat or setbool for the conditions/parameters and quote it 
        }
    }
        public void playerLifeState()
        {
            if (health <= 0)
            {
                animator.SetTrigger("Death");
                isDead = true;
            }
            else
            {
                isDead = false;
                animator.SetTrigger("TakeDamage");   //use set trigger or setfloat or setbool for the conditions/parameters and quote it 
            }
        

    }



}

