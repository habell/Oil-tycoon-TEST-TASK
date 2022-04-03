namespace Learning.Scripts.DamageSystem
{
    public class Mine : AbstractAmmo
    {
        protected override void CollisionAmmo(Health objHealth)
        {
            // TODO: need to make explosive effects for homework
            objHealth.Hurt(_damage);
            Destroy(gameObject);
        }
    }
}
