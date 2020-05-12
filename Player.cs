using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    //get basicsS
    public Rigidbody2D PlayerRb;
    public BoxCollider2D oongaCollider;
    Animator animator;

    //movement
    Vector2 movement;
    public float moveSpeed;
    
    //spawning
    private static bool isSpawned;
    public GameObject PlayerObject;
    //flip
    private bool facingRight;
    //ny area + inte gå i början
    public LoadNewArea loadNewArea;
    public float RoomWalkCD;
    private float RoomWalkOnCD= 100;
    private float RoomWalkOffCD = 0;


    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        oongaCollider = GetComponent<BoxCollider2D>();
        PlayerRb = GetComponent<Rigidbody2D>();

        if (!isSpawned)
        {
            isSpawned = true;
            DontDestroyOnLoad(PlayerObject.gameObject);
        }
       else
        {
            Destroy(gameObject);
        }


        facingRight = true;
        
        SceneManager.sceneLoaded += OnSceneLoaded;

    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
    }


    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (RoomWalkCD > 0)
        {           
            RoomWalkCD -= Time.deltaTime;
            RoomWalkCD = Mathf.Clamp(RoomWalkCD, RoomWalkOffCD, RoomWalkOnCD); //gör så att de inte går under 0   
        }

        if (Input.GetKey(KeyCode.A) && (RoomWalkCD == 0))
        {
            PlayerRb.velocity = new Vector2(-moveSpeed, PlayerRb.velocity.y);
            
        }
        else if (Input.GetKey(KeyCode.D) && (RoomWalkCD == 0))
        {
            PlayerRb.velocity = new Vector2(moveSpeed, PlayerRb.velocity.y);
            
        }
        else
        {
            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);
        }
        
        if (RoomWalkCD > 0)
        {
            animator.SetFloat("speed", 0);
        }

        if (RoomWalkCD == 0)
        {
            animator.SetFloat("speed", Mathf.Abs(movement.x));
        }
        

    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RoomWalkCD = 1f;

    }


    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight && RoomWalkCD == 0|| horizontal < 0 && facingRight && RoomWalkCD == 0)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
