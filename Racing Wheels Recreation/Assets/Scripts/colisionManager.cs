using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionManager : MonoBehaviour
{
    MeshCollider mc;
    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableMeshCollider()
    {
        mc.enabled = true;
    }

    public void DisableMeshCollider()
    {
        mc.enabled = false;
    }
}
