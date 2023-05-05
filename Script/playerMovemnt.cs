using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovemnt : MonoBehaviour
{
     SpriteRenderer renderer;
     Animator animator;
    public float Speed=4;
    public int replayAfterY = -40;
    

    public GameObject FireBallPrefap;
    public Transform FireBallSpawnpoint;
    public Transform FireBallCountainer;

    public bool isGrounded = false;
    public bool isDead = false;
    public bool isHurt= false;
    public bool isFlipX =false;
    public static playerMovemnt instance;

    public int MonisterLifes=5;
    Rigidbody2D rg2d;
    public int JumpStrength = 300;
    // Start is called before the first frame update
     void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        rg2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LEFT");
            transform.Translate(-1*Speed*Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("RIGHT");
            transform.Translate( Speed * Time.deltaTime, 0, 0);
        }*/
        if (isDead)
            return;

        if (isHurt)
            return;
        Vector3 vector3=new Vector3(Input.GetAxis("Horizontal"), 0,0);
        transform.position += vector3 * Time.deltaTime * Speed;
        /*Debug.Log("Horizontal value is : "+Input.GetAxis("Horizontal"));
        //right movement using Input.GetAxis("Horizontal") is 0-1 float
        //left movement using Input.GetAxis("Horizontal") is -1-0 float*/
        if (transform.position.y== replayAfterY) {
            ReplayGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            Debug.Log("Space button");
            isGrounded = false;

            animator.Play("JumpAnimation");
            rg2d.AddForce(Vector2.up* JumpStrength);
         
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) )
        {

            /* first way to move fireball
            GameObject FireballObj = Instantiate(FireBallPrefap, FireBallSpawnpoint.position, Quaternion.identity);
             FireballMovementScript Fb = FireballObj.GetComponent<FireballMovementScript>();
             SpriteRenderer SR= FireballObj.GetComponent<SpriteRenderer>();
             SR.flipX = renderer.flipX;
             if (renderer.flipX == false) {
                 Fb.direction = 1;
             }
             else {
                 Fb.direction = -1;
             }*/
            //second way
            GameObject FireballObj = Instantiate(FireBallPrefap, FireBallSpawnpoint.position, Quaternion.identity);
            FireballObj.transform.SetParent(FireBallCountainer);
        }
        if (isGrounded)
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                //idle
                animator.Play("idleAnimation");
            }
            else
            {
                //running
                animator.Play("RunAnimation");
                if (Input.GetAxis("Horizontal") > 0.01f)
                {

                    //disable flip option right
                    renderer.flipX = false;
                    isFlipX = false;
                }
                if (Input.GetAxis("Horizontal") < -0.01f)
                {
                    renderer.flipX = true;
                    isFlipX = true;
                    //enable flop option left
                }
                animator.Play("RunAnimation");
            }
        }
        //enable Jump Animation
       
    
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        else if (collision.gameObject.tag == "Mashroom"|| collision.gameObject.tag == "Monister")
        {
          //SoundMangerScript.instance.hurtSound.Play();

            isHurt = true;
            UIManager.instance.playerLifesCounter--;
            UIManager.instance.DeleteLastestPlayerLife();
            animator.Play("hurtAnimation");
            renderer.color = Color.red;
            Invoke("DisableHurtFlag",2);
            if (UIManager.instance.playerLifesCounter <= 0) {
                SoundMangerScript.instance.PlayGameOvertSound();

                isDead = true;
              animator.Play("DeadAnimation");
              Destroy(gameObject,2);
            }
            else
                SoundMangerScript.instance.HurtSoundStatus(true);

        }
    }
     Transform spawnPointTemp;
    public void OnTriggerEnter2D(Collider2D other)
    {
      //Debug.Log("water" + other.gameObject.tag);
        if (other.CompareTag("water")) {
            waterScript WS = other.gameObject.GetComponent<waterScript>();
            int randomPoint = Random.Range(0,WS.spawnPoint.Length);
             spawnPointTemp =WS.spawnPoint[randomPoint];

  

           isGrounded = false;
            animator.Play("FallAnimation");


            Invoke("ReCreatePlayer", 2);
         }
        if (other.CompareTag("coin")) {
            UIManager.instance.IncreaseCoinCounterText();
            Destroy(other.gameObject);
        }
    }

    void ReCreatePlayer() {
        transform.position = spawnPointTemp.position;//new Vector3(-9.64f,-2.7f,0);
    }

    void DisableHurtFlag() {
        isHurt = false;
        renderer.color = Color.white;
    }
void ReplayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
