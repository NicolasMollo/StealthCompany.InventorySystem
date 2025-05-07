namespace NewLab.Unity.SDK.Core.Systems.Input
{

    public abstract class BaseSystemInput : BaseSystem
    {

        #region API

        /// <summary>
        /// Method that takes care of enabling all inputs.
        /// </summary>
        public abstract void EnableAllInput();

        /// <summary>
        /// Method that takes care of disabling all inputs.
        /// </summary>
        public abstract void DisableAllInput();

        #endregion

    }

}