namespace NewLab.Unity.SDK.Core.Systems.SavingData
{

    public abstract class BaseSystemSavingData : BaseSystem
    {

        /// <summary>
        /// Method that saves the data.
        /// </summary>
        public abstract void SaveData();

        /// <summary>
        /// Method that loads data.
        /// </summary>
        public abstract void LoadData();

        /// <summary>
        /// Method that clear data.
        /// </summary>
        public virtual void ClearData() { }

    }

}