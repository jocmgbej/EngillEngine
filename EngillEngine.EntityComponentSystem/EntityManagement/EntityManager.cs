///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-18
///@Purpose :
/// This class is the entity manager. this class will be the on that can be created by the library user.
/// The responsabilty of this class is managing the entities, the entity component manager and registering
/// systems. Also all entities can be safed from here

using System;
using System.Collections.Generic;

namespace EngillEngine.EntityComponentSystem.EntityManagement
{
    public class EntityManager
    {
        //exception messages
        public const string EXCEPTION_ENTITY_OVERFLOW = "The maximum number of entities has been reached!";
        public const string EXCEPTION_INVALID_ENTITY_ID = "The given entity id:{0} is invalid!";

        //the maximum number of entities this entitymanager can contain
        private readonly uint MAX_NUM_OF_ENTITIES;

        //the next id counter
        private uint idCounter;
        //list of existing entity's that can be ressurected
        private List<uint> deadEntityList;

        //Array of entities
        private Entity[] entities;

        //the EntityHandleManager that manages entity handles
        private HandleManager handleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityComponentSystem.EntityManagement.EntityManager"/> class.
        /// </summary>
        /// <param name="numOfEntities">Number of entities.</param>
        public EntityManager(uint numOfEntities)
        {
            MAX_NUM_OF_ENTITIES = numOfEntities;
            idCounter = 0;
            deadEntityList = new List<uint>();
            entities = new Entity[MAX_NUM_OF_ENTITIES];
            handleManager = new HandleManager();
        }

        /// <summary>
        /// Gets the new identifier.
        /// </summary>
        /// <returns>The new identifier.</returns>
        private uint GetNewID(){
            //set the id to a value that will throw exceptions by default
            uint newId = MAX_NUM_OF_ENTITIES;
                      

            //check if we can reset the idCounter "this happens when the amount of dead entities == idCounter"
			if(deadEntityList.Count > 0 && idCounter == deadEntityList.Count){
                idCounter = 0;
                deadEntityList.Clear();
            }

            //check if we have existing dead entities
			if(deadEntityList.Count > 0)
            {
                newId = deadEntityList[0];
                deadEntityList.RemoveAt(0);
            }
            else //if we have no dead entities return a fresh id
            {
				if (idCounter >= MAX_NUM_OF_ENTITIES)
                    throw new Exception(EXCEPTION_ENTITY_OVERFLOW);
				
                newId = idCounter;
                idCounter++;
            }
            
			return newId;
        }

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <returns>EntityHandle that refers to the created entity.</returns>
        public EntityHandle CreateEntity(){
            uint newId = GetNewID();

            //Create a new entity if it doesnt exist
            if(entities[newId] == null){
                entities[newId] = new Entity(newId);
            }

            //ressurect the entity
            entities[newId].Ressurect();

            //create and return a new entityhandle for the entity
            return handleManager.CreateHandle(entities[newId]);
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <returns>EntityHandle that refers to the created entity.</returns>
        /// <param name="id">Identifier.</param>
        public EntityHandle GetEntity(uint id){
            //check if the id is valid
            if (id >= MAX_NUM_OF_ENTITIES)
                throw new Exception(string.Format(EXCEPTION_INVALID_ENTITY_ID, id));

            //check if the entity is alive
            if (entities[id].IsAlive)
                return handleManager.CreateHandle(entities[id]);
            else //if it is not return null
                return null;
        } 

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void RemoveEntity(uint id){
            //check if the id is valid
            if (id >= MAX_NUM_OF_ENTITIES)
                throw new Exception(string.Format(EXCEPTION_INVALID_ENTITY_ID, id));

			if (entities[id] != null)
			{
				//kill the entity so it can reincarnate into something else
				entities[id].Kill();
				deadEntityList.Add(id);
			}
        }
    }
}
