﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;


namespace GZPIAnswer
{
    class Answer
    {
        //提取网页题目
        // string html = null;
        public static string[] GetWebTitles(string html)//还需要一个HTML
        {
            //StreamReader sr = new StreamReader(@"C:\网页样本.txt", System.Text.Encoding.GetEncoding(936), true);
            string input = html;
            string pattern = @"问题\d+[^<]+";
            Regex rgx = new Regex(pattern);
            // input = html.ReadToEnd();
            MatchCollection matches = rgx.Matches(input);
            string[] str = new string[matches.Count];
            if (matches.Count > 0)
            {
                int i = 0;
                foreach (Match match in matches)
                {
                    str[i] = match.Value;
                    i++;
                }
            }
            int k = 0;
            foreach (string s in str)
            {

                string s1 = s;
                s1 = s1.Replace("（", "");
                s1 = s1.Replace("。", "");
                s1 = s1.Replace("）", "");
                s1 = s1.Replace("，", "");
                s1 = s1.Replace("：", "");
                s1 = s1.Replace("？", "");
                s1 = s1.Replace("?", "");
                s1 = s1.Replace("“", "");
                s1 = s1.Replace("”", "");
                s1 = s1.Replace("√", "");
                s1 = s1.Replace("×", "");
                s1 = s1.Replace("A", "");
                s1 = s1.Replace("B", "");
                s1 = s1.Replace("C", "");
                s1 = s1.Replace("D", "");
                s1 = s1.Replace("1", "");
                s1 = s1.Replace("2", "");
                s1 = s1.Replace("3", "");
                s1 = s1.Replace("4", "");
                s1 = s1.Replace("5", "");
                s1 = s1.Replace("6", "");
                s1 = s1.Replace("7", "");
                s1 = s1.Replace("9", "");
                s1 = s1.Replace("0", "");
                s1 = s1.Replace("8", "");
                s1 = s1.Replace(".", "");
                s1 = s1.Replace("、", "");
                s1 = s1.Replace(" ", "");
                s1 = s1.Replace(",", "");
                s1 = s1.Replace("问题", "");
                s1 = s1.Replace("；", "");
                s1 = s1.Replace("(", "");
                s1 = s1.Replace(")", "");
                s1 = s1.Trim();
                str[k] = s1;
                k++;
                //Console.WriteLine(s1);              
            }
            // Console.WriteLine(str.Length);
            //Console.ReadKey();
            //sr.Close();
            return str;
        }
        
