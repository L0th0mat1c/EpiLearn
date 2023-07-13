using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOnChange : MonoBehaviour
{
    // Start is called before the first frame update
    ItemManger itemManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Renderer renderer;
    string attractorMassName = "null";

    void Start()
    {
        itemManager = ItemManger.Instance;
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        setAttractorProperti();
        attractorMassName = itemManager.attractorSelected.massName; 
    }

    // Update is called once per frame
    void Update()
    {
        if(itemManager.attractorSelected.massName != attractorMassName){
            attractorMassName = itemManager.attractorSelected.massName;
            setAttractorProperti();
        }
    }

    private void setAttractorProperti(){
        rigidbody.mass = itemManager.attractorSelected.massValue;
        renderer.material.SetFloat("_Tiling_Y", itemManager.attractorSelected.sphereTilling);
    }
}
