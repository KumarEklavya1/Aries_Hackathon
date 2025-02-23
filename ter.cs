using UnityEngine;

public class InfiniteTerrainC : MonoBehaviour
{
    public Transform playerC;
    public Vector2 terrainSizeC = new Vector2(500, 500);
    private Vector3 lastPlayerPositionC;

    void Start()
    {
        lastPlayerPositionC = playerC.position;
    }

    void Update()
    {
        Vector3 deltaMovementC = playerC.position - lastPlayerPositionC;
        if (Mathf.Abs(deltaMovementC.x) >= terrainSizeC.x || Mathf.Abs(deltaMovementC.z) >= terrainSizeC.y)
        {
            MoveTerrainC();
            lastPlayerPositionC = playerC.position;
        }
    }

    void MoveTerrainC()
    {
        Vector3 newPositionC = new Vector3(
            Mathf.Floor(playerC.position.x / terrainSizeC.x) * terrainSizeC.x,
            transform.position.y,
            Mathf.Floor(playerC.position.z / terrainSizeC.y) * terrainSizeC.y
        );
        transform.position = newPositionC;
    }
}
