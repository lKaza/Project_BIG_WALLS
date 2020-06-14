using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPosInt;
    public bool isPleaceable = true;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    [SerializeField] Tower towerPrefab;
    
    
    
    [SerializeField] Color exploredColor = Color.cyan;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetGridPos();        
    }

    private void PaintMeLikeOneOfYourFrenchGirls()
    {
        if(isExplored){
            MeshRenderer TopMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
            TopMeshRenderer.material.color = exploredColor;
        }
    }

    public Vector2Int GetGridPos()
    {    
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
                              Mathf.RoundToInt(transform.position.z / gridSize));
    }
    
    public void SetTopColor(Color color)
    {
       MeshRenderer TopMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
       TopMeshRenderer.material.color = color;
      
    }

    public int GetGridSize(){
        return gridSize;
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && isPleaceable){
            Tower newTower = Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity);
            isPleaceable = false;
        }else if(Input.GetMouseButtonDown(0)){
            print("impossibur");
        }
       
    }

}
