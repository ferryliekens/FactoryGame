﻿using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameManager gameManager;
    public Transform block;

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

            gameManager.BuyTile();

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(block, finalPosition, Quaternion.identity);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }
}