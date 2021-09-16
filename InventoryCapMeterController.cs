// Decompiled with JetBrains decompiler
// Type: InventoryCapMeterController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class InventoryCapMeterController : MonoBehaviour
{
  private TextFieldController tfc;
  private InventoryController ic;
  public static InventoryCapMeterController cm;

  private void Awake()
  {
    if ((Object) InventoryCapMeterController.cm == (Object) null)
    {
      InventoryCapMeterController.cm = this;
      this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
      this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
      this.tfc = this.gameObject.GetComponent<TextFieldController>();
      this.ic = this.gameObject.transform.parent.gameObject.GetComponent<InventoryController>();
    }
    else
    {
      if (!((Object) InventoryCapMeterController.cm != (Object) this))
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }

  private void Start()
  {
    this.tfc.viewText("/", quick: true);
    this.tfc.keepAlive = true;
    this.tfc.black.SetActive(false);
    this.tfc.container.transform.parent = this.gameObject.transform;
    this.tfc.zzz = this.gameObject.transform.position.z - 0.01f;
  }

  private void Update()
  {
  }

  public void updateText()
  {
    string str = Mathf.Round((float) this.ic.maxCapacity).ToString();
    this.tfc.viewText((Mathf.Round(this.ic.getCurrentWeight() * 100f) / 100f).ToString() + "/" + str + GameStrings.getString(GameStrings.gui, "kg"), quick: true, instant: true, mwidth: 100, r: 0.58f, g: 0.58f, b: 0.58f);
    this.tfc.keepAlive = true;
    this.tfc.black.SetActive(false);
  }

  private void OnMouseEnter()
  {
    if (PlayerController.wc.busy)
      return;
    string str1 = this.ic.maxCapacity.ToString();
    string str2 = this.ic.getCurrentWeight().ToString();
    GameObject.Find("BottomText").GetComponent<TextFieldController>().viewText(GameStrings.getString(GameStrings.gui, "capacity") + ": " + str2 + "/" + str1 + " " + GameStrings.getString(GameStrings.gui, "kg"), quick: true, mwidth: ObjectActionController.BOTTOM_TEXT_WIDTH);
  }

  private void OnMouseExit()
  {
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<WalkController>().busy)
      return;
    GameObject.Find("BottomText").GetComponent<TextFieldController>().keepAlive = false;
  }

  private void OnMouseDown()
  {
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<WalkController>().busy)
      return;
    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().clickedSomething = true;
  }
}
