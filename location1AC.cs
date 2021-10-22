// Decompiled with JetBrains decompiler
// Type: location1AC
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class location1AC : ObjectActionController
{
  public AudioClip acSound;
  public Sprite powered_ac;
  public Sprite unpowered_ac;
  private CursorController cursorController;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.range = 1f;
    this.characterAnimationName = "kneel_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "ac_window";
    this.range = 1f;
    this.updateState();
    this.cursorController = GameObject.Find("cursor").GetComponent<CursorController>();
  }

  private void Update()
  {
  }

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("base_ac_cord_plugged"))
    {
      PlayerController.pc.say(GameStrings.getString(GameStrings.actions, "unplug_first"));
    }
    else
    {
      if (!InventoryController.ic.pickUpItem(ItemsManager.im.getItem("ac")))
        return;
      GameDataController.gd.setObjective("window1_ac_placed", false);
      this.updateAll();
    }
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjective("window1_ac_placed"))
    {
      this.colliderManager.setCollider(0);
      this.GetComponent<SpriteRenderer>().enabled = true;
    }
    else
    {
      this.colliderManager.setCollider(-1);
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.GetComponent<AudioSource>().Stop();
    }
    if (GameDataController.gd.getObjective("base_ac_cord_plugged"))
    {
      this.range = 100f;
      this.characterAnimationName = "action_stnd_";
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.GetComponent<SpriteRenderer>().sprite = this.powered_ac;
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().volume = 0.3f;
        this.GetComponent<AudioSource>().Play();
      }
      else
      {
        this.GetComponent<SpriteRenderer>().sprite = this.unpowered_ac;
        this.GetComponent<AudioSource>().Stop();
      }
    }
    else
    {
      this.GetComponent<SpriteRenderer>().sprite = this.unpowered_ac;
      this.range = 1f;
      this.characterAnimationName = "kneel_";
      this.GetComponent<AudioSource>().Stop();
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
