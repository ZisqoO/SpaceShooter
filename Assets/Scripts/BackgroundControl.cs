using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    MeshRenderer renderer;
    Material material;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.x = 0;
        offset.y += 0.001f;
        material.mainTextureOffset = offset;
    }
}
