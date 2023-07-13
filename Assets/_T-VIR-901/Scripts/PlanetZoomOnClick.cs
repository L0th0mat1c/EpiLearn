using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;


public class PlanetZoomOnClick : MonoBehaviour
{
    //Variables
    public GameObject interfaceUI;
    public Transform type;
    public Transform title;
    public Transform rayon;
    public Transform description;
    public List<GameObject> planetsModels;
    public AudioSource backgroundSound;
    //private AudioSource currentSpeach = null;

    //Variables dynamique globales
    GameObject planetClickedObject;
    //bool alreadyZoomed = false;

    //Constantes
    const int ratioScale = 2;

    //void Update() {
    //    //Si on clique sur une planète sur le téléphone
    //    if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //        RaycastHit Hit;

    //        //Si le raycast passe par la planète on prend l'objet
    //        if(Physics.Raycast(ray, out Hit) && gameManager.State != GameState.PlanetMenu)
    //        {
    //            string planetClickedName = Hit.transform.name;
    //            //On désactive tous les enfants sauf la planète cliquée
    //            if(planetsModels.Contains(Hit.transform.gameObject)) {
    //                foreach (GameObject child in planetsModels) {
    //                    if(child.name != planetClickedName) {
    //                        child.SetActive(false);
    //                    } else {
    //                        //On garde en mémoire la planète sur laquelle on viens de cliquer
    //                        planetClickedObject = child;
    //                        //On aggrandit la planète
    //                        child.transform.localScale = new Vector3(child.transform.localScale.x+ratioScale, child.transform.localScale.y+ratioScale, child.transform.localScale.z+ratioScale);
    //                        // child.transform.DOScale(new Vector3(2,2,2), 2f);

    //                        //On récupère les infos de la planète 
    //                        Info planetInfo = child.GetComponent<InfoComponent>().Info;
    //                        //On récupère les Input de l'interface
    //                        Transform titreUI       = title;
    //                        Transform rayonUI      = rayon;
    //                        Transform typeUI        = type;
    //                        Transform descriptionUI = description;
    //                        currentSpeach = planetClickedObject.gameObject.GetComponent<AudioSource>();

    //                        //On met a jour les informations de l'interface
    //                        // TODO : Le switch en dessous est provisoire. A nettoyer et placer dans l'UIManager.
    //                        switch (planetInfo)
    //                        {
    //                            case PlanetInfo planet:
    //                                if (titreUI != null) { titreUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = planet.Titre; }
    //                                if (rayonUI != null) { rayonUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = planet.Rayon.ToString() + " km"; }
    //                                if (typeUI != null) { typeUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = planet.GetTypeInString(); }
    //                                if (descriptionUI != null) { descriptionUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = planet.Description; }
    //                                if (currentSpeach != null) { currentSpeach.PlayDelayed(1); }
    //                                break;
    //                            case StarInfo star:
    //                                if (titreUI != null) { titreUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = star.Titre; }
    //                                if (rayonUI != null) { rayonUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = star.Rayon.ToString() + " km"; }
    //                                if (typeUI != null) { typeUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = star.GetTypeInString(); }
    //                                if (descriptionUI != null) { descriptionUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = star.Description; }
    //                                if (currentSpeach != null) { currentSpeach.PlayDelayed(1); }
    //                                break;
    //                        }
    //                    }
    //                }
    //                //On active l'interface
    //                interfaceUI.gameObject.SetActive(true);
    //                backgroundSound.volume = 0.4F;
    //                // this.gameObject.GetComponent<AudioSource>().volume = 0.1F;

    //                alreadyZoomed = true;
    //            }
    //        }
    //    }
    //}

    void Update()
    {
        //Si on clique sur une planète sur le téléphone
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;

            //Si le raycast passe par la planète on prend l'objet
            if (Physics.Raycast(ray, out Hit) && GameManager.Instance.State != GameState.PlanetMenu)
            {
                string planetClickedName = Hit.transform.name;
                //On désactive tous les enfants sauf la planète cliquée
                if (planetsModels.Contains(Hit.transform.gameObject))
                {
                    GameObject planetClickedObject = planetsModels.Find((obj) => obj.name == planetClickedName);
                    GameObject manager = GameObject.FindGameObjectWithTag("GameController");

                    if (planetClickedObject == null)
                        return;

                    if (manager != null)
                    {
                        switch (GameManager.Instance.CurrentProjectManager)
                        {
                            case SolarSystemManager solarSystemManager:
                                solarSystemManager.ShowInfo(planetClickedObject);
                                break;
                        }
                    }

                    backgroundSound.volume = 0.4F;
                }
            }
        }
    }

    //public void dezoomFromPlanet() {
    //    //On réactive toutes les planètes
    //    foreach (GameObject child in planetsModels) {
    //        child.SetActive(true);
    //    }
    //    if (currentSpeach != null)  {currentSpeach.Stop();}
    //    interfaceUI.gameObject.SetActive(false);
    //    backgroundSound.volume = 1.0F;
    //    alreadyZoomed = false;
    //    //On remet la planète à sa taille initiale
    //    planetClickedObject.transform.localScale = new Vector3(planetClickedObject.transform.localScale.x-ratioScale, planetClickedObject.transform.localScale.y-ratioScale, planetClickedObject.transform.localScale.z-ratioScale);
    //}
}
