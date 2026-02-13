using UnityEngine;

public class CookingView : MonoBehaviour, ICookingView
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}