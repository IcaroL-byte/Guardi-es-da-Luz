using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    private Animator animator;
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
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
