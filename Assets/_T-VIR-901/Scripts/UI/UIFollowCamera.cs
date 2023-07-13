using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    Camera cameraToLookAt;

    public float FixedSize = .2f;
 
    // Use t$$anonymous$$s for initialization 
    void Start()
    {
        cameraToLookAt = Camera.main;
    }

    // Update is called once per frame 
    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);

        var distance = (cameraToLookAt.transform.position - transform.position).magnitude;
        transform.localScale = new Vector3(FixedSize,FixedSize,FixedSize) * (distance * FixedSize);
    }
}
