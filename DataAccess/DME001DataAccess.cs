using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;

using Frap3Core.BCore;

using Dsms.Model;
using Dsms.Resource;

namespace Dsms.DataAccess
{
    public class DME001DataAccess : ProjectDataAccessBase
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public DME001DataAccess(AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(helper, bcp)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="con">Connection</param>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public DME001DataAccess(DbConnection con, AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(con, helper, bcp)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="con">コネクション</param>
        /// <param name="txn">トランザクション</param>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public DME001DataAccess(DbConnection con, DbTransaction txn, AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(con, txn, helper, bcp)
        {
        }

        #endregion

        #region メソッド

        #region ユーザマスタ取得

        ///	<summary>
        ///	ユーザマスタ取得
        ///	</summary>
        ///	<remarks>
        ///	ユーザマスタ取得
        ///	<para>作成年月日 2019/01/08</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="cdUser">ユーザコード</param>
        /// <param name="anPassword">パスワード</param>
        /// <returns>オーダデータ</returns>
        public M_USERModel GetMUser(string cdUser, string anPassword)
        {
            // コマンド実行
            using (DbCommand command = this.CreateGetMUserCommand(cdUser, anPassword))
            {
                using (DbDataReader reader = this.ExecuteReader(command))
                {

                    // 検索結果
                    M_USERModel model = null;

                    if (reader.HasRows)
                    {
                        // 結果を読み込む
                        reader.Read();
                        model = this.CreateModelFromDataReader<M_USERModel>(reader);
                    }

                    // 戻り値セット
                    return model;

                }
            }
        }

        ///	<summary>
        ///	ユーザマスタ取得コマンド
        /// </summary>
        ///	<remarks>
        ///	ユーザマスタ取得コマンド
        ///	<para>作成年月日 2019/01/08</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="cdUser">ユーザコード</param>
        /// <param name="anPassword">パスワード</param>
        /// <returns>コマンド</returns>
        private DbCommand CreateGetMUserCommand(string cdUser, string anPassword)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" SELECT ");
            sql.AppendLine("   M_USER.CD_USER ");
            sql.AppendLine("   , M_USER.NM_USER ");
            sql.AppendLine("   , M_USER.AN_KENGEN ");
            sql.AppendLine("   , M_USER.CD_JICHITAI ");
            sql.AppendLine("   , M_JICHITAI.NM_JICHITAI ");
            sql.AppendLine("   , M_USER.AN_PASSWORD ");
            sql.AppendLine("   , M_USER.AN_MAIL_ADDRESS ");
            sql.AppendLine("   , M_USER.FL_DELETE ");
            sql.AppendLine("   , M_USER.CD_SAKUSEI_USER ");
            sql.AppendLine("   , M_USER.ID_SAKUSEI_SESSION ");
            sql.AppendLine("   , M_USER.TM_SAKUSEI ");
            sql.AppendLine("   , M_USER.CD_KOSHIN_USER ");
            sql.AppendLine("   , M_USER.ID_KOSHIN_SESSION ");
            sql.AppendLine("   , M_USER.TM_KOSHIN ");
            sql.AppendLine(" FROM ");
            sql.AppendLine("   M_USER ");
            sql.AppendLine("   LEFT JOIN M_JICHITAI ");
            sql.AppendLine("     ON M_USER.CD_JICHITAI = M_JICHITAI.CD_JICHITAI ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("   M_USER.CD_USER = @CD_USER ");
            sql.AppendLine("   AND M_USER.AN_PASSWORD = @AN_PASSWORD ");
            sql.AppendLine("   AND M_USER.FL_DELETE = @FL_DELETE ");

            // コマンドの作成
            DbCommand cmd = this.CreateCommand(sql.ToString());

            // ユーザコード
            cmd.Parameters.Add(this.CreateParameter("CD_USER", Frap3DBType.VarChar, ParameterDirection.Input, cdUser));
            // パスワード
            cmd.Parameters.Add(this.CreateParameter("AN_PASSWORD", Frap3DBType.VarChar, ParameterDirection.Input, anPassword));
            // 削除フラグ
            cmd.Parameters.Add(this.CreateParameter("FL_DELETE", Frap3DBType.Bit, ParameterDirection.Input, EnumCodeValueAttribute.GetCodeValue(Enums.Code_論理値.False)));

            return cmd;
        }

        #endregion

        #endregion
    }
}
