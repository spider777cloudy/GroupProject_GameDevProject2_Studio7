using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player;  // Assign the player's transform in the Inspector
    public float smoothSpeed = 0.125f;  // Adjust for smoother or more responsive movement
    public Vector3 offset;  // Offset from the player's position
    public float fixedYPos = 652f;  // Offset from the player's position

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.y = fixedYPos;
        transform.position = smoothedPosition;
    }
}
