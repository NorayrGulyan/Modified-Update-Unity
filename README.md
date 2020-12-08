# Modified Update in Unity
### Optimization of the function Update,FixedUpdate,LateUpdate;

#### 1. First add component (UpdateManager)-Script.

#### 2. Depending on which method you need to implement(Update,FixedUpdate,LateUpdate).
   - Implement an interface of the same name (IUpdate,IFixedUpdate,ILateUpdate).

#### 3. An object that implements the interfaces must be passed to the UpdateManager via MonoData properties.
   - ImplementationUpdates
   - ImplementationFixedUpdates
   - ImplementationLateUpdate
