using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateManager : MonoData
{
    static IMonoData monoData = null;

    public static IMonoData MonoData
    {
        get
        {
            if(monoData == null)
            {
                monoData = (IMonoData)FindObjectOfType(typeof(UpdateManager));
            }

            return monoData;

        }
    }

    private UpdateManager() { }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        foreach (var item in AllUpdates)
        {
            item?.ThisUpdate();
        }
    }

    private void LateUpdate()
    {
        foreach (var item in AllLateUpdates)
        {
            item?.ThisLateUpdate();
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in AllFixedUpdates)
        {
            item?.ThisFixedUpdates();
        }
    }
}
