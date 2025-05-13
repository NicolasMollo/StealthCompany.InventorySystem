using UnityEngine;
using System.Collections;
using InventorySystem.Systems.Controllers.Player;


namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_DecreaseSpeed", menuName = "ScriptableObjects/CB_DecreaseSpeed")]
    public class CB_DecreaseSpeed : CommandBehaviour, ITimedCommand
    {

        [SerializeField]
        [Tooltip("Value that will be added to a target's speed")]
        private float subtractiveSpeed = 1.0f;

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
                Debug.LogError($"== CB_DecreaseSpeed.{this.name} == Your target object doesn't have a \"InventorySystem_MovementModule\" component attached");
                return;
            }

            OnStartCommand?.Invoke();
            movementModule.StartCoroutine(SetSpeed(movementModule, subtractiveSpeed, _duration));

        }

        #region Private methods

        private IEnumerator SetSpeed(InventorySystem_MovementModule movementModule, float speed, float duration)
        {

            DecreaseSpeed(movementModule, speed);
            yield return new WaitForSeconds(duration);
            ResetSpeed(movementModule, speed);
            OnEndCommand?.Invoke();

        }

        private void DecreaseSpeed(InventorySystem_MovementModule movementModule, float speed)
        {

            movementModule.MovementSpeed -= speed;

        }

        private void ResetSpeed(InventorySystem_MovementModule movementModule, float speed)
        {

            movementModule.MovementSpeed += speed;

        }

        #endregion

    }

}