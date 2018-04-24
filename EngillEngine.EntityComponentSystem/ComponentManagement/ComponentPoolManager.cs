///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-18
///@Purpose :
/// The ComponentPoolManager manages componentsPools it checks the type of component 
/// and interacts with the right ComponentPool to create remove or get the component

using System;
using System.Collections.Generic;

namespace EngillEngine.EntityComponentSystem.ComponentManagement
{
    internal class ComponentPoolManager
    {
        //the maximum number of components 1 type per entity
        private readonly uint MAX_NUM_OF_COMPONENTS;
        //the dictionary where we save all our componentPool's
        private Dictionary<Type, IComponentPool> componentPools;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:EntityComponentSystem.ComponentManagement.ComponentPoolManager"/> class.
        /// </summary>
        public ComponentPoolManager(uint numOfComponents)
        {
            MAX_NUM_OF_COMPONENTS = numOfComponents;
            componentPools = new Dictionary<Type, IComponentPool>();
        }

        /// <summary>
        /// Creates a component pool.
        /// </summary>
        /// <typeparam name="T">Type of the component.</typeparam>
        private IComponentPool CreateComponentPool<T>()where T : class, IComponent, new(){
            ComponentPool <T> newPool = new ComponentPool<T>(MAX_NUM_OF_COMPONENTS);
            componentPools.Add(typeof(T), newPool);
            return newPool;
        }

        /// <summary>
        /// Creates the component in right componentPool.
        /// </summary>
        /// <returns>The component.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">Type of the component.</typeparam>
        public T CreateComponent<T>(uint id)where T : class, IComponent, new(){
            IComponentPool pool;
            //if ComponsentPool doesn't exist create a new one
            if (!componentPools.ContainsKey(typeof(T)))
                pool = CreateComponentPool<T>();
            else // get a existing one
                pool = componentPools[typeof(T)];
            
            return pool.CreateComponent(id) as T;
        }

        /// <summary>
        /// Gets the component from the right componentPool.
        /// </summary>
        /// <returns>The component.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">Type of the component.</typeparam>
        public T GetComponent<T>(uint id)where T : class, IComponent, new(){
            //check if we have the component pool
            if (componentPools.ContainsKey(typeof(T)))
                return componentPools[typeof(T)].GetComponent(id) as T;
            //else return null;
            return null;
        }

        /// <summary>
        /// Gets the components.
        /// </summary>
        /// <returns>The components.</returns>
        /// <typeparam name="T">Type of the component.</typeparam>
        public T[] GetComponents<T>()where T : class, IComponent, new(){
            //check if we have the component pool
            if (componentPools.ContainsKey(typeof(T)))
                return componentPools[typeof(T)].GetComponents() as T[];
            //else return null;
            return null;
        }

        /// <summary>
        /// Removes the component from the right componentPool
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">Type of the component.</typeparam>
        public void RemoveComponent<T>(uint id)where T : class, IComponent, new(){
            //check if we have the component pool
            if (componentPools.ContainsKey(typeof(T)))
                componentPools[typeof(T)].RemoveComponent(id);
        }

        //clean up all cached components before serializing
        public void CleanUp(){
            foreach (IComponentPool pool in componentPools.Values)
                pool.CleanUp();
        }
    }
}