        //得到标准参考题目
        public static string[] GetStandardTitles()
        {

            //string[] str = { "信用报告被人们喻为", "如果个人对自己信用报告中的信息有不同意见可以向征信机构提出并由征信机构按程序进行处理这就是个人作为征信对象及数据主体所拥有的", "是指个人有权要求数据报送机构和征信机构对个人信用报告中记载并证实的错误信息进行修改", "是指个人对信用报告中的错误信息存在异议并经正常程序处理仍未得到满意解决向法院提出起诉用法律手段维护自身的个人权益", "逾期还款等负面信息不是永远记录在个人的信用报告中的我国逾期本息还清后大部分负面记录保存的时间为", "别人要查看您的信用报告的条件是", "征信信息主要来自提供先消费后付款服务的机构法院政府部门", "正面信息是指您在过去获得的信用交易以及在信用交易中正常履约的信息简单说就是您借钱的信息和", "负面信息是指您在过去的信用交易中的信息即违约信息", "使用信用报告可以的途径", "以下对个人在征信活动中的义务描述错误的是", "个人信用信息基础数据库中最重要的信息是", "按照《个人信用信息基础数据库管理暂行办法》的要求所有的商业银行无论是中资金融机构还是外资金融机构只要在中国境内从事个人信贷业务都应当向报送相关信息", "个人信用报告对个人最大的好处就是为个人积累方便个人办理信贷业务", "个人信用信息基础数据库已经覆盖信贷营业网点包括政策性银行全国性商业银行地方性商业银行农村信用社财务公司以及部分住房公积金管理中心小额信贷公司和汽车金融公司等", "采集国家助学贷款是商业银行等金融机构按照国家政策向经济困难的大学生发放的个人信用贷款自起商业银行等金融机构就将助学贷款及还款情况等相关信息报送到个人信用信息基础数据库", "逾期信贷信息是指", "个人信用信息是由只要在商业银行开立过结算账户或者是与银行发生过信贷交易的个人都加入了个人信用信息基础数据库", "个人信用报告由出具", "个人信用报告目前主要用于", "查询个人信用报告要提供资料", "查询个人信用报告要填写", "目前个人信用报告本人查询的限制次数为", "除对已发放的个人信贷进行贷后风险管理之外商业银行查询个人信用报告时应当取得被查询人的", "个人信用信息的主要提供者是", "除时无需取得被查询人的书面同意外商业银行查询个人信用报告必须取得被查询人的书面授权", "在均可以查询个人信用报告", "委托别人查询自己的信用报告时不需提供如下材料", "信用卡按期只还最低还款额算不算负面信息", "以下对逾期天与逾期天的区别表述正确的是", "个人信用报告中显示的个人身份信息是各商业银行上报的同类信息中最新的一条如果与当前的实际情况不符应及时到商业银行更改客户资料以保证个人信用报告中身份信息的及时性和准确性", "对信用报告持有不同意见时可向哪些部门提出异议申请", "个人办理按揭贷款购房后将房屋出售没有到银行办理转按揭贷款后来房主不按时还款造成个人信用报告中显示逾期记录由谁承担责任", "朋友用我的身份证向银行贷款却不还款有关的信息记在我的信用报告中可以提异议吗", "如果信用报告漏记个人的信用交易信息怎么办", "评价一个人的信用状况时通常依据这个人过去的信用行为记录下列信息中不属于信用行为记录的是", "您搬家后特别是搬进新购的二手房后一定要记住到水电燃气公司做更换水电燃气费的使用者即房屋户主的名称及联系方式否则可能会使个人信用信息基础数据库中的信用信息张冠李戴造成不必要的麻烦", "为什么偿还了欠款曾经逾期的记录还保留在信用报告中", "按照《中华人民共和国担保法》的有关规定担保人对偿还被担保人的贷款一旦借款人无力履行还款义务银行可以要求担保人履行担保义务代替借款人偿还贷款", "以下行为属于信用卡消费的好习惯的是", "信用良好能带来什么优惠", "晚还几天利息会记入个人信用报告吗", "生源地信用助学贷款到期还款日为", "生源地信用助学贷款期限最长和最短年限分别是", "生源地信用助学贷款主要用于", "张三现为贵阳医学院临床医学专业大二学生本科五年制将于年毕业家庭贫困符合申请开发银行生源地助学贷款条件以下说法正确的是", "生源地信用助学贷款金额最高和最低表述准确的是", "国家开发银行助学贷款含高校助学贷款和生源地助学贷款年度利息还款日为", "国家开发银行助学贷款含高校助学贷款和生源地助学贷款提前还款日为", "国家开发银行助学贷款含高校助学贷款和生源地助学贷款提前还款申请日为", "国家开发银行助学贷款含高校助学贷款和生源地助学贷款逾期贷款还款日为", "以下关于开发银行生源地信用助学贷款表述正确的是", "开发银行助学贷款系统学生在线系统不具有以下哪项功能", "以下关于提前还款申请说法正确的是", "若贷款学生未按时归还贷款本金开发银行将根据逾期本金金额和逾期天数计收罚息罚息利率为本合同借款利息的", "张三申请了生源地信用助学贷款元学费元欠缴学校住宿费元贷款发放后元汇到学校账户元汇到自己的贷款账户上", "通过什么途径可以知道自己的生源地信用助学贷款的详细情况", "张三年申请生源地信用助学贷款元账户是农行卡年申请生源地信用助学贷款元账户是支付宝毕业后张三申请了提前还款钱应该存入", "办理生源地信用助学贷款时生成的支付宝账户密码忘记怎么办", "高校助学贷款到期还款日为", "生源地信用助学贷款一般每年开始受理", "在签订国家助学贷款合同前务必阅读合同全部条款合同一经签订即视同同意全部条款", "申请国家助学贷款的借款人不需要向银行出具的资料", "支付宝的支付密码忘记需要怎么找回", "更换了身份信息支付宝无法进行实名认证怎么办", "不了解支付宝的还款流程怎么办", "支付宝进行还款时提示限额怎么办", "充值时显示支付宝余额支付功能关闭怎么办", "若贷款扣除学费后剩余部分想取现怎么办", "个人在征信活动中享有以下权利", "个人的信贷信息主要包括", "个人在征信活动中的义务有", "在个人信用报告中以下体现出负面信息的有", "征信信息主要来自以下机构", "征信机构提供的主要服务有", "在信用报告的使用中下列行为正确的是", "个人信用信息基础数据库是一个全国统一的个人信用信息共享平台可依法向提供信用信息服务", "个人信用信息基础数据库已经覆盖全国银行类金融机构各级信贷营业网点包括以及部分住房公积金管理中心小额信贷公司和汽车金融公司等", "商业银行办理下列业务可以向个人信用信息基础数据库查询个人信用报告", "建立个人征信系统的目的是", "个人信用报告出错了可以通过渠道反映出错信息要求核查纠正", "为全面反映您的信用状况个人信用信息基础数据库除贷款信息外还采集了一些能证明您信用状况的信息包括", "什么人有信用报告", "以下哪些情况属于逾期行为将会被记入信用报告", "以下对当前逾期总额表述正确的是", "个人信用报告被查询有以下几种原因", "以下关于个人信用报告的描述正确的是", "对个人信用记录产生异议的主要原因一般包括以下几种", "为了使个人信用信息基础数据库更全面准确地记录本人信息可以从以下几方面入手", "对姓名性别户籍地址等个人基本信息有异议怎么办", "在情况下可以使用个人声明", "个人可采取以下措施防止个人身份被盗用", "下列选项中哪些情况容易出现负面记录", "出差在外遇上了还款期可采取以下哪些措施防止产生逾期还款信息", "为了在日常生活中注意养成良好的意识和习惯个人可以从以下哪些方面着手", "个人发生信用交易后应当", "如果在本人不知情的情况下身份证被盗用个人应该", "银行凭什么决定是否给您贷款", "以下关于休眠卡的理解正确的是", "个人建立信用记录的主要方法是与银行发生信贷业务关系主要包括", "未按时归还国家助学贷款对个人信用有影响吗", "商业银行办理哪些业务查询个人信用报告时应当取得被查询人的书面授权", "以下关于高校助学贷款表述正确的是", "以下关于共同借款人表述中正确的有", "以下属于合同变更的有", "年李四被贵州财经学院金融学本科专业录取学制四年年毕业李四于年月日申请开发银行助学贷款元期限年以下说法错误的有", "关于高校助学贷款延迟贴息截止日手续办理表述正确的有", "以下关于开发银行助学贷款学生在线系统说法正确的有", "国家助学贷款借款学生出现不按时还贷或恶意拖欠贷款等明显违约行为时各级学生资助管理中心有权采取以下措施", "若学生未按时归还助学贷款并且长期拖欠违约信息多次载入中国人民银行个人征信系统后会对违约学生未来的工作生活带来什么不良影响", "开发银行及学生资助中心将定期向贷款学生致电短信告知重要通知进行还款提示为了保证及时获得通知贷款学生出现如下情形之一时应在个工作日书面通知办理助学贷款的资助中心并登陆学生在线服务系统对个人信息进行变更", "从何处可以获知自己生源地信用助学贷款的账户号", "生源地信用助学贷款成功后贷款的支付宝账户上余额无法提现的原因以下说法错误的是", "申请生源地贷款的学生须符合以下哪些条件", "生源地信用助学贷款借款学生未按借款合同约定还款连续拖欠超过一年且不与所在县市区学生资助管理中心主动联系办理有关手续的有权在不通知甲方的情况下在新闻媒体和网络等信息渠道上公布借款学生姓名身份证号码毕业学校生源地县区及违约行为等信息并提供给全国学生资助管理中心等相关机构", "申请助学贷款的支付宝账号遗失以下哪种方法可行", "支付宝密码因注册电子邮箱丢失手机号码无法找回到了贷款还款日期应怎么还款", "信用报告是个人的经济身份证", "征信是适应现代经济的需要而发展起来的", "征信既不是诚信也不是信用而是客观记录人们过去的信用信息并帮助预测未来是否履约的一种服务", "个人信用信息是个人在经济活动中产生的敏感信息涉及个人隐私因而不能像公共产品一样无条件共享", "征信机构必须有专人接受并处理您的异议申请", "可以随便看他人的信用报告", "在实际生活中征信机构的评分与银行的评分互相补充", "负面信息是指您在过去的信用交易中未能按时足额偿还贷款支付各种费用的信息即违约信息", "个人在征信活动中有提供正确的个人基本信息的义务及时更新自身信息的义务关心自己信用记录的义务", "如果查实信用报告中记载的信息被征信机构搞错了征信机构必须尽快改正如果是由商业银行等报送数据的机构搞错了则征信机构必须协调出错的数据报送机构更正错误", "征信机构的评分与银行的评分是一样的", "征信记录您过去的信用行为这些行为将影响您未来的经济活动", "征信是适应现代经济的需要而发展起来的它在帮助每个人积累信用财富的同时也激励每个人养成守信履约的行为习惯方便您在更大的范围内从事经济金融交易", "诚信是人们诚实守信的品质与人格特征它属于道德范畴是一种社会公德一种为人处事的基本准则", "个人信用报告是征信机构出具的记录您过去信用信息的一种文件它的就像我们的居民身份证因此人们形象地称它为经济身份证", "在海南的欠款记录不会影响在福建省商业银行取得个人住房贷款", "个人信用信息基础数据库需要征得个人同意才能采集个人信息", "个人信用信息基础数据库中的个人基本信息只包括个人姓名及证件号码", "国家助学贷款信息也属个人信用信息基础数据库的征集范围", "个人信用信息基础数据库尚未采集国家助学贷款信息", "未按时还款的信息即逾期记录只要后来还清了借款就不会在个人信用信息基础数据库中记录", "商业银行在考察个人信用状况决定是否贷款时要同时考虑本人及其配偶的信用状况", "个人信用信息基础数据库不采集个人存款信息", "为保护个人隐私和信息安全保障个人信用信息基础数据库的规范运行《中国人民银行个人信用信息基础数据库管理暂行办法》中采取了授权查限定用途保障安全查询记录违规处罚等措施", "逾期信贷信息是指个人与银行发生信贷关系时未能按时足额偿还应还款项而产生的相关信息", "目前在互联网上可以直接查询个人信用报告", "个人信用报告有查询次数的限制", "商业银行的所有工作人员均可查询客户的信用报告", "本人可不经授权直接查询包括配偶子女在内的直系亲属的信用报告", "凡是与银行发生信贷关系或者开立了个人结算账户的个人都有自己的信用报告", "除商业银行等金融机构外个人信用报告的使用日益广泛这些机构查询个人信用报告的一个必要条件就是必须取得被查询人的授权授权可以是公告性的也可以是特定的书面授权", "信用卡按期只还最低还款额算负面信息", "个人信用报告中的个人身份信息主要是由各商业银行上报的就是个人在商业银行办理信用卡或贷款业务时填写的相关申请表上的个人基本信息", "信用报告中不区分善意欠款与恶意欠款", "最高逾期期数是当前逾期期数的历史最大值", "当前逾期总额对贷记卡而言是指当前未归还最低还款额的总额对贷款而言是指当前应还未还的贷款额合计", "朋友用我的身份证向银行贷款却不还款相关信息记在我的信用报告中我可以向人民银行征信管理部门提出异议申请", "借款多刷卡多但不及时还款形成的负面记录多说明此人履约意识差商业银行对其信用状况的判断可能就要大打折扣了", "在信用活动中要遵循口说无凭立字为据的原则", "偿还欠款后曾经逾期的记录不会在信用报告中保留", "每月还款时多存入一定金额现金可以保证足额还款应付出差利率上调等特殊情况避免造成不良信用记录", "晚还几天利息不会记入个人信用报告", "信用卡注销后欠年费的记录也会马上删除", "个人参加社会保险和住房公积金信息对银行审查个人信贷申请可以帮助银行更好地了解您的偿债能力", "如果个人的信用状况非常好且其他条件也符合要求商业银行有可能给个人发放不需要抵押或担保的个人信用贷款", "个人公用事业费用的缴纳情况会有助于银行全面了解个人的信用状况", "我在外地的贷款发生逾期对我在本地的贷款没有影响", "既然我已经还清了借款那么相关信息就应该从个人信用信息基础数据库中删除所以个人征信系统不采集我已还清的信贷信息", "逾期指到还款日最后期限仍未足额还款", "共同借款人为借款学生担保人无需承担第一还款责任", "申请开发银行生源地信用助学贷款的学生不能作为其他借款学生的共同借款人", "第一次申请开行生源地信用助学贷款共同借款人如果不能到现场办理可委托其他人办理", "借款学生可登陆开发银行助学贷款在线系统进行贷款申请不需要前往县学生资助管理中心申请", "采用支付宝发放和回收贷款时借款学生需要在指定银行开立个人银行账户", "第一次申请开发银行助学贷款的学生需持申请表前往村委会居委会或乡镇街道民政部门确认贫困身份", "国家开发银行助学贷款生源地学生在线系统的密码忘记可以请县资助中心老师帮其重置密码", "忘记了获得贷款的支付宝密码可以通过学生资助中心或国家开发银行重置密码X", "生源地贷款学生毕业时可由高校老师做毕业确认不需要自己到国家开发银行助学贷款学生在线系统申请", "年申请了生源地信用助学贷款若年想申请续贷而原共同借款人不能在贷款期间到现场办理手续这时需要与共同借款人提前到资助中心签订授权委托书", "已经开展生源地贷款省份的学生还可以在学校申请高校助学贷款", "高校助学贷款学生办理贴息延期手续必须是毕业当年考入更高层次学历就读", "生源地信用助学贷款不能办理展期只能办理贴息延期手续", "生源地信用助学贷款是国家开发银行向符合条件的家庭经济困难的普通高校新生和在校生发放的在学生入学前户籍所在县市区办理的享受财政风险补偿金和贴息政策的助学贷款", "获得助学贷款以后能否将还款账号由支付宝变更为银行卡", "预科生可以申请国家开发银行助学贷款" };
            string[] str = TitleAndAnswer.titleList.ToArray();
            return str;
        }
        //得到标准参考答案
        public static string[] GetStandardAnswers()
        {
            //string[] standardAnswers = { "B", "B", "C", "D", "D", "C", "A", "A", "B", "A", "C", "B", "C", "A", "B", "B", "A", "C", "A", "A", "A", "C", "D", "C", "B", "D", "D", "D", "B", "A", "C", "A", "C", "B", "C", "D", "D", "D", "A", "D", "B", "A", "C", "B", "C", "C", "C", "D", "D", "B", "C", "A", "B", "B", "A", "C", "D", "B", "A", "C", "B", "A", "D", "D", "B", "A", "D", "A", "B", "ABCD", "ABCD", "BCD", "ABCD", "ABCD", "BCD", "BCD", "ABCD", "ABCD", "ABCD", "ABCD", "ABCD", "ABCD", "AB", "ABC", "ABCD", "ABCD", "ABCD", "ABCD", "ABCD", "ABC", "AB", "ABCD", "ABCD", "ABCD", "ABCD", "ABCD", "AC", "ABCD", "ABCD", "ABCD", "BC", "ABC", "ABD", "ABCD", "BCD", "ABD", "AB", "BCD", "ABCD", "ABCD", "ABCD", "AB", "AD", "ABCD", "AC", "ABD", "AD", "√", "√", "√", "√", "√", "×", "√", "√", "√", "√", "×", "√", "√", "√", "√", "×", "×", "×", "√", "×", "×", "√", "√", "√", "√", "×", "×", "×", "×", "√", "√", "×", "√", "√", "√", "√", "×", "√", "√", "×", "√", "×", "×", "√", "√", "√", "×", "×", "√", "×", "√", "×", "×", "×", "√", "√", "×", "×", "×", "×", "√", "√", "√", "×", "×" };
            string[] standardAnswers = TitleAndAnswer.answerList.ToArray();
            return standardAnswers;

        }
        //得到网页答题 为72个答案
        public static string[] GetWebAnswers(string html)
        {
            int flag = 0;
            string[] standardAnswers = GetStandardAnswers();
            string[] standardTitles = GetStandardTitles();//全部题目
            string[] webTitles = GetWebTitles(html);//网上题目
            string[] webAnswers = new string[75];
            //StreamWriter sw = new StreamWriter(@"C:\72个题目答案.txt");
            bool x = false;
            bool y = false;
            bool z = false;
            for (int i = 0; i < webTitles.Length; i++)
            {
                int num = webTitles[i].Length / 2;
                string st = null;
                st = webTitles[i].Substring(0, num);
                int num2 = webTitles[i].Length / 2;
                string se = null;
                se = webTitles[i].Substring(num2);
                for (int j = 0; j < standardTitles.Length; j++)
                {
                    if (webTitles[i] == standardTitles[j])
                    {
                        webAnswers[i] = standardAnswers[j];
                        x = true;
                        break;
                    }
                }
                if (!x)
                {
                    for (int j = 0; j < standardTitles.Length; j++)
                    {

                        if (standardTitles[j].Contains(st))
                        {
                            webAnswers[i] = standardAnswers[j];
                            y = true;
                            break;
                        }
                    }
                    if (!y)
                        for (int j = 0; j < standardTitles.Length; j++)
                        {

                            if (standardTitles[j].Contains(se))
                            {
                                webAnswers[i] = standardAnswers[j];
                                break;
                            }
                        }
                    flag++;//没找到的答案是
                    webAnswers[i] = "A";//如果没找到答题则为A

                }
            }
            //foreach (string s in webAnswers)
            //{
            //    Console.WriteLine(s);
            //    sw.WriteLine(s);
            //}
            //sw.Close();
            return webAnswers;
        }
        //在不同的题目类型中产生要答错的题目编号数组GenerateRandomNumbers
        public static int[] GetErrorMarks(int N)
        {
            int yue;
            int[] w = new int[3];
            int t2 = N / 4;
            if ((N - 2 * t2) % 2 == 0)
            {
                w[0] = (N - 2 * t2) / 2;
                w[1] = t2;
                w[2] = (N - 2 * t2) / 2;
            }

            else
            {
                yue = (N - 2 * t2) % 2;
                w[0] = (N - 2 * t2) / 2;
                w[1] = t2;
                w[2] = (N - 2 * t2) / 2 + yue;
            }
            return w;
        }
        //在固定范围内产生不重复的随机数组
        public static int[] GenerateRandomNumbers(int num, int dms)
        {
            //用于存放1到dms这20个数     
            int[] container = new int[dms];
            //用于保存返回结果     
            int[] result = new int[num];
            Random random = new Random();
            for (int i = 1; i <= dms; i++)
            {
                container[i - 1] = i;
            }
            int index = 0;
            int value = 0;
            for (int i = 0; i < num; i++)
            {
                //从[1,container.Count + 1)中取一个随机值，保证这个值不会超过container的元素个数     
                index = random.Next(1, container.Length - 1 - i);
                //以随机生成的值作为索引取container中的值     
                value = container[index];
                //将随机取得值的放到结果集合中     
                result[i] = value;
                //将刚刚使用到的从容器集合中移到末尾去     
                container[index] = container[container.Length - i - 1];
                //将队列对应的值移到队列中     
                container[container.Length - i - 1] = value;
            }
            //result.Sort();排序     
            return result;
        }
        //在全对的网页答案中换进少量错的
        public static string[] Method1(string[] strs, int num)
        {

            int[] result = GenerateRandomNumbers(num, 30);
            string[] str = strs;
            for (int j = 0; j <= num - 1; j++)
            {
                int k = result[j];
                if (str[k] == "A")
                    str[k] = "B";
                if (str[k] == "B")
                    str[k] = "C";
                if (str[k] == "C")
                    str[k] = "D";
                if (str[k] == "D")
                    str[k] = "A";
            }
            return str;
        }
        public static string[] Method2(string[] strs, int num)
        {
            int[] result = GenerateRandomNumbers(num, 25);
            string[] str = strs;
            for (int j = 0; j <= num - 1; j++)
            {
                int k = result[j];
                if (str[k] == "ABCD")
                    str[k] = "ABD";
                else
                    str[k] = "ABCD";
            }

            return strs;
        }
        public static string[] Method3(string[] strs, int num)
        {
            int[] result = GenerateRandomNumbers(num, 20);
            string[] str = strs;
            for (int j = 0; j <= num - 1; j++)
            {
                int k = result[j];
                if (str[k] == "√")
                    str[k] = "×";
                else
                    str[k] = "√";
            }

            return strs;
        }
        //得到网页的checkbutton的ID
        //score最高为10分
        public static string[] GetWebID(int score, string html)
        {
            int wrongnumber=0;//= 19;//100分减去得到的分数
            //wrongnumber = 100 - score;
            int[] wn = GetErrorMarks(wrongnumber);
            int wn1 = wn[0];
            int wn2 = wn[1];
            int wn3 = wn[2];

            //StreamReader sr = new StreamReader(@"C:\72个题目答案.txt", System.Text.Encoding.UTF8, true);
            // StreamWriter sw = new StreamWriter(@"C:\72个题目ID.txt");
            string[] strs = new string[75];
            string[] str30 = new string[30];
            string[] str25 = new string[25];
            string[] str20 = new string[20];
            int i = 0;
            string s = null;

            //string s = null;strs为网页答案数组
            //while ((s = sr.ReadLine()) != null)
            //{
            //    strs[i] = s;
            //    i++;
            //}
            strs = GetWebAnswers(html);
            //有一个为空值情况处理
            for (int iiii = 0; iiii < strs.Length; iiii++)
            {
                if (strs[iiii] == null)
                {
                    strs[iiii] = "A";
                }
            }
            // Console.WriteLine(strs.Length);
            for (int x = 0; x <= 29; x++)
            {
                str30[x] = strs[x];
            }
            //匹配错误
            str30 = Method1(str30, wn1);

            for (int y = 0; y < 25; y++)
            {
                str25[y] = strs[y + 30];
            }
            str25 = Method2(str25, wn2);

            for (int z = 0; z < 20; z++)
            {
                str20[z] = strs[z + 55];
            }
            str20 = Method3(str20, wn3);
            //foreach (string s1 in str30)
            //{
            //    Console.WriteLine(s1);

            //}
            //foreach (string s1 in str25)
            //{
            //    Console.WriteLine(s1);

            //}
            //foreach (string s1 in str20)
            //{
            //    Console.WriteLine(s1);
            //}
            //
            //匹配相依错误

            //sr.Close();
            string[] id30 = new string[30];
            string c0 = null;
            for (int i1 = 0; i1 < 30; i1++)
            {
                c0 = str30[i1];
                if (i1 <= 9)
                {
                    switch (c0)
                    {
                        case "A":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl0" + i1 + "_rblSelection_0";
                            break;
                        case "B":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl0" + i1 + "_rblSelection_1";
                            break;
                        case "C":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl0" + i1 + "_rblSelection_2";
                            break;
                        case "D":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl0" + i1 + "_rblSelection_3";
                            break;
                        default:
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl0" + i1 + "_rblSelection_3";
                            break;
                    }
                }
                else
                {
                    switch (c0)
                    {
                        case "A":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl" + i1 + "_rblSelection_0";
                            break;
                        case "B":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl" + i1 + "_rblSelection_1";
                            break;
                        case "C":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl" + i1 + "_rblSelection_2";
                            break;
                        case "D":
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl" + i1 + "_rblSelection_3";
                            break;
                        default:
                            id30[i1] = "uSimpleSelection_dlSimpleSelection_ctl" + i1 + "_rblSelection_3";
                            break;
                    }
                }

            }
            //foreach (string s1 in id30)//id
            //{
            //    Console.WriteLine(s1);

            //}

            string[] id25 = new string[100];
            //string c1 = null;
            int i22 = 0;
            for (int i2 = 0; i2 < 25; i2++)
            {
                char[] ch = str25[i2].ToArray<char>();
                for (int tt = 0; tt < ch.Length; tt++, i22++)
                {
                    char c11 = ch[tt];
                    if (i2 <= 9)
                    {
                        switch (c11)
                        {
                            case 'A':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl0" + i2 + "_cblSelection_" + tt;
                                break;
                            case 'B':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl0" + i2 + "_cblSelection_" + tt;
                                break;
                            case 'C':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl0" + i2 + "_cblSelection_" + tt;
                                break;
                            case 'D':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl0" + i2 + "_cblSelection_" + tt;
                                break;

                        }
                    }
                    else
                    {
                        switch (c11)
                        {
                            case 'A':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl" + i2 + "_cblSelection_" + tt;
                                break;
                            case 'B':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl" + i2 + "_cblSelection_" + tt;
                                break;
                            case 'C':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl" + i2 + "_cblSelection_" + tt;
                                break;
                            case 'D':
                                id25[i22] = "uMultiSelection_dlMultiSelection_ctl" + i2 + "_cblSelection_" + tt;
                                break;
                        }


                    }
                }
            }
                int kk1 = 0;
                for (int kk = 0; kk < id25.Length; kk++)
                {
                    string s1 = id25[kk];
                    if (s1 != null)
                    {
                        kk1++;
                    }
                }
                string[] id251 = new string[kk1];
                for (int yy = 0; yy < kk1; yy++)
                {
                    id251[yy] = id25[yy];
                }
                //foreach (string s1 in id251)//id
                //{
                //    Console.WriteLine(s1);
                //}
                string[] id20 = new string[20];
                string c3;
                for (int i3 = 0; i3 < 20; i3++)
                {
                    c3 = str20[i3];
                    if (i3 <= 9)
                    {
                        switch (c3)
                        {
                            case "√":
                                id20[i3] = "uJudge_dlJudge_ctl0" + i3 + "_rblSelection_0";
                                break;
                            case "×":
                                id20[i3] = "uJudge_dlJudge_ctl0" + i3 + "_rblSelection_1";
                                break;
                            case "A":
                                id20[i3] = "uJudge_dlJudge_ctl0" + i3 + "_rblSelection_1";
                                break;
                        }
                    }
                    else
                    {
                        switch (c3)
                        {
                            case "√":
                                id20[i3] = "uJudge_dlJudge_ctl" + i3 + "_rblSelection_0";
                                break;
                            case "×":
                                id20[i3] = "uJudge_dlJudge_ctl" + i3 + "_rblSelection_1";
                                break;
                            case "A":
                                id20[i3] = "uJudge_dlJudge_ctl" + i3 + "_rblSelection_1";
                                break;
                        }
                    }


                }

                //foreach (string s1 in id20)//id
                //{
                //    Console.WriteLine(s1);
                //}
                string[] webID = id30.Concat(id251).Concat(id20).ToArray();

                return webID;
            }
            //为用户点击答案，以及提交
            //public static void ClickCheckButton(string[] webIDs)
            //{
            //    foreach(string webID in webIDs)
            //    {
            //        webBrowser1.Document.GetElementById(webID).SetAttribute("Checked", "true");
            //    }

            //}
        }

    }


