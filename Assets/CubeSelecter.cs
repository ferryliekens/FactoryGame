using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeSelecter : MonoBehaviour, IPointerDownHandler{

    public GameObject Block;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.BlockSelected = Block;
        CubePlacer.ChangeBlock(Block);
    }
}