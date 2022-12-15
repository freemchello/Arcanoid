using System;

namespace Arcanoid
{
    public class LifeViewModel : ILifeViewModel
    {
        private bool _isDead;
        public bool isDead => _isDead;
        
        public event Action<float> OnLifeChange;
        public ILifeModel LifeModel { get; }
        public LifeViewModel(ILifeModel lifeModel)
        {
            LifeModel = lifeModel;
        }
        public void ApplyDamage(float damage)
        {
            LifeModel.CurrentLife -= damage;
            if (LifeModel.CurrentLife <= 0) _isDead = true;
            OnLifeChange?.Invoke(LifeModel.CurrentLife);
        }
    }
}