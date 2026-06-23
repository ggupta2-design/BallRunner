using UnityEngine;

// Every spawned obstacle gets this script — it moves left and destroys itself when off screen
public class ObstacleMover : MonoBehaviour
{
    public float speed = 6f;          // How fast obstacle moves left
    public float destroyX = -12f;     // Where to delete it (off the left edge)

    void Update()
    {
        // Move left every frame
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy when out of screen
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
