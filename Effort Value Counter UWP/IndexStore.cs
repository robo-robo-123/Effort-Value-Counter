using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effort_Value_Counter
{
  public class IndexStore
  {
    public int times { get; set; }
    public int capacity1 { get; set; }
    public int capacity2 { get; set; }
    public int effort1 { get; set; }
    public int effort2 { get; set; }
    public int pkrsf { get; set; }//フラグの数字:0がオフ、1がオン
    public int gpsf { get; set; }//flag
    public int power { get; set; }
    public int effortResult1 { get; set; }
    public int effortResult2 { get; set; }
    public int effortResult3 { get; set; } 
  }

  public class IndivisualDatas
  {
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int sAttack { get; set; }
    public int sDefence { get; set; }
    public int Speed { get; set; }
  }

}
