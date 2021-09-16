// Decompiled with JetBrains decompiler
// Type: LoadingScene
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
  public float pyk;
  public string loadingTxt;
  public string addonTxt1;
  public string addonTxt2;
  public int dot;
  public bool doneanddone;
  public TextFieldController tfc;

  private void Start()
  {
    Cursor.visible = false;
    this.pyk = 0.0f;
    this.doneanddone = false;
    Application.targetFrameRate = 240;
    GameStrings.Language language;
    if (!PlayerPrefs.HasKey("stati"))
    {
      PlayerPrefs.SetInt("stati", 50);
      PlayerPrefs.SetInt("music", 100);
      PlayerPrefs.SetInt("sound", 100);
      PlayerPrefs.SetFloat("textSpeed", 0.0425f);
      language = GameStrings.Language.PL;
      PlayerPrefs.SetString("lang", language.ToString());
      PlayerPrefs.Save();
    }
    this.setRes();
    language = GameStrings.Language.PL;
    GameStrings.readStrings(PlayerPrefs.GetString("lang", language.ToString()));
    this.loadingTxt = GameStrings.getString(GameStrings.gui, "loading");
    this.dot = 0;
    this.tfc.viewText(this.loadingTxt, quick: true, instant: true);
  }

  private string ToHex(byte[] bytes)
  {
    char[] chArray = new char[bytes.Length * 2];
    int index1 = 0;
    int index2 = 0;
    while (index1 < bytes.Length)
    {
      byte num1 = (byte) ((uint) bytes[index1] >> 4);
      chArray[index2] = num1 <= (byte) 9 ? (char) ((int) num1 + 48) : (char) ((int) num1 + 55 + 32);
      byte num2 = (byte) ((uint) bytes[index1] & 15U);
      int num3;
      chArray[num3 = index2 + 1] = num2 <= (byte) 9 ? (char) ((int) num2 + 48) : (char) ((int) num2 + 55 + 32);
      ++index1;
      index2 = num3 + 1;
    }
    return new string(chArray);
  }

  private void setRes()
  {
    ScreenControler.setSavedResolution();
    CurtainController.fixCameraRect();
  }

  private void Update()
  {
    this.pyk += 0.01f;
    if ((double) this.pyk >= 0.5)
    {
      this.pyk = 0.0f;
      ++this.dot;
      if (this.dot > 3)
        this.dot = 0;
    }
    this.addonTxt1 = string.Empty;
    this.addonTxt2 = string.Empty;
    for (int index = 0; index < this.dot; ++index)
      this.addonTxt2 += ".";
    this.tfc.viewText(this.addonTxt1 + this.loadingTxt + this.addonTxt2, quick: true, instant: true);
    if (this.doneanddone || !GameObject.Find("SoundsManager").GetComponent<SoundsManagerController>().ALL_LOADED)
      return;
    this.doneanddone = true;
    MonoBehaviour.print((object) ("PlayerPrefs.HasKey(\"font\") " + PlayerPrefs.HasKey("font").ToString()));
    PlayerPrefs.SetString("lang", "PL");
    SceneManager.LoadScene("MainMenu");
  }
}
