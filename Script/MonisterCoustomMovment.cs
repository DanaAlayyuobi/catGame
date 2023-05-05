using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonisterCoustomMovment : MonoBehaviour
{
    public Image LifeBar;
    public GameObject []points;
    public float speed=4;
    public int currentPointIndex=0;
    public int MonisterLifes = 5;
    int MaxMonisterLifes = 5;

    // Start is called before the first frame update
    void Start()
    {
        MaxMonisterLifes = MonisterLifes;
    }


    // Update is called once per frame
    void Update()
    {
        float distance =Vector2.Distance(transform.position, points[currentPointIndex].transform.position);
        //Debug.Log("Distance = " +distance);
        if (distance < 0.2f) {
            currentPointIndex++;
            if (currentPointIndex >= points.Length)
                currentPointIndex = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].transform.position,speed*Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Destroy(collision.gameObject);
            MonisterLifes--;
            changeLifeBarAmount();
            if (MonisterLifes <= 0)
                Destroy(gameObject);
        }
    }

  
    void changeLifeBarAmount() {
      float  Value = (float )MonisterLifes / (float)MaxMonisterLifes ;
;
        LifeBar.fillAmount = Value;
    }
}
