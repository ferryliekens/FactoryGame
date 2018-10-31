using UnityEngine;
using System.Collections.Generic;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameManager gameManager;
    public List<Transform> BlockTypes;
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
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);
            RaycastHit hitInfo;

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
            }

            if (Physics.Raycast(ray, out hitInfo) && hits.Length < 4)
            {
                gameManager.BuyTile();
                PlaceCubeNear(hitInfo.point);
            }

            
        }

        BlueprintCube();

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            foreach(var x in hits)
            {
                if(x.collider.tag == "Block")
                {
                    Destroy(x.collider.gameObject);
                }
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        var blockType = CheckSelectedCube();
        Instantiate(blockType, finalPosition, Quaternion.identity);
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