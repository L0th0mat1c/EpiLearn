using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    public string titre;
    [SerializeField]
    public string description;
    [SerializeField]
    public string rayon;
    [SerializeField]
    public string type;

    public Vector3 angularVelocity;
    public Space space = Space.Self;

    private void Update() {
        transform.Rotate(angularVelocity * Time.deltaTime, space);
    }
}
