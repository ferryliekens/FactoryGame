using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed = 0.5f;
    private Camera camera;
    public float MaxCameraDistance = 14f;
    public float MinCameraDistance = 5f;
    private bool MaxCameraReached;
    private bool MinCameraReached;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Scroll();
	}

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            float xMovement = transform.position.x - speed;
            float zMovement = -72 - xMovement;

            transform.position = new Vector3(xMovement, transform.position.y, zMovement);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            float xMovement = transform.position.x + speed;
            float zMovement = -72 - xMovement;

            transform.position = new Vector3(xMovement, transform.position.y, zMovement);
        }

    }

    private void Scroll()
    {
        
        var mouseScroll = Input.mouseScrollDelta.y;

        if(mouseScroll <= -1 && MaxCameraReached != true)
        {
            MinCameraReached = false;
            camera.orthographicSize -= -1;

            if (camera.orthographicSize > MaxCameraDistance)
            {
                MaxCameraReached = true;
                Debug.Log("max reached;");
            }
        }

        else if(mouseScroll >= 1 && MinCameraReached != true)
        {

            camera.orthographicSize -= 1;
            MaxCameraReached = false;

            if (camera.orthographicSize < MinCameraDistance)
            {
                MinCameraReached = true;
                Debug.Log("Min reached;");
            }
        }
     

    }
}
