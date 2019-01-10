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
    public class CommonDataAccess : ProjectDataAccessBase
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
        public CommonDataAccess(AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(helper, bcp)
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
        public CommonDataAccess(DbConnection con, AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(con, helper, bcp)
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
        public CommonDataAccess(DbConnection con, DbTransaction txn, AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(con, txn, helper, bcp)
        {
        }

        #endregion

        #region メソッド

        #region 操作ログ登録

        ///	<summary>
        ///	操作ログ登録
        ///	</summary>
        ///	<remarks>
        ///	操作ログ登録
        ///	<para>作成年月日 2017/11/24</para>
        ///	<para>作成者 (株)フューチャーイン 岡田 健太郎</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="model">操作ログモデル</param>
        /// <returns>件数</returns>
        public int InsertL1Sosa(L1_SOSAModel model)
        {
            // コマンド実行
            using (DbCommand command = this.CreateInsertL1SosaCommand(model))
            {
                return command.ExecuteNonQuery();
            }
        }

        ///	<summary>
        ///	操作ログ登録コマンド
        /// </summary>
        ///	<remarks>
        ///	操作ログ登録コマンド
        ///	<para>作成年月日 2017/11/24</para>
        ///	<para>作成者 (株)フューチャーイン 岡田 健太郎</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="model">操作ログモデル</param>
        /// <returns>コマンド</returns>
        private DbCommand CreateInsertL1SosaCommand(L1_SOSAModel model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" INSERT  ");
            sql.AppendLine(" INTO L1_SOSA(  ");
            //sql.AppendLine("   NO_LOG ");
            sql.AppendLine("   CD_USER ");
            sql.AppendLine("   , ID_SESSION ");
            sql.AppendLine("   , ID_PROGRAM ");
            sql.AppendLine("   , ID_GAMEN ");
            sql.AppendLine("   , AN_CONTROLLER ");
            sql.AppendLine("   , AN_ACTION ");
            sql.AppendLine("   , TM_SHORI ");
            sql.AppendLine("   , AN_IP_ADDRESS ");
            sql.AppendLine(" )  ");
            sql.AppendLine(" VALUES (  ");
            //sql.AppendLine("   @NO_LOG ");
            sql.AppendLine("   @CD_USER ");
            sql.AppendLine("   , @ID_SESSION ");
            sql.AppendLine("   , @ID_PROGRAM ");
            sql.AppendLine("   , @ID_GAMEN ");
            sql.AppendLine("   , @AN_CONTROLLER ");
            sql.AppendLine("   , @AN_ACTION ");
            sql.AppendLine("   , CURRENT_TIMESTAMP(3) ");
            sql.AppendLine("   , @AN_IP_ADDRESS ");
            sql.AppendLine(" )  ");

            // コマンドの作成
            DbCommand cmd = this.CreateCommand(sql.ToString());

            // ユーザコード
            cmd.Parameters.Add(this.CreateParameter("CD_USER", Frap3DBType.VarChar, ParameterDirection.Input, model.CD_USER));
            // セッションID
            cmd.Parameters.Add(this.CreateParameter("ID_SESSION", Frap3DBType.VarChar, ParameterDirection.Input, model.ID_SESSION));
            // プログラムID
            cmd.Parameters.Add(this.CreateParameter("ID_PROGRAM", Frap3DBType.Char, ParameterDirection.Input, model.ID_PROGRAM));
            // 画面ID
            cmd.Parameters.Add(this.CreateParameter("ID_GAMEN", Frap3DBType.Char, ParameterDirection.Input, model.ID_GAMEN));
            // コントローラー
            cmd.Parameters.Add(this.CreateParameter("AN_CONTROLLER", Frap3DBType.Char, ParameterDirection.Input, model.AN_CONTROLLER));
            // アクション
            cmd.Parameters.Add(this.CreateParameter("AN_ACTION", Frap3DBType.VarChar, ParameterDirection.Input, model.AN_ACTION));
            // 端末IPアドレス
            cmd.Parameters.Add(this.CreateParameter("AN_IP_ADDRESS", Frap3DBType.VarChar, ParameterDirection.Input, model.AN_IP_ADDRESS));

            return cmd;
        }

        #endregion

        #endregion
    }
}
