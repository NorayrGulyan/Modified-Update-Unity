using System;

namespace Update.System
{
    internal class Update<T> : IComparable
        where T : IBase
    {
        T update1;

        bool order;

        Func<Update<T>, bool> deleatThis;

        public T update
        {
            get
            {
                if (!order)
                {
                    return update1;
                }
                else if (OrderCount > 0)
                {
                    OrderCount--;
                    CalleCount++;
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

        public int CalleCount { get; private set; }

        public Update(T update, int scriptExecutionOrder)
        {
            this.update = update;
            ScriptExecutionOrder = scriptExecutionOrder;
            OrderCount = 0;
            order = false;
        }

        public Update(T update, int scriptExecutionOrder, int orderCount,Func<Update<T>, bool> deleatThis) :
            this(update, scriptExecutionOrder)
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

