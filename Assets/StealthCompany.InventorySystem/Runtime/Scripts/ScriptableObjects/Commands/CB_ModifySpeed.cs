using InventorySystem.Systems.Controllers.Player;
using NewLab.Unity.SDK.Core.Modules;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Data;
using UnityEngine;


namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_ModifySpeed", menuName = "Scriptable Objects/CB_ModifySpeed")]
    public class CB_ModifySpeed : CommandBehaviour
    {

        [SerializeField]
        [Tooltip("Value that will be assigned to a target's speed")]
        private float speed = 1.0f;

        [SerializeField]
        [Tooltip("Effect duration")]
        private float duration = 1.0f;

        private float startSpeed = 1.0f;



        public override void DoCommand(GameObject self = null)
        {

            InventorySystem_MovementModule movementModule = self.GetComponentInChildren<InventorySystem_MovementModule>();
            if (movementModule == null)
            {
                Debug.Log($"== CB_ModifySpeed.{this.name} == Your target object doesn't have a \"InventorySystem_MovementModule\" component attached");
                return;
            }

            startSpeed = movementModule.MovementSpeed;
            movementModule.StartCoroutine(ModifySpeed(movementModule, speed, duration));

        }


        private IEnumerator ModifySpeed(InventorySystem_MovementModule movementModule, float speed, float duration)
        {

            bool commandState = true;
            IsCurrentlyCast = commandState;
            SetSpeed(movementModule, speed);
            yield return new WaitForSeconds(duration);
            SetSpeed(movementModule, startSpeed);
            IsCurrentlyCast = !commandState;

        }

        private void SetSpeed(InventorySystem_MovementModule movementModule, float speed)
        {

            movementModule.MovementSpeed = speed;

        }

    }

}