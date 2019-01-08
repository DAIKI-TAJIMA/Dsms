using System;

using Dsms.Resource;

namespace Dsms.Model
{
    [Serializable]
    public class M_USERModel
    {
        /// <summary>
        /// ユーザコード
        /// </summary>
        public string CD_USER { get; set; }
        /// <summary>
        /// ユーザ名
        /// </summary>
        public string NM_USER { get; set; }
        /// <summary>
        /// 権限
        /// </summary>
        public int? AN_KENGEN { get; set; }
        /// <summary>
        /// 自治体コード
        /// </summary>
        public string CD_JICHITAI { get; set; }
        /// <summary>
        /// 自治体名
        /// </summary>
        public string NM_JICHITAI { get; set; }
        /// <summary>
        /// パスワード
        /// </summary>
        public string AN_PASSWORD { get; set; }
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string AN_MAIL_ADDRESS { get; set; }
        /// <summary>
        /// 削除フラグ
        /// </summary>
        public bool FL_DELETE { get; set; }
        /// <summary>
        /// 作成ユーザコード
        /// </summary>
        public string CD_SAKUSEI_USER { get; set; }
        /// <summary>
        /// 作成セッションID
        /// </summary>
        public string ID_SAKUSEI_SESSION { get; set; }
        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime? TM_SAKUSEI { get; set; }
        /// <summary>
        /// 最終更新ユーザコード
        /// </summary>
        public string CD_KOSHIN_USER { get; set; }
        /// <summary>
        /// 最終更新セッションID
        /// </summary>
        public string ID_KOSHIN_SESSION { get; set; }
        /// <summary>
        /// 最終更新日時
        /// </summary>
        public DateTime? TM_KOSHIN { get; set; }
    }
}
