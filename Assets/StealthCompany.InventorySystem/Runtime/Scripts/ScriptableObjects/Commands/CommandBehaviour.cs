using Sirenix.OdinInspector;
using UnityEngine;

namespace InventorySystem.ScriptableObjects.Commands
{

    public abstract class CommandBehaviour : ScriptableObject
    {

        public abstract void DoCommand(GameObject self = null);

        [ShowInInspector]
        [ReadOnly]
        public bool IsCurrentlyCast
        {
            get;
            protected set;
        } = false;

        public virtual void CleanUp()
        {
            IsCurrentlyCast = false;
        }

    }

}