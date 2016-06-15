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

namespace Effort_Value_Counter
{
  sealed partial class ItemDetailPage1
  {
    //グル―ぷ1
    //カウント＋1
    private void add1_Tapped(object sender, TappedRoutedEventArgs e)
    {

      //      if()
      //      {}
      flag += 1;
      count.Text = flag.ToString();
      indexStore[0].times = flag;

      selectedeffort1 = (int)effortSelect1.SelectedItem;
      if (effortSelect2.IsEnabled == true) selectedeffort2 = (int)effortSelect2.SelectedItem;
      else capacity2Num = 0;

      indexStore[0].effort1 = selectedeffort1;
      indexStore[0].effort2 = selectedeffort2;



      if (flagX == 1)
      {
        effort1ResultOld += selectedeffort1 * revision1 * revision2 + selectedeffort3 * revision1;
        effort2ResultOld += selectedeffort2 * revision1 * revision2;

        DataCompare(ref effort1Result, x1, selectedeffort1 * revision1 * revision2 + selectedeffort3 * revision1);
        DataCompare(ref effort2Result, y1, selectedeffort2 * revision1 * revision2);

        //        x1 += selectedeffort1 * revision1 * revision2 + selectedeffort3 * revision1 ;
        //        y1 += selectedeffort2 * revision1 * revision2 ;

        if (effort1Result != selectedeffort1 * revision1 * revision2 + selectedeffort3 * revision1) { selectedeffort1 = 0; selectedeffort3 = 0; }
        if (effort2Result != selectedeffort2 * revision1 * revision2) selectedeffort2 = 0;

        /*
        if (effort1ResultOld > 252) { effort1Result = 252; selectedeffort1 = 0; selectedeffort3 = 0; }
        else effort1Result = selectedeffort1 * revision1 * revision2 + selectedeffort3 * revision1;
        if (effort2ResultOld > 252) { effort2Result = 252; selectedeffort1 = 0; }
        else effort2Result = selectedeffort2 * revision1 * revision2;
        */
        IndivisualDataStore(capacity1Num, effort1Result);
        IndivisualDataStore(capacity2Num, effort2Result);

        ItemStore(capacity1Num, ref x1);
        ItemStore(capacity2Num, ref y1);
      }
      else if (flagY == 1)
      {
        effort1ResultOld += selectedeffort1 * revision1 * revision2;
        effort2ResultOld += selectedeffort2 * revision1 * revision2 + selectedeffort3 * revision1;

        DataCompare(ref effort1Result, x1, selectedeffort1 * revision1 * revision2);
        DataCompare(ref effort2Result, y1, selectedeffort2 * revision1 * revision2 + selectedeffort3 * revision1);

        //        ItemStore(capacity1Num, ref x1);
        //        ItemStore(capacity2Num, ref y1);
        //        x1 += selectedeffort1 * revision1 * revision2;
        //        y1 += selectedeffort2 * revision1 * revision2 + selectedeffort3 * revision1;

        if (effort1Result != selectedeffort1 * revision1 * revision2) selectedeffort1 = 0;
        if (effort2Result != selectedeffort2 * revision1 * revision2 + selectedeffort3 * revision1) { selectedeffort2 = 0; selectedeffort3 = 0; }

        /*
        if (effort1ResultOld > 252) { effort1Result = 252; selectedeffort1 = 0; }
        else effort1Result = selectedeffort1 * revision1 * revision2;
        if (effort2ResultOld > 252) { effort2Result = 252; selectedeffort1 = 0; selectedeffort3 = 0; }
        else effort2Result = selectedeffort2 * revision1 * revision2 + selectedeffort3 * revision1;
         * */
        IndivisualDataStore(capacity1Num, effort1Result);
        IndivisualDataStore(capacity2Num, effort2Result);

        ItemStore(capacity1Num, ref x1);
        ItemStore(capacity2Num, ref y1);

      }
      else
      {
        effort1ResultOld += selectedeffort1 * revision1 * revision2;
        effort2ResultOld += selectedeffort2 * revision1 * revision2;
        effort3ResultOld += selectedeffort3 * revision1;


        DataCompare(ref effort1Result, x1, selectedeffort1 * revision1 * revision2);
        DataCompare(ref effort2Result, y1, selectedeffort2 * revision1 * revision2);
        DataCompare(ref effort3Result, z1, selectedeffort3 * revision1);

        /*
        ItemStore(capacity1Num, ref x1);
        ItemStore(capacity2Num, ref y1);
        ItemStore(powerNum, ref z1);
        */
        /*
        x1 += selectedeffort1 * revision1 * revision2;
        y1 += selectedeffort2 * revision1 * revision2;
        z1 += selectedeffort3 * revision1;
        */
        if (effort1Result != selectedeffort1 * revision1 * revision2) selectedeffort1 = 0;
        if (effort2Result != selectedeffort2 * revision1 * revision2) selectedeffort2 = 0;
        if (effort3Result != selectedeffort3 * revision1) selectedeffort3 = 0;

        /*        if (effort1ResultOld + effort2ResultOld + effort3ResultOld <= 520)
                {
                  if (effort1ResultOld > 252) { GapSet(ref effort1Result, x); selectedeffort1 = 0; }
                  else { effort1Result = selectedeffort1 * revision1 * revision2; x += effort1Result; }
                  if (effort2ResultOld > 252) { GapSet(ref effort2Result, y); selectedeffort2 = 0; }
                  else { effort2Result = selectedeffort2 * revision1 * revision2; y += effort2Result; }
                  if (effort3ResultOld > 252) { GapSet(ref effort3Result, z); selectedeffort3 = 0; }
                  else { effort3Result = selectedeffort3 * revision1 * revision2; z += effort3Result; }
                }
                else SwitchCntroll(0);
        */
        IndivisualDataStore(capacity1Num, effort1Result);
        IndivisualDataStore(capacity2Num, effort2Result);
        IndivisualDataStore(powerNum, effort3Result);

        ItemStore(capacity1Num, ref x1);
        ItemStore(capacity2Num, ref y1);
        ItemStore(powerNum, ref z1);
      }



      //        capacityBlock1.Text = capacitySelect1.SelectedItem.ToString();
      capacityBlock1.Text = capa[capacity1Num];
      capacityBlock2.Text = capa[capacity2Num];
      powerBlock.Text = capa[powerNum];
      effortBlock1.Text = x1.ToString();
      effortBlock2.Text = y1.ToString();
      effortBlock3.Text = z1.ToString();

      ResultOutput(1);

      /*
      H1.Text = indivisualData[pokenum].HP.ToString();
      A1.Text = indivisualData[pokenum].Attack.ToString();
      D1.Text = indivisualData[pokenum].Defence.ToString();
      SA1.Text = indivisualData[pokenum].sAttack.ToString();
      SD1.Text = indivisualData[pokenum].sDefence.ToString();
      SP1.Text = indivisualData[pokenum].Speed.ToString();
      */

      //      if(flag != 0) sub1.IsEnabled = true;
    }

