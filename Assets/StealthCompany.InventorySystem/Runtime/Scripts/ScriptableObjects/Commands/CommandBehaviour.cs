using System;
using UnityEngine;

namespace InventorySystem.ScriptableObjects.Commands
{

    /// <summary>
    /// Abstract class that will serve as the base for all concrete classes that want to be Commands.
    /// </summary>
    public abstract class CommandBehaviour : ScriptableObject
    {

        public Action OnStartCommand = null;
        public Action OnEndCommand = null;

        public abstract void DoCommand(GameObject self = null);

    }

}