
namespace Update.System
{
    public interface IImplementation
    {
        bool Update(in IUpdate update,in MonoSwitch monoSwitch,in int scriptOrder = 0,in int orderCount = 0);

        bool FixedUpdate(in IFixedUpdate fixedUpdate,in MonoSwitch monoSwitch,in int scriptOrder = 0,in int orderCount = 0);

        bool LateUpdate(in ILateUpdate lateUpdate,in MonoSwitch monoSwitch,in int scriptOrder = 0,in int orderCount = 0);
    }
}

