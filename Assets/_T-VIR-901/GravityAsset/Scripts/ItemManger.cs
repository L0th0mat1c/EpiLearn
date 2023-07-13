using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManger : MonoBehaviour
{
    // Start is called before the first frame update

    public List<MassPreset> satelliteList;
    public List<string> satelliteListName;
    public List<MassPreset> attractorList;
    public List<string> attractorListName;
    public MassPreset satelliteSelected;
    public MassPreset attractorSelected;

    public float vitesse;

    private static ItemManger _instance;

    public static ItemManger Instance
    {
        get 
        {
            if(_instance == null){
               Debug.LogWarning("No instance of ItemManger in the scene");
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
        initMass();
    }

    private void initMass(){
        

        foreach(MassPreset massPreset in satelliteList){
            satelliteListName.Add(massPreset.massName);
        }
        foreach(MassPreset massPreset in attractorList){
            attractorListName.Add(massPreset.massName);
        }
        satelliteSelected = satelliteList[0];
        attractorSelected = attractorList[0];
    }

    public void setSelectedMass(string massNameArg, string types){
        if(types == "sat"){
            satelliteSelected = satelliteList.Find(x => x.massName.Contains(massNameArg));
        }else if(types == "att"){
            attractorSelected = attractorList.Find(x => x.massName.Contains(massNameArg));
        }
    }

    public void setVitesse(float value){
        vitesse = value;
    }

    
}
