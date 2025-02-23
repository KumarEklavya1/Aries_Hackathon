using UnityEngine;

public class InfiniteTerrain : MonoBehaviour
{
    public Transform player;
    public Vector2 terrainSize = new Vector2(500, 500);
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        if (Mathf.Abs(deltaMovement.x) >= terrainSize.x || Mathf.Abs(deltaMovement.z) >= terrainSize.y)
        {
            MoveTerrain();
            lastPlayerPosition = player.position;
        }
    }

    void MoveTerrain()
    {
        Vector3 newPosition = new Vector3(
            Mathf.Floor(player.position.x / terrainSize.x) * terrainSize.x,
            transform.position.y,
            Mathf.Floor(player.position.z / terrainSize.y) * terrainSize.y
        );
        transform.position = newPosition;
    }
}
