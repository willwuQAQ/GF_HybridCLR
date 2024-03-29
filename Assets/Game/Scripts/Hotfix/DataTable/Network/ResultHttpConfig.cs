#region Login

using System.Collections.Generic;

namespace Game.Hotfix
{
    [System.Serializable]
    public class UserData
    {
        public string token;
        public int user_id;//用户 id
        public int login_type;//登录类型
        public string username; //用户名
        public string avatar_url;//头像资源路径
        public int balloons_gold;//每分钟漂浮气球奖励金币数
        public int gender;//性别(0未知/1男/2女)
        public int gold;//用户金币数
        public int is_registered;//是否为新注册用户 0-否，1-是
        public int is_newbie;//是否领取过新手奖励宝箱，0-否，1-是
        public string currency_symbol; //提现货币符号
        public int coin_ratio;//与1单位提现货币等价的金币数量
        public List<WithdrawalConfig> withdrawal_config;
    }

    /// <summary>
    /// 提现配置
    /// </summary>
    [System.Serializable]
    public class WithdrawalConfig
    {
        public List<int> quota_coin;
        //提现途径
        public string type;
    }

    [System.Serializable]
    public class LoginResultData
    {
        public int code;
        public UserData data;
        public string msg;
        public int time;
    }

    #endregion

    #region NewbieReward

    [System.Serializable]
    public class NewbieRewardsResultData
    {
        public int code;
        public RewardData data;
        public string msg;
        public long time;
    }

    public class RewardData
    {
        public int amount;
    }

    #endregion

    #region Balloon

    [System.Serializable]
    public class BalloonResultData
    {
        public int code;
        public BalloonRewardData data;
        public string msg;
        public long time;
    }

    public class BalloonRewardData
    {
        public int amount;
        public int next_amount;
    }

    #endregion

    #region Level
    [System.Serializable]
    public class LevelResultData
    {
        public int code;
        public RewardData data;
        public string msg;
        public long time;
    }
    #endregion

    #region WithDraw

    [System.Serializable]
    public class WithDrawResultData
    {
        public int code;
        public WithDrawRewardData data;
        public string msg;
        public long time;
    }

    public class WithDrawRewardData
    {
        public int coin_amount;
        public int pay_id;
        public string pay_out_type;
    }

    #endregion

}
