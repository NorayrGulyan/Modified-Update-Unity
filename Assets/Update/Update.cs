using System;

namespace Update.System
{
    internal class Update : IComparable
    {
        IUpdate update1;

        bool order;

        Func<Update, bool> deleatThis;

        public IUpdate update
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
                    return null;
                }
            }

            private set => update1 = value;
        }

        public int ScriptExecutionOrder { get; private set; }

        public int OrderCount { get;private set; }

        public int CalleCount { get; private set; }

        public Update(IUpdate update, int scriptExecutionOrder)
        {
            this.update = update;
            ScriptExecutionOrder = scriptExecutionOrder;

            OrderCount = 0;

            order = false;
        }

        public Update(IUpdate update, int scriptExecutionOrder, int orderCount,Func<Update, bool> deleatThis) : this(update, scriptExecutionOrder)
        {
            OrderCount = orderCount;
            order = true;
            this.deleatThis = deleatThis;
        }

        public int CompareTo(object obj)
        {
            Update u = obj as Update;

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

