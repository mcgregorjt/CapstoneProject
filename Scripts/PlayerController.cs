using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 10f;
   [SerializeField]public Rigidbody2D rb;
    public Weapon weapon;
    [SerializeField] private AudioSource laserBulletSoundEffect;

    Vector2 moveDirection;
    Vector2 mousePosition;

    List<Item> inventory = new List<Item>();

    void Start()
    {
        transform.position = new Vector2(0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (!PauseMenu.isPaused){
            if (Input.GetMouseButtonDown(0)) {
                laserBulletSoundEffect.Play();
                weapon.Fire();
            }
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.tag == "Item")
        {
            string currItem = col.gameObject.name;
            Debug.Log("The item " + currItem + " was retrieved!");
            GetComponent<ItemCollection>().CollectItem(currItem);
            Destroy(col.gameObject);
        }
    }
}

