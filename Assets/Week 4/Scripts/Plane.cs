using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;
    public Sprite[] pSprites;
     
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();

        GetComponent<SpriteRenderer>().sprite = pSprites[Random.Range(0, pSprites.Length)];
    }
    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count>0)
            //rotation to point
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle; 
        }
        //move positions
        //transform is for 3d so saying vector 2 will make it ignore z axis
            rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up*speed* Time.deltaTime);
    }

    void Update()
    {
        //interpolations
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.1f* Time.deltaTime; //increments
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z<0.1f)
            {
                Destroy(gameObject); //will destroy plane 
            }
            transform.localScale = Vector3.Lerp(Vector3.one,Vector3.zero,interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if(points.Count>0)
        {
            if(Vector2.Distance(currentPosition, points[0])< newPointThreshold)
            {
                points.RemoveAt(0);
                //arrays dont have a remove action only lists do 
                for (int i = 0; i < lineRenderer.positionCount - 2; i++){
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i +1));
                }
               
                lineRenderer.positionCount--; 
                
                
            }

        }
    }
    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold )
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;

        }
    
    }
}
