using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int money = 100;
    public Text moneyText;
    public static BlockType selectedBlock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Money: " + money.ToString();
	}

    public void BuyTile()
    {
        // Should be more dynamic
        if (money > 0) money -= 10;
    }

}

public enum BlockType
{
    Tiny, Small, Medium
}