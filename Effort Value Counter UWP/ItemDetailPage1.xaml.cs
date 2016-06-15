using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Effort_Value_Counter.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// アイテム詳細ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234232 を参照してください

namespace Effort_Value_Counter
{
  /// <summary>
  /// グループ内の単一のアイテムに関する詳細情報を表示するページです。同じグループに属する他の
  /// アイテムにフリップするジェスチャを使用できます。
  /// </summary>
  public sealed partial class ItemDetailPage1 : Page
  {
    private NavigationHelper navigationHelper;
    private ObservableDictionary defaultViewModel = new ObservableDictionary();


      int revision1=1, revision2=1;
      int effort1Result = 0, effort2Result = 0,effort3Result = 0;
      int effort1ResultOld = 0, effort2ResultOld = 0, effort3ResultOld = 0;
      int flag = 0, flag2 = 0,flagX = 0, flagY = 0;
      int gap = 0, sign = 0;
      int sum=0;
      int x1 = 0, y1 = 0, z1 = 0;
      int pokenum = 0;

      int selectedeffort1 = 0;
      int selectedeffort2 = 0;
      int selectedeffort3 = 4;

      string attack, defence, spAtc, spDef, speed, hp;
      string pWeight, pBracer, pBelt, pLens, pBand, pAnklet;
      string[] capa = new string[7];

      int capacity1Num=0, capacity2Num=0, powerNum = 0;

      List<IndexStore> indexStore;
      List<IndivisualDatas> indivisualData;

      int effort4Result = 0;
      int numberSum;

      string msg, data;

    /// <summary>
    /// これは厳密に型指定されたビュー モデルに変更できます。
    /// </summary>
    public ObservableDictionary DefaultViewModel
    {
      get { return this.defaultViewModel; }
    }

    /// <summary>
    /// NavigationHelper は、ナビゲーションおよびプロセス継続時間管理を
    /// 支援するために、各ページで使用します。
    /// </summary>
    public NavigationHelper NavigationHelper
    {
      get { return this.navigationHelper; }
    }

    public ItemDetailPage1()
    {
      this.InitializeComponent();
      this.navigationHelper = new NavigationHelper(this);
      this.navigationHelper.LoadState += navigationHelper_LoadState;
      this.SizeChanged += VerticalHubPage_SizeChanged;

      indexStore = new List<IndexStore>();
      indivisualData = new List<IndivisualDatas>();

      //Result Grid = number:0
      ValueStore0();
      DefaultGrid();
      DefaultItem0();
      //①grid = nuber:1
      ValueStore1();
      DefaultItem1();
      //②grid = nuber:2
      ValueStore2();
      DefaultItem2();
      //③grid = nuber:3
      ValueStore3();
      DefaultItem3();

//      sub1.IsEnabled = false;
//      effortSelect2.IsEnabled = false;


    }
    //この部分は将来的に変わるかも
    private void ValueStore0()
    {

      pokemonSelect.Items.Add("pokemon1");
      pokemonSelect.Items.Add("pokemon2");
      pokemonSelect_d.Items.Add("pokemon1");
      pokemonSelect_d.Items.Add("pokemon2");
      pokemonSelect_s.Items.Add("pokemon1");
      pokemonSelect_s.Items.Add("pokemon2");
    }

