using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text detailName;
    public Text detailDescription;

    public Button changeScaleButton;
    public GameObject panelDesc;
    public void ShowPanel()
    {
        panelDesc.SetActive(true);
    }
    public void HidePanel()
    {
        panelDesc.SetActive(false);
    }
}
