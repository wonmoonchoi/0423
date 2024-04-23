using UnityEngine;

public class Player_Test : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(h, 0, v).normalized;

        transform.position += moveVec * moveSpeed;
        anim.SetBool("move", true);

        transform.LookAt(transform.position + moveVec);

        if (moveVec.magnitude <= 0.0f)
            anim.SetBool("move", false);
    }
}
