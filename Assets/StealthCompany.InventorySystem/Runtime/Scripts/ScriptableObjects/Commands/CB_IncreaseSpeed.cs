using System.Collections;
using UnityEngine;
using InventorySystem.Systems.Controllers.Player;


namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_ModifySpeed", menuName = "Scriptable Objects/CB_ModifySpeed")]
    public class CB_IncreaseSpeed : CommandBehaviour, ITimedCommand
    {

        [SerializeField]
        [Tooltip("Value that will be added to a target's speed")]
        private float additionalSpeed = 1.0f;

        [SerializeField]
        [Tooltip("Effect duration")]
        private float _duration = 1.0f;
        public float Duration
        {
            get => _duration;
            set => _duration = value;
        }


        public override void DoCommand(GameObject self = null)
        {

            InventorySystem_MovementModule movementModule = self.GetComponentInChildren<InventorySystem_MovementModule>();
            if (movementModule == null)
            {
                Debug.LogError($"== CB_IncreaseSpeed.{this.name} == Your target object doesn't have a \"InventorySystem_MovementModule\" component attached");
                return;
            }
            OnStartCommand?.Invoke();

            //startSpeed = movementModule.MovementSpeed;
            movementModule.StartCoroutine(SetSpeed(movementModule, additionalSpeed, _duration));

        }

        private IEnumerator SetSpeed(InventorySystem_MovementModule movementModule, float speed, float duration)
        {

            IncreaseSpeed(movementModule, speed);
            yield return new WaitForSeconds(duration);
            ResetSpeed(movementModule, speed);
            OnEndCommand?.Invoke();

        }

        private void IncreaseSpeed(InventorySystem_MovementModule movementModule, float speed)
        {

            movementModule.MovementSpeed += speed;

        }

        private void ResetSpeed(InventorySystem_MovementModule movementModule, float speed)
        {

            movementModule.MovementSpeed -= speed;

        }

    }

}