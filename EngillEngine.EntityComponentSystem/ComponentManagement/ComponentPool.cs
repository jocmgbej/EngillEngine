using System;
using System.Collections.Generic;
using EngillEngine.EntityComponentSystem.EntityManagement;

namespace EngillEngine.EntityComponentSystem.ComponentManagement
{
    internal class ComponentPool<T> : IComponentPool where T : class, IComponent, new()
    {
        //exceptions
        public const string EXCEPTION_INVALID_COMPONENT_ID = "The given component id:{0} is invalid!";

        //max num of entities that can contain components
        private readonly uint NUM_OF_COMPONENTS;
        //Array of components
        private T[] components;
        //registerd entities that have the component
        private HashSet<uint> entitiesWithComponent;
        //list of used components
        private List<T> usedComponentsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityComponentSystem.ComponentManagement.ComponentPool`1"/> class.
        /// </summary>
        /// <param name="numOfComponents">Number of components.</param>
        public ComponentPool(uint numOfComponents)
        {
            NUM_OF_COMPONENTS = numOfComponents;
            entitiesWithComponent = new HashSet<uint>();
            usedComponentsList = new List<T>();
        }

        /// <summary>
        /// Creates the component.
        /// </summary>
        /// <returns>The component.</returns>
        /// <param name="id">Identifier.</param>
        public IComponent CreateComponent(uint id)
        {
            //check if we have a valid id
            if (id >= NUM_OF_COMPONENTS)
                throw new Exception(string.Format(EXCEPTION_INVALID_COMPONENT_ID, id));
            
            //check if we already have it registerd
            if (entitiesWithComponent.Contains(id))
                return components[id];

            T newComponent;

            //if we have unused components recycle first
            if(usedComponentsList.Count > 0)
            {
                newComponent = usedComponentsList[0];
                newComponent.Reset();
                usedComponentsList.RemoveAt(0);
            }
            else //create new component
            {
                newComponent = new T();
            }

            //register entity id
            entitiesWithComponent.Add(id);
            //set the componet in componetArray
            components[id] = newComponent;
            //return new component
            return newComponent;
        }

        /// <summary>
        /// Gets the component.
        /// </summary>
        /// <returns>The component.</returns>
        /// <param name="id">Identifier.</param>
        public IComponent GetComponent(uint id)
        {
            //check for invalid id
            if (id >= NUM_OF_COMPONENTS)
                throw new Exception(string.Format(EXCEPTION_INVALID_COMPONENT_ID, id));
            return components[id];
        }

        /// <summary>
        /// Gets the components.
        /// </summary>
        /// <returns>The components.</returns>
        public IComponent[] GetComponents()
        {
            //check if we have registerd componets if not we have nothing to return
            if (entitiesWithComponent.Count == 0)
                return null;

            //create a new component array for all the componets we have
            T[] componentArray = new T[entitiesWithComponent.Count];

            //fill the component array
            int i = 0;
            foreach(uint id in entitiesWithComponent){
                componentArray[i] = components[id];
                i++;
            }

            //return component array
            return componentArray;
        }

        /// <summary>
        /// Removes the component.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void RemoveComponent(uint id)
        {
            //check if id is in valid range
            if(id >= NUM_OF_COMPONENTS)
                throw new Exception(string.Format(EXCEPTION_INVALID_COMPONENT_ID, id));

            //remove the component
            if(entitiesWithComponent.Contains(id) && components[id] != null)
            {
                //remove from entities with components
                entitiesWithComponent.Remove(id);
                //add to the unused list
                usedComponentsList.Add(components[id]);
                //set componetsArray to null
                components[id] = null;
            }
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        public void CleanUp()
        {
            //clear al unused components
            usedComponentsList.Clear();
        }
    }
}
