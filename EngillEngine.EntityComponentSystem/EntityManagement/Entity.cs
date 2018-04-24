///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-18
///@Purpose :       
/// This class is a entity class(ironicly) it represents a entity. This class cannot be
/// interacted with directly but has to be handled from the outside by a entityHandle 

using System;
namespace EngillEngine.EntityComponentSystem.EntityManagement
{
    internal class Entity
    {
        //Exceptions
        public const string EXCEPTION_ENTITY_IS_ALREADY_ALIVE = "Entity:{0} is already alive and cannot be resurected!";
        public const string EXCEPTION_ENTITY_IS_ALREADY_DEAD = "Entity:{0} is already dead and cannot be killed!";

        //the unique entity id that is given on creation
        private uint id;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public uint ID{
            get{
                return id;
            }
        }

        // indicates wether this instance is alive
        private bool alive;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:EntityComponentSystem.EntityManagement.Entity"/> is alive.
        /// </summary>
        /// <value><c>true</c> if is alive; otherwise, <c>false</c>.</value>
        public bool IsAlive{
            get{
                return alive;
            }
        }

        //the current itteration in reincarnation
        private uint phase;

        /// <summary>
        /// Gets the phase.
        /// </summary>
        /// <value>The phase.</value>
        public uint Phase{
            get{
                return phase;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityComponentSystem.EntityManagement.Entity"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public Entity(uint id)
        {
            this.id = id;
            alive = false;
            phase = 0;
        }

        /// <summary>
        /// Ressurect this instance.
        /// </summary>
        internal void Ressurect(){
            if (alive)
                throw new Exception(string.Format(EXCEPTION_ENTITY_IS_ALREADY_ALIVE, id));

			alive = true;            
        }

        /// <summary>
        /// Kill this instance.
        /// </summary>
        internal void Kill(){
            if (!alive)
                throw new Exception(string.Format(EXCEPTION_ENTITY_IS_ALREADY_DEAD, id));
            alive = false;
            phase++;
        }
    }
}
