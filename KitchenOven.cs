// Decompiled with JetBrains decompiler
// Type: KitchenOven
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class KitchenOven : ObjectActionController
{
  public Sprite dark;
  public Sprite light1;
  public SpriteRenderer ovenLight;
  public float lightAlfa;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "kneel_n";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_oven";
    this.range = 1f;
    this.updateState();
  }

  private void Update()
  {
    if (GameDataController.gd.getObjective("kitchen_oven_open") && (double) this.lightAlfa < 1.0 && GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      this.lightAlfa += Time.deltaTime * 2f;
    if ((double) this.lightAlfa > 0.0 && (!GameDataController.gd.getObjective("barn_pump_started") || GameDataController.gd.getObjectiveDetail("barn_pump_started") != 1) || !GameDataController.gd.getObjective("kitchen_oven_open"))
      this.lightAlfa -= Time.deltaTime * 2f;
    if ((double) this.lightAlfa < 0.0)
      this.lightAlfa = 0.0f;
    if ((double) this.lightAlfa > 1.0)
      this.lightAlfa = 1f;
    this.ovenLight.color = new Color(1f, 1f, 1f, this.lightAlfa);
  }

  public override void clickAction()
  {
    GameDataController.gd.setObjective("kitchen_oven_open", !GameDataController.gd.getObjective("kitchen_oven_open"));
    this.updateAll();
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.trunk_open);
    if (GameDataController.gd.getObjective("kitchen_oven_open"))
    {
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "kitchen_oven_open")
      });
      if (!GameDataController.gd.getObjective("barn_pump_started") || GameDataController.gd.getObjectiveDetail("barn_pump_started") != 1)
      {
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "kitchen_oven_off")
        });
      }
      else
      {
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "kitchen_oven_on")
        });
        if (GameDataController.gd.getCurrentDay() != 1)
          return;
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "kitchen_oven_nogood")
        });
      }
    }
    else
      Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
      {
        text = GameStrings.getString(GameStrings.actions, "kitchen_oven_close")
      });
  }

  public override void updateState()
  {
    this.colliderManager.setCollider(0);
    if (GameDataController.gd.getObjective("kitchen_oven_open"))
    {
      this.GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getObjective("barn_pump_started") && GameDataController.gd.getObjectiveDetail("barn_pump_started") == 1)
      {
        this.GetComponent<SpriteRenderer>().sprite = this.dark;
        this.ovenLight.enabled = true;
        this.objectName = "kitchen_oven_hot";
      }
      else
      {
        this.GetComponent<SpriteRenderer>().sprite = this.dark;
        this.ovenLight.enabled = false;
        this.objectName = "kitchen_oven";
      }
    }
    else
    {
      this.GetComponent<SpriteRenderer>().enabled = false;
      this.ovenLight.enabled = false;
      this.objectName = "kitchen_oven";
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
