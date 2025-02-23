using UnityEngine;

public class InfinitePlane : MonoBehaviour
{
    public Transform player;
    public float planeLength = 10f; // Default length of Unity plane is 10 units

    void Update()
    {
        if (player.position.z - transform.position.z >= planeLength)
        {
            Vector3 newPos = transform.position;
            newPos.z += planeLength;
            transform.position = newPos;
        }
    }
}
