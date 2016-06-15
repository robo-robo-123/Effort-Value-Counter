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
    //グループ3
    //サンドバッグのセレクト
    private void bagSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if ((string)bagSelected.SelectedItem == "---")
      {
        count1Buttom2.IsEnabled = false;
      }
      else
      {
        count1Buttom2.IsEnabled = true;
      }
    }
    //スパトレのセレクト
    private void trainingSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if ((string)trainingSelected.SelectedItem == "---")
      {
        count1Buttom3.IsEnabled = false;
      }
      else
      {
        count1Buttom3.IsEnabled = true;
      }
    }

    //サンドバッグ
    private void count1Buttom2_Tapped(object sender, TappedRoutedEventArgs e)
    {
      int str = 0;

      if (bagSelected.SelectedIndex == 1) AddEffect(1, 1, ref str);
      else if (bagSelected.SelectedIndex == 2) AddEffect(2, 1, ref str);
      else if (bagSelected.SelectedIndex == 3) AddEffect(3, 1, ref str);
      else if (bagSelected.SelectedIndex == 4) AddEffect(4, 1, ref str);
      else if (bagSelected.SelectedIndex == 5) AddEffect(5, 1, ref str);
      else if (bagSelected.SelectedIndex == 6) AddEffect(6, 1, ref str);

      else if (bagSelected.SelectedIndex == 7) AddEffect(1, 4, ref str);
      else if (bagSelected.SelectedIndex == 8) AddEffect(2, 4, ref str);
      else if (bagSelected.SelectedIndex == 9) AddEffect(3, 4, ref str);
      else if (bagSelected.SelectedIndex == 10) AddEffect(4, 4, ref str);
      else if (bagSelected.SelectedIndex == 11) AddEffect(5, 4, ref str);
      else if (bagSelected.SelectedIndex == 12) AddEffect(6, 4, ref str);

      else if (bagSelected.SelectedIndex == 13) AddEffect(1, 12, ref str);
      else if (bagSelected.SelectedIndex == 14) AddEffect(2, 12, ref str);
      else if (bagSelected.SelectedIndex == 15) AddEffect(3, 12, ref str);
      else if (bagSelected.SelectedIndex == 16) AddEffect(4, 12, ref str);
      else if (bagSelected.SelectedIndex == 17) AddEffect(5, 12, ref str);
      else if (bagSelected.SelectedIndex == 18) AddEffect(6, 12, ref str);

      else if (bagSelected.SelectedIndex == 19)
      {


        DefaultGrid();
        DefaultItem0();
        DefaultItem1();
        DefaultItem2();
        DefaultItem3();

        DataReset();

      }

      capacityBlock5.Text = capa[bagSelected.SelectedIndex % 6];
      effortBlock5.Text = str.ToString();

      ResultOutput(2);
    }
    //スパトレ
    private void count1Buttom3_Tapped(object sender, TappedRoutedEventArgs e)
    {
      int str = 0;
      if (trainingSelected.SelectedIndex == 1) AddEffect(1, 4, ref str);
      else if (trainingSelected.SelectedIndex == 2) AddEffect(2, 4, ref str);
      else if (trainingSelected.SelectedIndex == 3) AddEffect(3, 4, ref str);
      else if (trainingSelected.SelectedIndex == 4) AddEffect(4, 4, ref str);
      else if (trainingSelected.SelectedIndex == 5) AddEffect(5, 4, ref str);
      else if (trainingSelected.SelectedIndex == 6) AddEffect(6, 4, ref str);
      else if (trainingSelected.SelectedIndex == 7) AddEffect(1, 8, ref str);
      else if (trainingSelected.SelectedIndex == 8) AddEffect(2, 8, ref str);
      else if (trainingSelected.SelectedIndex == 9) AddEffect(3, 8, ref str);
      else if (trainingSelected.SelectedIndex == 10) AddEffect(4, 8, ref str);
      else if (trainingSelected.SelectedIndex == 11) AddEffect(5, 8, ref str);
      else if (trainingSelected.SelectedIndex == 12) AddEffect(6, 8, ref str);
      else if (trainingSelected.SelectedIndex == 13) AddEffect(1, 12, ref str);
      else if (trainingSelected.SelectedIndex == 14) AddEffect(2, 12, ref str);
      else if (trainingSelected.SelectedIndex == 15) AddEffect(3, 12, ref str);
      else if (trainingSelected.SelectedIndex == 16) AddEffect(4, 12, ref str);
      else if (trainingSelected.SelectedIndex == 17) AddEffect(5, 12, ref str);
      else if (trainingSelected.SelectedIndex == 18) AddEffect(6, 12, ref str);


      capacityBlock6.Text = capa[trainingSelected.SelectedIndex % 6];
      effortBlock6.Text = str.ToString();

      ResultOutput(2);
    }
  }
}
