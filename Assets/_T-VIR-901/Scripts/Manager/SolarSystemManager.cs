using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : BaseManager
{   
    private const int ratioScale = 2;

    public GameObject container;
    public int GameSpeed { get; set; } = 1;
    public Info InfoShowed { get; set; }
    [SerializeField] private List<GameObject> infoObjects;
    private GameObject objShowedWithInfo { get; set; }
    private AudioSource currentSpeach = null;

    public override void Init()
    {
        base.Init();
        AnimationManager.Instance.PopUp(container);

        UIManager.Instance.SwitchTutorialMode(0);
        UIManager.Instance.EnableUI();
        UIManager.Instance.SwitchMenuUI("SolarSystem");
    }

    public override void Exit()
    {
        base.Exit();
        RemoveInfo();

        if(UIManager.Instance != null)
            UIManager.Instance.DisableUI();

         // On désactive les circle renderers
        foreach(GameObject obj in infoObjects)
        {
            DrawCircle drawCircle;
            if(obj.TryGetComponent(out drawCircle))
                obj.GetComponent<DrawCircle>().hideCircle();
        }
    }

    //Stop rotation
    public void PauseGame()
    {
        UIManager.Instance.SwitchTutorialMode(3);
        GameSpeed = 0;
    }
    //Play rotation
    public void PlayGame()
    {
        UIManager.Instance.SwitchTutorialMode(3);
        GameSpeed = 1;
    }
    //Speed rotation
    public void SpeedGame()
    {
        UIManager.Instance.SwitchTutorialMode(3);
        if (GameSpeed < 10)
            GameSpeed += 1;
    }
    //Slow rotation
    public void SlowGame()
    {
        UIManager.Instance.SwitchTutorialMode(3);
        if (GameSpeed > 1)
            GameSpeed -= 1;
    }
    public void ShowInfo(GameObject objWithInfo)
    {
        UIManager.Instance.SwitchTutorialMode(1);

        InfoComponent infoComponent;
        if (!objWithInfo.TryGetComponent(out infoComponent))
            return;

        InfoShowed = infoComponent.Info;
        objShowedWithInfo = objWithInfo;
        UIManager.Instance.ShowInfo(InfoShowed, objWithInfo.transform.position);
        zoomOneObject(objShowedWithInfo);
    }
    public void RemoveInfo()
    {
        InfoShowed = null;
        UIManager.Instance.ShowInfo(null, Vector3.zero);
        dezoom();
    }

    /// <summary>
    /// Cache tous les objets (sauf celui en param�tre) puis zoom l'objet en param�tre.
    /// </summary>
    /// <param name="objShowed">L'objet qu'on veut zoom�.</param>
    private void zoomOneObject(GameObject objShowed)
    {
        if (infoObjects.Contains(objShowed))
        {
            // On d�sactive les autres objets.
            foreach(GameObject obj in infoObjects)
            {
                if (obj != objShowed) {
                    InfoComponent infoComp;
                    if(obj.TryGetComponent(out infoComp)) {
                        float defaultScale = obj.GetComponent<InfoComponent>().getDefaultScale();
                        AnimationManager.Instance.PopOut(obj, defaultScale);
                    }

                    //On masque les lines renderers
                    DrawCircle drawCircle;
                    if(obj.TryGetComponent(out drawCircle))
                        obj.GetComponent<DrawCircle>().hideCircle();
                }
            }
             
            //On lance le speach de la planète clickée
            currentSpeach = objShowed.GetComponent<AudioSource>();
            if (currentSpeach != null)
                currentSpeach.PlayDelayed(1); 

            //On arrête la rotation de la planète
            Rotation rotateTest;
            if(objShowed.transform.parent.TryGetComponent(out rotateTest))
                objShowed.transform.parent.GetComponent<Rotation>().activateRotation = false;

            // On zoom l'objet.
            AnimationManager.Instance.ScaleTo(objShowed, objShowed.transform.localScale.x + ratioScale);
        }
    }

    /// <summary>
    /// R�affiche tous les objets et d�zoom l'objet zoom�.
    /// </summary>
    private void dezoom()
    {
        // On r�affiche tous les autres objets.
        foreach (GameObject obj in infoObjects)
        {
            if (obj != objShowedWithInfo) {
                InfoComponent infoComp;
                if(obj.TryGetComponent(out infoComp)) {
                    float defaultScale = obj.GetComponent<InfoComponent>().getDefaultScale();
                    AnimationManager.Instance.PopUp(obj, defaultScale);
                }
            
                //On affiche les lines renderers
                DrawCircle drawCircle;
                if(obj.TryGetComponent(out drawCircle))
                    obj.GetComponent<DrawCircle>().showCircle();
            }
        }

        // Si il y a un objet zoom�, on le dezoom.
        if(objShowedWithInfo != null)
        {
            //On arrête le speach de la planète
            if (currentSpeach != null)
                currentSpeach.Stop();

            //On relance la rotation de la planète
            Rotation rotateTest;
            if(objShowedWithInfo.transform.parent.TryGetComponent(out rotateTest))
                objShowedWithInfo.transform.parent.GetComponent<Rotation>().activateRotation = true;

            //On dezoom la planète
            AnimationManager.Instance.ScaleTo(objShowedWithInfo, objShowedWithInfo.transform.localScale.x - ratioScale);

            objShowedWithInfo = null;
        }
    }
}
