using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : BaseManager
{   
    public override void Init()
    {
        base.Init();
        UIManager.Instance.EnableUI();
        UIManager.Instance.SwitchMenuUI("Gravity");
    }

    public override void Exit()
    {
        base.Exit();

        if(UIManager.Instance != null)
            UIManager.Instance.DisableUI();
    }
}