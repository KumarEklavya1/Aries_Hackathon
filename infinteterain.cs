using UnityEngine;

public class InfiniteTerrainA : MonoBehaviour
{
    public Transform playerA;
    public Vector2 terrainSizeA = new Vector2(500, 500);
    private Vector3 lastPlayerPositionA;

    void Start()
    {
        lastPlayerPositionA = playerA.position;
    }

    void Update()
    {
        Vector3 deltaMovementA = playerA.position - lastPlayerPositionA;
        if (Mathf.Abs(deltaMovementA.x) >= terrainSizeA.x || Mathf.Abs(deltaMovementA.z) >= terrainSizeA.y)
        {
            MoveTerrainA();
            lastPlayerPositionA = playerA.position;
        }
    }

    void MoveTerrainA()
    {
        Vector3 newPositionA = new Vector3(
            Mathf.Floor(playerA.position.x / terrainSizeA.x) * terrainSizeA.x,
            transform.position.y,
            Mathf.Floor(playerA.position.z / terrainSizeA.y) * terrainSizeA.y
        );
        transform.position = newPositionA;
    }
}
