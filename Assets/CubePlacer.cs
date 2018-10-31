using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    private List<Vector3> blockPositions = new List<Vector3>();
    public GameManager gameManager;
    public Transform block;
    public Button button;
    private Input input;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        button.onClick.AddListener(() => PlayConveyorBelt());
    }

    private void Update()
    {

        if (Input.GetMouseButton(0) && gameManager.money > 0)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        if (blockPositions.Count > 1)
        {
            float distance = Vector3.Distance(blockPositions.Last(), clickPoint);

            if (distance < 1f) return;
        }

        gameManager.BuyTile();
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(block, finalPosition, Quaternion.identity);

        blockPositions.Add(finalPosition);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }

    private void PlayConveyorBelt()
    {
        GameObject product = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 position = new Vector3 { x = blockPositions[0].x, y = blockPositions[0].y + 1, z = blockPositions[0].z };
        product.transform.position = position;
        StartCoroutine("MoveProductWithDelay", product);
    }

    //private IEnumerator StartMoveProductWithDelay(GameObject product)
    //{
    //    StartCoroutine("MoveProductWithDelay", product);
    //    yield return new WaitForSeconds(10);
    //    StopCoroutine("MoveProductWithDelay");
    //}

    private IEnumerator MoveProductWithDelay(GameObject product)
    {
        Vector3 lastPosition = blockPositions.Last();

        foreach (Vector3 position in blockPositions)
        {
            product.transform.position = new Vector3 { x = position.x, y = position.y + 1, z = position.z };
            yield return new WaitForSeconds(0.5f);

            if (position.Equals(lastPosition))
            {
                Destroy(product);
            }
        }
    }
}