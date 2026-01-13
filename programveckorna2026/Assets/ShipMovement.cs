using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;
    public float direction = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (transform.position.y < -2)
        {
            direction = 1;
        }

        if (transform.position.y > 1)
        {
            direction = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y + direction, transform.position.z);
            moveSpeed *= -1;
        }
    }
}
