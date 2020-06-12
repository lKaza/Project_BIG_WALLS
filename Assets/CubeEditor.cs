using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;

    void Start(){
        textMesh = GetComponentInChildren<TextMesh>();       
    }

    [Range(1f, 20f)] [SerializeField] float gridSize=10f;
    void Update()
    {
        
        Vector3 snapPos;
        snapPos.x = Mathf.Round(transform.position.x/gridSize)*gridSize;
        snapPos.z = Mathf.Round(transform.position.z/gridSize)*gridSize;
        textMesh.text = snapPos.x/gridSize + "," +snapPos.z/gridSize;
        transform.position = new Vector3 (snapPos.x,0f,snapPos.z);
    }
}
