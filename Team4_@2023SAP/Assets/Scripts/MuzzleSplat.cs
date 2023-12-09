using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuzzleSplat : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();

    public float ShowTime = 0.2f;

    Image image;
    float ShowTimer = 0.0f;

    int Color;
    int Direction;

    Vector2 Pos;
    float xScale;

    void Start()
    {
        Pos = transform.localPosition;
        xScale = transform.localScale.x;

        image = GetComponent<Image>();

        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootPaint>(PaintSplat);
        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootProjectile>(ShootSplat);

        EvtSystem.EventDispatcher.AddListener<GameEvents.ColorWheelChange>(SetColor);
        EvtSystem.EventDispatcher.AddListener<GameEvents.GunDirectionChange>(SetDirection);
    }

    void Update()
    {
        if (image.enabled)
        {
            ShowTimer += Time.deltaTime;
            if (ShowTimer >= ShowTime)
            {
                ShowTimer = 0.0f;

                image.enabled = false;
            }
        }
    }

    private void OnDestroy()
    {
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ShootPaint>(PaintSplat);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ShootProjectile>(ShootSplat);

        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ColorWheelChange>(SetColor);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.GunDirectionChange>(SetDirection);
    }

    void PaintSplat(GameEvents.ShootPaint evt) 
    {
        ShowSplat();
    }

    void ShootSplat(GameEvents.ShootProjectile evt)
    {
        ShowSplat();
    }

    void ShowSplat()
    {
        if (Direction != 0)
        {
            if (Direction > 0)
            {
                transform.localPosition = new Vector2(-Pos.x, Pos.y);
                transform.localScale = new Vector2(-xScale, transform.localScale.y);
            }
            else
            {
                transform.localPosition = Pos;
                transform.localScale = new Vector2(xScale, transform.localScale.y);
            }

            image.enabled = true;
        }

        image.sprite = Sprites[Color];
    }

    void SetColor(GameEvents.ColorWheelChange evt)
    {
        Color = evt.ChangedColor;
    }

    void SetDirection(GameEvents.GunDirectionChange evt)
    {
        Direction = evt.direction;
    }
}