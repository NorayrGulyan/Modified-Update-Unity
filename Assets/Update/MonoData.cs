using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Update.System
{
    public enum MonoSwitch
    {
        Add,
        Remove
    }

    public abstract class MonoData : MonoBehaviour, IMonoData
    {
        protected private List<Update> Updates { get; private set; } = new List<Update>();

        protected private List<ILateUpdate> LateUpdates { get; private set; } = new List<ILateUpdate>();

        protected private List<IFixedUpdate> FixedUpdates { get; private set; } = new List<IFixedUpdate>();

        public bool ImplementationUpdate(IUpdate update, MonoSwitch monoSwitch, int scriptOrder = 0,int orderCount = 0)
        {
            Update upd;

            if (orderCount <= 0)
            {
                upd = new Update(update, scriptOrder);
            }
            else upd = new Update(update, scriptOrder,orderCount,Updates.Remove);


            switch (monoSwitch)
            {
                case MonoSwitch.Add:

                    if (Updates.Contains(upd))
                    {
                        Debug.LogWarning("Element already exists");
                        return false;
                    }
                    else
                    {
                        Updates.Add(upd);
                        Updates.Sort();
                        return true;
                    }

                case MonoSwitch.Remove:
                    return Updates.Remove(upd);
            }
            return false;
        }

        public bool ImplementationFixedUpdate(IFixedUpdate fixedUpdate, MonoSwitch monoSwitch)
        {
            switch (monoSwitch)
            {
                case MonoSwitch.Add:

                    if (FixedUpdates.Contains(fixedUpdate))
                    {
                        Debug.LogWarning("Element already exists");
                        return false;
                    }
                    else
                    {
                        FixedUpdates.Add(fixedUpdate);
                        return true;
                    }

                case MonoSwitch.Remove:
                    return FixedUpdates.Remove(fixedUpdate);
            }
            return false;
        }

        public bool ImplementationLateUpdate(ILateUpdate lateUpdate, MonoSwitch monoSwitch)
        {
            switch (monoSwitch)
            {
                case MonoSwitch.Add:

                    if (LateUpdates.Contains(lateUpdate))
                    {
                        Debug.LogWarning("Element already exists");
                        return false;
                    }
                    else
                    {
                        LateUpdates.Add(lateUpdate);
                        return true;
                    }

                case MonoSwitch.Remove:
                    return LateUpdates.Remove(lateUpdate);
            }
            return false;
        }
    }
}