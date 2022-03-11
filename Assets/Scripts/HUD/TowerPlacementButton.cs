using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TowerPlacementButton : MonoBehaviour {
    [SerializeField] private Image image;
    [SerializeField]
    private Tower.Type towerType;
    private TowerPlacementManager manager;
    private Button m_button;

    void Awake() {
        manager = transform.parent.parent.GetComponent<TowerPlacementManager>();
        m_button = this.GetComponent<Button>();
    }

    public void SetTower(Tower.Type type) {
        TowerData data = GameDB.instance.GetTowerData(type);
        towerType = data.Type;
        image.sprite = data.Sprite;
    }

    public void SetPlacable() {
        manager.SetPlacable(towerType);
    }
}