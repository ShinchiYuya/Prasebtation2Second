using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounterScript : MonoBehaviour
{
    [SerializeField] Sprite _playerUiSpr = null;
    [SerializeField] Vector2 _spriteSize = new Vector2(50f, 50f);
    [SerializeField] RectTransform _playerCounterPanel = null;

    void Refresh(int playerCount)
    {
        if (_playerUiSpr &&  _playerCounterPanel)
        {
            foreach(Transform t  in _playerCounterPanel.transform)
            {
                Destroy(t.gameObject);
            }
        }

        for (int i = 0; i < playerCount - 1; i++)
        {
            GameObject go = new GameObject();
            Image image = go.AddComponent<Image>();
            image.sprite = _playerUiSpr;
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.sizeDelta = _spriteSize;
            go.transform.SetParent(_playerCounterPanel.transform);
        }
    }
}
