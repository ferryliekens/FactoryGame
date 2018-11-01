using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {



    public int Table;
    public int BigTable;
    public int WoodenBench;
    public int Wood;
    public int Steel;
    public int Iron;
    public int money;



    public Text moneyText;
    public Text woodText;
    public Text steelText;
    public Text ironText;
    public Text tableText;
    public Text bigTableText;
    public Text woodenBenchText;

    private int amountOfBlocks;
    public static GameObject BlockSelected;


    private List<GameObject> Blocks;

   



	// Use this for initialization
	void Start () {
        Blocks = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Money: " + money.ToString();
        woodText.text = "Wood: " + Wood.ToString();
        steelText.text = "Steel: " + Steel.ToString();
        ironText.text = "Iron: " + Iron.ToString();
        tableText.text = "Table: " + Table.ToString();
        bigTableText.text = "BigTable: " + BigTable.ToString();
        woodenBenchText.text = "WoodenBench: " + WoodenBench.ToString();
    }

 
    public int BlocksPlaced()
    {
        return amountOfBlocks;
    }

    public void BuyBlock(int cost, GameObject block)
    {
        Debug.Log(block.name);
        money = money - cost;
        Blocks.Add(block.gameObject);
        amountOfBlocks += 1;
    }

    public void CreateObject(int woodCost, int steelCost, int ironCost, ObjectType type)
    {
        Wood -= woodCost;
        Steel -= steelCost;
        Iron -= ironCost;

        switch (type)
        {
            case ObjectType.Table:
                Table++;
                break;
            case ObjectType.BigTable:
                BigTable++;
                break;
            case ObjectType.WoodenBench:
                WoodenBench++;
                break;
        }
    }



}
