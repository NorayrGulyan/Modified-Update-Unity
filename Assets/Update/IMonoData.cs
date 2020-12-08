using System.Collections.Generic;

public interface IMonoData
{

    void ImplementationUpdate(IUpdate update ,MonoSwitch monoSwitch);

    void ImplementationFixedUpdate(IFixedUpdate fixedUpdate,MonoSwitch monoSwitch);

    void ImplementationLateUpdate(ILateUpdate lateUpdate ,MonoSwitch monoSwitch);
}