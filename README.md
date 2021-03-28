# Modified Update in Unity
### Optimization of the function Update,FixedUpdate,LateUpdate;
### You can also script execution order and execution count;

#### 1. First add component (UpdateManager)-Script.

#### 2. Depending on which method you need to implement(Update,FixedUpdate,LateUpdate).
   - Implement an interface of the same name (IUpdate,IFixedUpdate,ILateUpdate).

#### 3. An object that implements the interfaces must be passed to the UpdateManager via Implementation properties.
   - Updates
   - FixedUpdates
   - LateUpdate
