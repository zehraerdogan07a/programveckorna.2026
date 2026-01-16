using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;
    public float direction = -1;

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (transform.position.y < -1) direction = 1;
        if (transform.position.y > 2) direction = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + direction, transform.position.z);
            moveSpeed *= -1;
        }
    }

    private void OnDestroy()
    {
        if (GameManager2.Instance != null)
        {
            GameManager2.Instance.ShipDestroyed();
        }
    }
}
