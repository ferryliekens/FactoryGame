using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject TestCube;
    public GameObject TestCube_2x2;

    public GameObject ReadyForPlace;
    public bool PlacementReady = false;
    public bool Toggle = false;
    GameObject objects;
    public bool active = false;
    public int rotateControl = 0;
    public LayerMask ObjectMask;
	public float RotateStock = 90.0f;
	public Color DefaultColor;
	public bool NotPlaceable = false;

    




    void Update()
    {



        /*keykode test only*/
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Toggle)
            {
                PlacementReady = true;
                Toggle = true;
                TestCube_2x2.SetActiveRecursively(true);
                RotateStock = TestCube_2x2.transform.eulerAngles.y;
                NotPlaceable = false;
            }
            else
            {
                PlacementReady = false;
                Toggle = false;
                TestCube_2x2.GetComponent<BacktoStart>().backTo();
                TestCube_2x2.SetActiveRecursively(false);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Toggle)
            {
                PlacementReady = true;
                Toggle = true;
                active = false;
                TestCube.SetActiveRecursively(true);
                RotateStock = TestCube.transform.eulerAngles.y;
                NotPlaceable = false;
            }
            else
            {
                PlacementReady = false;
                Toggle = false;
                active = true;
                TestCube.GetComponent<BacktoStart>().backTo();
                TestCube.SetActiveRecursively(false);
            }

        }
        /**/

        /*Arrays*/
        GameObject[] TopLeft;
        GameObject[] TopRight;
        GameObject[] BotRight;
        GameObject[] BotLeft;
        GameObject[] Bot;
        GameObject[] Right;
        GameObject[] Left;
        GameObject[] Top;

        GameObject[] TopLeft_D;
        GameObject[] TopRight_D;
        GameObject[] BotRight_D;
        GameObject[] BotLeft_D;
        GameObject[] Bot_D;
        GameObject[] Right_D;
        GameObject[] Left_D;
        GameObject[] Top_D;

        /*Placed Objects*/
        GameObject[] Placed;
        Placed = GameObject.FindGameObjectsWithTag("Placed");
        foreach (GameObject placedBuildings in Placed)
        {
            placedBuildings.GetComponent<BoxCollider>().isTrigger = true;
        }
        /*end*/

        /*Tags*/
        TopLeft = GameObject.FindGameObjectsWithTag("TopLeft");
        TopRight = GameObject.FindGameObjectsWithTag("TopRight");
        BotLeft = GameObject.FindGameObjectsWithTag("BotLeft");
        BotRight = GameObject.FindGameObjectsWithTag("BotRight");
        
        Bot = GameObject.FindGameObjectsWithTag("Bot");
        Right = GameObject.FindGameObjectsWithTag("Right");
        Left = GameObject.FindGameObjectsWithTag("Left");
        Top = GameObject.FindGameObjectsWithTag("Top");

        /*disable Tags*/
        TopLeft_D = GameObject.FindGameObjectsWithTag("TopLeft_D");
        TopRight_D = GameObject.FindGameObjectsWithTag("TopRight_D");
        BotLeft_D = GameObject.FindGameObjectsWithTag("BotLeft_D");
        BotRight_D = GameObject.FindGameObjectsWithTag("BotRight_D");

        Bot_D = GameObject.FindGameObjectsWithTag("Bot_D");
        Right_D = GameObject.FindGameObjectsWithTag("Right_D");
        Left_D = GameObject.FindGameObjectsWithTag("Left_D");
        Top_D = GameObject.FindGameObjectsWithTag("Top_D");
        /**/
        /*End*/





        /*rotate control update*/
        /*_D For Disables*/
        if (rotateControl == 0)
        {

            foreach (GameObject singleFloor in Left)
            {
                singleFloor.transform.gameObject.tag = "Left_D";
            }
            
            foreach (GameObject singleFloor in BotLeft)
            {
                singleFloor.transform.gameObject.tag = "BotLeft_D";
            }
            foreach (GameObject singleFloor in Bot)
            {
                singleFloor.transform.gameObject.tag = "Bot_D";
            }

            
            foreach (GameObject singleFloor in BotRight_D)
            {
                singleFloor.transform.gameObject.tag = "BotRight";
            }
            

            foreach (GameObject singleFloor in Right)
            {
                singleFloor.transform.gameObject.tag = "Right";
            }
            foreach (GameObject singleFloor in Right_D)
            {
                singleFloor.transform.gameObject.tag = "Right";
            }
            foreach (GameObject singleFloor in BotRight)
            {
                singleFloor.transform.gameObject.tag = "BotRight";
            }
            foreach (GameObject singleFloor in Top_D)
            {
                singleFloor.transform.gameObject.tag = "Top";
            }

            
            foreach (GameObject singleFloor in TopLeft_D)
            {
                singleFloor.transform.gameObject.tag = "TopLeft";
            }
            foreach (GameObject singleFloor in TopRight)
            {
                singleFloor.transform.gameObject.tag = "TopRight";
            }
            

        }

        if (rotateControl == 1)
        {

            foreach (GameObject singleFloor in Left_D)
            {
                singleFloor.transform.gameObject.tag = "Left";
            }
            foreach (GameObject singleFloor in BotLeft_D)
            {
                singleFloor.transform.gameObject.tag = "BotLeft";
            }
            foreach (GameObject singleFloor in Bot)
            {
                singleFloor.transform.gameObject.tag = "Bot_D";
            }

            foreach (GameObject singleFloor in Right)
            {
                singleFloor.transform.gameObject.tag = "Right_D";
            }
            foreach (GameObject singleFloor in BotRight)
            {
                singleFloor.transform.gameObject.tag = "BotRight_D";
            }
            foreach (GameObject singleFloor in Top_D)
            {
                singleFloor.transform.gameObject.tag = "Top";
            }

            foreach (GameObject singleFloor in TopLeft)
            {
                singleFloor.transform.gameObject.tag = "TopLeft";
            }
            foreach (GameObject singleFloor in TopRight)
            {
                singleFloor.transform.gameObject.tag = "TopRight";
            }

        }

        if (rotateControl == 2)
        {

            foreach (GameObject singleFloor in Left_D)
            {
                singleFloor.transform.gameObject.tag = "Left";
            }
            foreach (GameObject singleFloor in BotLeft_D)
            {
                singleFloor.transform.gameObject.tag = "BotLeft";
            }
            foreach (GameObject singleFloor in Bot_D)
            {
                singleFloor.transform.gameObject.tag = "Bot";
            }
            

            foreach (GameObject singleFloor in Right)
            {
                singleFloor.transform.gameObject.tag = "Right_D";
            }
            foreach (GameObject singleFloor in BotRight_D)
            {
                singleFloor.transform.gameObject.tag = "BotRight";
            }
            foreach (GameObject singleFloor in Top)
            {
                singleFloor.transform.gameObject.tag = "Top_D";
            }

            foreach (GameObject singleFloor in TopLeft)
            {
                singleFloor.transform.gameObject.tag = "TopLeft";
            }
            foreach (GameObject singleFloor in TopRight)
            {
                singleFloor.transform.gameObject.tag = "TopRight_D";
            }

        }

        if (rotateControl == 3)
        {

            foreach (GameObject singleFloor in Left)
            {
                singleFloor.transform.gameObject.tag = "Left_D";
            }
            foreach (GameObject singleFloor in BotLeft)
            {
                singleFloor.transform.gameObject.tag = "BotLeft";
            }
            foreach (GameObject singleFloor in Bot)
            {
                singleFloor.transform.gameObject.tag = "Bot";
            }


            foreach (GameObject singleFloor in Right_D)
            {
                singleFloor.transform.gameObject.tag = "Right";
            }
            foreach (GameObject singleFloor in BotRight_D)
            {
                singleFloor.transform.gameObject.tag = "BotRight";
            }
            foreach (GameObject singleFloor in Top)
            {
                singleFloor.transform.gameObject.tag = "Top_D";
            }

            foreach (GameObject singleFloor in TopLeft)
            {
                singleFloor.transform.gameObject.tag = "TopLeft_D";
            }
            foreach (GameObject singleFloor in TopRight_D)
            {
                singleFloor.transform.gameObject.tag = "TopRight";
            }

        }





        if (PlacementReady == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            /*2x2*/
            if (active == true)
            {


                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Floor" || hit.collider.gameObject.tag == "TopLeft" || hit.collider.gameObject.tag == "TopRight" || hit.collider.gameObject.tag == "BotLeft" || hit.collider.gameObject.tag == "BotRight"
                        || hit.collider.gameObject.tag == "Bot" || hit.collider.gameObject.tag == "Left" || hit.collider.gameObject.tag == "Right" || hit.collider.gameObject.tag == "Top")
                    {
                        //print("Collider Object :" + hit.collider.name + " Pos.X : " + hit.transform.position.x + " Pos.Z : " + hit.transform.position.z);
                        Vector3 temp = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                        TestCube_2x2.transform.position = temp;


                        if (Input.GetMouseButtonDown(0))
                        {

                            if (NotPlaceable == false)
                            {
                                //GameObject go = (TestCube_2x2, temp , Quaternion.Euler(new Vector3(0, RotateStock, 0))) as GameObject;
                                GameObject go = Instantiate(TestCube_2x2, temp, Quaternion.Euler(new Vector3(0, RotateStock, 0))) as GameObject;
                                go.name = "Box_2x2";
                                go.tag = "Placed";
                                go.AddComponent<ColliderDetect>();
                                Destroy(go.GetComponent<BacktoStart>());
                                go.SetActiveRecursively(true);
                                go.transform.Find("Child_Box").gameObject.tag = "Placed";
                                go.transform.Find("Child_Box").gameObject.AddComponent<ColliderDetect>();
                            }
                            else
                            {
                                print("Not Placeable");
                                return;
                            }


                        }

                        /*Rotate control click*/
                        if (Input.GetMouseButtonDown(1))
                        {
                            if (active == true)
                            {
                                rotateControl++;

                                TestCube_2x2.transform.Rotate(0, 90, 0);

                                RotateStock = TestCube_2x2.transform.eulerAngles.y;
                                print(TestCube_2x2.transform.eulerAngles.y);

                                if (rotateControl > 3)
                                    rotateControl = 0;
                            }
                        }
                        /*End*/


                    }
                }
            }
            /*end*/




            /*1x1*/
            if (active == false)
            {
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.gameObject.tag == "Floor" || hit.collider.gameObject.tag == "TopLeft" || hit.collider.gameObject.tag == "TopRight" || hit.collider.gameObject.tag == "BotLeft" || hit.collider.gameObject.tag == "BotRight"
                        || hit.collider.gameObject.tag == "Bot" || hit.collider.gameObject.tag == "Left" || hit.collider.gameObject.tag == "Right" || hit.collider.gameObject.tag == "Top" || hit.collider.gameObject.tag == "Top_D"
                        || hit.collider.gameObject.tag == "Bot_D" || hit.collider.gameObject.tag == "Left_D" || hit.collider.gameObject.tag == "Right_D" || hit.collider.gameObject.tag == "Bot_D" || hit.collider.gameObject.tag == "BotLeft_D"
                        || hit.collider.gameObject.tag == "BotRight_D" || hit.collider.gameObject.tag == "TopLeft_D" || hit.collider.gameObject.tag == "TopRight_D")
                    {
                        //print("Collider Object :" + hit.collider.name + " Pos.X : " + hit.transform.position.x + " Pos.Z : " + hit.transform.position.z);
                        Vector3 temp = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                        TestCube.transform.position = temp;

                        if (Input.GetMouseButtonDown(0))
                        {

                            if (NotPlaceable == false)
                            {
                                //GameObject go = (TestCube_2x2, temp , Quaternion.Euler(new Vector3(0, RotateStock, 0))) as GameObject;
                                GameObject go = Instantiate(TestCube, temp, Quaternion.Euler(new Vector3(0, RotateStock, 0))) as GameObject;
                                //go.name = "1x1-Building";
                                go.tag = "Placed";
                                go.AddComponent<ColliderDetect>();
                                Destroy(go.GetComponent<BacktoStart>());
                                go.SetActiveRecursively(true);

                            }
                            else
                            {
                                print("Not Placeable");
                                return;
                            }


                        }

                        /*Rotate control click*/
                        if (Input.GetMouseButtonDown(1))
                        {
                            if (active == true)
                            {
                                rotateControl++;

                                TestCube.transform.Rotate(0, 90, 0);

                                RotateStock = TestCube.transform.eulerAngles.y;
                                print(TestCube.transform.eulerAngles.y);

                                if (rotateControl > 3)
                                    rotateControl = 0;
                            }
                        }
                        /*End*/

                    }
                }
            }
        }
        /*end*/
    }
}

