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

    public abstract class MonoData : MonoBehaviour, IImplementation
    {
        protected private List<Update<IUpdate>> Updates { get; private set; } = new List<Update<IUpdate>>();

        protected private List<Update<ILateUpdate>> LateUpdates { get; private set; } = new List<Update<ILateUpdate>>();

        protected private List<Update<IFixedUpdate>> FixedUpdates { get; private set; } = new List<Update<IFixedUpdate>>();

        public bool Update(in IUpdate update, in MonoSwitch monoSwitch, in int scriptOrder = 0, in int orderCount = 0)
        {
            Update<IUpdate> upd;

            if (orderCount <= 0)
            {
                upd = new Update<IUpdate>(update, scriptOrder);
            }
            else upd = new Update<IUpdate>(update, scriptOrder,orderCount,Updates.Remove);


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

        public bool FixedUpdate(in IFixedUpdate fixedUpdate, in MonoSwitch monoSwitch, in int scriptOrder = 0, in int orderCount = 0)
        {

            Update<IFixedUpdate> upd;

            if (orderCount <= 0)
            {
                upd = new Update<IFixedUpdate>(fixedUpdate, scriptOrder);
            }
            else upd = new Update<IFixedUpdate>(fixedUpdate, scriptOrder, orderCount, FixedUpdates.Remove);


            switch (monoSwitch)
            {
                case MonoSwitch.Add:

                    if (FixedUpdates.Contains(upd))
                    {
                        Debug.LogWarning("Element already exists");
                        return false;
                    }
                    else
                    {
                        FixedUpdates.Add(upd);
                        FixedUpdates.Sort();
                        return true;
                    }

                case MonoSwitch.Remove:
                    return FixedUpdates.Remove(upd);
            }
            return false;
        }

        public bool LateUpdate(in ILateUpdate lateUpdate, in MonoSwitch monoSwitch, in int scriptOrder = 0, in int orderCount = 0)
        {
            Update<ILateUpdate> upd;

            if (orderCount <= 0)
            {
                upd = new Update<ILateUpdate>(lateUpdate, scriptOrder);
            }
            else upd = new Update<ILateUpdate>(lateUpdate, scriptOrder, orderCount, LateUpdates.Remove);


            switch (monoSwitch)
            {
                case MonoSwitch.Add:

                    if (LateUpdates.Contains(upd))
                    {
                        Debug.LogWarning("Element already exists");
                        return false;
                    }
                    else
                    {
                        LateUpdates.Add(upd);
                        LateUpdates.Sort();
                        return true;
                    }

                case MonoSwitch.Remove:
                    return LateUpdates.Remove(upd);
            }
            return false;
        }
    }
}