    private void ItemStore(int a, ref int b)
    {
      if (a == 1)
      {
        b = indivisualData[pokenum].HP;
      }
      else if (a == 2)
      {
        b = indivisualData[pokenum].Attack;
      }
      else if (a == 3)
      {
        b = indivisualData[pokenum].Defence;
      }
      else if (a == 4)
      {
        b = indivisualData[pokenum].sAttack;
      }
      else if (a == 5)
      {
        b = indivisualData[pokenum].sDefence;
      }
      else if (a == 6)
      {
        b = indivisualData[pokenum].Speed;
      }
    }


    //ポケルス補正
    private void pokerus_Toggled(object sender, RoutedEventArgs e)
    {

      if (pokerus.IsOn == true)
      {
        revision1 = 2;
        indexStore[0].pkrsf = 1;
      }
      else { revision1 = 1; indexStore[0].pkrsf = 0; }

    }

    //ギプス補正
    private void gypsum_Toggled(object sender, RoutedEventArgs e)
    {
      if (gypsum.IsOn == true)
      {
        revision2 = 2;
        powerItem.IsEnabled = false;
        indexStore[0].gpsf = 1;
      }
      else
      {
        revision2 = 1;
        powerItem.IsEnabled = true;
        indexStore[0].gpsf = 0;
      }
    }

