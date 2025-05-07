using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NewLab.Unity.SDK.Core.Modules;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.Player
{

    [DisallowMultipleComponent]
    public class BasePlayerController : BaseSceneController
    {

        [SerializeField]
        [Tooltip("List of modules that compose player")]
        protected List<BaseModule> playerModules = null;

        #region Internal methods

        /// <summary>
        /// Method that returns the "BaseModule" of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// The method accepts a parameter of type 'T'(generic) which must be a "BaseModule".
        /// <returns></returns>
        protected T GetModule<T>() where T : BaseModule
        {
            return playerModules.OfType<T>().FirstOrDefault();
        }

        #endregion

    }

}