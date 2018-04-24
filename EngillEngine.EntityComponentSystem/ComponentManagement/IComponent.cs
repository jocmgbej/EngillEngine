///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-18
///@Purpose :
/// This interface contains the functionality every component should have

using System;
namespace EngillEngine.EntityComponentSystem.ComponentManagement
{
    public interface IComponent
    {
        void Reset();
    }
}
