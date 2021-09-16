// Decompiled with JetBrains decompiler
// Type: LocationAirplane3Transponder
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationAirplane3Transponder : ObjectActionController
{
  public float alpha;
  public float dir;
  public bool stopped;
  public SpriteRenderer sr;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action1_e";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airplane_transponder";
    this.range = 2f;
    this.dir = 1f;
    this.alpha = 0.0f;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.updateAll();
  }

  private void Update()
  {
    if (this.stopped)
      this.alpha = 0.0f;
    this.sr.color = new Color(1f, 1f, 1f, this.alpha);
    this.alpha += (float) ((double) Time.deltaTime * (double) this.dir * 1.0);
    if ((double) this.alpha >= 1.0)
    {
      this.dir = -1f;
    }
    else
    {
      if ((double) this.alpha > 0.0)
        return;
      this.dir = 1f;
    }
  }

  public override void clickAction()
  {
    if (!GameDataController.gd.getObjective("plane_transponder_disabled"))
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click2);
      GameDataController.gd.setObjective("plane_transponder_disabled", true);
      this.updateState();
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "transponder_disabled1"));
    }
    else
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "transponder_disabled2"));
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("plane_transponder_disabled"))
    {
      this.characterAnimationName = "action_stnd_";
      this.animationFlip = false;
      this.useCurrentDirection = true;
      this.stopped = true;
      this.range = 100f;
    }
    else
    {
      this.characterAnimationName = "action1_e";
      this.animationFlip = false;
      this.useCurrentDirection = false;
      this.range = 2f;
      this.stopped = false;
    }
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
