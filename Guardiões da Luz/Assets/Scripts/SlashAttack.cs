using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    private Animator animator;
    private bool isFacingRight;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAngles();
        
        if (Input.GetMouseButton(0)) 
        {
            animator.SetTrigger("Attack");
        }
    }

    void ChangeAngles()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isFacingRight)
            {
                Vector3 attackPos = transform.localPosition;
                attackPos.x *= -1;
                transform.localPosition = attackPos;
                transform.rotation = Quaternion.Euler(0f, -180f, 0f);

                isFacingRight = true;
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
           
            if (isFacingRight)
            {
                Vector3 attackPos = transform.localPosition;
                attackPos.x *= -1;
                transform.localPosition = attackPos;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                isFacingRight = false;
            }
        }
    }
}
