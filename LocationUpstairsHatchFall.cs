// Decompiled with JetBrains decompiler
// Type: LocationUpstairsHatchFall
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationUpstairsHatchFall : MonoBehaviour
{
  private void Start()
  {
  }

  private void Update()
  {
  }

  private void endFall()
  {
    GameDataController.gd.setObjective("day_2_hatch_fallen", true);
    GameObject.Find("Ladder").transform.Find("faller").GetComponent<Animator>().Play("klapa_0");
    this.GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjectiveDetail("day1_complete") < 0)
      GameObject.Find("Ladder").GetComponent<LocationBaseUpstairsLadder>().updateState();
    else
      GameObject.Find("Ladder").GetComponent<LocationBaseUpstairsLadder>().updateAll();
  }

  private void jebs()
  {
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.double_bang);
    GameDataController.gd.setObjective("day_2_hatch_fallen", true);
  }
}
