// Decompiled with JetBrains decompiler
// Type: OutpostBarsButtonReset
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class OutpostBarsButtonReset : ObjectActionController
{
  public OutpostBarsButtonAdd button_a;
  public OutpostBarsButtonAdd button_b;
  public OutpostBarsButtonAdd button_c;
  public OutpostBarsButtonAdd button_d;
  public OutpostBarsButtonAdd button_e;
  public Sprite sprite_on;
  public Sprite sprite_off;
  public Sprite sprite_disabled;
  public SpriteRenderer sr;
  public TextFieldController label;
  public AudioSource aS;
  public bool allowed;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = string.Empty;
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "outpost_bars_reset";
    this.teleport = true;
    this.range = 1000f;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    this.sr.sprite = this.sprite_on;
    PlayerController.pc.setBusy(true);
    this.Invoke("unlock", 0.5f);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.mouse_click, 0.5f);
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.denied);
    this.button_a.targetValue = 50;
    this.button_b.targetValue = 50;
    this.button_c.targetValue = 50;
    this.button_d.targetValue = 50;
    this.button_e.targetValue = 50;
    GameDataController.gd.setObjectiveDetail("outpost_bars_a", this.button_a.targetValue);
    GameDataController.gd.setObjectiveDetail("outpost_bars_b", this.button_b.targetValue);
    GameDataController.gd.setObjectiveDetail("outpost_bars_c", this.button_c.targetValue);
    GameDataController.gd.setObjectiveDetail("outpost_bars_d", this.button_d.targetValue);
    GameDataController.gd.setObjectiveDetail("outpost_bars_e", this.button_e.targetValue);
    this.aS.PlayOneShot(SoundsManagerController.sm.power_down_small, 0.5f);
    this.aS.pitch = 0.8f;
  }

  public void zrobCos(OutpostBarsButtonAdd obiekt, string nazwa, int minus)
  {
  }

  public void unlock()
  {
    PlayerController.pc.setBusy(false);
    this.updateState();
  }

  public override void updateState()
  {
    this.allowed = this.button_a.targetValue != 50 || this.button_b.targetValue != 50 || this.button_c.targetValue != 50 || this.button_d.targetValue != 50 || this.button_e.targetValue != 50;
    if (!this.allowed)
    {
      this.sr.sprite = this.sprite_disabled;
      this.setCollider(-1);
      this.label.viewText(GameStrings.getString(GameStrings.world_labels, "generic_reset_small"), quick: true, instant: true, mwidth: 50, r: 0.5019608f, g: 0.5019608f, b: 0.5019608f, ba: 0.0f);
      this.label.keepAlive = true;
    }
    else
    {
      this.setCollider(0);
      this.sr.sprite = this.sprite_off;
      this.label.viewText(GameStrings.getString(GameStrings.world_labels, "generic_reset_small"), quick: true, instant: true, mwidth: 50, r: 0.1372549f, g: 0.3333333f, b: 0.4509804f, ba: 0.0f);
      this.label.keepAlive = true;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
