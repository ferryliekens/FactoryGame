<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
using UnityEngine;
>>>>>>> a65c8890789a0444f24d87fe9691593a45e68749

public class CubePlacer : MonoBehaviour
{
    public List<Transform> BlockTypes;
    private Grid grid;
    public GameManager gameManager;
<<<<<<< HEAD
    public List<Transform> BlockTypes;
    private static Transform BlockHolder;

=======
    private static Transform BlockHolder;
>>>>>>> a65c8890789a0444f24d87fe9691593a45e68749

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
<<<<<<< HEAD

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
            }

            if (Physics.Raycast(ray, out hitInfo) && hits.Length < 4)
=======
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // IF Raycast = HIT
            if (Physics.Raycast(ray, out hitInfo))
>>>>>>> a65c8890789a0444f24d87fe9691593a45e68749
            {
                gameManager.BuyTile();
                PlaceCubeNear(hitInfo.point);
                Debug.Log(hitInfo);
            }

            
        }

        BlueprintCube();
<<<<<<< HEAD

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
=======
        
>>>>>>> a65c8890789a0444f24d87fe9691593a45e68749
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
<<<<<<< HEAD
        var blockType = CheckSelectedCube();
        Instantiate(blockType, finalPosition, Quaternion.identity);
=======
        var blocktype = CheckSelectedCube();
        Instantiate(blocktype, finalPosition, Quaternion.identity);
>>>>>>> a65c8890789a0444f24d87fe9691593a45e68749
    }

    private void BlueprintCube()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log(hitInfo);
            BlockHolder.position = grid.GetNearestPointOnGrid(hitInfo.point);
<<<<<<< HEAD

=======
            
>>>>>>> a65c8890789a0444f24d87fe9691593a45e68749
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