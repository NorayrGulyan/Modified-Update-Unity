using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Update.System;

public class Test : MonoBehaviour, IUpdate
{
    [SerializeField]
    int num;

    [SerializeField]
    int scriptExecutionOrder;

    [SerializeField]
    int orderCount;

    private void Start()
    {
        UpdateManager.Implementation.Update(this, MonoSwitch.Add, scriptExecutionOrder, orderCount);
    }

    public void ThisUpdate()
    {
        Debug.Log(num);
    }
}
