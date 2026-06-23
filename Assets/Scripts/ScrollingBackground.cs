using UnityEngine;

// This script makes the ground (and optionally background) scroll left
// giving the illusion that the player is running forward
public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 6f;     // Should match obstacle speed
    public float resetX = -20f;        // When to loop back
    public float startX = 20f;         // Where to reset to

    private bool isRunning = false;

    void Update()
    {
        if (!isRunning) return;

        // Move this object to the left
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // If it scrolled too far left, jump it back to the right (seamless loop)
        if (transform.position.x <= resetX)
        {
            Vector3 pos = transform.position;
            pos.x = startX;
            transform.position = pos;
        }
    }

    public void StartScrolling() { isRunning = true; }
    public void StopScrolling()  { isRunning = false; }
}