    //パワーアイテムボックス
    private void powerItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      powerNum = powerItem.SelectedIndex;
      try
      {
        indexStore[0].power = powerNum;
      }
      catch (ArgumentOutOfRangeException ex)
      { }
      if ((string)powerItem.SelectedItem == "---")
      {
        gypsum.IsEnabled = true;
        selectedeffort3 = 0;
      }
      else
      {
        gypsum.IsEnabled = false;
        selectedeffort3 = 4;
      }

      if (capa[capacity1Num] == capa[powerNum])
      {
        flagX = 1;
      }
      else flagX = 0;

      if (capa[capacity2Num] == capa[powerNum])
      {
        flagY = 1;
      }
      else flagY = 0;

    }

    //カウント-1
    private void sub1_Tapped(object sender, TappedRoutedEventArgs e)
    {
      flag -= 1;
      count.Text = flag.ToString();


      selectedeffort1 = (int)effortSelect1.SelectedItem;
      selectedeffort2 = (int)effortSelect2.SelectedItem;

      effort1Result -= selectedeffort1 * revision1 * revision2;
      effortBlock1.Text = effort1Result.ToString();

      effort2Result -= selectedeffort2 * revision1 * revision2;
      effortBlock2.Text = effort2Result.ToString();
      //      if (flag == 0) sub1.IsEnabled = false;
      //96,752,872
    }

    //カウントする能力1
    private void capacitySelect1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      capacity1Num = capacitySelect1.SelectedIndex + 1;
      try
      {
        indexStore[0].capacity1 = capacitySelect1.SelectedIndex + 1;
      }
      catch (Exception ex)
      { }

      if (capa[capacity1Num] == capa[powerNum])
      {
        flagX = 1;
      }
      else flagX = 0;

