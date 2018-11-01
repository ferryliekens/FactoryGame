using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Table, BigTable, WoodenBench
}

public class BlockController : MonoBehaviour
{
    public GameManager GameManager;

    public int Cost;
    int interval = 1;
    float nextTime = 0;

    public int WoodCost;
    public int SteelCost;
    public int IronCost;

    public State MachineState = State.Idle;
    public ObjectType CreateObjectType;

    bool isRunning = false;

    public enum State
    {
        Running, Idle
    }

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
        if (MachineState == State.Running)
        {
            if (!isRunning) StartCoroutine(ObjectCreationCoroutine());
        }
    }

    void OnDestroy()
    {
        Debug.Log("Block Removed");
    }


    public void runMachine()
    {
        MachineState = State.Running;
    }

    IEnumerator ObjectCreationCoroutine()
    {
        isRunning = true;
        yield return new WaitForSeconds(1);
        GameManager.CreateObject(WoodCost, SteelCost, IronCost, CreateObjectType);
        isRunning = false;
        Debug.Log(CreateObjectType + " Is Created");
    }

}
