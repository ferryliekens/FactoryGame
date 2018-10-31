using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {

    private int Happiness;
    public GameManager gameManager;
    public Material yellow;
    public Material red;

    void Start () {
        Happiness = 20;
    }
	
	void Update () {
        if(gameManager.BlocksPlaced() > 10 && gameManager.BlocksPlaced() < 20 && Happiness != 10)
        {
            Happiness = 10;
            changeColor();
        } else if(gameManager.BlocksPlaced() >= 20 && Happiness != 0)
        {
            Happiness = 0;
            changeColor();
        }
    }

    private void changeColor()
    {
        if (Happiness == 10)
        {
            GetComponent<Renderer>().material = yellow;
        }
        else if (Happiness == 0)
        {
            GetComponent<Renderer>().material = red;
        }
    }
}
