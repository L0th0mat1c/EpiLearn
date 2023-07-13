using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoComponent : MonoBehaviour
{
    [SerializeField] public Info Info;
    
    private float defaultScale;

    void Start() {
        defaultScale = transform.localScale.x;
    }

    public float getDefaultScale() {
        return defaultScale;
    }
    
}