    private void ValueStore1()
    {
      var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();

      hp = resourceLoader.GetString("hp");
      attack = resourceLoader.GetString("attack");
      defence = resourceLoader.GetString("defence");
      spAtc = resourceLoader.GetString("spAtk");
      spDef = resourceLoader.GetString("spDef");
      speed = resourceLoader.GetString("speed");

      pWeight = resourceLoader.GetString("pWeight");
      pBracer = resourceLoader.GetString("pBracer");
      pBelt = resourceLoader.GetString("pBelt");
      pLens = resourceLoader.GetString("pLens");
      pBand = resourceLoader.GetString("pBand");
      pAnklet = resourceLoader.GetString("pAnklet");

      capa[0] = "---";
      capa[1] = hp;
      capa[2] = attack;
      capa[3] = defence;
      capa[4] = spAtc;
      capa[5] = spDef;
      capa[6] = speed;

      capacitySelect1.Items.Add(hp);//1
      capacitySelect1.Items.Add(attack);//2
      capacitySelect1.Items.Add(defence);
      capacitySelect1.Items.Add(spAtc);
      capacitySelect1.Items.Add(spDef);
      capacitySelect1.Items.Add(speed);//6

      capacitySelect2.Items.Add("---");//0
      capacitySelect2.Items.Add(hp);//1
      capacitySelect2.Items.Add(attack);
      capacitySelect2.Items.Add(defence);//3
      capacitySelect2.Items.Add(spAtc);
      capacitySelect2.Items.Add(spDef);
      capacitySelect2.Items.Add(speed);


      effortSelect1.Items.Add(1);
      effortSelect1.Items.Add(2);
      effortSelect1.Items.Add(3);


      effortSelect2.Items.Add(1);
      effortSelect2.Items.Add(2);
   //   effortSelect2.Items.Add(3);


      powerItem.Items.Add("---");//0
      powerItem.Items.Add(pWeight);//1
      powerItem.Items.Add(pBracer);
      powerItem.Items.Add(pBelt);
      powerItem.Items.Add(pLens);
      powerItem.Items.Add(pBand);
      powerItem.Items.Add(pAnklet);//6



      /*　Power Weight---パワーウエイト---HP対応
　Power Bracer---パワーリスト---攻撃対応
　Power Belt---パワーベルト---防御対応
　Power Lens---パワーレンズ---特攻対応
　Power Band---パワーバンド---特防対応
　Power Anklet---パワーアンクル---素早さ対応*/

    }

    private void ValueStore2()
    {

      itemSelected1.Items.Add("---");
      itemSelected1.Items.Add("マックスアップ");
      itemSelected1.Items.Add("タウリン");
      itemSelected1.Items.Add("ブロムヘキシン");
      itemSelected1.Items.Add("リゾチウム");
      itemSelected1.Items.Add("キトサン");
      itemSelected1.Items.Add("インドメタシン");

      itemSelected1.Items.Add("たいりょく のはね");
      itemSelected1.Items.Add("きんりょく のはね");
      itemSelected1.Items.Add("ていこう のはね");
      itemSelected1.Items.Add("ちりょく のはね");
      itemSelected1.Items.Add("せいしん のはね");
      itemSelected1.Items.Add("しゅんぱつ のはね");

      itemSelected1.Items.Add("ざくろ のみ");
      itemSelected1.Items.Add("ねこぶ のみ");
      itemSelected1.Items.Add("たぽる のみ");
      itemSelected1.Items.Add("ろめ のみ");
      itemSelected1.Items.Add("うぶ のみ");
      itemSelected1.Items.Add("まとま のみ");

      /*
      itemSelected2.Items.Add("---");
      itemSelected2.Items.Add("ざくろ");
      itemSelected2.Items.Add("ねこぶ");
      itemSelected2.Items.Add("たぽる");
      itemSelected2.Items.Add("ろめ");
      itemSelected2.Items.Add("うぶ");
      itemSelected2.Items.Add("まとま");
      */
      /*
       マックスアップ:HP努力値を10上昇させる。 
タウリン:攻撃努力値を10上昇させる。 
ブロムヘキシン:防御努力値を10上昇させる。 
リゾチウム:特攻努力値を10上昇させる。 
キトサン:特防努力値を10上昇させる。 
インドメタシン:素早さ努力値を10上昇させる。 
      たいりょくのハネ:HP努力値を1上昇させる。 
きんりょくのハネ:攻撃努力値を1上昇させる。 
ていこうのハネ:防御努力値を1上昇させる。 
ちりょくのハネ:特攻努力値を1上昇させる。 
せいしんのハネ:特防努力値を1上昇させる。 
しゅんぱつのハネ:素早さ努力値を1上昇させる。
ザロクのみ（きのみNo.21）:HP努力値を10減少させる。 
ネコブのみ（きのみNo.22）:攻撃努力値を10減少させる。 
タポルのみ（きのみNo.23）:防御努力値を10減少させる。 
ロメのみ（きのみNo.24）:特攻努力値を10減少させる。 
ウブのみ（きのみNo.25）:特防努力値を10減少させる。 
マトマのみ（きのみNo.26）:素早さ努力値を10減少させる。

       */
    }

