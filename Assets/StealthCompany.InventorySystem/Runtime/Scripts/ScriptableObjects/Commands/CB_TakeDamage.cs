using NewLab.Unity.SDK.Core.Modules;
using UnityEngine;

namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_TakeDamage", menuName = "Scriptable Objects/CB_TakeDamage")]
    public class CB_TakeDamage : CommandBehaviour
    {

        [SerializeField]
        [Tooltip("Amount of hp to decrease")]
        private float damage = 1.0f;

        public override void DoCommand(GameObject self = null)
        {

            BaseHealthModule healtModule = self.GetComponentInChildren<BaseHealthModule>();
            healtModule.TakeDamage(damage);

        }

    }

}