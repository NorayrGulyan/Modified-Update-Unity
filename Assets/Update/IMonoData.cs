using System.Collections.Generic;

public interface IMonoData
{
    List<IUpdate> AllUpdates { get;}

    List<ILateUpdate> AllLateUpdates { get; }

    List<IFixedUpdate> AllFixedUpdates { get; }

    void ImplementationUpdate(IUpdate update ,MonoSwitch monoSwitch);

    void ImplementationFixedUpdate(IFixedUpdate fixedUpdate,MonoSwitch monoSwitch);

    void ImplementationLateUpdate(ILateUpdate lateUpdate ,MonoSwitch monoSwitch);
}