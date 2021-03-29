using System;

namespace Update.System
{
    internal class Update<T> : IComparable
        where T : IBaseUpdate
    {
        T update1;

        bool order;

        Func<Update<T>, bool> deleatThis;

        public readonly string Name;

        public bool Foldout;

        public T update
        {
            get
            {
                if (!order)
                {
                    CallCount++;
                    return update1;
                }
                else if (OrderCount > 0)
                {
                    OrderCount--;
                    CallCount++;
                    return update1;
                }
                else
                {
                    deleatThis?.Invoke(this);
                    return default;
                }
            }

            private set => update1 = value;
        }

        public int ScriptExecutionOrder { get; private set; }

        public int OrderCount { get;private set; }

        public int CallCount { get; private set; }

        public Update(in T update,in int scriptExecutionOrder,in string name)
        {
            this.update = update;
            ScriptExecutionOrder = scriptExecutionOrder;
            OrderCount = 0;
            order = false;
            Name = name;
        }

        public Update(in T update,in int scriptExecutionOrder,in string name ,in int orderCount,in Func<Update<T>, bool> deleatThis) :
            this(update, scriptExecutionOrder,name)
        {
            OrderCount = orderCount;
            order = true;
            this.deleatThis = deleatThis;
        }

        public int CompareTo(object obj)
        {
            Update<T> u = obj as Update<T>;

            if (u != null)
            {
                if (ScriptExecutionOrder > u.ScriptExecutionOrder)
                    return 1;
                else if (ScriptExecutionOrder < u.ScriptExecutionOrder)
                    return -1;
                else
                    return 0;
            }
            else return 0;
        }
    }
}

