using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effort_Value_Counter
{
  sealed partial class App
  {




    private const string URI_PrivacyPolicy = "https://sites.google.com/site/123roborobo123/app/effortvaluescounter/support_privacypolicy";

    private const string SID_PrivacyPolicy = "privacyPolicy"; // リンクを識別する定数（他のリンクを追加した場合に必要になる）
    /*private const*/ string SLB_PrivacyPolicy = "プライバシー ポリシー"; // 設定チャームに表示する文字列

    private const string URI_AppExplanation = "https://sites.google.com/site/123roborobo123/app/effortvaluescounter";

    private const string SID_AppExplanation = "appExplanation"; // リンクを識別する定数（他のリンクを追加した場合に必要になる）
    /*private const*/ string SLB_AppExplanation = "アプリの説明"; // 設定チャームに表示する文字列

//    private const string SID_AppDetermination = "appDetermination"; // リンクを識別する定数（他のリンクを追加した場合に必要になる）
//    string SLB_AppDetermination = "アプリの使い方"; // 設定チャームに表示する文字列

    // 設定コントラクトのイベントハンドラーをセットする
    void SettingsLoad()
    {
      var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();

      /*
      string pp = resourceLoader.GetString("pp");
      string ata = resourceLoader.GetString("ata");
      string ade = resourceLoader.GetString("ade");

      SLB_PrivacyPolicy = pp;
      SLB_AppExplanation = ata;
      SLB_AppDetermination = ade;
      */

    //  Windows.UI.ApplicationSettings.SettingsPane.GetForCurrentView()
     //   .CommandsRequested
     //   += onCommandsRequested;
    }

    // 設定チャームに、カスタムメニューを追加する
/*
    void onCommandsRequested(
            Windows.UI.ApplicationSettings.SettingsPane settingsPane,
            Windows.UI.ApplicationSettings.SettingsPaneCommandsRequestedEventArgs eventArgs
          )
    {
      if (eventArgs.Request.ApplicationCommands.Count > 0)  // 追加済み（重複登録の防止）
        return;

      Windows.UI.Popups.UICommandInvokedHandler handler
        = new Windows.UI.Popups.UICommandInvokedHandler(onSettingsCommand);

      Windows.UI.ApplicationSettings.SettingsCommand generalCommand
        = new Windows.UI.ApplicationSettings.SettingsCommand(SID_PrivacyPolicy, SLB_PrivacyPolicy, handler);
      eventArgs.Request.ApplicationCommands.Add(generalCommand);

      Windows.UI.ApplicationSettings.SettingsCommand explainCommand
  = new Windows.UI.ApplicationSettings.SettingsCommand(SID_AppExplanation, SLB_AppExplanation, handler);
      eventArgs.Request.ApplicationCommands.Add(explainCommand);

      /*
      Windows.UI.ApplicationSettings.SettingsCommand determinationCommand
= new Windows.UI.ApplicationSettings.SettingsCommand(SID_AppDetermination, SLB_AppDetermination, handler);
      eventArgs.Request.ApplicationCommands.Add(determinationCommand);
      */
/*
    }
*/
 /*
    // 設定チャームからメニューが呼ばれた後の処理
    void onSettingsCommand(Windows.UI.Popups.IUICommand command)
    {
      Windows.UI.ApplicationSettings.SettingsCommand settingsCommand
        = (Windows.UI.ApplicationSettings.SettingsCommand)command;
      switch (settingsCommand.Id.ToString())
      {
          // プライバシーポリシーの呼び出し
        case SID_PrivacyPolicy:
          ShowPrivacyPolicy();
          break;
//使い方の呼び出し
        case SID_AppExplanation:
          ShowAppExplanation();
          break;
          /*
        case SID_AppDetermination:
          ShowCustomSettingFlyout();
          break;
           * */
        // 他のリンクを追加する場合に備えてswitch文にしてある
/*      }
    }
*/


    // プライバシーポリシーを表示する
    async void ShowPrivacyPolicy()
    {
      await Windows.System.Launcher.LaunchUriAsync(
              new Uri(URI_PrivacyPolicy),
              new Windows.System.LauncherOptions() // 画面の分割比を変更するオプション
              {
                DesiredRemainingView
                  = Windows.UI.ViewManagement.ViewSizePreference.UseMinimum
              }
            );
    }

    async void ShowAppExplanation()
    {
      await Windows.System.Launcher.LaunchUriAsync(
              new Uri(URI_AppExplanation),
              new Windows.System.LauncherOptions() // 画面の分割比を変更するオプション
              {
                DesiredRemainingView
                  = Windows.UI.ViewManagement.ViewSizePreference.UseMinimum
              }
            );
    }

    /*
    public void ShowCustomSettingFlyout()
    {
      AppExplain CustomSettingFlyout = new AppExplain();
      CustomSettingFlyout.Show();
    }
    */
  }
}
