using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovementScript : MonoBehaviour
{
    public float speed = 3;
    public int direction = 1;
    public float lifeTimer=10;
    // Start is called before the first frame update
    void Start()
    {
        if (playerMovemnt.instance.isFlipX)
        {
            direction = -1;
        }
        else
        {
            direction = 1;

        }
        GetComponent<SpriteRenderer>().flipX = playerMovemnt.instance.isFlipX;

        Destroy(gameObject,lifeTimer);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mashroom")) {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
/*
 
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*speed*Time.deltaTime, 0, 0);
    }
 */