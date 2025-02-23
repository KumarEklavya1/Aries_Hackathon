using UnityEngine;

public class InfiniteTerrainB : MonoBehaviour
{
    public Transform playerB;
    public Vector2 terrainSizeB = new Vector2(500, 500);
    private Vector3 lastPlayerPositionB;

    void Start()
    {
        lastPlayerPositionB = playerB.position;
    }

    void Update()
    {
        Vector3 deltaMovementB = playerB.position - lastPlayerPositionB;
        if (Mathf.Abs(deltaMovementB.x) >= terrainSizeB.x || Mathf.Abs(deltaMovementB.z) >= terrainSizeB.y)
        {
            MoveTerrainB();
            lastPlayerPositionB = playerB.position;
        }
    }

    void MoveTerrainB()
    {
        Vector3 newPositionB = new Vector3(
            Mathf.Floor(playerB.position.x / terrainSizeB.x) * terrainSizeB.x,
            transform.position.y,
            Mathf.Floor(playerB.position.z / terrainSizeB.y) * terrainSizeB.y
        );
        transform.position = newPositionB;
    }
}
