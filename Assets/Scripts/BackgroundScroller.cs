using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    private MeshRenderer _backgroundMeshRenderer;
    private Vector2 _textureOffset = Vector2.zero;
    private float _speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        _backgroundMeshRenderer = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        _textureOffset.y += _speed * Time.deltaTime;
        _backgroundMeshRenderer.material.mainTextureOffset = _textureOffset;
    }
}
