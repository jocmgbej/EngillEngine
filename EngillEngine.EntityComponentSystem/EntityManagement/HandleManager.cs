///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-18
///@Purpose :   
/// This class is responsible for managing entityHandles this so we don't have to recreate
/// a entityHandle every time we want one, when the handle is disposed it comes back here
/// this all in a effort to evade GC

using System;
using System.Collections.Generic;

namespace EngillEngine.EntityComponentSystem.EntityManagement
{
    internal class HandleManager
    {
        //List where we store all the entity handles if they are not used we dont want to trigger GC for every handle dispose
        private List<EntityHandle> handleList;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityComponentSystem.EntityManagement.HandleManager"/> class.
        /// </summary>
        public HandleManager(){
            handleList = new List<EntityHandle>();
        }

        /// <summary>
        /// Creates a new entity handle.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public EntityHandle CreateHandle(Entity entity){
            EntityHandle newEntityHandle = null;

            //check if we have handles in existance
            if(handleList.Count > 0)
            {
                newEntityHandle = handleList[0];
                handleList.RemoveAt(0);
            }
            else //create a new entity handle
            {
                newEntityHandle = new EntityHandle(this);
            }

            //appoint the new entity
            newEntityHandle.AppointNewEntity(entity);

            //return the entityhandle
            return newEntityHandle;
        }

        /// <summary>
        /// Stores a disposed entity handle.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public void StoreHandle(EntityHandle handle){
            handleList.Add(handle);
        }

        /// <summary>
        /// Cleans up the handle manager before storage.
        /// </summary>
        public void CleanUp(){
            handleList.Clear();
        }
    }
}