      if (capa[capacity2Num] == capa[powerNum])
      {
        flagY = 1;
      }
      else flagY = 0;
      /*
      if(capacitySelect1.SelectedIndex==0)
      {
        capacitySelect2.Items.Clear();
        capacitySelect2.Items.Add("---");//0
//        capacitySelect2.Items.Add(hp);//1
        capacitySelect2.Items.Add(attack);
        capacitySelect2.Items.Add(defence);//3
        capacitySelect2.Items.Add(spAtc);
        capacitySelect2.Items.Add(spDef);
        capacitySelect2.Items.Add(speed);
      }
      else if(capacitySelect1.SelectedIndex==1)
      {
        capacitySelect2.Items.Clear();
        capacitySelect2.Items.Add("---");//0
        capacitySelect2.Items.Add(hp);//1
//        capacitySelect2.Items.Add(attack);
        capacitySelect2.Items.Add(defence);//3
        capacitySelect2.Items.Add(spAtc);
        capacitySelect2.Items.Add(spDef);
        capacitySelect2.Items.Add(speed);
      }
      else if(capacitySelect1.SelectedIndex==2)
      {
        capacitySelect2.Items.Clear();
        capacitySelect2.Items.Add("---");//0
        capacitySelect2.Items.Add(hp);//1
        capacitySelect2.Items.Add(attack);
//        capacitySelect2.Items.Add(defence);//3
        capacitySelect2.Items.Add(spAtc);
        capacitySelect2.Items.Add(spDef);
        capacitySelect2.Items.Add(speed);
      }
      else if(capacitySelect1.SelectedIndex==3)
      {
        capacitySelect2.Items.Clear();
        capacitySelect2.Items.Add("---");//0
        capacitySelect2.Items.Add(hp);//1
        capacitySelect2.Items.Add(attack);
        capacitySelect2.Items.Add(defence);//3
//        capacitySelect2.Items.Add(spAtc);
        capacitySelect2.Items.Add(spDef);
        capacitySelect2.Items.Add(speed);
      }
      else if(capacitySelect1.SelectedIndex==4)
      {
        capacitySelect2.Items.Clear();
        capacitySelect2.Items.Add("---");//0
        capacitySelect2.Items.Add(hp);//1
        capacitySelect2.Items.Add(attack);
        capacitySelect2.Items.Add(defence);//3
        capacitySelect2.Items.Add(spAtc);
//        capacitySelect2.Items.Add(spDef);
        capacitySelect2.Items.Add(speed);
      }
      else if(capacitySelect1.SelectedIndex==5)
      {
        capacitySelect2.Items.Clear();
        capacitySelect2.Items.Add("---");//0
        capacitySelect2.Items.Add(hp);//1
        capacitySelect2.Items.Add(attack);
        capacitySelect2.Items.Add(defence);//3
        capacitySelect2.Items.Add(spAtc);
        capacitySelect2.Items.Add(spDef);
//        capacitySelect2.Items.Add(speed);
      }
       * */
    }

    //カウントする能力2
    private void capacitySelect2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

      capacity2Num = capacitySelect2.SelectedIndex;

      try
      {
        indexStore[0].capacity2 = capacity2Num;
      }
      catch (ArgumentOutOfRangeException ex)
      { }
      if ((string)capacitySelect2.SelectedItem == "---")
      {
        effortSelect2.IsEnabled = false;
        selectedeffort2 = 0;
      }
      else
      {
        effortSelect2.IsEnabled = true;
        //        selectedeffort2 = (int)effortSelect2.SelectedItem;
        //        count.Text = selectedeffort2.ToString();
      }

      if (capa[capacity1Num] == capa[powerNum])
      {
        flagX = 1;
      }
      else flagX = 0;

      if (capa[capacity2Num] == capa[powerNum])
      {
        flagY = 1;
      }
      else flagY = 0;

    }

    //努力値
    private void effortSelect1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //      flag2 += 1;
      //      if (flag2 != 0) itemSelected2.IsEnabled = true;

      if (effortSelect1.SelectedIndex == 0)
      {
        effortSelect2.Items.Clear();
        effortSelect2.Items.Add(1);
        effortSelect2.Items.Add(2);
        effortSelect2.SelectedIndex = 0;
        capacitySelect2.IsEnabled = true;
      }
      else if (effortSelect1.SelectedIndex == 1)
      {
        effortSelect2.Items.Clear();
        effortSelect2.Items.Add(1);
        effortSelect2.SelectedIndex = 0;
        capacitySelect2.IsEnabled = true;
      }
      else if (effortSelect1.SelectedIndex == 2)
      {
        capacitySelect2.IsEnabled = false;
        effortSelect2.IsEnabled = false;
        selectedeffort2 = 0;
      }

    }

    //リセットボタン
    private void Button_Tapped(object sender, TappedRoutedEventArgs e)
    {
      DefaultItem1();
    }

    //値の格納
    private void IndivisualDataStore(int a, int b)
    {
      if (a == 1) { indivisualData[pokenum].HP += b; }
      else if (a == 2) { indivisualData[pokenum].Attack += b; }
      else if (a == 3) { indivisualData[pokenum].Defence += b; }
      else if (a == 4) { indivisualData[pokenum].sAttack += b; }
      else if (a == 5) { indivisualData[pokenum].sDefence += b; }
      else if (a == 6) { indivisualData[pokenum].Speed += b; }
    }

    /*
    private void DataReflection(int a, int b)
    {
      int c, sum;
      if (a == 1) { c = int.Parse(H1.Text); c += b; H1.Text = c.ToString(); }
      else if (a == 2) { c = int.Parse(A1.Text); c += b; A1.Text = c.ToString(); }
      else if (a == 3) { c = int.Parse(D1.Text); c += b; D1.Text = c.ToString(); }
      else if (a == 4) { c = int.Parse(SA1.Text); c += b; SA1.Text = c.ToString(); }
      else if (a == 5) { c = int.Parse(SD1.Text); c += b; SD1.Text = c.ToString(); }
      else if (a == 6) { c = int.Parse(SP1.Text); c += b; SP1.Text = c.ToString(); }
    }
     * */
  }
}