    private void ValueStore3()
    {
      bagSelected.Items.Add("---");
      bagSelected.Items.Add("HP-S");
      bagSelected.Items.Add("こうげき-S");
      bagSelected.Items.Add("ぼうぎょ-S");
      bagSelected.Items.Add("とくこう-S");
      bagSelected.Items.Add("とくぼう-S");
      bagSelected.Items.Add("すばやさ-S");

      bagSelected.Items.Add("HP-M");
      bagSelected.Items.Add("こうげき-M");
      bagSelected.Items.Add("ぼうぎょ-M");
      bagSelected.Items.Add("とくこう-M");
      bagSelected.Items.Add("とくぼう-M");
      bagSelected.Items.Add("すばやさ-M");

      bagSelected.Items.Add("HP-L");
      bagSelected.Items.Add("こうげき-L");
      bagSelected.Items.Add("ぼうぎょ-L");
      bagSelected.Items.Add("とくこう-L");
      bagSelected.Items.Add("とくぼう-L");
      bagSelected.Items.Add("すばやさ-L");
      bagSelected.Items.Add("まっさら");

      trainingSelected.Items.Add("---");
      trainingSelected.Items.Add("HP-Lv.1");
      trainingSelected.Items.Add("こうげき-Lv.1");
      trainingSelected.Items.Add("ぼうぎょ-Lv.1");
      trainingSelected.Items.Add("とくこう-Lv.1");
      trainingSelected.Items.Add("とくぼう-Lv.1");
      trainingSelected.Items.Add("すばやさ-Lv.1");

      trainingSelected.Items.Add("HP-Lv.2");
      trainingSelected.Items.Add("こうげき-Lv.2");
      trainingSelected.Items.Add("ぼうぎょ-Lv.2");
      trainingSelected.Items.Add("とくこう-Lv.2");
      trainingSelected.Items.Add("とくぼう-Lv.2");
      trainingSelected.Items.Add("すばやさ-Lv.2");

      trainingSelected.Items.Add("HP-Lv.3");
      trainingSelected.Items.Add("こうげき-Lv.3");
      trainingSelected.Items.Add("ぼうぎょ-Lv.3");
      trainingSelected.Items.Add("とくこう-Lv.3");
      trainingSelected.Items.Add("とくぼう-Lv.3");
      trainingSelected.Items.Add("すばやさ-Lv.3");

    }

    private void DefaultGrid()
    {/*
      H1.Text = "0";
      A1.Text = "0";
      D1.Text = "0";
      SA1.Text = "0";
      SD1.Text = "0";
      SP1.Text = "0";

      h2.Text = "0";
      a2.Text = "0";
      d2.Text = "0";
      sa2.Text = "0";
      sd2.Text = "0";
      sp2.Text = "0";

      h3.Text = "0";
      a3.Text = "0";
      d3.Text = "0";
      sa3.Text = "0";
      sd3.Text = "0";
      sp3.Text = "0";
      */
      h4.Text = "0";
      a4.Text = "0";
      d4.Text = "0";
      sa4.Text = "0";
      sd4.Text = "0";
      sp4.Text = "0";
      sum4.Text = "0";

    }

    private void DefaultItem0()
    {
      indivisualData.Add(new IndivisualDatas
      {
        HP = 0,
        Attack = 0,
        Defence = 0,
        sAttack = 0,
        sDefence = 0,
        Speed = 0
      });
      indivisualData.Add(new IndivisualDatas
      {
        HP = 0,
        Attack = 0,
        Defence = 0,
        sAttack = 0,
        sDefence = 0,
        Speed = 0
      });
    }

