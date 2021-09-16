// Decompiled with JetBrains decompiler
// Type: LocationDesertTitleStart
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LocationDesertTitleStart : MonoBehaviour
{
  private void Start()
  {
    GameDataController.gd.setObjective("intro_desert_walked", false);
    JukeboxAmbient.jb.changeAmbient(SoundsManagerController.sm.ambient_wind_1, 0.25f);
    GameObject.Find("inventory_button").GetComponent<InventoryButtonController>().hide();
    GameObject.Find("journal").GetComponent<JournalButtonController>().hide();
    GameObject.Find("SmallPlayer").GetComponent<SmallWalker>().fakeClick();
  }

  private void Update()
  {
    PlayerController.pc.gameObject.transform.position = new Vector3(-11f, 0.5f, -2.5f);
    GameObject.Find("journal").gameObject.transform.position = new Vector3(-11f, 0.5f, -2.5f);
  }
}
