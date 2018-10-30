using UnityEngine;
using System.Collections;

public class ColliderDetect : MonoBehaviour {

    public GameObject Control;
    public bool SmallBuilding = false;


	void Start(){
		if (Control == null) {
			Control = GameObject.FindWithTag("ControlGame");
		}

		Control.GetComponent<GridMove> ().NotPlaceable = false;
        if (transform.tag == "Placed")
        {
            if (SmallBuilding == false)
            {
                transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                //transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
	}

    void Update()
    {
        if (transform.tag == "Placed")
        {
			DontDestroyOnLoad(transform.gameObject);
            GetComponent<Renderer>().material.color = Color.green;

			Material newMat = Resources.Load("Mat/PivotSelector", typeof(Material)) as Material;
			GetComponent<Renderer>().material = newMat;
        }
        if (Control == null)
             Control = GameObject.FindWithTag("ControlGame");
    }
    void OnTriggerEnter(Collider other)
    {
        if (transform.tag == "Placed")
        {
            other.GetComponent<Renderer>().material.color = Color.red;
			transform.localScale = new Vector3(0.99F, 0.99F, 0.99F);
			Control.GetComponent<GridMove> ().NotPlaceable = true;
            return;
        }
        else {
			transform.localScale = new Vector3(0.99F, 0.99F, 0.99F);
            other.GetComponent<Renderer>().material.color = Color.red;
			Control.GetComponent<GridMove> ().NotPlaceable = true;
            if (SmallBuilding == false)
            other.transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        
        
    }
    void OnTriggerExit(Collider other)
    {
        if (transform.tag == "Placed")
        {
            other.GetComponent<Renderer>().material.color = Color.green;
			transform.localScale = new Vector3(1F, 1F, 1F);
			Control.GetComponent<GridMove> ().NotPlaceable = false;
            return;
        }
        else
        {
			Control.GetComponent<GridMove> ().NotPlaceable = false;
            other.GetComponent<Renderer>().material.color = Color.green;
			transform.localScale = new Vector3(1F, 1F, 1F);
            if (SmallBuilding == false)
            other.transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        
        
    }
}


