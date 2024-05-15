using Unity.VisualScripting;

public interface IActor
{
    void Unpause();
    void Pause();
    void RegisterSelf();
    void NextActorTurn();
    float GetActorInititiative();
}