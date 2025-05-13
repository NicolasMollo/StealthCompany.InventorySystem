using System;
using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Modules
{

    public class Std_HealthModule : BaseHealthModule
    {

        [TitleGroup("STD_HEALTHMODULE", null, TitleAlignments.Centered)]

        [SerializeField]
        [Tooltip("Maximum health")]
        [Range(1.0f, 1000.0f)]
        protected float _maxHealth = 1.0f;
        public float MaxHealth
        {
            get => _maxHealth;
        }

        private float _currentHealth = 0.0f;
        public float CurrentHealth
        {
            get
            {
                _currentHealth = _currentHealth < 0.0f ? 0.0f : _currentHealth > _maxHealth ? _maxHealth : _currentHealth;
                return _currentHealth;
            }
            protected set => _currentHealth = value;
        }

        public bool IsDead
        {
            get => CurrentHealth == 0.0f;
        }

        public Action<Std_HealthModule> OnTakeHealth = null;
        public Action<Std_HealthModule> OnTakeDamage = null;
        public Action<Std_HealthModule> OnDeath = null;


        #region API

        public override void SetUp()
        {

            CurrentHealth = _maxHealth;

        }

        public override void TakeHealth(float health)
        {

            CurrentHealth += health;
            OnTakeHealth?.Invoke(this);

        }

        public override void TakeDamage(float damage)
        {

            CurrentHealth -= damage;
            OnTakeDamage?.Invoke(this);
            if (IsDead)
            {
                OnDeath?.Invoke(this);
            }

        }

        #endregion

    }

}