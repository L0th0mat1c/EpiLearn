using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class PlanetListManager : BaseManager
{
    public GameObject[] planetList;
    public float scaleTime;
    public VisualElement root;

    private AudioSource switchSound;

    public override void Init()
    {
        base.Init();
        UIManager.Instance.EnableUI();
        UIManager.Instance.SwitchMenuUI("PlanetList");
    }

    public override void Exit()
    {
        base.Exit();
        if(UIManager.Instance != null)
            UIManager.Instance.DisableUI();
    }

    public void ActualiserAffichage(int index) {
        for (var i = 0; i < planetList.Length-1; i++)
        {
            if(planetList[i] != null) {
                if(i != index) {
                    planetList[i].transform.DOScale(0f, scaleTime-0.25f).SetEase(Ease.OutBounce).OnComplete(() => {
                        planetList[i].SetActive(false);
                    });
                } else {
                    planetList[i].transform.DOScale(2.4f, scaleTime).SetEase(Ease.OutBounce).OnStart(() => { 
                        planetList[i].transform.localScale = Vector3.zero;
                        planetList[i].SetActive(true);
                    });
                }
            }
        }
    }
}
