using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public List<Transform> BlockTypes;
    private Grid grid;
    public GameManager gameManager;
    private static Transform BlockHolder;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        BlockHolder = Instantiate(BlockTypes[0]) as Transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameManager.money > 0)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // IF Raycast = HIT
            if (Physics.Raycast(ray, out hitInfo))
            {
                gameManager.BuyTile();
                PlaceCubeNear(hitInfo.point);
                Debug.Log(hitInfo);
            }
        }

        BlueprintCube();
        
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        var blocktype = CheckSelectedCube();
        Instantiate(blocktype, finalPosition, Quaternion.identity);
    }

    private void BlueprintCube()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log(hitInfo);
            BlockHolder.position = grid.GetNearestPointOnGrid(hitInfo.point);
            
        }
    }

    private Transform CheckSelectedCube()
    {
        switch (GameManager.selectedBlock)
        {
            case BlockType.Tiny:
                return BlockTypes[0];
            case BlockType.Small:
                return BlockTypes[1];
            case BlockType.Medium:
                return BlockTypes[2];
            default:
                return BlockTypes[0];
        }
    }

    public static void ChangeCube(GameObject Block)
    {
        Destroy(BlockHolder.gameObject);
        BlockHolder = Instantiate(Block.transform) as Transform;
    }
}