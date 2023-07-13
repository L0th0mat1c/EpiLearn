using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiScript : MonoBehaviour
{
    private VisualElement root;
    private ItemManger itemManger;
    private SatelliteManager satelliteManager;

    public bool isOpen = false;
        
    private void OnEnable() {

        itemManger = ItemManger.Instance;
        satelliteManager = SatelliteManager.Instance;
        root = GetComponent<UIDocument>().rootVisualElement;

        DropdownField sat = root.Q<DropdownField>("Sat");
        DropdownField att = root.Q<DropdownField>("Att");
        Slider vit = root.Q<Slider>("Vit");

        sat.choices = itemManger.satelliteListName;
        att.choices = itemManger.attractorListName;

        sat.RegisterValueChangedCallback(v => itemManger.setSelectedMass(v.newValue, "sat"));
        att.RegisterValueChangedCallback(v => itemManger.setSelectedMass(v.newValue, "att"));
        vit.RegisterValueChangedCallback(v => itemManger.setVitesse(v.newValue));

        Button send = root.Q<Button>("send");

        send.clicked += sendSatellite;
    }

    public void sendSatellite(){
        satelliteManager.SendSattelite();
    }

    public void ToggleView(){
        if(isOpen){
            root.style.display = DisplayStyle.None;
        }else{
            root.style.display = DisplayStyle.Flex;
        }
    }
}



