using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonoSwitch
{
    Add,
    Remove
}

public class MonoData : MonoBehaviour,IMonoData
{
    public List<IUpdate> AllUpdate { get;private set; } = new List<IUpdate>();

    public List<ILateUpdate> AllLateUpdate { get;private set; } = new List<ILateUpdate>();

    public List<IFixedUpdate> AllFixedUpdate { get;private set; } = new List<IFixedUpdate>();

    public void ImplementationUpdate(IUpdate update, MonoSwitch monoSwitch)
    {
        switch (monoSwitch)
        {
            case MonoSwitch.Add:
                AllUpdate.Add(update);
                break;

            case MonoSwitch.Remove:
                AllUpdate.Remove(update);
                break;
        }
    }

    public void ImplementationFixedUpdate(IFixedUpdate fixedUpdate, MonoSwitch monoSwitch)
    {
        switch (monoSwitch)
        {
            case MonoSwitch.Add:
                AllFixedUpdate.Add(fixedUpdate);
                break;

            case MonoSwitch.Remove:
                AllFixedUpdate.Remove(fixedUpdate);
                break;
        }
    }

    public void ImplementationLateUpdate(ILateUpdate lateUpdate, MonoSwitch monoSwitch)
    {
        switch (monoSwitch)
        {
            case MonoSwitch.Add:
                AllLateUpdate.Add(lateUpdate);
                break;

            case MonoSwitch.Remove:
                AllLateUpdate.Remove(lateUpdate);
                break;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
