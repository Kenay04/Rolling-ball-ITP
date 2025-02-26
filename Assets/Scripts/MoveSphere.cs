using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    public float speed;
    public float topSpeed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 400);
        }

        if (transform.position.y < -10f || Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(1, 3, -5);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);

        float y = rb.linearVelocity.y;

        Vector3 tempVec = rb.linearVelocity;
        tempVec.y = 0;

        if (tempVec.magnitude > topSpeed)
        {
            tempVec = tempVec.normalized * topSpeed;
        }

        tempVec.y = y;

        rb.linearVelocity = tempVec;
    }
}
