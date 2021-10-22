// Decompiled with JetBrains decompiler
// Type: TentDistanceThings
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class TentDistanceThings : ObjectActionController
{
  private Vector3 pozycja;
  private GameObject thingToShow;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_ne";
    this.animationFlip = false;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.range = 30f;
    this.gameObject.transform.Find("thing_gas").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("thing").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("thing_webs").GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      this.thingToShow = this.gameObject.transform.Find("thing").gameObject;
      this.objectName = "tent_distance_swarm";
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      this.thingToShow = this.gameObject.transform.Find("thing_gas").gameObject;
      this.objectName = "tent_distance_gas";
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      this.thingToShow = this.gameObject.transform.Find("thing_webs").gameObject;
      this.objectName = "tent_distance_webs";
    }
    this.thingToShow.GetComponent<SpriteRenderer>().enabled = true;
    this.pozycja = new Vector3(this.thingToShow.transform.position.x, this.thingToShow.transform.position.y, this.thingToShow.transform.position.z);
    if (GameDataController.gd.getObjective("tent_distance_checked"))
      this.pozycja.y = -0.68f;
    this.updateState();
  }

  private void Update()
  {
    if ((double) PlayerController.wc.currentXY.x > 60.0 && !GameDataController.gd.getObjective("tent_distance_triggered"))
    {
      GameDataController.gd.setObjective("tent_distance_triggered", true);
      this.updateState();
    }
    if (GameDataController.gd.getObjective("tent_distance_triggered") && (double) this.pozycja.y < -0.66)
    {
      if ((double) this.pozycja.y < -0.76)
        this.pozycja.y += 0.012f * Time.deltaTime;
      if ((double) this.pozycja.y < -0.74)
        this.pozycja.y += 0.01f * Time.deltaTime;
      if ((double) this.pozycja.y < -0.72)
        this.pozycja.y += 0.007f * Time.deltaTime;
      if ((double) this.pozycja.y < -0.7)
        this.pozycja.y += 0.005f * Time.deltaTime;
      if ((double) this.pozycja.y < -0.68)
        this.pozycja.y += 1f / 500f * Time.deltaTime;
      this.pozycja.y += 1f / 1000f * Time.deltaTime;
      this.thingToShow.transform.position = ScreenControler.roundToNearestFullPixel2(this.pozycja);
    }
    PlayerController.wc.shadowOffsetY = -5;
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    PlayerController.wc.fullStop(true);
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, this.objectName)
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "tent_distance_2")
    });
    Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
    {
      text = GameStrings.getString(GameStrings.actions, "tent_distance_3")
    });
    if (!GameDataController.gd.getObjective("tent_distance_checked"))
      Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
      {
        textWidth = BottomTextController.bottomTextWidth,
        text = "[" + GameStrings.getString(GameStrings.gui, "gui_hint") + "]",
        actionWithText = true,
        function = new TimelineFunction(GameObject.Find("journal").GetComponent<JournalButtonController>().showJournal)
      });
    GameDataController.gd.setObjective("tent_distance_checked", true);
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tent_distance_triggered"))
      this.colliderManager.setCollider(-1);
    else
      this.colliderManager.setCollider(0);
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
