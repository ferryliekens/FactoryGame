using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeSelecter : MonoBehaviour, IPointerDownHandler{

    public BlockType Type;
    public GameObject Block;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.selectedBlock = Type;
        CubePlacer.ChangeCube(Block);
    }
}
