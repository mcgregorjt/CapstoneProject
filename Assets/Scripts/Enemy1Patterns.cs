using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Patterns : MonoBehaviour {

     public GameObject pointA;
     public GameObject pointB;
     private Rigidbody2D rb;
     private Transform currentPoint;
     public float speed = 2f;

   /* [SerializeField] float moveSpeed = 1f;
     Rigidbody2D rb;
     BoxCollider2D myCollider;*/

    // Start is called before the first frame update
    void Start() {
        /*rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();*/

        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;

    }

    // Update is called once per frame
    void Update() {
        Vector2 point = currentPoint.position - transform.position;

         if(currentPoint == pointB.transform) 
         {
             rb.velocity = new Vector2(speed, -3f/*Random.Range(-10* Time.deltaTime, 8* Time.deltaTime)*/);
         }

         else 
         {
             rb.velocity = new Vector2(-speed, 3f);
         }

         if(Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointB.transform) 
         {
             currentPoint = pointA.transform;
         }

        if (Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointA.transform) {
            currentPoint = pointB.transform;

        }


       /* if (IsFacingUp()) {
            //move down
            rb.velocity = new Vector2(0f, -moveSpeed);
        }

        else {
            rb.velocity = new Vector2(0f, moveSpeed);
        }*/

    }

   /* private bool IsFacingUp() {
        return transform.localScale.y > Mathf.Epsilon;
    }


    private void OnTriggerExit(Collider2D collision) {
        transform.localScale = new Vector2(transform.localScale.y, -(Mathf.Sign(rb.velocity.y)));
        }*/




}
