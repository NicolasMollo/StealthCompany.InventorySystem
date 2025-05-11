using NewLab.Unity.SDK.Core.Modules;
using UnityEngine;


namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_TakeHealth", menuName = "Scriptable Objects/CB_TakeHealth")]
    public class CB_TakeHealth : CommandBehaviour
    {

        [SerializeField]
        [Tooltip("Amount of hp to increase")]
        private float hp = 1.0f;

        public override void DoCommand(GameObject self = null)
        {

            BaseHealthModule healthModule = self.GetComponentInChildren<BaseHealthModule>();
            healthModule.TakeHealth(hp);

        }

    }

}