using System;
using System.Collections.Generic;
using System.Text;

namespace Dsms.Model
{
    [Serializable]
    public class L1_SOSAModel
    {
        /// <summary>
        /// ログNO
        /// </summary>
        public int NO_LOG { get; set; }
        /// <summary>
        /// ユーザコード
        /// </summary>
        public string CD_USER { get; set; }
        /// <summary>
        /// セッションID
        /// </summary>
        public string ID_SESSION { get; set; }
        /// <summary>
        /// プログラムID
        /// </summary>
        public string ID_PROGRAM { get; set; }
        /// <summary>
        /// 画面ID
        /// </summary>
        public string ID_GAMEN { get; set; }
        /// <summary>
        /// コントローラー
        /// </summary>
        public string AN_CONTROLLER { get; set; }
        /// <summary>
        /// アクション
        /// </summary>
        public string AN_ACTION { get; set; }
        /// <summary>
        /// 処理日時
        /// </summary>
        public DateTime? TM_SHORI { get; set; }
        /// <summary>
        /// 端末IPアドレス
        /// </summary>
        public string AN_IP_ADDRESS { get; set; }
    }
}
