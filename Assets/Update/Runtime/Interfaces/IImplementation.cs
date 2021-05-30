
namespace Update.System
{
    public interface IImplementation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="update">Interface IUpdate</param>
        /// <param name="switch"></param>
        /// <param name="scriptOrder"></param>
        /// <param name="orderCount"></param>
        /// <returns>True if Implementation is successfully integrated or removed/returns>
        bool Update(in IUpdate update,in Switch @switch, in string name,in int scriptOrder = 0,in int orderCount = 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedUpdate">Interface IFixedUpdate</param>
        /// <param name="switch"></param>
        /// <param name="scriptOrder"></param>
        /// <param name="orderCount"></param>
        /// <returns>True if Implementation is successfully integrated or removed</returns>
        bool FixedUpdate(in IFixedUpdate fixedUpdate,in Switch @switch, in string name, in int scriptOrder = 0,in int orderCount = 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lateUpdate">Interface ILateUpdate</param>
        /// <param name="switch"></param>
        /// <param name="scriptOrder"></param>
        /// <param name="orderCount"></param>
        /// <returns>True if Implementation is successfully integrated or removed</returns>
        bool LateUpdate(in ILateUpdate lateUpdate,in Switch @switch, in string name, in int scriptOrder = 0,in int orderCount = 0);
    }
}

