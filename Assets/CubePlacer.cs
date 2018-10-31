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
            RaycastHit hitInfo;

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();
            }

            if (Physics.Raycast(ray, out hitInfo) && hits.Length < 2)
            {
                gameManager.BuyTile();
                PlaceCubeNear(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit[] hits;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            foreach(var x in hits)
            {
                if(x.collider.tag == "Block")
                {
                    Destroy(x.collider.gameObject);
                }
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(block, finalPosition, Quaternion.identity);
    }

    private void TempCube(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);

    }
}