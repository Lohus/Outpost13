// Interface for applying effects to the player
public interface IPlayerEffect
{
    public void Apply(PlayerController player);
    public void Remove(PlayerController player);
}