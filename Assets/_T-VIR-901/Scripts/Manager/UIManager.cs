using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public PanelPlanetInfo PanelInfo;
    private bool tutorialMode = true;

    [SerializeField] private InGameUi playerUi;

    private UIManager() { }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        playerUi = GameObject.Find("PlayerUI").GetComponent<InGameUi>();
    }

    /// <summary>
    /// Donne les informations a l'UI et change le game state. Si info est null : l'UI disparait et on reviens au jeu.
    /// </summary>
    /// <param name="info">Info d'un element pour afficher ses infos dans l'UI ou mettre null pour cacher l'UI</param>
    public void ShowInfo(Info info, Vector3 pos)
    {
        PanelInfo.SetInfo(info);

        //On set la position de l'interface a côté de la planète sélectionnée
        PanelInfo.transform.parent.transform.position = new Vector3(pos.x + 5, pos.y + 2, pos.z);

        if (info != null) {
            GameManager.Instance.ChangeState(GameState.PlanetMenu);
        }
        else {
            GameManager.Instance.ChangeState(GameState.Game);
        }
    }

    //Activate a specific UI by name
    public void SwitchMenuUI(string name) {
        playerUi.setActualMenu(name);
    }
    public void EnableUI() {
        playerUi.EnableUI();
    }
    public void DisableUI() {
        playerUi.DisableUI();
    }
    
    //Change tuto slide
    public void SwitchTutorialMode(int? tutoStep)
    {
        if(tutorialMode == true) {
            TutorialManager.Instance.SwitchTutoMode(tutoStep);
        }
    }
}
