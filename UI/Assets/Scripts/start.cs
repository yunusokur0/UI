using UnityEngine;
using UnityEngine.EventSystems;

public class start : MonoBehaviour
{
    public bool isGameStart;
    public GameObject startPanel;
    public static start Start;
    public GameObject settingsOpen, settingsClose, LayoutanGroup, reset;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        Start = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                isGameStart = true;
                startPanel.gameObject.SetActive(false);
                anim.SetBool("run", true);
                settingsOpen.SetActive(false);
                settingsClose.SetActive(false);
                LayoutanGroup.SetActive(false);
                reset.SetActive(true);
            }
        }
    }
}
