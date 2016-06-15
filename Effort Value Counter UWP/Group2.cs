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
    //グル―p@宇２
    //カウント＋1
    private void count1Buttom_Tapped(object sender, TappedRoutedEventArgs e)
    {
      int x = 0;
      flag2 += 1;
      //      if (flag2 != 0) itemSelected2.IsEnabled = true;
      numberBlock.Text = effort4Result.ToString();

      if (itemSelected1.SelectedIndex == 1) Doping(1, 10, ref x);
      else if (itemSelected1.SelectedIndex == 2) Doping(2, 10, ref x);
      else if (itemSelected1.SelectedIndex == 3) Doping(3, 10, ref x);
      else if (itemSelected1.SelectedIndex == 4) Doping(4, 10, ref x);
      else if (itemSelected1.SelectedIndex == 5) Doping(5, 10, ref x);
      else if (itemSelected1.SelectedIndex == 6) Doping(6, 10, ref x);

      else if (itemSelected1.SelectedIndex == 7) AddEffect(1, 1, ref x);
      else if (itemSelected1.SelectedIndex == 8) AddEffect(2, 1, ref x);
      else if (itemSelected1.SelectedIndex == 9) AddEffect(3, 1, ref x);
      else if (itemSelected1.SelectedIndex == 10) AddEffect(4, 1, ref x);
      else if (itemSelected1.SelectedIndex == 11) AddEffect(5, 1, ref x);
      else if (itemSelected1.SelectedIndex == 12) AddEffect(6, 1, ref x);

      else if (itemSelected1.SelectedIndex == 13) Fruit(1, ref x);
      else if (itemSelected1.SelectedIndex == 14) Fruit(2, ref x);
      else if (itemSelected1.SelectedIndex == 15) Fruit(3, ref x);
      else if (itemSelected1.SelectedIndex == 16) Fruit(4, ref x);
      else if (itemSelected1.SelectedIndex == 17) Fruit(5, ref x);
      else if (itemSelected1.SelectedIndex == 18) Fruit(6, ref x);

      capacityBlock4.Text = capa[itemSelected1.SelectedIndex % 6];
      effortBlock4.Text = x.ToString();

      ResultOutput(2);

    }

    //カウント+10
    private void count10Buttom_Tapped(object sender, TappedRoutedEventArgs e)
    {
      flag2 += 10;
      //      if (flag2 != 0) itemSelected2.IsEnabled = true;
      int x = 0;

      numberBlock.Text = effort4Result.ToString();

      for (int c = 0; c < 10; c++)
      {
        if (itemSelected1.SelectedIndex == 1) Doping(1, 10, ref x);
        else if (itemSelected1.SelectedIndex == 2) Doping(2, 10, ref x);
        else if (itemSelected1.SelectedIndex == 3) Doping(3, 10, ref x);
        else if (itemSelected1.SelectedIndex == 4) Doping(4, 10, ref x);
        else if (itemSelected1.SelectedIndex == 5) Doping(5, 10, ref x);
        else if (itemSelected1.SelectedIndex == 6) Doping(6, 10, ref x);

        else if (itemSelected1.SelectedIndex == 7) AddEffect(1, 1, ref x);
        else if (itemSelected1.SelectedIndex == 8) AddEffect(2, 1, ref x);
        else if (itemSelected1.SelectedIndex == 9) AddEffect(3, 1, ref x);
        else if (itemSelected1.SelectedIndex == 10) AddEffect(4, 1, ref x);
        else if (itemSelected1.SelectedIndex == 11) AddEffect(5, 1, ref x);
        else if (itemSelected1.SelectedIndex == 12) AddEffect(6, 1, ref x);

        else if (itemSelected1.SelectedIndex == 13) Fruit(1, ref x);
        else if (itemSelected1.SelectedIndex == 14) Fruit(2, ref x);
        else if (itemSelected1.SelectedIndex == 15) Fruit(3, ref x);
        else if (itemSelected1.SelectedIndex == 16) Fruit(4, ref x);
        else if (itemSelected1.SelectedIndex == 17) Fruit(5, ref x);
        else if (itemSelected1.SelectedIndex == 18) Fruit(6, ref x);
      }
      capacityBlock4.Text = capa[itemSelected1.SelectedIndex % 6];
      effortBlock4.Text = x.ToString();

      ResultOutput(2);
    }

    //カウント-1
    private void count_1Buttom_Tapped(object sender, TappedRoutedEventArgs e)
    {
      flag2 += 1;

      effort4Result += 1;

      numberBlock.Text = effort4Result.ToString();


      ResultOutput(2);
    }




    //アイテムのセレクト
    private void itemSelected1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if ((string)itemSelected1.SelectedItem == "---")
      {
        count1Buttom.IsEnabled = false;
        count10Buttom.IsEnabled = false;
        //              count_1Buttom.IsEnabled = false;
      }
      else
      {
        count1Buttom.IsEnabled = true;
        count10Buttom.IsEnabled = true;
        //              count_1Buttom.IsEnabled = true;
      }
    }


    private void reset2_Tapped(object sender, TappedRoutedEventArgs e)
    {
      DefaultItem2();
    }


    //結果の出力
    private void ResultOutput(int block)
    {
      //      int sum = 0;

      h4.Text = indivisualData[pokenum].HP.ToString();
      a4.Text = indivisualData[pokenum].Attack.ToString();
      d4.Text = indivisualData[pokenum].Defence.ToString();
      sa4.Text = indivisualData[pokenum].sAttack.ToString();
      sd4.Text = indivisualData[pokenum].sDefence.ToString();
      sp4.Text = indivisualData[pokenum].Speed.ToString();

      sum = indivisualData[pokenum].HP + indivisualData[pokenum].Attack + indivisualData[pokenum].Defence + indivisualData[pokenum].sAttack
      + indivisualData[pokenum].sDefence + indivisualData[pokenum].Speed;
      sum4.Text = sum.ToString();

    }

    /*
    if(block==1)
    {
      H1.Text = indivisualData[pokenum].HP.ToString();
      A1.Text = indivisualData[pokenum].Attack.ToString();
      D1.Text = indivisualData[pokenum].Defence.ToString();
      SA1.Text = indivisualData[pokenum].sAttack.ToString();
      SD1.Text = indivisualData[pokenum].sDefence.ToString();
      SP1.Text = indivisualData[pokenum].Speed.ToString();
      ResultSum();
    }
    else if(block==2)
    {
      h2.Text = indivisualData[pokenum].HP.ToString();
      a2.Text = indivisualData[pokenum].Attack.ToString();
      d2.Text = indivisualData[pokenum].Defence.ToString();
      sa2.Text = indivisualData[pokenum].sAttack.ToString();
      sd2.Text = indivisualData[pokenum].sDefence.ToString();
      sp2.Text = indivisualData[pokenum].Speed.ToString();
      ResultSum();
    }
    else if(block==3)
    {
      h3.Text = indivisualData[pokenum].HP.ToString();
      a3.Text = indivisualData[pokenum].Attack.ToString();
      d3.Text = indivisualData[pokenum].Defence.ToString();
      sa3.Text = indivisualData[pokenum].sAttack.ToString();
      sd3.Text = indivisualData[pokenum].sDefence.ToString();
      sp3.Text = indivisualData[pokenum].Speed.ToString();
    }
     * */

    /*
    private void ResultSum()
    {
      int a=0, b=0, c=0, d=0, e=0, f=0;
      a+= int.Parse(H1.Text) + int.Parse(h2.Text) + int.Parse(h3.Text);
      h4.Text = a.ToString();
      b += int.Parse(D1.Text) + int.Parse(d2.Text) + int.Parse(d3.Text);
      d4.Text = a.ToString();
    }
     * */

    /*
    private void itemSelected2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if ((string)itemSelected2.SelectedItem == "---")
      {

        itemSelected1.IsEnabled = true;
        itemSelected2.IsEnabled = false;
        count_1Buttom.IsEnabled = false;
//        count1Buttom.IsEnabled = true;
//        count10Buttom.IsEnabled = true;
//        selectedeffort2 = 0;
      }
      else
      {
        itemSelected1.SelectedIndex = 0;
        itemSelected1.IsEnabled = false;
        count_1Buttom.IsEnabled = true;
        //        selectedeffort2 = (int)effortSelect2.SelectedItem;
        //        count.Text = selectedeffort2.ToString();
      }
    }
     * */
  }
}
