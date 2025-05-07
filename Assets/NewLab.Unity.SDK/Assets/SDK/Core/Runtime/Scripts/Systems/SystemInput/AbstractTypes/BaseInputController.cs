using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace NewLab.Unity.SDK.Core.Systems.Input
{

    public abstract class BaseInputController : BaseController
    {

        #region API

        /// <summary>
        /// Method that takes care of enabling input.
        /// </summary>
        public abstract void EnableInput();

        /// <summary>
        /// Method that takes care of disabling input.
        /// </summary>
        public abstract void DisableInput();

        #endregion

    }

}