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
    public GameObject[] products;
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
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);
            RaycastHit hitInfo;

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();
            }

            if (Physics.Raycast(ray, out hitInfo) && hits.Length < 2)
            {
                PlaceCubeNear(hitInfo.point);
            }
        }

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
        if (blockPositions.Count > 1)
        {
            float distance = Vector3.Distance(blockPositions.Last(), clickPoint);

            if (distance < 1f) return;
        }

        gameManager.BuyTile();
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(block, finalPosition, Quaternion.identity);
        blockPositions.Add(grid.GetNearestPointOnGrid(clickPoint));
    }

    private void TempCube(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        blockPositions.Add(finalPosition);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }

    private void PlayConveyorBelt()
    {
        StartCoroutine("MoveProductWithDelay");
    }

    private IEnumerator MoveProductWithDelay()
    {
        Vector3 lastPosition = blockPositions.Last();

        for(int i = 0; i < products.Length; i++)
        {
            Vector3 position = new Vector3 { x = blockPositions[0].x, y = blockPositions[0].y + 1, z = blockPositions[0].z };

            GameObject product = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            product.transform.position = position;

            Instantiate(product, position, Quaternion.identity);

            foreach (Vector3 p in blockPositions)
            {
                Debug.Log("I is " + i + p);
                
                product.transform.localPosition = new Vector3 { x = p.x, y = p.y + 1, z = p.z };
                yield return new WaitForSeconds(0.1f);

                if (position.Equals(lastPosition))
                {
                    Destroy(product);
                }
            }

            Destroy(product);
        }
    }
}