using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]
    IMonoData monoData = null;

    private void Awake()
    {

        if(monoData == null)
        {
            GameObject[] objects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var item in objects)
            {

                if (item.TryGetComponent<IMonoData>(out monoData))
                {
                    break;
                }
            }

            if (monoData == null) { throw new System.NullReferenceException(); }
        }
        
    }

    void Update()
    {
        foreach (var item in monoData.AllUpdates)
        {
            item?.ThisUpdate();
        }
    }

    private void LateUpdate()
    {
        foreach (var item in monoData.AllLateUpdates)
        {
            item?.ThisLateUpdate();
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in monoData.AllFixedUpdates)
        {
            item?.ThisFixedUpdates();
        }
    }
}
