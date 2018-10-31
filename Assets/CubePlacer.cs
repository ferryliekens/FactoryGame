using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameManager gameManager;
    public Transform block;



    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {


        
        


        if (Input.GetMouseButtonDown(0) && gameManager.money > 0)
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();

                Debug.Log(hit.collider.name);
            }


            RaycastHit hitInfo;


            if (Physics.Raycast(ray, out hitInfo) && hits.Length < 2)
            {
                


                gameManager.BuyTile();
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(block, finalPosition, Quaternion.identity);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }

    //
    private void TempCube(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);

    }
}