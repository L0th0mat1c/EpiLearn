/// <summary>
/// Interface des managers pour les diff�rents projets.
/// </summary>
public interface IManager
{
    // Ces fonctions sont � appliquer au composant "Default Observer Event Handler" du gameobject.

    /// <summary>
    /// Se lance quand la target a �t� trouv�.
    /// </summary>
    public void Init();
    /// <summary>
    /// Se lance quand la target a �t� perdu.
    /// </summary>
    public void Exit();
}
