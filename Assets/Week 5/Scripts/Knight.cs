using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        //refernece rigidbody
       rb =  GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth; 
    }
    private void FixedUpdate()
    {
        if (isDead) return; 
            movement = destination - (Vector2)transform.position; //changed transform into vector 2
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed *Time.deltaTime); //normalized makes the smaller version of vector or limitation
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude); 
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        TakeDamage(1); //subtracts from functions below 
    
    }
    private void OnMouseUp()
    {
        clickingOnSelf = false; 
    }
    void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
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
