using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frap3Core.BCore
{
    /// <summary>
    /// DBMS識別
    /// </summary>
    /// <remarks>
    /// Frap3で扱うDBMSを識別するための列挙型
    ///	<para>作成年月日 2010/02/02</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    /// </remarks>
    public enum DBMS
    {
        /// <summary>
        /// SQLServer
        /// </summary>
        SQLServer = 1,
        /// <summary>
        /// Oralce(管理対象ドライバ)
        /// </summary>
        Oracle = 2,
        /// <summary>
        /// Oralce(管理対象外ドライバ)
        /// </summary>
        Oracle2 = 3,
        /// <summary>
        /// PostgreSQL
        /// </summary>
        PostgreSQL = 4,
        /// <summary>
        /// MySQL
        /// </summary>
        MySQL = 5
    }

    /// <summary>
    /// データ型
    /// </summary>
    /// <remarks>
    /// Frap3で扱うデータベースのデータ型を識別するための列挙型
    ///	<para>作成年月日 2010/02/02</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日　2010/02/05</para>
    ///	<para>修正者 (株)フューチャーイン 横井 忠司</para>
    ///	<para>修正内容</para>
    ///	<para>修正年月日　2014/10/21</para>
    ///	<para>修正者 (株)フューチャーイン 平崎 裕紀</para>
    ///	<para>修正内容 BLOB,CLOB,NCLOBの追加</para>
    ///	<para>修正年月日　2015/01/15</para>
    ///	<para>修正者 (株)フューチャーイン 三厨 朱根</para>
    ///	<para>修正内容 DATEの追加</para>
    /// </remarks>
    public enum Frap3DBType
    {
        /// <summary>
        /// 固定長文字列型（2000バイト）
        /// </summary>
        Char = 1,
        /// <summary>
        /// 文字列型（UNICODE：4000バイトまで）
        /// </summary>
        NVarChar = 2,
        /// <summary>
        /// 文字列型（4000バイトまで）
        /// </summary>
        VarChar = 3,
        /// <summary>
        /// 16ビット符号付き整数
        /// </summary>
        SmallInt = 4,
        /// <summary>
        /// 32ビット符号付き整数型
        /// </summary>
        Int = 5,
        /// <summary>
        /// 単精度浮動小数型
        /// </summary>
        Float = 6,
        /// <summary>
        /// 倍精度浮動小数型
        /// </summary>
        Double = 7,
        /// <summary>
        /// １バイト符号なし整数
        /// </summary>
        Byte = 8,
        /// <summary>
        /// バイナリ型（2000バイトまで）
        /// </summary>
        Raw = 9,
        /// <summary>
        /// バイナリ型（2Gバイトまで）
        /// </summary>
        LongRaw = 10,
        /// <summary>
        /// 文字列型（2Gバイトまで）
        /// </summary>
        LongVarChar = 11,
        /// <summary>
        /// 数値型
        /// </summary>
        Decimal = 12,
        /// <summary>
        /// 1ビット型
        /// </summary>
        Bit = 13,
        /// <summary>
        /// 日付型
        /// </summary>
        DateTime = 14,
        /// <summary>
        /// バイナリデータを格納(Oracle専用)
        /// </summary>
        BLOB = 15,
        /// <summary>
        /// 文字データを格納(Oracle専用)
        /// </summary>
        CLOB = 16,
        /// <summary>
        /// 各国語キャラクタ・セットの文字データを格納(Oracle専用)
        /// </summary>
        NCLOB = 17,
        /// 日付型
        /// </summary>
        Date = 18
    }

    /// <summary>
    /// ログ種別
    /// </summary>
    /// <remarks>
    /// Frap3で扱うログの種類を識別するための列挙型
    ///	<para>作成年月日 2012/03/25</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    /// </remarks>
    public enum LogShubetsu
    {
        /// <summary>
        /// 操作ログ
        /// </summary>
        SosaLog = 0,
        /// <summary>
        /// 拡張用1
        /// </summary>
        SonotaLog1 = 1,
        /// <summary>
        /// 拡張用2
        /// </summary>
        SonotaLog2 = 2,
        /// <summary>
        /// 拡張用3
        /// </summary>
        SonotaLog3 = 3,
        /// <summary>
        /// 拡張用4
        /// </summary>
        SonotaLog4 = 4,
        /// <summary>
        /// 拡張用5
        /// </summary>
        SonotaLog5 = 5,
        /// <summary>
        /// 拡張用6
        /// </summary>
        SonotaLog6 = 6,
        /// <summary>
        /// 拡張用7
        /// </summary>
        SonotaLog7 = 7,
        /// <summary>
        /// Sqlログ(拡張用)
        /// </summary>
        SqlLog = 8,
        /// <summary>
        /// エラーログ
        /// </summary>
        ErrorLog = 9
    }

    ///	<summary>
    ///	定数クラス
    ///	</summary>
    ///	<remarks>
    ///	Frap3のビジネス、及びデータアクセス関連クラスで共通して使用する定数などを定義するクラス
    ///	<para>作成年月日 2010/02/02</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class Constants
    {
        /// <summary>
        /// 接続情報のXMLファイル名
        /// </summary>
        ///	<remarks>
        /// 接続情報のXMLファイル名
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        internal const string FILENAME_CONNECTIONINFO_XML = "connectInfo.xml";
    }
}
