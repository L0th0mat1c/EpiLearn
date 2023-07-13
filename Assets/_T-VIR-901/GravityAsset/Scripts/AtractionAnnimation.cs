using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractionAnnimation : MonoBehaviour
{
    // Start is called before the first frame update

    private Renderer renderer;
    private float offset = 0f;
    [SerializeField] float offsetSpeed = 7f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset -= offsetSpeed * Time.deltaTime;
        renderer.material.SetFloat("_Offset_Y", offset);
    }

    
}
