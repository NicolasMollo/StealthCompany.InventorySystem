using UnityEngine;
using UnityEngine.Events;


namespace NewLab.Unity.SDK.Core.Events
{

    [DisallowMultipleComponent]
    public class Event_PrintString : BaseEvent
    {

        public UnityEvent<string> OnPrintString = null;

        #region API

        /// <summary>
        /// Method that deals with launching the event.
        /// The method accepts as a parameter the parameter defined by the event itself.
        /// </summary>
        /// <param name="stringToPrint"></param>
        public void CallOnPrintString(string stringToPrint)
        {

            OnPrintString?.Invoke(stringToPrint);

        }

        public override void RemoveAllListeners()
        {

            OnPrintString.RemoveAllListeners();

        }

        #endregion

    }

}