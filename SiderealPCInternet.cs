// Decompiled with JetBrains decompiler
// Type: SiderealPCInternet
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SiderealPCInternet : ObjectActionController
{
  public SpriteRenderer spriter;
  public SiderealComputerSound beeper;
  public Sprite icon;
  public Sprite window;
  public WorldCaption caption;
  public WorldCaption txt;
  public WorldCaption iconCaption;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_internet_app";
    this.range = 8000f;
    this.teleport = true;
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    this.beeper.beep();
    if (!GameDataController.gd.getObjective("sidereal_internet_displayed"))
    {
      PlayerController.pc.setBusy(true);
      this.Invoke("makeItSo", Random.Range(0.25f, 1f));
    }
    else
      this.Invoke("makeItSo2", Random.Range(0.15f, 0.25f));
  }

  private void makeItSo2()
  {
    GameDataController.gd.setObjective("sidereal_internet_displayed", false);
    PlayerController.pc.setBusy(false);
    this.updateAll();
  }

  private void makeItSo()
  {
    PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjective("sidereal_internet_displayed", true);
    this.updateAll();
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("sidereal_email_displayed"))
    {
      this.caption.hide();
      this.spriter.sprite = this.icon;
      this.setCollider(-1);
      this.txt.hide();
      this.iconCaption.manualUpdate();
    }
    else if (!GameDataController.gd.getObjective("sidereal_internet_displayed"))
    {
      this.caption.hide();
      this.spriter.sprite = this.icon;
      this.setCollider(1);
      this.txt.hide();
      this.iconCaption.manualUpdate();
      this.objectName = "sidereal_internet_app";
    }
    else
    {
      this.caption.manualUpdate();
      this.spriter.sprite = this.window;
      this.setCollider(0);
      this.txt.manualUpdate();
      this.objectName = "sidereal_x_app";
      this.iconCaption.manualUpdate();
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
