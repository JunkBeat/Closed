// Decompiled with JetBrains decompiler
// Type: SiderealPCMailSelector
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class SiderealPCMailSelector : ObjectActionController
{
  public int mailNumber;
  public Sprite mailHighlight;
  public SpriteRenderer MHR;
  public List<WorldCaption> wcs;
  public WorldCaption caption;
  public WorldCaption email;
  public SiderealComputerSound beeper;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "sidereal_mail";
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
    PlayerController.pc.setBusy(true);
    this.beeper.beep();
    this.Invoke("makeItSo", Random.Range(0.25f, 1f));
  }

  private void makeItSo()
  {
    PlayerController.pc.setBusy(false);
    GameDataController.gd.setObjectiveDetail("sidereal_email_displayed", this.mailNumber);
    GameDataController.gd.setObjectiveDetail("sidereal_email_page", 1);
    if (this.mailNumber == 10)
    {
      this.caption.b = 111f;
      this.caption.r = 111f;
      this.caption.g = 111f;
      GameDataController.gd.setObjective("sidereal_read_last_mail", true);
    }
    this.updateAll();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("sidereal_email_displayed"))
    {
      MonoBehaviour.print((object) ("IM HIDING MAIL: " + (object) this.mailNumber));
      this.setCollider(-1);
      this.email.enabled = false;
      this.MHR.enabled = false;
      this.caption.hide();
    }
    else
    {
      MonoBehaviour.print((object) ("IM SHOWING MAIL: " + (object) this.mailNumber));
      this.email.enabled = true;
      this.MHR.enabled = true;
      if (this.mailNumber == GameDataController.gd.getObjectiveDetail("sidereal_email_displayed"))
      {
        this.setCollider(-1);
        this.caption.r = (float) byte.MaxValue;
        this.caption.g = (float) byte.MaxValue;
        this.caption.b = (float) byte.MaxValue;
        this.MHR.sprite = this.mailHighlight;
      }
      else
      {
        this.setCollider(0);
        if (this.mailNumber == 10 && !GameDataController.gd.getObjective("sidereal_read_last_mail"))
        {
          this.caption.b = 0.0f;
          this.caption.r = 0.0f;
          this.caption.g = 0.0f;
        }
        else
        {
          this.caption.r = 111f;
          this.caption.g = 111f;
          this.caption.b = 111f;
        }
      }
      this.caption.manualUpdate();
      this.email.nameToDisplay = "sidereal_pc_email_" + (object) GameDataController.gd.getObjectiveDetail("sidereal_email_displayed") + "_b_" + (object) GameDataController.gd.getObjectiveDetail("sidereal_email_page");
      this.email.manualUpdate();
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
