using System;
using UnityEngine;

namespace InventorySystem.ScriptableObjects.Commands
{

    public interface ITimedCommand
    {

        public float Duration
        {
            get;
            set;
        }

    }

    public abstract class CommandBehaviour : ScriptableObject
    {

        public Action OnStartCommand = null;
        public Action OnEndCommand = null;

        public abstract void DoCommand(GameObject self = null);


    }

}