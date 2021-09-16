// Decompiled with JetBrains decompiler
// Type: CrashsiteBodies
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CrashsiteBodies : MonoBehaviour
{
  private void Start()
  {
    this.gameObject.transform.Find("bodies_gas").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("bodies_bugs").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("bodies_spiders").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("remains_a").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("remains_b").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("remains_c").GetComponent<SpriteRenderer>().enabled = false;
    if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 0)
    {
      this.gameObject.transform.Find("bodies_bugs").GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getCurrentDay() > 1)
        this.gameObject.transform.Find("remains_a").GetComponent<SpriteRenderer>().enabled = true;
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 1)
    {
      this.gameObject.transform.Find("bodies_gas").GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getCurrentDay() > 1)
        this.gameObject.transform.Find("remains_b").GetComponent<SpriteRenderer>().enabled = true;
    }
    else if (GameDataController.gd.getObjectiveDetail("day_1_threat") == 2)
    {
      this.gameObject.transform.Find("bodies_spiders").GetComponent<SpriteRenderer>().enabled = true;
      if (GameDataController.gd.getCurrentDay() > 1)
        this.gameObject.transform.Find("remains_c").GetComponent<SpriteRenderer>().enabled = true;
    }
    if (GameDataController.gd.getCurrentDay() <= 1)
      return;
    this.gameObject.transform.Find("bodies_gas").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("bodies_bugs").GetComponent<SpriteRenderer>().enabled = false;
    this.gameObject.transform.Find("bodies_spiders").GetComponent<SpriteRenderer>().enabled = false;
  }

  private void Update()
  {
  }
}
