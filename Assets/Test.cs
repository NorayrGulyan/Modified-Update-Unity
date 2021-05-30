using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Update.System;

public class Test : MonoBehaviour, IUpdate,ILateUpdate
{
    [SerializeField]
    int num;

    [SerializeField]
    int scriptExecutionOrder;

    [SerializeField]
    int orderCount;

    private void Start()
    {
        UpdateManager.Implementation.Update(this, Switch.Add, gameObject.name, scriptExecutionOrder, orderCount);
        UpdateManager.Implementation.LateUpdate(this, Switch.Add, gameObject.name, scriptExecutionOrder, orderCount);
    }

    public void ThisUpdate()
    {
        for (int i = 0; i < 100000; i++)
        {

        }
    }

    public void ThisLateUpdate()
    {
        for (int i = 0; i < 100000; i++)
        {

        }
    }
}