    private void DefaultItem1()
    {
      capacitySelect1.SelectedIndex = 0;
      capacitySelect2.SelectedIndex = 0;

      effortSelect1.SelectedIndex = 0;
      effortSelect2.SelectedIndex = 0;

      powerItem.SelectedIndex = 0;

      capacityBlock1.Text = capa[0];
      capacityBlock2.Text = capa[0];
      powerBlock.Text = capa[powerNum];

      count.Text = "0";

      effortBlock1.Text = "0";
      effortBlock2.Text = "0";
      effortBlock3.Text = "0";

      effort1ResultOld = 0;
      effort2ResultOld = 0;
      effort3ResultOld = 0;
       revision1 = 1; revision2 = 1;
       effort1Result = 0; effort2Result = 0; effort3Result = 0;

       flag = 0; flagX = 0; flagY = 0;

       pokerus.IsOn = false;
       gypsum.IsOn = false;


       selectedeffort1 = 0;
       selectedeffort2 = 0;
       selectedeffort3 = 0;

       indexStore.Add(new IndexStore
       {
         times = 0,
         capacity1 = 0,
         capacity2 = 0,
         effort1 = 0,
         effort2 = 0,
         pkrsf = 0,
         gpsf = 0,
         power = 0,
         effortResult1 = 0,
         effortResult2 = 0,
         effortResult3 = 0
       });



       indexStore[0].effortResult1 = 0;
       indexStore[0].effortResult2 = 0;
       indexStore[0].effortResult3 = 0;
      /*
       H1.Text = "0";
       A1.Text = "0";
       D1.Text = "0";
       SA1.Text = "0";
       SD1.Text = "0";
       SP1.Text = "0";
*/
    }

    private void DefaultItem2()
    {
      itemSelected1.SelectedIndex = 0;
//      itemSelected2.SelectedIndex = 0;

      numberBlock.Text = "0";
      effortBlock4.Text = "0";
      effort4Result = 0;
      numberSum = 0;
//      itemSelected2.IsEnabled = false;
    }

    private void DefaultItem3()
    {
      bagSelected.SelectedIndex = 0;
      trainingSelected.SelectedIndex = 0;

      capacityBlock6.Text = "0";
      effortBlock6.Text = "0";
      capacityBlock5.Text = "0";
      effortBlock5.Text = "0";
      /*
      h3.Text = indivisualData[pokenum].HP.ToString();
      a3.Text = indivisualData[pokenum].Attack.ToString();
      d3.Text = indivisualData[pokenum].Defence.ToString();
      sa3.Text = indivisualData[pokenum].sAttack.ToString();
      sd3.Text = indivisualData[pokenum].sDefence.ToString();
      sp3.Text = indivisualData[pokenum].Speed.ToString();
       * */
    }

    private void SwitchCntroll(int a)
    {
      if (a == 0)
      {
        add1.IsEnabled = false;
      }
      else if(a == 1)
      {

      }
    }

    /// <summary>
    /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
    /// 再作成する場合は、保存状態も指定されます。
    /// </summary>
    /// <param name="sender">
    /// イベントのソース (通常、<see cref="NavigationHelper"/>)
    /// </param>
    /// <param name="e">このページが最初に要求されたときに
    /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたナビゲーション パラメーターと、
    /// 前のセッションでこのページによって保存された状態の辞書を提供する
    /// イベント データ。ページに初めてアクセスするとき、状態は null になります。</param>
    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
//      object navigationParameter;
      if (e.PageState != null && e.PageState.ContainsKey("dataText"))
      {
        //        navigationParameter = e.PageState["SelectedItem"];
        msg = (string)e.PageState["dataText"];

        DataRestore(msg);

      }
      String filePath = "StoreDataSave.txt";
      DataStore(filePath);
      // TODO: バインド可能なグループを this.DefaultViewModel["Group"] に割り当てます
      // TODO: バインド可能なアイテムのコレクションを this.DefaultViewModel["Items"] に割り当てます
      // TODO: 選択したアイテムを this.flipView.SelectedItem に割り当てます
    }

    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
      data = h4.Text + "/" + a4.Text + "/" + d4.Text + "/" + sa4.Text + "/" + sd4.Text + "/" + sp4.Text + "\n";
      e.PageState["dataText"] = data;

