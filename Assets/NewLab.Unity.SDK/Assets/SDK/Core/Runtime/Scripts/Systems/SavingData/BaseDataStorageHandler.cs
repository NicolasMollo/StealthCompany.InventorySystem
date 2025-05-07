using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.SavingData
{

    public abstract class BaseDataStorageHandler<T> : MonoBehaviour where T : BaseSaveData
    {

        /// <summary>
        /// Method that saves the data.
        /// </summary>
        public abstract void SaveData(T data);

        /// <summary>
        /// Method that loads data.
        /// </summary>
        public abstract T LoadData();

        /// <summary>
        /// Method that clear data.
        /// </summary>
        public abstract void ClearData(ref T data);

    }

}