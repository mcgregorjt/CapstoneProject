using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Pattern2 : MonoBehaviour
{
   // private Rigidbody2D rb;
    public int isRunning = 1;
    public int numberOfSeconds;
    //rb = GetComponent<Rigidbody2D>();

   /*// Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (isRunning == 1) {
            StartCoroutine(Wait());
        }

        if (isRunning == 2) {
            StartCoroutine(Wait2());
        }

    }

    public IEnumerator Wait() {
        isRunning = 0;
        yield return new WaitForSeconds(numberOfSeconds);
        isRunning = 2;

        //rb.transform.translate();
        gameObject.transform.Translate (4,-4,0);
    }

    public IEnumerator Wait2() {
        isRunning = 0;
        yield return new WaitForSeconds(numberOfSeconds);
        isRunning = 1;

        //rb.transform.translate();
        gameObject.transform.Translate (-4, -4, 0);
    }
}
