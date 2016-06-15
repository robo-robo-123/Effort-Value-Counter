using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effort_Value_Counter
{
  sealed partial class ItemDetailPage1
  {
    private void DataCompare(ref int a, int b, int c)
    {//aは元の数字、bは比較用の数字  cは格納する値
      //1dannkai252wokositenaika
      int dif = 0;
      if (sum + c <= 510)
      {
        if (b >= 252) a = 0;
        else if (b >= (252 - c) + 1 && b < 252)
        {
          dif = 252 - b;
          a = dif;
        }
        else a = c;
      }
      //2dannkai-510wokositenaika

    //  else if(sum +c > 510)


      else
      {
        if (b == 252)
        {
          a = 0;
        }
        else if (sum >= 510 - c + 1 && sum < 510)
        {
          dif = 510 - sum;
          a = dif;
        }
        else
        {
          a = 0;
          //          SwitchCntroll(0);
        }

      }
    }

    //ドーピング系専用-tabunnii?
    private void Doping(int a, int b, ref int x)
    {
      int dif = 0;
      //      capacityBlock4.Text = capa[a];
      if (a == 1)
      {
        if (indivisualData[pokenum].HP >= 100) x = numberSum;
        else if (indivisualData[pokenum].HP >= 91 && indivisualData[pokenum].HP < 100)
        {
          dif = 100 - indivisualData[pokenum].HP;
          indivisualData[pokenum].HP += dif;
          numberSum += dif;
          x = numberSum;
        }
        else
        {
          DataCompare(ref b, indivisualData[pokenum].HP, b);
          numberSum += b;
          indivisualData[pokenum].HP += b;
          x = numberSum;
        }
      }
      else if (a == 2)
      {
        if (indivisualData[pokenum].Attack >= 100) x = numberSum;
        else if (indivisualData[pokenum].Attack >= 91 && indivisualData[pokenum].Attack < 100)
        {
          dif = 100 - indivisualData[pokenum].Attack;
          indivisualData[pokenum].Attack += dif;
          numberSum += dif;
          x = numberSum;
        }
        else
        {
          DataCompare(ref b, indivisualData[pokenum].Attack, b);
          numberSum += b;
          indivisualData[pokenum].Attack += b;
          x = numberSum;
        }
      }
      else if (a == 3)
      {
        if (indivisualData[pokenum].Defence >= 100) x = numberSum;
        else if (indivisualData[pokenum].Defence >= 91 && indivisualData[pokenum].Defence < 100)
        {
          dif = 100 - indivisualData[pokenum].Defence;
          indivisualData[pokenum].Defence += dif;
          numberSum += dif;
          x = numberSum;
        }
        else
        {
          DataCompare(ref b, indivisualData[pokenum].Defence, b);
          numberSum += b;
          indivisualData[pokenum].Defence += b;
          x = numberSum;
        }
      }
      else if (a == 4)
      {
        if (indivisualData[pokenum].sAttack >= 100) x = numberSum;
        else if (indivisualData[pokenum].sAttack >= 91 && indivisualData[pokenum].sAttack < 100)
        {
          dif = 100 - indivisualData[pokenum].sAttack;
          indivisualData[pokenum].sAttack += dif;
          numberSum += dif;
          x = numberSum;
        }
        else
        {
          DataCompare(ref b, indivisualData[pokenum].sAttack, b);
          numberSum += b;
          indivisualData[pokenum].sAttack += b;
          x = numberSum;
        }
      }
      else if (a == 5)
      {
        if (indivisualData[pokenum].sDefence >= 100) x = numberSum;
        else if (indivisualData[pokenum].sDefence >= 91 && indivisualData[pokenum].sDefence < 100)
        {
          dif = 100 - indivisualData[pokenum].sDefence;
          indivisualData[pokenum].sDefence += dif;
          numberSum += dif;
          x = numberSum;
        }
        else
        {
          DataCompare(ref b, indivisualData[pokenum].sDefence, b);
          numberSum += b;
          indivisualData[pokenum].sDefence += b;
          x = numberSum;
        }
      }
      else if (a == 6)
      {
        if (indivisualData[pokenum].Speed >= 100) x = numberSum;
        else if (indivisualData[pokenum].Speed >= 91 && indivisualData[pokenum].Speed < 100)
        {
          dif = 100 - indivisualData[pokenum].Speed;
          indivisualData[pokenum].Speed += dif;
          numberSum += dif;
          x = numberSum;
        }
        else
        {
          DataCompare(ref b, indivisualData[pokenum].Speed, b);
          numberSum += b;
          indivisualData[pokenum].Speed += b;
          x = numberSum;
        }
      }

      //      effortBlock4.Text = numberSum.ToString();
      //      IndivisualDataStore(a, numberSum);
    }

    //グループ2と3の共存-if文で、合計が510を超えそうであればそれを越さないようにする
    private void AddEffect(int a, int b, ref int c)
    {

      if (a == 1)
      {
        DataCompare(ref b, indivisualData[pokenum].HP, b);
        numberSum += b;
        indivisualData[pokenum].HP += b;
        c = numberSum;
        //        str = indivisualData[pokenum].HP.ToString();
      }
      else if (a == 2)
      {

        DataCompare(ref b, indivisualData[pokenum].Attack, b);
        numberSum += b;
        indivisualData[pokenum].Attack += b;
        c = numberSum;
      }
      else if (a == 3)
      {
        DataCompare(ref b, indivisualData[pokenum].Defence, b);
        numberSum += b;
        indivisualData[pokenum].Defence += b;
        c = numberSum;
        //        str = indivisualData[pokenum].Defence.ToString();
      }
      else if (a == 4)
      {
        DataCompare(ref b, indivisualData[pokenum].sAttack, b);
        numberSum += b;
        indivisualData[pokenum].sAttack += b;
        c = numberSum;
      }
      else if (a == 5)
      {
        DataCompare(ref b, indivisualData[pokenum].sDefence, b);
        numberSum += b;
        indivisualData[pokenum].sDefence += b;
        c = numberSum;
      }
      else if (a == 6)
      {
        // if()
        DataCompare(ref b, indivisualData[pokenum].Speed, b);
        numberSum += b;
        indivisualData[pokenum].Speed += b;
        c = numberSum;
      }
    }

    //気のみ専用--if文で0を切らないように
    private void Fruit(int a, ref int x)
    {
      capacityBlock4.Text = capa[a];
      if (a == 1)
      {
        numberSum -= 10;
        indivisualData[pokenum].HP -= 10;
        x = indivisualData[pokenum].HP;
      }
      else if (a == 2)
      {
        numberSum -= 10;
        indivisualData[pokenum].Attack -= 10;
        x = indivisualData[pokenum].Attack;
      }
      else if (a == 3)
      {
        numberSum -= 10;
        indivisualData[pokenum].Defence -= 10;
        x = indivisualData[pokenum].Attack;
        //        str = indivisualData[pokenum].Defence.ToString();
      }
      else if (a == 4)
      {
        numberSum -= 10;
        indivisualData[pokenum].sAttack -= 10;
        x = indivisualData[pokenum].Attack;
      }
      else if (a == 5)
      {
        numberSum -= 10;
        indivisualData[pokenum].sDefence -= 10;
        x = indivisualData[pokenum].Attack;
      }
      else if (a == 6)
      {
        // if()
        numberSum -= 10;
        indivisualData[pokenum].Speed -= 10;
        x = indivisualData[pokenum].Attack;
      }

    }
  }
}