      DataSave(100);
    }


    private void DataRestore(string msg0)
    {
      string[] msg1 = msg0.Split('/');

      indivisualData[pokenum].HP = int.Parse(msg1[0]);
      indivisualData[pokenum].Attack = int.Parse(msg1[1]);
      indivisualData[pokenum].Defence = int.Parse(msg1[2]);
      indivisualData[pokenum].sAttack = int.Parse(msg1[3]);
      indivisualData[pokenum].sDefence = int.Parse(msg1[4]);
      indivisualData[pokenum].Speed = int.Parse(msg1[5]);

      ResultOutput(1);

    }

    async private void DataSave(int num)
    {


//      await FileIO.AppendTextAsync(sampleFile, data);
      String filePath = null;
      if (num == 0)
      {
         filePath = "StoreData0.txt";
      }

      else if(num == 1)
      {
         filePath = "StoreData1.txt";
      }
      else filePath = "StoreDataSave.txt";
      // write file
//      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
//      StorageFile file = await localFolder.CreateFileAsync(filePath,
//          CreationCollisionOption.OpenIfExists);
      try { 
      StorageFolder roamingFolder = ApplicationData.Current.LocalFolder;
      StorageFile file = await roamingFolder.CreateFileAsync(filePath,
        CreationCollisionOption.ReplaceExisting);


      //          data = "sampleData/" + (string)attackBox1.SelectedIndex + "/" + (string)attackBox2.SelectedIndex + "/" +
      //            (string)attackTechBox.SelectedIndex + "/" + (string)defenseBox1.SelectedIndex + "/" + (string)defenseBox2.SelectedIndex + "\n";
/*
      data = indexStore[0].times.ToString() + "/" + indexStore[0].capacity1.ToString() + "/" + indexStore[0].capacity2.ToString() + "/"
        + indexStore[0].effort1.ToString() + "/" + indexStore[0].effort2.ToString() + "/" + indexStore[0].pkrsf.ToString() + "/"
        + indexStore[0].gpsf.ToString() + "/" + indexStore[0].power.ToString() + "/" + indexStore[0].effortResult1.ToString() + "/"
        + indexStore[0].effortResult2.ToString() + "/" + indexStore[0].effortResult3.ToString() + "\n";
*/
      data = h4.Text + "/" + a4.Text + "/" + d4.Text + "/" + sa4.Text + "/" + sd4.Text + "/" + sp4.Text + "\n";


      //      data = comment + "\t" + defenseBox1.SelectedIndex + "\t" + defenseBox2.SelectedIndex + "\t" + attackTechBox.SelectedIndex + "\t"
      //          + attackBox1.SelectedIndex + "\t" + attackBox2.SelectedIndex + "\t" + DateTime.Now + "\n";
      await FileIO.AppendTextAsync(file, data);
}
      catch(Exception ex)
      { }
    }

    async private void DataStore(String filePath)
    {
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
      try
      {

        StorageFile file = await localFolder.GetFileAsync(filePath);
        IList<String> strList = await FileIO.ReadLinesAsync(file);
        foreach (String str in strList)
        {
          msg = str;

          //          datas.Add(str);

        }

        DataRestore(msg);


      }
      catch (Exception ex)
      {
        // ファイル無し
      }


      if (indexStore[0].gpsf == 1) { revision2 = 2; gypsum.IsOn = true; }
      else if (indexStore[0].gpsf == 0) { revision2 = 1; gypsum.IsOn = false; }

      if (indexStore[0].pkrsf == 1) { revision1 = 2; pokerus.IsOn = true; }
      else if (indexStore[0].pkrsf == 0) { revision1 = 1; pokerus.IsOn = false; }

    }

    async private void pokemonSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //      attentionBlock.Text = "";

      //      DataRestore(msg);
      String filePath = null;
      if (pokemonSelect.SelectedIndex == 0) { pokenum = 0; filePath = "StoreData0.txt"; }
      else if (pokemonSelect.SelectedIndex == 1) { pokenum = 1; filePath = "StoreData1.txt"; }
