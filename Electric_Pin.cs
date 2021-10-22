// Decompiled with JetBrains decompiler
// Type: Electric_Pin
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class Electric_Pin : ObjectActionController
{
  public Sprite wire_1;
  public Sprite wire_2;
  public Sprite wire_3;
  public Sprite wire_4;
  public Sprite wire_5;
  public ElectricPuzzleReset butbut;
  public bool input;
  public bool output;
  public string pinLetter;
  public int pinNumber;
  public string prevPin;
  public Sprite selector;
  public bool showValue;
  public int electricValue;
  private SpriteRenderer sr;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "electric_pin";
    this.range = 10000f;
    this.teleport = true;
    this.interactions = new List<ItemInteraction>();
    this.interactions.Add(new ItemInteraction("puzzle_cable", string.Empty, anim: string.Empty));
    this.sr = this.GetComponent<SpriteRenderer>();
  }

  public override void clickAction()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_" + this.pinLetter.ToLower() + (object) this.pinNumber) == 0)
    {
      if (!(bool) (Object) this.sr)
        return;
      this.sr.enabled = false;
    }
    else
    {
      if (!(bool) (Object) this.sr)
        return;
      this.sr.enabled = true;
      if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_" + this.pinLetter.ToLower() + (object) this.pinNumber) == 1)
        this.sr.sprite = this.wire_1;
      else if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_" + this.pinLetter.ToLower() + (object) this.pinNumber) == 2)
        this.sr.sprite = this.wire_2;
      else if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_" + this.pinLetter.ToLower() + (object) this.pinNumber) == 3)
        this.sr.sprite = this.wire_3;
      else if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_" + this.pinLetter.ToLower() + (object) this.pinNumber) == 4)
        this.sr.sprite = this.wire_4;
      else
        this.sr.sprite = this.selector;
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
    if (this.output && this.usedItem != "puzzle_cable")
    {
      PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.hose);
      CursorController.cc.selectItem(ItemsManager.im.getItem("puzzle_cable"));
      GameDataController.gd.setObjectiveDetail("sidereal_electric_pin_" + this.pinLetter.ToLower() + (object) this.pinNumber, -1);
      this.updateAll();
      this.checkConnect(1, "sidereal_electric_pin_A");
      this.checkConnect(2, "sidereal_electric_pin_B");
    }
    if (this.usedItem == "puzzle_cable" && this.input)
    {
      string id1 = string.Empty;
      for (int index = 0; index < 5; ++index)
      {
        string id2 = "sidereal_electric_pin_" + this.prevPin.ToLower() + (object) index;
        if (GameDataController.gd.getObjective(id2) && GameDataController.gd.getObjectiveDetail(id2) == -1)
        {
          id1 = id2;
          break;
        }
      }
      if (id1 != string.Empty)
      {
        for (int index = 0; index < 5; ++index)
        {
          string id3 = "sidereal_electric_pin_" + this.prevPin.ToLower() + (object) index;
          if (GameDataController.gd.getObjective(id3) && GameDataController.gd.getObjectiveDetail(id3) == this.pinNumber)
            GameDataController.gd.setObjectiveDetail(id3, 0);
        }
        PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.pyk);
        GameDataController.gd.setObjectiveDetail(id1, this.pinNumber);
        this.updateAll();
      }
      this.checkConnect(1, "sidereal_electric_pin_A");
      this.checkConnect(2, "sidereal_electric_pin_B");
    }
    this.butbut.showOrNot();
  }

  public override void whatOnClick()
  {
  }

  public void startWithCheck()
  {
    this.checkConnect(1, "sidereal_electric_pin_A");
    this.checkConnect(2, "sidereal_electric_pin_B");
  }

  private void checkConnect(int exit, string pinName)
  {
    int num = exit;
    int detail = 0;
    for (int index1 = 4; index1 >= 0; --index1)
    {
      string str = "a";
      if (index1 == 0)
        str = "a";
      if (index1 == 1)
        str = "b";
      if (index1 == 2)
        str = "c";
      if (index1 == 3)
        str = "d";
      if (index1 == 4)
        str = "e";
      bool flag = false;
      for (int index2 = 0; index2 < 5; ++index2)
      {
        if (GameDataController.gd.getObjective("sidereal_electric_pin_" + str + (object) index2) && GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_" + str + (object) index2) == num)
        {
          detail += GameObject.Find("Pin_" + str.ToUpper() + (object) index2).GetComponent<Electric_Pin>().electricValue;
          num = index2;
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        GameDataController.gd.setObjective(pinName, false);
        GameDataController.gd.setObjectiveDetail(pinName, 0);
        GameObject.Find(pinName + "Label").GetComponent<SiderealElectricPinA>().display("-");
        break;
      }
      if (index1 == 0)
      {
        GameDataController.gd.setObjective(pinName, true);
        GameDataController.gd.setObjectiveDetail(pinName, detail);
        GameObject.Find(pinName + "Label").GetComponent<SiderealElectricPinA>().display(detail.ToString() + string.Empty);
      }
    }
  }
}
