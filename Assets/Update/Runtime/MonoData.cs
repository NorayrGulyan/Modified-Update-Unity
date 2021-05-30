using System.Collections.Generic;
using UnityEngine;

namespace Update.System
{
    public enum Switch
    {
        Add,
        Remove
    }
    public abstract class MonoData : MonoBehaviour, IImplementation
    {
        internal List<Update<IUpdate>> Updates { get; private set; } = new List<Update<IUpdate>>();

        internal List<Update<ILateUpdate>> LateUpdates { get; private set; } = new List<Update<ILateUpdate>>();

        internal List<Update<IFixedUpdate>> FixedUpdates { get; private set; } = new List<Update<IFixedUpdate>>();

        public bool Update(in IUpdate update, in Switch @switch,in string name ,in int scriptOrder = 0, in int orderCount = 0)
        {
            Update<IUpdate> upd;

            if (orderCount <= 0)
            {
                upd = new Update<IUpdate>(update, scriptOrder, name);
            }
            else upd = new Update<IUpdate>(update, scriptOrder, name, orderCount, Updates.Remove);


            switch (@switch)
            {
                case Switch.Add:

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

                case Switch.Remove:
                    return Updates.Remove(upd);
            }
            return false;
        }

        public bool FixedUpdate(in IFixedUpdate fixedUpdate, in Switch @switch, in string name, in int scriptOrder = 0, in int orderCount = 0)
        {

            Update<IFixedUpdate> upd;

            if (orderCount <= 0)
            {
                upd = new Update<IFixedUpdate>(fixedUpdate, scriptOrder, name);
            }
            else upd = new Update<IFixedUpdate>(fixedUpdate, scriptOrder, name, orderCount, FixedUpdates.Remove);


            switch (@switch)
            {
                case Switch.Add:

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

                case Switch.Remove:
                    return FixedUpdates.Remove(upd);
            }
            return false;
        }

        public bool LateUpdate(in ILateUpdate lateUpdate, in Switch @switch, in string name, in int scriptOrder = 0, in int orderCount = 0)
        {
            Update<ILateUpdate> upd;

            if (orderCount <= 0)
            {
                upd = new Update<ILateUpdate>(lateUpdate, scriptOrder, name);
            }
            else upd = new Update<ILateUpdate>(lateUpdate, scriptOrder, name,orderCount, LateUpdates.Remove);


            switch (@switch)
            {
                case Switch.Add:

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

                case Switch.Remove:
                    return LateUpdates.Remove(upd);
            }
            return false;
        }
    }
}