using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool activateRotation = true;

    public float RotationSpeed;
    public float dampAtm;
    SolarSystemManager manager;

    void Start() {
        manager = GameObject.Find("GameManager").GetComponent<SolarSystemManager>();
    }

    void Update()
    {
        if(activateRotation) {
            transform.Rotate((Vector3.up* (manager.GameSpeed * RotationSpeed)) * (Time.deltaTime * dampAtm), Space.Self);
        }
    }

}