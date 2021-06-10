using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGen : MonoBehaviour
{
    public int gridWidth = 20;
    public int gridHeight = 20;

    public float cellWidth = 1.1f;
    public float cellHeight = 1.1f;

    public GameObject gridObject;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            for (int y = 0; y < gridHeight; ++y)
            {
                Vector3 offest = transform.right * ((x - (gridWidth * 0.5f)) * cellWidth) + transform.up * ((y - (gridHeight * 0.5f)) * cellHeight);

                GameObject newObject = Instantiate(gridObject, transform.position + offest, transform.rotation);
                newObject.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
