
namespace Update.System
{
    public interface IMonoData
    {
        bool ImplementationUpdate(IUpdate update, MonoSwitch monoSwitch, int scriptOrder = 0, int orderCount = 0);

        bool ImplementationFixedUpdate(IFixedUpdate fixedUpdate, MonoSwitch monoSwitch);

        bool ImplementationLateUpdate(ILateUpdate lateUpdate, MonoSwitch monoSwitch);
    }
}

