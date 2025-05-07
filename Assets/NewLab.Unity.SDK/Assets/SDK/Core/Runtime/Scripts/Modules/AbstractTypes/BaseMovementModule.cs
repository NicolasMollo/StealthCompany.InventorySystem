using UnityEngine;

namespace NewLab.Unity.SDK.Core.Modules
{

    public abstract class BaseMovementModule : BaseModule
    {

        #region API

        /// <summary>
        /// Method that deals with the movement of a target.
        /// </summary>
        public abstract void Movement(Vector3 direction = default);

        #endregion


    }

}