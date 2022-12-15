namespace Arcanoid
{
    public class LifeModel : ILifeModel
    {
        public float MaxLife { get; }

        public float CurrentLife { get ; set ; }

        public LifeModel(float maxLife)
        {
            MaxLife = maxLife;
            CurrentLife = maxLife;
        }
    }
}