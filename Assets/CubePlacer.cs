using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameManager gameManager;
    private static Transform BlockHolder;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
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
                PlaceCubeNear(hitInfo.point);
            }
        }

        BlueprintCube();

    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        var blocktype = GameManager.BlockSelected;
        if (blocktype != null)
        {
            GameObject block = Instantiate(blocktype, finalPosition, Quaternion.identity) as GameObject;
            var cost = blocktype.GetComponent<BlockController>().Cost;
            blocktype.GetComponent<BlockController>().runMachine();
            gameManager.BuyBlock(cost, block);
        }

    }

    private void BlueprintCube()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo) && BlockHolder != null)
        {
            Debug.Log(hitInfo);
            BlockHolder.position = grid.GetNearestPointOnGrid(hitInfo.point);

        }
    }


    public static void ChangeBlock(GameObject Block)
    {
        if(BlockHolder)
        Destroy(BlockHolder.gameObject);

        BlockHolder = Instantiate(Block.transform) as Transform;
    }
}