//      else filePath = "StoreDataSave.txt";
      DataStore(filePath);

      //      if (pokemonSelect.SelectedItem == null) { attentionBlock.Text = "ポケモンを選択してください"; }
      //      else if (pokemonSelect.SelectedIndex == 0) 
      //      else if (pokemonSelect.SelectedIndex == 1) 

    }

    private void deleteButton_Tapped(object sender, TappedRoutedEventArgs e)
    {

    }

    private void pokemonSelect_d_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    async private void deleteOkButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      DeleteFlyoutTextBlock.Text = "";
      String filePath = null;
      if (pokemonSelect_d.SelectedItem == null) { DeleteFlyoutTextBlock.Text = "項目を選んでください"; }
      else if (pokemonSelect_d.SelectedIndex == 0) { pokenum = 0; filePath = "StoreData0.txt"; DeleteFlyoutTextBlock.Text = "削除しました"; }
      else if (pokemonSelect_d.SelectedIndex == 1) { pokenum = 1; filePath = "StoreData1.txt"; DeleteFlyoutTextBlock.Text = "削除しました"; }
      try
      { 
      StorageFolder roamingFolder = ApplicationData.Current.LocalFolder;
      StorageFile file = await roamingFolder.CreateFileAsync(filePath,
        CreationCollisionOption.ReplaceExisting);

      data = "0/0/0/0/0/0\n";
      await FileIO.AppendTextAsync(file, data);
      }
      catch(Exception ex)
      { }
      DataReset();

      ResultOutput(2);
    }

    private void deleteCancelButton_Tapped(object sender, TappedRoutedEventArgs e)
    {

    }

    void VerticalHubPage_SizeChanged(object sender, SizeChangedEventArgs e)
    {


      if (e.NewSize.Width <= 768)
      {
        VisualStateManager.GoToState(this, "MiniContentRegion", true);
      }

      else
      {

        VisualStateManager.GoToState(this, "ContentRegion", true);
      }

    }

    private void refreshOkButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      DefaultGrid();
      DefaultItem0();
      DefaultItem1();
      DefaultItem2();
      DefaultItem3();

      DataReset();

      ResultOutput(2);

    }

    private void refreshCancelButton_Tapped(object sender, TappedRoutedEventArgs e)
    {

    }

    private void DataReset()
    {
      indivisualData[pokenum].HP = 0;
      indivisualData[pokenum].Attack = 0;
      indivisualData[pokenum].Defence = 0;
      indivisualData[pokenum].sAttack = 0;
      indivisualData[pokenum].sDefence = 0;
      indivisualData[pokenum].Speed = 0;
    }

    private void saveOkButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      SaveFluoutTextBlock.Text = "";
      if (pokemonSelect_s.SelectedItem == null) { SaveFluoutTextBlock.Text = "ポケモンを選択してください"; }
      else { SaveFluoutTextBlock.Text = "記録が終わりました"; DataSave(pokemonSelect_s.SelectedIndex); }
    }

    private void saveCancelButton_Tapped(object sender, TappedRoutedEventArgs e)
    {

    }

    async private void restoreButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      /*
      //      DataRestore(msg);
      String filePath = null;
      if (pokemonSelect.SelectedItem == null) { attentionBlock.Text = "ポケモンを選択してください"; }
      else if(pokemonSelect.SelectedIndex == 0) filePath = "StoreData0.txt";
      else if (pokemonSelect.SelectedIndex == 1) filePath = "StoreData1.txt";
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
      try
      {

        StorageFile file = await localFolder.GetFileAsync(filePath);
        IList<String> strList = await FileIO.ReadLinesAsync(file);
        foreach (String str in strList)
        {
          msg = str;

          //          datas.Add(str);

        }

        DataRestore(msg);


      }
      catch (Exception ex)
      {
        // ファイル無し
      }


      if (indexStore[0].gpsf == 1) { revision2 = 2; gypsum.IsOn = true; }
      else if (indexStore[0].gpsf == 0) { revision2 = 1; gypsum.IsOn = false; }

      if (indexStore[0].pkrsf == 1) { revision1 = 2; pokerus.IsOn = true; }
      else if (indexStore[0].pkrsf == 0) { revision1 = 1; pokerus.IsOn = false; }
      */
    }

    #region NavigationHelper の登録

    /// このセクションに示したメソッドは、NavigationHelper がページの
    /// ナビゲーション メソッドに応答できるようにするためにのみ使用します。
    /// 
    /// ページ固有のロジックは、
    /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
    /// および <see cref="GridCS.Common.NavigationHelper.SaveState"/> のイベント ハンドラーに配置する必要があります。
    /// LoadState メソッドでは、前のセッションで保存されたページの状態に加え、
    /// ナビゲーション パラメーターを使用できます。

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedTo(e);
    }

   protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedFrom(e);
      DataSave(pokemonSelect.SelectedIndex);

    }

    #endregion


    










  }
}
