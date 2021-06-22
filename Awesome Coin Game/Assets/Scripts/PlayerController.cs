using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // variables

    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 3.0f;
    private static PlayerController sharedInstance;
    private const string HIGHEST_SCORE_KEY = "highestScore";

    private Vector3 initialPosition;
    private Vector2 initialVelocity;

    
    private void Awake()
    {
        sharedInstance = this;
        rigidBody = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        initialPosition = rigidBody.velocity;
        animator.SetBool("isAlive", true);
    }

    public static PlayerController GetInstance() 
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        
        animator.SetBool("isAlive", true);
        transform.position = initialPosition;
        rigidBody.velocity = initialVelocity;
        
    }
    //This method is called at a very precise period of time
    private void FixedUpdate()
    {
        GameState currState = GameManager.GetInstance().currentGameState;
        if (currState == GameState.InGame) {

            if (rigidBody.velocity.x < runSpeed)
            {
                rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        bool canJump = GameManager.GetInstance().currentGameState == GameState.InGame;
        bool isOnTheGround = IsOnTheGround();
        animator.SetBool("isGrounded",isOnTheGround);

        if (canJump && (Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W))
            && isOnTheGround)
        {    
            Jump();
        }

    }

    //Methods

    void Jump() {
       
            rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        
    }

    bool IsOnTheGround() {
        
        return Physics2D.Raycast(
            this.transform.position,
            Vector2.down,
            1.5f, 
            groundLayerMask.value);
    }

    public void KillPlayer() 
    {
        
        animator.SetBool("isAlive", false);
        
        int highestScore = PlayerPrefs.GetInt(HIGHEST_SCORE_KEY);
        int currentScore = GetDistance();
        if(currentScore > highestScore)
        {
            PlayerPrefs.SetInt(HIGHEST_SCORE_KEY, currentScore);
        }
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = Vector2.zero;
        GameManager.GetInstance().GameOver();
    }

    

    public int GetDistance()
    {
        var distance = (int) Vector2.Distance(initialPosition, transform.position);
        print("diastance = " +distance);
        return distance;

    }
    public void ClearMaxScore()
    {
        PlayerPrefs.SetInt(HIGHEST_SCORE_KEY, 0);
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt(HIGHEST_SCORE_KEY);
    }
}
