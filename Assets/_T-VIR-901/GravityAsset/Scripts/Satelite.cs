using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Satelite : MonoBehaviour
{
    ItemManger itemManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Renderer renderer;
    string satelliteMassName;
    private Vector3 initPos; 

    void Start()
    {
        AnimEnter();
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        itemManager = ItemManger.Instance;
        setSatelliteProperti();
        initPos = transform.position;
        
        
    }

    void Update(){
        if(Vector3.Distance(gameObject.transform.position, initPos ) > 75 ){
            Destroy();
        }
    }

    private void AnimEnter(){
        renderer.material.DOFade(0,0);
        renderer.material.DOFade(1,0.5f);
    }

   

    private void setSatelliteProperti(){
        rigidbody.mass = itemManager.satelliteSelected.massValue;
        renderer.material.SetFloat("_Tiling_Y", itemManager.satelliteSelected.sphereTilling);
        renderer.material.SetFloat("_Tiling_X", itemManager.satelliteSelected.sphereTilling);
    }

    public void Destroy(){
        transform.DOScale(new Vector3(0,0,0), 1f);
        Destroy(this, 1f);
    }
}
