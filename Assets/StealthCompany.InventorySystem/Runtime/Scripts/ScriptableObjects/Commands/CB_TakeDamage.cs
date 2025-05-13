using NewLab.Unity.SDK.Core.Modules;
using UnityEngine;

namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_TakeDamage", menuName = "ScriptableObjects/CB_TakeDamage")]
    public class CB_TakeDamage : CommandBehaviour
    {

        [SerializeField]
        [Tooltip("Amount of hp to decrease")]
        private float damage = 1.0f;

        public override void DoCommand(GameObject self = null)
        {

            BaseHealthModule healthModule = self.GetComponentInChildren<BaseHealthModule>();
            if (healthModule == null)
            {
                Debug.LogError($"== CB_TakeDamage.{this.name} == Your object doesn't have a healtModule attached!");
                return;
            }
            healthModule.TakeDamage(damage);

        }

    }

}