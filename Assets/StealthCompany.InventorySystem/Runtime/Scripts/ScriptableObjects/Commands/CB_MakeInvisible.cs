using System.Collections;
using UnityEngine;


namespace InventorySystem.ScriptableObjects.Commands
{

    [CreateAssetMenu(fileName = "CB_MakeInvisible", menuName = "Scriptable Objects/CB_MakeInvisible")]
    public class CB_MakeInvisible : CommandBehaviour, ITimedCommand
    {

        [SerializeField]
        [Range(0f, 1.0f)]
        [Tooltip("Value that will be assigned to the target's alpha channel to make it invisible")]
        private float alphaValue = 1.0f;

        [SerializeField]
        [Range(1.0f, 1000.0f)]
        [Tooltip("Time during which the target will remain invisible")]
        private float _duration = 1.0f;
        public float Duration
        { 
            get => _duration;
            set => _duration = value;
        }

        public override void DoCommand(GameObject self = null)
        {

            MonoBehaviour monoBehaviour = self.GetComponent<MonoBehaviour>();
            OnStartCommand?.Invoke();
            monoBehaviour.StartCoroutine(SetInvisibility(self, alphaValue, _duration));

        }

        #region Private methods

        private IEnumerator SetInvisibility(GameObject target, float alphaValue, float duration)
        {

            bool collisionsState = false;
            SetAlphaChannels(target, alphaValue);
            SetCollisions(target, collisionsState);
            yield return new WaitForSeconds(duration);
            SetAlphaChannels(target, 1);
            SetCollisions(target, !collisionsState);
            OnEndCommand?.Invoke();

        }

        private void SetAlphaChannels(GameObject target, float alphaValue)
        {

            if (target == null)
                return;

            Renderer[] renderers = target.GetComponentsInChildren<Renderer>(includeInactive: true);
            if (renderers == null)
            {
                Debug.LogError($"== CB_MakeInvisible.{this.name} == Your target object doesn't have a graphic component\n(Any type of Renderer)");
                return;
            }

            foreach (Renderer renderer in renderers)
            {
                foreach (Material material in renderer.materials)
                {
                    if (material.HasProperty("_Color"))
                    {
                        Color color = material.color;
                        color.a = alphaValue;
                        material.color = color;
                    }
                }
            }

        }

        private void SetCollisions(GameObject target, bool enablingValue)
        {

            Rigidbody rigidbody = target.GetComponentInChildren<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.detectCollisions = enablingValue;
                return;
            }

            CharacterController characterController = target.GetComponentInChildren<CharacterController>();
            if (characterController != null)
            {
                characterController.detectCollisions = enablingValue;
            }
            else
            {
                Debug.LogWarning($"== CB_MakeInvisible.{this.name} == Your target object doesn't have a physical component\n(Rigidbody or Collider)");
            }

        }

        #endregion

    }

}