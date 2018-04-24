///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-18
///@Purpose :
/// This interface only purpose is to prevent casting to dynamic type's and prevents the use of 
/// reflection for removal of components

using System;
namespace EngillEngine.EntityComponentSystem.ComponentManagement
{
    internal interface IComponentPool
    {
        IComponent CreateComponent(uint id);
        IComponent GetComponent(uint id);
        IComponent[] GetComponents();
        void RemoveComponent(uint id);
        void CleanUp();
    }
}
