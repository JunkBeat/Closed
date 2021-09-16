// Decompiled with JetBrains decompiler
// Type: RestaurantFlag
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class RestaurantFlag : MonoBehaviour
{
  private void Start()
  {
    if (GameDataController.gd.getObjective("restaurant_flag_lowered"))
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    else
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
  }

  private void Update()
  {
  }
}
