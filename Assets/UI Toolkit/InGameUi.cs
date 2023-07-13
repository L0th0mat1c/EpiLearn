using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUi : MonoBehaviour
{
    VisualElement root;
    VisualElement menuSolarSystem;
    VisualElement menuPlanetList;
    VisualElement menuGravity;
    SolarSystemManager solarSystemManager;
    PlanetListManager planetListManager;
    private ItemManger itemManger;
    private SatelliteManager satelliteManager;
    public bool isOpen = false;
    private int index = 0;
    private string actualMenu = "";
        
    private void OnEnable() {
        //Récupération du UIDocument
        root = GetComponent<UIDocument>().rootVisualElement;

        //SolarSystem Scene
        solarSystemManager = GameObject.Find("GameManager").GetComponent<SolarSystemManager>();
        menuSolarSystem = root.Q<VisualElement>("MenuSolar");

        Button play = root.Q<Button>("Play");
        Button pause = root.Q<Button>("Pause");
        Button speed = root.Q<Button>("Speed");
        Button slow = root.Q<Button>("Slow");

        play.clicked += OnPlay;
        pause.clicked += OnPause;
        speed.clicked += OnSpeed;
        slow.clicked += OnSlow;
        
        //PlanetList Scene
        planetListManager = GameObject.Find("GameManager").GetComponent<PlanetListManager>();
        menuPlanetList = root.Q<VisualElement>("MenuList");

        Button previousList = root.Q<Button>("PreviousList");
        Button nextList = root.Q<Button>("NextList");

        previousList.clicked += PreviousIndex;
        nextList.clicked += NextIndex;

        planetListManager.ActualiserAffichage(index);

        //Gravity Scene
        itemManger = ItemManger.Instance;
        satelliteManager = SatelliteManager.Instance;
        menuGravity = root.Q<VisualElement>("MenuGravity");

        DropdownField sat = root.Q<DropdownField>("Sat");
        DropdownField att = root.Q<DropdownField>("Att");
        Slider vit = root.Q<Slider>("Vit");

        sat.choices = itemManger.satelliteListName;
        att.choices = itemManger.attractorListName;

        sat.RegisterValueChangedCallback(v => itemManger.setSelectedMass(v.newValue, "sat"));
        att.RegisterValueChangedCallback(v => itemManger.setSelectedMass(v.newValue, "att"));
        vit.RegisterValueChangedCallback(v => itemManger.setVitesse(v.newValue));

        Button send = root.Q<Button>("send");
        Button reset = root.Q<Button>("reset");

        send.clicked += sendSatellite;
        reset.clicked += clickOnReset;
    }

    private void LateUpdate() {
        if(actualMenu != "") {
            EnableSpecificUI(actualMenu);
        }
    }

    //Activation de tout l'IUPlayer
    public void EnableUI(){
       root.style.display = DisplayStyle.Flex;
    }
    //Désactivation de tout l'IUPlayer
    public void DisableUI(){
        root.style.display = DisplayStyle.None;
    }

    //Set le nom du menu qui doit être affiché
    public void setActualMenu(string menu) {
        actualMenu = menu;
    }

    //Active l'UI et désactive les autres
    public void EnableSpecificUI(string uiName) {
        switch(uiName) {
            case "SolarSystem":
                menuSolarSystem.style.display = DisplayStyle.Flex;
                menuPlanetList.style.display = DisplayStyle.None;
                menuGravity.style.display = DisplayStyle.None;
                break;
            case "PlanetList":
                menuPlanetList.style.display = DisplayStyle.Flex;
                menuSolarSystem.style.display = DisplayStyle.None;
                menuGravity.style.display = DisplayStyle.None;
                break;
            case "Gravity":
                menuGravity.style.display = DisplayStyle.Flex;
                menuPlanetList.style.display = DisplayStyle.None;
                menuSolarSystem.style.display = DisplayStyle.None;
                break;
            default:
                menuSolarSystem.style.display = DisplayStyle.None;
                menuPlanetList.style.display = DisplayStyle.None;
                menuGravity.style.display = DisplayStyle.None;
                break;
        }
    }

    public void ToggleView(){
        if(isOpen){
            root.style.display = DisplayStyle.None;
        }else{
            root.style.display = DisplayStyle.Flex;
        }
    }

    ////////////////// Solar System Scene ///////////////////

    void OnPlay(){
        Debug.Log("play");
        solarSystemManager.PlayGame();
    }
    void OnPause(){
        Debug.Log("Pause");
        solarSystemManager.PauseGame();
    }
    void OnSpeed(){
        Debug.Log("Speed");
        solarSystemManager.SpeedGame();
    }
    void OnSlow(){
        Debug.Log("Slow");
        solarSystemManager.SlowGame();
    }

    ////////////////// Planet List Scene ///////////////////

    public void NextIndex() {
        Debug.Log("NextIndex");
        if(index+1 > planetListManager.planetList.Length-1) {
            index=0;
        } else {
            index+=1;
        }
        planetListManager.ActualiserAffichage(index);
    }

    public void PreviousIndex() {
        Debug.Log("PreviousIndex");
         if(index-1 < 0) {
            index=planetListManager.planetList.Length-1;
        } else {
            index-=1;
        }
        planetListManager.ActualiserAffichage(index);
    }

    //////////////// Gravity Scene ////////////////////

    public void sendSatellite(){
        satelliteManager.SendSattelite();
    }

     public void clickOnReset(){
        satelliteManager.DestroyAllSat();
    }
}
