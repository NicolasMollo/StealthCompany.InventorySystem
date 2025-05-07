namespace NewLab.Unity.SDK.Core.Modules
{

    public abstract class BaseHealthModule : BaseModule
    {

        #region API

        /// <summary>
        /// Method that deals with adding health.
        /// This method takes as an argument a 'float' parameter representing the amount of health that will be added.
        /// </summary>
        /// <param name="health"></param>
        public abstract void TakeHealth(float health);

        /// <summary>
        /// Method that deals with subtracting damage.
        /// This method takes as an argument a 'float' parameter representing the amount of damage that will be substracted.
        /// </summary>
        /// <param name="damage"></param>
        public abstract void TakeDamage(float damage);

        #endregion

    }

}