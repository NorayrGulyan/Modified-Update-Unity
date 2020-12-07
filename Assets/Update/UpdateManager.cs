using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateManager : MonoBehaviour
{
    IMonoData monoData = null;

    private void Awake()
    {
        GameObject[] objects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (var item in objects)
        {
            
            if(item.TryGetComponent<IMonoData>(out monoData))
            {
                break;
            }
        }

        if(monoData == null) { throw new System.NullReferenceException(); }
    }

    void Update()
    {
        foreach (var item in monoData.AllUpdate)
        {
            item?.ThisUpdate();
        }
    }

    private void LateUpdate()
    {
        foreach (var item in monoData.AllLateUpdate)
        {
            item?.ThisLateUpdate();
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in monoData.AllFixedUpdate)
        {
            item?.ThisFixedUpdates();
        }
    }
}
