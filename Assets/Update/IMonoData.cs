using System.Collections.Generic;

public interface IMonoData
{
    List<IUpdate> AllUpdate { get;}

    List<ILateUpdate> AllLateUpdate { get; }

    List<IFixedUpdate> AllFixedUpdate { get; }

    void ImplementationUpdate(IUpdate update ,MonoSwitch monoSwitch);

    void ImplementationFixedUpdate(IFixedUpdate fixedUpdate,MonoSwitch monoSwitch);

    void ImplementationLateUpdate(ILateUpdate lateUpdate ,MonoSwitch monoSwitch);
}