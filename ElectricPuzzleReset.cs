// Decompiled with JetBrains decompiler
// Type: ElectricPuzzleReset
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class ElectricPuzzleReset : MonoBehaviour
{
  public Button butbut;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void showOrNot()
  {
    if (GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_a1") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_a2") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_b1") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_b2") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_b3") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_c1") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_c2") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_d1") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_d2") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_d3") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_d4") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_e1") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_e2") > 0 || GameDataController.gd.getObjectiveDetail("sidereal_electric_pin_e3") > 0)
    {
      MonoBehaviour.print((object) "SHOWING RESET");
      this.butbut.buttonEnabled = true;
      this.butbut.initButton(GameStrings.getString(GameStrings.world_labels, "generic_reset"));
      this.butbut.gameObject.SetActive(true);
    }
    else
    {
      this.butbut.buttonEnabled = false;
      this.butbut.buttonText.dissmiss(true);
      this.butbut.gameObject.SetActive(false);
    }
  }
}
