namespace Arcanoid
{
    public interface ILifeModel
    {
        public float MaxLife { get; }
        public float CurrentLife { get; set; }
    }
}