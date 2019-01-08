using System;
using System.Collections.Generic;
using System.Text;

namespace Dsms.Resource
{
    ///	<summary>
    ///	コード一覧
    ///	</summary>
    ///	<remarks>
    ///	コード一覧
    ///	<para>作成年月日 2017/11/21</para>
    ///	<para>作成者 (株)フューチャーイン 田島 大輝</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class Enums
    {
        /// <summary>
        /// 論理値
        /// </summary>
        public enum Code_論理値
        {
            /// <summary>
            /// False
            /// </summary>
            [EnumCodeValueAttribute("0")]
            [EnumTextAttribute("False")]
            False = 0,
            /// <summary>
            /// True
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("True")]
            True = 1
        }

        /// <summary>
        /// 緊急時動作
        /// </summary>
        public enum Code_緊急時動作
        {
            /// <summary>
            /// 表示しない
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("表示しない")]
            表示しない = 1,
            /// <summary>
            /// L字表示
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("L字表示")]
            L字表示 = 2,
            /// <summary>
            /// フル表示
            /// </summary>
            [EnumCodeValueAttribute("3")]
            [EnumTextAttribute("フル表示")]
            フル表示 = 3
        }

        /// <summary>
        /// コンテンツ種類
        /// </summary>
        public enum Code_コンテンツ種類
        {
            /// <summary>
            /// 本日の天気予報
            /// </summary>
            [EnumCodeValueAttribute("101")]
            [EnumTextAttribute("本日の天気予報")]
            本日の天気予報 = 101,
            /// <summary>
            /// 週間天気予報
            /// </summary>
            [EnumCodeValueAttribute("102")]
            [EnumTextAttribute("週間天気予報")]
            週間天気予報 = 102,
            /// <summary>
            /// デジタルフォトニュース
            /// </summary>
            [EnumCodeValueAttribute("103")]
            [EnumTextAttribute("デジタルフォトニュース")]
            デジタルフォトニュース = 103,
            /// <summary>
            /// 交通情報
            /// </summary>
            [EnumCodeValueAttribute("104")]
            [EnumTextAttribute("交通情報")]
            交通情報 = 104,
            /// <summary>
            /// 災害情報
            /// </summary>
            [EnumCodeValueAttribute("105")]
            [EnumTextAttribute("災害情報")]
            災害情報 = 105,
            /// <summary>
            /// エリアメール（一般）
            /// </summary>
            [EnumCodeValueAttribute("106")]
            [EnumTextAttribute("エリアメール（一般）")]
            エリアメール_一般 = 106,
            /// <summary>
            /// エリアメール（緊急）
            /// </summary>
            [EnumCodeValueAttribute("107")]
            [EnumTextAttribute("エリアメール（緊急）")]
            エリアメール_緊急 = 107,
            /// <summary>
            /// Facebook
            /// </summary>
            [EnumCodeValueAttribute("108")]
            [EnumTextAttribute("Facebook")]
            Facebook = 108,
            /// <summary>
            /// Twitter
            /// </summary>
            [EnumCodeValueAttribute("109")]
            [EnumTextAttribute("Twitter")]
            Twitter = 109,
            /// <summary>
            /// 行政情報（緊急）
            /// </summary>
            [EnumCodeValueAttribute("110")]
            [EnumTextAttribute("行政情報（緊急）")]
            行政情報_緊急 = 110,
            /// <summary>
            /// 行政情報
            /// </summary>
            [EnumCodeValueAttribute("201")]
            [EnumTextAttribute("行政情報")]
            行政情報 = 201,
            /// <summary>
            /// 広告
            /// </summary>
            [EnumCodeValueAttribute("202")]
            [EnumTextAttribute("広告")]
            広告 = 202
        }

        /// <summary>
        /// ユーザ権限
        /// </summary>
        public enum Code_ユーザ権限
        {
            /// <summary>
            /// 不明
            /// </summary>
            [EnumCodeValueAttribute("0")]
            [EnumTextAttribute("不明")]
            NONE = 0,
            /// <summary>
            /// 管理者
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("管理者")]
            管理者 = 1,
            /// <summary>
            /// 一般
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("一般")]
            一般 = 2
        }

        /// <summary>
        /// 解像度
        /// </summary>
        public enum Code_解像度
        {
            /// <summary>
            /// 1024×576
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("1024×576")]
            W1024H576 = 1,
            /// <summary>
            /// 1136×640
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("1136×640")]
            W1136H640 = 2,
            /// <summary>
            /// 1280×720
            /// </summary>
            [EnumCodeValueAttribute("3")]
            [EnumTextAttribute("1280×720")]
            W1280H720 = 3,
            /// <summary>
            /// 1366×768
            /// </summary>
            [EnumCodeValueAttribute("4")]
            [EnumTextAttribute("1366×768")]
            W1366H768 = 4,
            /// <summary>
            /// 1920×1080
            /// </summary>
            [EnumCodeValueAttribute("5")]
            [EnumTextAttribute("1920×1080")]
            W1920H1080 = 5,
            /// <summary>
            /// 2048×1152
            /// </summary>
            [EnumCodeValueAttribute("6")]
            [EnumTextAttribute("2048×1152")]
            W2048H1152 = 6,
            /// <summary>
            /// 2560×1440
            /// </summary>
            [EnumCodeValueAttribute("7")]
            [EnumTextAttribute("2560×1440")]
            W2560H1440 = 7,
            /// <summary>
            /// 3200×1800
            /// </summary>
            [EnumCodeValueAttribute("8")]
            [EnumTextAttribute("3200×1800")]
            W3200H1800 = 8,
            /// <summary>
            /// 3840×2160
            /// </summary>
            [EnumCodeValueAttribute("9")]
            [EnumTextAttribute("3840×2160")]
            W3840H2160 = 9,
            /// <summary>
            /// 7680×4320
            /// </summary>
            [EnumCodeValueAttribute("10")]
            [EnumTextAttribute("7680×4320")]
            W7680H4320 = 10
        }

        /// <summary>
        /// レイアウト画面向き
        /// </summary>
        public enum Code_レイアウト画面向き
        {
            /// <summary>
            /// OFF
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("縦")]
            縦 = 1,
            /// <summary>
            /// ON
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("横")]
            横 = 2
        }

        /// <summary>
        /// 所有者
        /// </summary>
        public enum Code_所有者
        {
            /// <summary>
            /// 顧客グループ
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("顧客グループ")]
            顧客グループ = 1,
            /// <summary>
            /// 顧客
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("顧客")]
            顧客 = 2
        }

        /// <summary>
        /// コンテンツ分類
        /// </summary>
        public enum Code_コンテンツ分類
        {
            /// <summary>
            /// 行政情報
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("行政情報")]
            行政情報 = 1,
            /// <summary>
            /// 広告
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("広告")]
            広告 = 2
        }

        /// <summary>
        /// ファイル拡張子
        /// </summary>
        public enum Code_ファイル拡張子
        {
            /// <summary>
            /// 静止画
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("静止画")]
            静止画 = 1,
            /// <summary>
            /// 動画
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("動画")]
            動画 = 2,
            /// <summary>
            /// テキスト
            /// </summary>
            [EnumCodeValueAttribute("3")]
            [EnumTextAttribute("テキスト")]
            テキスト = 3
        }

        /// <summary>
        /// エリア区分
        /// </summary>
        public enum Code_エリア区分
        {
            /// <summary>
            /// 住所タイプ
            /// </summary>
            [EnumCodeValueAttribute("01")]
            [EnumTextAttribute("住所タイプ")]
            住所タイプ = 1,
            /// <summary>
            /// 気象タイプ
            /// </summary>
            [EnumCodeValueAttribute("02")]
            [EnumTextAttribute("気象タイプ")]
            気象タイプ = 2,
            /// <summary>
            /// 火山タイプ
            /// </summary>
            [EnumCodeValueAttribute("03")]
            [EnumTextAttribute("火山タイプ")]
            火山タイプ = 3,
            /// <summary>
            /// 鉄道タイプ
            /// </summary>
            [EnumCodeValueAttribute("04")]
            [EnumTextAttribute("鉄道タイプ")]
            鉄道タイプ = 4,
            /// <summary>
            /// フェリータイプ
            /// </summary>
            [EnumCodeValueAttribute("05")]
            [EnumTextAttribute("フェリータイプ")]
            フェリータイプ = 5,
            /// <summary>
            /// フライトタイプ
            /// </summary>
            [EnumCodeValueAttribute("06")]
            [EnumTextAttribute("フライトタイプ")]
            フライトタイプ = 6
        }

        /// <summary>
        /// エリアメール区分
        /// </summary>
        public enum Code_エリアメール区分
        {
            /// <summary>
            /// 一般
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("一般")]
            一般 = 1,
            /// <summary>
            /// 緊急情報
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("緊急情報")]
            緊急情報 = 2
        }

        /// <summary>
        /// 文字条件
        /// </summary>
        public enum Code_文字条件
        {
            /// <summary>
            /// 文字列で制限
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("文字列で制限")]
            文字列で制限 = 1,
            /// <summary>
            /// 文字列で除外
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("文字列で除外")]
            文字列で除外 = 2
        }

        /// <summary>
        /// レイアウト画面分割
        /// </summary>
        public enum Code_レイアウト画面分割
        {
            /// <summary>
            /// 縦
            /// </summary>
            [EnumCodeValueAttribute("1")]
            [EnumTextAttribute("縦")]
            縦 = 1,
            /// <summary>
            /// 横
            /// </summary>
            [EnumCodeValueAttribute("2")]
            [EnumTextAttribute("横")]
            横 = 2
        }

        #region セッション情報識別

        /// <summary>
        /// セッション情報識別
        /// </summary>
        ///	<remarks>
        /// セッション情報の項目を定義する
        /// <para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public enum SessionInfo
        {
            /// <summary>
            /// 権限
            /// </summary>
            AN_KENGEN,
            /// <summary>
            /// ユーザコード
            /// </summary>
            CD_USER,
            /// <summary>
            /// ユーザ名
            /// </summary>
            NM_USER,
            /// <summary>
            /// 自治体コード
            /// </summary>
            CD_JICHITAI,
            /// <summary>
            /// 自治体名
            /// </summary>
            NM_JICHITAI
        }

        #endregion

    }
}
