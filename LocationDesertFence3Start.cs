// Decompiled with JetBrains decompiler
// Type: LocationDesertFence3Start
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class LocationDesertFence3Start : MonoBehaviour
{
  public SpriteRenderer thePiasek;
  public SpriteRenderer thePiasekB;
  public Sprite sand1;
  public Sprite sand2;
  public Sprite sand3;
  public Sprite sand4;
  public Sprite sand1B;
  public Sprite sand2B;
  public Sprite sand3B;
  public Sprite sand4B;
  private float alpha;
  private float playerMove;
  private float previous;
  public Sprite dropHint;
  private float proc;
  public Sprite hammerDown;
  public Sprite hammerDown2;
  private Item hammer;

  private void Start()
  {
    this.alpha = 1f;
    PlayerController.wc.shadow.fadeRateV = 0.01f;
    PlayerController.wc.shadow.fadeRateH = 0.0f;
    PlayerController.wc.shadowOffsetY = 2;
    PlayerController.wc.shadow.skewFactor = 0.0f;
    PlayerController.wc.shadow.skewFactor2 = 4f;
    PlayerController.wc.shadow.startAlpha = 0.5f;
    PlayerController.wc.shadow.scaleFactor = 0.75f;
    PlayerController.wc.shadow.downwards = false;
    PlayerController.wc.speed = PlayerController.wc.MAX_SPEED;
    PlayerController.wc.GetComponent<Animator>().speed = 1f;
    PlayerController.wc.shadow.source = 0.0f;
    PlayerController.ssg.setStepType2(StepSoundGenerator.DIRT, AudioReverbPreset.Off);
    PlayerController.pc.copySettingsToNPCs();
    JukeboxMusic.jb.changeMusic((AudioClip) null);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_3, 1f);
    this.hammer = ItemsManager.im.getItem("sledgehammer");
  }

  private void showDropHint(string param)
  {
    ExamineSprite.es.textField.shift.x = 10f;
    ExamineSprite.es.textField.shift.y = -30f;
    ExamineSprite.es.readyText(new List<string>()
    {
      GameStrings.getString(GameStrings.gui, "tutorial_drop_item")
    }, 100, 1f, 1f, 1f, 0.0f, 0.0f, 0.0f, 0.75f);
    ExamineSprite.es.show(this.dropHint);
  }

  private void Update()
  {
    Vector3 vector3 = new Vector3(PlayerController.wc.currentXY.x, 0.0f, PlayerController.pc.transform.position.z);
    this.hammer.groundSprite = this.hammer.dataRef.droppedLocation == "inventory" && (double) PlayerController.wc.currentXY.x >= 135.0 || this.hammer.dataRef.droppedLocation != "inventory" && this.hammer.dataRef.locX >= 135 ? this.hammerDown2 : this.hammerDown;
    if (GameDataController.gd.getItemData("sledgehammer").droppedLocation == "inventory")
    {
      this.proc = (float) (((double) vector3.x - (double) ScreenControler.sourceWidth * 0.600000023841858) / ((double) ScreenControler.sourceWidth * 0.600000023841858));
      if ((double) PlayerController.wc.currentXY.x > 190.0)
      {
        PlayerController.wc.currentXY.x = 189f;
        PlayerController.wc.fullStop(true);
        Timeline.t.addAction(new TimelineAction(PlayerController.pc.textField)
        {
          text = GameStrings.getString(GameStrings.actions, "tutorial_quicksands"),
          function = new TimelineFunction(this.showDropHint)
        });
      }
    }
    else
    {
      this.proc -= 0.015f * Mathf.Abs(this.previous - PlayerController.wc.currentXY.x);
      if (!GameDataController.gd.getObjective("tutorial_tab"))
      {
        GameDataController.gd.setObjective("tutorial_tab", true);
        Timeline.t.addAction(new TimelineAction(GameObject.Find("BottomText").GetComponent<TextFieldController>())
        {
          text = GameStrings.getString(GameStrings.actions, "tutorial_tab"),
          textWidth = 200
        });
      }
    }
    if ((double) vector3.x < (double) ScreenControler.sourceWidth * 0.600000023841858 || (double) this.proc < 0.0)
    {
      vector3.x = (float) ScreenControler.sourceWidth * 0.6f;
      PlayerController.wc.speed = PlayerController.wc.MAX_SPEED * 1f;
      this.thePiasekB.sprite = this.sand1B;
      this.thePiasek.sprite = this.sand1;
    }
    else
    {
      vector3.y = PlayerController.wc.currentXY.y;
      vector3.y += (float) (5.0 + (double) this.proc * 20.0);
      this.thePiasek.sprite = (double) this.proc <= 0.150000005960464 ? ((double) this.proc <= 0.100000001490116 ? ((double) this.proc <= 0.0500000007450581 ? this.sand1 : this.sand2) : this.sand3) : this.sand4;
      this.thePiasekB.sprite = (double) this.proc <= 0.150000005960464 ? ((double) this.proc <= 0.100000001490116 ? ((double) this.proc <= 0.0500000007450581 ? this.sand1B : this.sand2B) : this.sand3B) : this.sand4B;
      PlayerController.wc.speed = (double) this.proc <= 0.150000005960464 ? ((double) this.proc <= 0.100000001490116 ? ((double) this.proc <= 0.0500000007450581 ? ((double) this.proc <= 0.0 ? PlayerController.wc.MAX_SPEED * 1f : PlayerController.wc.MAX_SPEED * 0.9f) : PlayerController.wc.MAX_SPEED * 0.75f) : PlayerController.wc.MAX_SPEED * 0.6f) : PlayerController.wc.MAX_SPEED * 0.5f;
    }
    Vector3 worldPoint1 = Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen((Vector2) vector3));
    worldPoint1.z = PlayerController.pc.transform.position.z - 0.005f;
    this.thePiasek.gameObject.transform.position = worldPoint1;
    vector3.y += 2f;
    Vector3 worldPoint2 = Camera.main.ScreenToWorldPoint((Vector3) ScreenControler.gameToScreen((Vector2) vector3));
    worldPoint2.z = PlayerController.pc.transform.position.z + 0.005f;
    this.thePiasekB.gameObject.transform.position = worldPoint2;
    this.previous = PlayerController.wc.currentXY.x;
  }
}
