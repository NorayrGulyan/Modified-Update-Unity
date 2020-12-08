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
    protected private List<IUpdate> AllUpdates { get;private set; } = new List<IUpdate>();

    protected private List<ILateUpdate> AllLateUpdates { get;private set; } = new List<ILateUpdate>();

    protected private List<IFixedUpdate> AllFixedUpdates { get;private set; } = new List<IFixedUpdate>();

    public void ImplementationUpdate(IUpdate update, MonoSwitch monoSwitch)
    {
        switch (monoSwitch)
        {
            case MonoSwitch.Add:
                AllUpdates.Add(update);
                break;

            case MonoSwitch.Remove:
                AllUpdates.Remove(update);
                break;
        }
    }

    public void ImplementationFixedUpdate(IFixedUpdate fixedUpdate, MonoSwitch monoSwitch)
    {
        switch (monoSwitch)
        {
            case MonoSwitch.Add:
                AllFixedUpdates.Add(fixedUpdate);
                break;

            case MonoSwitch.Remove:
                AllFixedUpdates.Remove(fixedUpdate);
                break;
        }
    }

    public void ImplementationLateUpdate(ILateUpdate lateUpdate, MonoSwitch monoSwitch)
    {
        switch (monoSwitch)
        {
            case MonoSwitch.Add:
                AllLateUpdates.Add(lateUpdate);
                break;

            case MonoSwitch.Remove:
                AllLateUpdates.Remove(lateUpdate);
                break;
        }
    }

}
