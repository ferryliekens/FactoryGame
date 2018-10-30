using UnityEngine;
using System.Collections;

public class BacktoStart : MonoBehaviour {
    public Vector3 startPos;
    public Quaternion startRot;
    
    void Awake () {
            startPos = transform.position;
            startRot = transform.rotation;
            gameObject.SetActiveRecursively(false);
            
    }
	
	public void backTo () {
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
