using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    public List<GameObject> Tutorials;
    public List<GameObject> TutorialsShowed;

    private TutorialManager() { }

    private void Awake()
    {
        if (Instance == null || Instance == this)
            Instance = this;
    }

    public void SwitchTutoMode(int? tutoStep)
    {
        if(tutoStep == null)
        {
            LeaveTutoMode();
        } 
        else {
            LeaveTutoMode();
            StartTutoMode((int) tutoStep);
        }
    }

    private void LeaveTutoMode()
    {
        foreach(GameObject gameObject in Tutorials) {
            gameObject.SetActive(false);
        }
    }

    private void StartTutoMode(int i)
    {
        if(!TutorialsShowed.Contains(Tutorials[i])) {
            TutorialsShowed.Add(Tutorials[i]);
            Tutorials[i].SetActive(true); 
        } else {
            LeaveTutoMode();
        }
    }
}
