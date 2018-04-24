using System;
namespace EngillEngine.EntityComponentSystem.EntityManagement
{
    public class EntityHandle
    {
        // the parent manager where we need to go back on disposal
        private HandleManager parent;

        // the entity we are referring to
        private Entity entity;

        // the phase the entity when appointed
        private long phase;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityComponentSystem.EntityManagement.EntityHandle"/> class.
        /// </summary>
        /// <param name="parent">Parent.</param>
        internal EntityHandle(HandleManager parent)
        {
            this.parent = parent;
            entity = null;
            phase = -1;
        }

        /// <summary>
        /// Appoints new entity to this instance.
        /// </summary>
        /// <param name="entity">Entity.</param>
        internal void AppointNewEntity(Entity entity){
            this.entity = entity;
            phase = entity.Phase;
        }

        /// <summary>
        /// Reset the entity and store it in the handle manager 
        /// </summary>
        public void Dispose(){
            entity = null;
            phase = -1;
            parent.StoreHandle(this);
        }
    }
}
