using System.Collections.Generic;
using UnityEngine;

namespace UnityExamples
{
    public abstract class Health : MonoBehaviour
    {
        [field: SerializeField] public int health { get; protected set; }
        [field: SerializeField] public int maxHealth { get; protected set; }
        [field: SerializeField] public bool dead { get; protected set; }
        [field: SerializeField] public bool invincible { get; protected set; }

        public Vector3 GetOffset() => transform.position + mOffset;
        [SerializeField] public Vector3 mOffset = new(0, 0.9f, 0);
        public abstract FactionGroup factionGroup { get; }
        public float ratio => health / (float)maxHealth;
        
        private void Awake() => health = maxHealth;
        
        public void Damage(int amount)
        {
            if (dead) return;

            if (invincible) return;
            
            health -= amount;
            health = Mathf.Clamp(health, 0, maxHealth);

            if (health == 0)
                Die();
            
            DamageEvent();
            HealthChangedEvent();
        }

        public bool Heal(int amount)
        {
            if (dead)
                return false;
            else if (health == maxHealth)
                return false;
            else
            {
                health += amount;
                health = Mathf.Clamp(health, 0, maxHealth);
                HealthChangedEvent();

                return true;
            }
        }

        public bool FullHeal()
        {
            if (dead)
                return false;
            else if (health == maxHealth)
                return false;
            else
            {
                health = maxHealth;
                HealthChangedEvent();
                
                return true;
            }
        }

        public void Kill(bool killInvincible = false)
        {
            if (invincible && !killInvincible) return;
            
            health = 0;
            
            DamageEvent();
            HealthChangedEvent();

            Die();
        }

        private void Die()
        {
            dead = true;
            DeathEvent();
        }

        protected abstract void DamageEvent();
        protected abstract void HealthChangedEvent();
        protected abstract void DeathEvent();
    }
}
