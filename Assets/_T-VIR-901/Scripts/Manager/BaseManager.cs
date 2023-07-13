using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager : MonoBehaviour, IManager
{
    public virtual void Exit()
    {
        if(GameManager.Instance.CurrentProjectManager == this)
            GameManager.Instance.ChangeProject(null);
    }

    public virtual void Init()
    {
        GameManager.Instance.ChangeProject(this);
    }
}
