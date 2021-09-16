// Decompiled with JetBrains decompiler
// Type: crashsite_sign
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class crashsite_sign : MonoBehaviour
{
  private void Start()
  {
    this.gameObject.transform.Find("pest_control").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("chem_control").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("spider_control").GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
      this.gameObject.transform.Find("pest_control").GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
      this.gameObject.transform.Find("chem_control").GetComponent<SpriteRenderer>().enabled = true;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") != 2)
      return;
    this.gameObject.transform.Find("spider_control").GetComponent<SpriteRenderer>().enabled = true;
  }

  private void Update()
  {
  }
}
