using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speedPlayer;
    private Rigidbody2D rigPlayer;

    [Header("Jump")]
    [SerializeField] float jumpStrange;    
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    public bool inFloor;
    private float jumpNumber;

    void Start()
    {
        rigPlayer = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        inFloor = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position, groundCheck.position, Color.cyan);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (inFloor)
        {
            jumpNumber = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpNumber > 0)
        {
            rigPlayer.AddForce(new Vector2(0f, jumpStrange), ForceMode2D.Impulse);
            jumpNumber = jumpNumber - 1;           
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rigPlayer.linearVelocity = new Vector2(rigPlayer.linearVelocity.x, rigPlayer.linearVelocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speedPlayer;
    }

  
}
