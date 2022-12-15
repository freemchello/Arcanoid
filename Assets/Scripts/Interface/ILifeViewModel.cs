using System;
namespace Arcanoid
{
    public interface ILifeViewModel
    {
        ILifeModel LifeModel { get; }
        bool isDead { get; }
        void ApplyDamage(float damage);
        event Action<float> OnLifeChange;
    }
}