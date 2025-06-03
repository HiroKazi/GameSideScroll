using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravity = -5.5f;
    public float maxFallSpeed = -10f;
    public float groundY = 0f; //nilai position y object saat menyentuh ground

    private Vector3 velocity = Vector3.zero;
    private bool isGrounded = false;

    private void OnEnable()
    {
        
    }
    void Update()
    {
        ApplyGravity();
        Move();
        Grounded();
    }
    

    void ApplyGravity()
    {
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y, maxFallSpeed, Mathf.Infinity);
        }
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void Grounded()
    {
        if (transform.position.y <= groundY)
        {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
        }
    }

}