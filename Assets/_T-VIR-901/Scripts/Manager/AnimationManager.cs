using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }

    private AnimationManager() { }

    private void Awake()
    {
        if (Instance == null || Instance == this)
            Instance = this;
    }

    //Grow up an object from 0 to value
    public void PopUp(GameObject obj, float scale = 1f)
    {
        obj.transform.DOScale(Vector3.zero, 0f).OnComplete(() => {
            obj.SetActive(true);
        });
        obj.transform.DOScale(scale, 1f);
    }

    //Grow down an object from value to 0
    public void PopOut(GameObject obj, float scale = 1f) 
    {
        obj.transform.DOScale(scale, 0f);
        obj.transform.DOScale(Vector3.zero, 1f).OnComplete(() => {
            obj.SetActive(false);
        });
    }

    //Scale an object to value
    public void ScaleTo(GameObject obj, float scale = 1f)
    {
        obj.transform.DOScale(scale, 1f);
    }
}
