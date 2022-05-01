namespace LearnProject.Scripts.Interfaces
{
    public interface IHealth
    {
        void Hurt(int damage);
        void Heal(int healAmount);
    }
}