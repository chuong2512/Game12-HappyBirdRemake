using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{
    public Button continueBtn, retryButton;

    public GameObject optionObj;
    public Button add0Btn, add50Btn, add100Btn, add500Btn;

    // Start is called before the first frame update
    void Start()
    {
        continueBtn.onClick.AddListener(ShowUI);
        retryButton.onClick.AddListener(Retry);
        add0Btn.onClick.AddListener(() => ReviveWithPoint(0));
        add50Btn.onClick.AddListener(() => ReviveWithPoint(50));
        add100Btn.onClick.AddListener(() => ReviveWithPoint(100));
        add500Btn.onClick.AddListener(() => ReviveWithPoint(500));
    }
    
    private void ReviveWithPoint(int point)
    {
        GameManager.addPoint = point;

        switch (point)
        {
            case 0:
                IAPManager.Instance.BuyProductID(IAPKey.PACK);
                break;
            case 50:
                IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                break;
            case 100:
                IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                break;
            case 500:
                IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                break;
        }
    }

    private void Retry()
    {
        GameManager.Instance.Retry();
    }

    private void ShowUI()
    {
        optionObj.SetActive(true);
    }
}