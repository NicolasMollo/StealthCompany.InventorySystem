using UnityEngine;

namespace NewLab.Unity.SDK.Core.Modules
{

    public abstract class BaseMovementModule : BaseModule
    {

        #region API

        /// <summary>
        /// Method that deals with the movement of a target.
        /// </summary>
        public virtual void Movement(Vector3 direction = default) { }

        #endregion


    }

}