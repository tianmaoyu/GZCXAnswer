﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GZPIAnswer
{
    class Answer2
    {
        private static string[] singleChoice =
        {
            "0.信用报告被人们喻为:B",
            "1.如果个人对自己信用报告中的信息有不同意见可以向征信机构提出并由征信机构按程序进行处理这就是个人作为征信对象及数据主体所拥有的:B",
            "2.是指个人有权要求数据报送机构和征信机构对个人信用报告中记载并证实的错误信息进行修改:C",
            "3.是指个人对信用报告中的错误信息存在异议并经正常程序处理仍未得到满意解决可向法院提出起诉用法律手段维护自身的个人权益:D",
            "4.逾期还款等负面信息是永远记录在个人的信用报告中的目前我国商业银行可查询内的逾期记录:C", 
            "5.别人要查看您的信用报告的条件是:C",
            "6.征信信息主要来自提供先消费后付款服务的机构法院政府部门:A",
            "7.正面信息是指您在过去获得的信用交易以及在信用交易中正常履约的信息简单说就是您借钱的信息和:A",
            "8.负面信息是指您在过去的信用交易中的信息即违约信息:B", "9.使用信用报告可以的途径:A",
            "10.以下对个人在征信活动中的义务描述错误的是:C",
            "11.个人信用信息基础数据库中最重要的信息是:B",
            "12.按照《个人信用信息基础数据库管理暂行办法》的要求所有的商业银行无论是中资金融机构还是外资金融机构只要在中国境内从事个人信贷业务都应当向报送相关信息:C",
            "13.个人信用报告对个人最大的好处就是为个人积累方便个人办理信贷业务:A",
            "14.个人信用信息基础数据库已经覆盖信贷营业网点包括政策性银行全国性商业银行地方性商业银行农村信用社财务公司以及部分住房公积金管理中心小额信贷公司和汽车金融公司等:B",
            "15.采集国家助学贷款是商业银行等金融机构按照国家政策向经济困难的大学生发放的个人信用贷款自起商业银行等金融机构就将助学贷款及还款情况等相关信息报送到个人信用信息基础数据库:B",
            "16.逾期信贷信息是指:A",
            "17.个人信用信息是由只要在商业银行开立过结算账户或者是与银行发生过信贷交易的个人都加入了个人信用信息基础数据库:C", 
            "18.个人信用报告由出具:A", 
            "19.个人信用报告目前主要用于:A",
            "20.查询个人信用报告要提供资料:A", 
            "21.查询个人信用报告要填写:C",
            "22.目前个人信用报告本人查询的限制次数为:D",
            "23.除对已发放的个人信贷进行贷后风险管理之外商业银行查询个人信用报告时应当取得被查询人的:C", 
            "24.个人信用信息的主要提供者是:B",
            "25.除时无需取得被查询人的书面同意外商业银行查询个人信用报告必须取得被查询人的书面授权:D",
            "26.在均可以查询个人信用报告:D",
            "27.委托别人查询自己的信用报告时不需提供如下材料:D",
            "28.信用卡按期只还最低还款额算不算负面信息:B",
            "29.以下对逾期天与逾期天的区别表述正确的是:A",
            "30.个人信用报告中显示的个人身份信息是各商业银行上报的同类信息中最新的一条如果与当前的实际情况不符应及时到商业银行更改客户资料以保证个人信用报告中身份信息的及时性和准确性:C",
            "31.对信用报告持有不同意见时可向哪些部门提出异议申请:A",
            "32.个人办理按揭贷款购房后将房屋出售没有到银行办理转按揭贷款后来房主不按时还款造成个人信用报告中显示逾期记录由谁承担责任:C",
            "33.朋友用我的身份证向银行贷款却不还款有关的信息记在我的信用报告中可以提异议吗:B", 
            "34.如果信用报告漏记个人的信用交易信息怎么办:C",
            "35.评价一个人的信用状况时通常依据这个人过去的信用行为记录下列信息中不属于信用行为记录的是:D",
            "36.您搬家后特别是搬进新购的二手房后一定要记住到水电燃气公司做更换水电燃气费的使用者即房屋户主的名称及联系方式否则可能会使个人信用信息基础数据库中的信用信息张冠李戴造成不必要的麻烦:D",
            "37.为什么偿还了欠款曾经逾期的记录还保留在信用报告中:D",
            "38.按照《中华人民共和国担保法》的有关规定担保人对偿还被担保人的贷款一旦借款人无力履行还款义务银行可以要求担保人履行担保义务代替借款人偿还贷款:A", 
            "39.以下行为属于信用卡消费的好习惯的是:D",
            "40.信用良好能带来什么优惠:B",
            "41.国家助学贷款晚还几天利息会记入个人信用报告吗:A", 
            "42.生源地信用助学贷款到期还款日为:C", 
            "43.生源地信用助学贷款期限最长和最短年限分别是:B",
            "44.生源地信用助学贷款主要用于:C",
            "45.张三现为贵阳医学院临床医学专业大二学生本科五年制将于年毕业家庭贫困符合申请开发银行生源地助学贷款条件以下说法正确的是:C",
            "46.生源地信用助学贷款金额最高和最低表述准确的是:C",
            "47.国家开发银行助学贷款含高校助学贷款和生源地助学贷款年度利息还款日为:D",
            "48.国家开发银行助学贷款含高校助学贷款和生源地助学贷款提前还款日为:D",
            "49.国家开发银行助学贷款含高校助学贷款和生源地助学贷款提前还款申请日为:B",
            "50.国家开发银行助学贷款含高校助学贷款和生源地助学贷款逾期贷款还款日为:C", 
            "51.以下关于开发银行生源地信用助学贷款表述正确的是:A", 
            "52.开发银行助学贷款系统学生在线系统不具有以下哪项功能:B",
            "53.以下关于提前还款申请说法正确的是:B",
            "54.若贷款学生未按时归还贷款本金开发银行将根据逾期本金金额和逾期天数计收罚息罚息利率为本合同借款利息的:A",
            "55.张三申请了生源地信用助学贷款元学费元欠缴学校住宿费元贷款发放后元汇到学校账户元汇到自己的贷款账户上:C",
            "56.通过什么途径可以知道自己的生源地信用助学贷款的详细情况:D",
            "57.张三年申请生源地信用助学贷款元账户是农行卡年申请生源地信用助学贷款元账户是支付宝毕业后张三申请了提前还款钱应该存入:B", "58.办理生源地信用助学贷款时生成的支付宝账户密码忘记怎么办:A",
            "59.高校助学贷款到期还款日为:C",
            "60.生源地信用助学贷款一般每年开始受理:B",
            "61.在签订国家助学贷款合同前务必阅读合同全部条款合同一经签订即视同同意全部条款:A",
            "62.申请国家助学贷款的借款人不需要向银行出具的资料:D",
            "63.支付宝的支付密码忘记需要怎么找回:D",
            "64.更换了身份信息支付宝无法进行实名认证怎么办:B",
            "65.不了解支付宝的还款流程怎么办:A",
            "66.支付宝进行还款时提示限额怎么办:D",
            "67.充值时显示支付宝余额支付功能关闭怎么办:A",
            "68.若贷款扣除学费后剩余部分想取现怎么办:B",
            "69.国家开发银行国家助学贷款咨询电话是:C",
            "70.张三现为某医学院临床医学专业大二学生本科五年制将于年毕业家庭贫困符合申请开发银行生源地助学贷款条件以下说法正确的是:C",
            "年月日起本专科学生每人每年生源地信用助学贷款金额最高和最低表述准确的是:B"
        };

        private static string[] mulitpleChoice =
        {
            "0.个人在征信活动中享有以下权利:ABCD",
            "1.个人的信贷信息主要包括:ABCD", 
            "2.个人在征信活动中的义务有:BCD",
            "3.在个人信用报告中以下体现出负面信息的有:ABCD",
            "4.征信信息主要来自以下机构:ABCD",
            "5.征信机构提供的主要服务有:BCD", 
            "6.在信用报告的使用中下列行为正确的是:BCD",
            "7.个人信用信息基础数据库是一个全国统一的个人信用信息共享平台可依法向提供信用信息服务:ABCD",
            "8.个人信用信息基础数据库已经覆盖全国银行类金融机构各级信贷营业网点包括以及部分住房公积金管理中心小额信贷公司和汽车金融公司等:ABCD",
            "9.商业银行办理下列业务可以向个人信用信息基础数据库查询个人信用报告:ABCD",
            "10.建立个人征信系统的目的是:ABCD",
            "11.个人信用报告出错了可以通过渠道反映出错信息要求核查纠正:ABCD",
            "12.为全面反映您的信用状况个人信用信息基础数据库除贷款信息外还采集了一些能证明您信用状况的信息包括:ABCD",
            "13.什么人有信用报告:AB",
            "14.以下哪些情况属于逾期行为将会被记入信用报告:ABC",
            "15.以下对当前逾期总额表述正确的是:ABCD",
            "16.个人信用报告被查询有以下几种原因:ABCD",
            "17.以下关于个人信用报告的描述正确的是:ABCD",
            "18.对个人信用记录产生异议的主要原因一般包括以下几种:ABCD", 
            "19.为了使个人信用信息基础数据库更全面准确地记录本人信息可以从以下几方面入手:ABCD",
            "20.对姓名性别户籍地址等个人基本信息有异议怎么办:ABC",
            "21.在情况下可以使用个人声明由于第三方的原因造成的负面记录:AB",
            "22.个人可采取以下措施防止个人身份被盗用:ABCD",
            "23.下列选项中哪些情况容易出现负面记录:ABCD",
            "24.出差在外遇上了还款期可采取以下哪些措施防止产生逾期还款信息:ABCD",
            "25.为了在日常生活中注意养成良好的意识和习惯个人可以从以下哪些方面着手:ABCD", 
            "26.个人发生信用交易后应当:ABCD",
            "27.如果在本人不知情的情况下身份证被盗用个人应该:AC",
            "28.银行凭什么决定是否给您贷款:ABCD",
            "29.以下关于休眠卡的理解正确的是:ABCD",
            "30.个人建立信用记录的主要方法是与银行发生信贷业务关系主要包括:ABCD",
            "31.未按时归还国家助学贷款对个人信用有影响吗:BC",
            "32.商业银行办理哪些业务查询个人信用报告时应当取得被查询人的书面授权:ABC", 
            "33.以下关于高校助学贷款表述正确的是:ABD",
            "34.以下关于共同借款人表述中正确的有:ABCD", 
            "35.以下属于合同变更的有:BCD",
            "36.年李四被贵州财经学院金融学本科专业录取学制四年年毕业李四于年月日申请开发银行助学贷款元期限年以下说法错误的有:ABD",
            "37.关于高校助学贷款延迟贴息截止日手续办理表述正确的有:AB",
            "38.以下关于开发银行助学贷款学生在线系统说法正确的有:BCD",
            "39.国家助学贷款借款学生出现不按时还贷或恶意拖欠贷款等明显违约行为时各级学生资助管理中心有权采取以下措施:ABCD",
            "40.若学生未按时归还助学贷款并且长期拖欠违约信息多次载入中国人民银行个人征信系统后会对违约学生未来的工作生活带来什么不良影响:ABCD",
            "41.开发银行及学生资助中心将定期向贷款学生致电短信告知重要通知进行还款提示为了保证及时获得通知贷款学生出现如下情形之一时应在个工作日书面通知办理助学贷款的资助中心并登陆学生在线服务系统对个人信息进行变更:ABCD",
            "42.从何处可以获知自己生源地信用助学贷款的账户号:AB",
            "43.生源地信用助学贷款成功后贷款的支付宝账户上余额无法提现的原因以下说法错误的是:AD",
            "44.申请生源地贷款的学生须符合以下哪些条件:ABCD",
            "45.生源地信用助学贷款借款学生未按借款合同约定还款连续拖欠超过一年且不与所在县市区学生资助管理中心主动联系办理有关手续的有权在不通知甲方的情况下在新闻媒体和网络等信息渠道上公布借款学生姓名身份证号码毕业学校生源地县区及违约行为等信息并提供给全国学生资助管理中心等相关机构:AC",
            "46.申请助学贷款的支付宝账号遗失以下哪种方法可行:ABD",
            "47.支付宝密码因注册电子邮箱丢失手机号码无法找回到了贷款还款日期应怎么还款:AD",
            "48.年李四被贵州某高校本科专业录取学制四年年毕业李四于年月日申请开发银行助学贷款元期限年以下说法错误的有:ABD",
            "49.从何处可以获知自己生源地信用助学贷款的还款账户号:AB",
            "50.个人征信报告中对姓名性别户籍地址等个人基本信息有异议怎么办:ABC",
            "申请助学贷款的支付宝支付密码因注册电子邮箱丢失手机号码无法找回到了贷款还款日期应怎么还款:ACD"

        };

        private static string[] judgeChoice =
        {
            "0.信用报告是个人的经济身份证:√", 
            "1.征信是适应现代经济的需要而发展起来的:√",
            "2.征信既不是诚信也不是信用而是客观记录人们过去的信用信息并帮助预测未来是否履约的一种服务:√", 
            "3.个人信用信息是个人在经济活动中产生的敏感信息涉及个人隐私因而不能像公共产品一样无条件共享:√",
            "4.征信机构必须有专人接受并处理您的异议申请:√",
            "5.可以随便看他人的信用报告:×", 
            "6.在实际生活中征信机构的评分与银行的评分互相补充:√",
            "7.负面信息是指您在过去的信用交易中未能按时足额偿还贷款支付各种费用的信息即违约信息:√",
            "8.个人在征信活动中有提供正确的个人基本信息的义务及时更新自身信息的义务关心自己信用记录的义务:√",
            "9.如果查实信用报告中记载的信息被征信机构搞错了征信机构必须尽快改正如果是由商业银行等报送数据的机构搞错了则征信机构必须协调出错的数据报送机构更正错误:√",
            "10.征信机构的评分与银行的评分是一样的:×",
            "11.征信记录您过去的信用行为这些行为将影响您未来的经济活动:√",
            "12.征信是适应现代经济的需要而发展起来的它在帮助每个人积累信用财富的同时也激励每个人养成守信履约的行为习惯方便您在更大的范围内从事经济金融交易:√",
            "13.诚信是人们诚实守信的品质与人格特征它属于道德范畴是一种社会公德一种为人处事的基本准则:√",
            "14.个人信用报告是征信机构出具的记录您过去信用信息的一种文件它的就像我们的居民身份证因此人们形象地称它为经济身份证:√",
            "15.在海南的欠款记录不会影响在福建省商业银行取得个人住房贷款:×",
            "16.个人信用信息基础数据库需要征得个人同意才能采集个人信息:×",
            "17.个人信用信息基础数据库中的个人基本信息只包括个人姓名及证件号码:×",
            "18.国家助学贷款信息也属个人信用信息基础数据库的征集范围:√", 
            "19.个人信用信息基础数据库尚未采集国家助学贷款信息:×",
            "20.未按时还款的信息即逾期记录只要后来还清了借款就不会在个人信用信息基础数据库中记录:×", 
            "21.商业银行在考察个人信用状况决定是否贷款时要同时考虑本人及其配偶的信用状况:√",
            "22.个人信用信息基础数据库不采集个人存款信息:√",
            "23.为保护个人隐私和信息安全保障个人信用信息基础数据库的规范运行《中国人民银行个人信用信息基础数据库管理暂行办法》中采取了授权查询限定用途保障安全查询记录违规处罚等措施:√",
            "24.逾期信贷信息是指个人与银行发生信贷关系时未能按时足额偿还应还款项而产生的相关信息:√",
            "25.目前在互联网上可以直接查询个人信用报告:×", 
            "26.个人信用报告有查询次数的限制:×",
            "27.商业银行的所有工作人员均可查询客户的信用报告:×", 
            "28.本人可不经授权直接查询包括配偶子女在内的直系亲属的信用报告:×",
            "29.凡是与银行发生信贷关系或者开立了个人结算账户的个人都有自己的信用报告:√",
            "30.除商业银行等金融机构外个人信用报告的使用日益广泛这些机构查询个人信用报告的一个必要条件就是必须取得被查询人的授权授权可以是公告性的也可以是特定的书面授权:√",
            "31.信用卡按期只还最低还款额算负面信息:×",
            "32.个人信用报告中的个人身份信息主要是由各商业银行上报的就是个人在商业银行办理信用卡或贷款业务时填写的相关申请表上的个人基本信息:√",
            "33.信用报告中不区分善意欠款与恶意欠款:√",
            "34.最高逾期期数是当前逾期期数的历史最大值:√",
            "35.当前逾期总额对贷记卡而言是指当前未归还最低还款额的总额对贷款而言是指当前应还未还的贷款额合计:√",
            "36.朋友用我的身份证向银行贷款却不还款相关信息记在我的信用报告中我可以向人民银行征信管理部门提出异议申请:×",
            "37.借款多刷卡多但不及时还款形成的负面记录多说明此人履约意识差商业银行对其信用状况的判断可能就要大打折扣了:√",
            "38.在信用活动中要遵循口说无凭立字为据的原则:√",
            "39.偿还欠款后曾经逾期的记录不会在信用报告中保留:×", 
            "40.每月还款时多存入一定金额现金可以保证足额还款应付出差利率上调等特殊情况避免造成不良信用记录:√", 
            "41.晚还几天利息不会记入个人信用报告:×",
            "42.信用卡注销后欠年费的记录也会马上删除:×", 
            "43.个人参加社会保险和住房公积金信息对银行审查个人信贷申请可以帮助银行更好地了解您的偿债能力:√",
            "44.如果个人的信用状况非常好且其他条件也符合要求商业银行有可能给个人发放不需要抵押或担保的个人信用贷款:√", 
            "45.个人公用事业费用的缴纳情况会有助于银行全面了解个人的信用状况:√",
            "46.我在外地的贷款发生逾期对我在本地的贷款没有影响:×",
            "47.既然我已经还清了借款那么相关信息就应该从个人信用信息基础数据库中删除所以个人征信系统不采集我已还清的信贷信息:×",
            "48.逾期指到还款日最后期限仍未足额还款:√", 
            "49.共同借款人为借款学生担保人无需承担第一还款责任:×",
            "50.申请开发银行生源地信用助学贷款的学生不能作为其他借款学生的共同借款人:√",
            "51.第一次申请开行生源地信用助学贷款共同借款人如果不能到现场办理可委托其他人办理:×",
            "52.借款学生可登陆开发银行助学贷款在线系统进行贷款申请不需要前往县学生资助管理中心申请:×",
            "53.采用支付宝发放和回收贷款时借款学生需要在指定银行开立个人银行账户:×",
            "54.第一次申请开发银行助学贷款的学生需持申请表前往村委会居委会或乡镇街道民政部门确认贫困身份:√",
            "55.国家开发银行助学贷款生源地学生在线系统的密码忘记可以请县资助中心老师帮其重置密码:√",
            "56.忘记了获得贷款的支付宝密码可以通过学生资助中心或国家开发银行重置密码:×",
            "57.生源地贷款学生毕业时可由高校老师做毕业确认不需要自己到国家开发银行助学贷款学生在线系统申请:×",
            "58.年申请了生源地信用助学贷款若年想申请续贷而原共同借款人不能在贷款期间到现场办理手续这时需要与共同借款人提前到资助中心签订授权委托书:×",
            "59.已经开展生源地贷款省份的学生还可以在学校申请高校助学贷款:×",
            "60.高校助学贷款学生办理贴息延期手续必须是毕业当年考入更高层次学历就读:√",
            "61.生源地信用助学贷款不能办理展期只能办理贴息延期手续:√",
            "62.生源地信用助学贷款是国家开发银行向符合条件的家庭经济困难的普通高校新生和在校生发放的在学生入学前户籍所在县市区办理的享受财政风险补偿金和贴息政策的助学贷款:√",
            "63.获得助学贷款以后能否将还款账号由支付宝变更为银行卡:×", 
            "64.预科生可以申请国家开发银行助学贷款:×",
            "个人征信不良记录不会影响个人公积金贷款:×",
            "凡是与银行发生信贷关系的个人都有自己的征信记录:√",
            "中小企业在申请贷款时通常要审查中小企业业主及配偶的个人信用状况:√",
            "偿还欠款后曾经逾期的记录会在信用报告中保留:√",
            "凡向金融机构贷款都要考察申请人的信用记录:√",
            "朋友用我的身份证向银行贷款却不还款相关信息记在我的信用报告中我可以向人民银行征信管理部门提出异议申请:√",
            "我在外地的贷款发生逾期对我在本地新申请的贷款有影响:√",
            "若国家助学贷款账户银行卡为休眠卡会影响还款:√",
            "信用卡注销后逾期的记录也会马上删除:×",
            "已经开展生源地贷款省份的学生不可以在学校申请高校助学贷款:√",
            "支付宝密码属于个人隐私信息忘记了获得贷款的支付宝密码不能通过学生资助中心或国家开发银行重置密码:√",
            ""
            
        };
        //得到相应的答案
        public static string[] singleAnswers = GetAnswers(singleChoice);
        public static String[] mulitpleAnsers = GetAnswers(mulitpleChoice);
        public static string[] judgeAnswers = GetAnswers(judgeChoice);
        //HTML提取的题目
        public static List<string> webSigleTitles=new List<string>();
        public static List<string> webMulitpleTitles=new List<string>();
        public static List<string> webJudgeTitles=new List<string>();
        //答案ID
      
        



        #region 提取网页中的题目

        /// <summary>
        /// 对HTML中的题目进行提取
        /// </summary>
        /// <param name="html">试卷的HTML</param>
        public static void GetWebTitles(string html)
        {
            string pattern = @"问题\d+[^<]+";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(html);
            List<string> webTitleList = new List<string>();
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string s = match.Value;
                    webTitleList.Add(HandleString(s));
                }
            }
            webSigleTitles = webTitleList.GetRange(0, 30);
            webMulitpleTitles = webTitleList.GetRange(30, 25);
            webJudgeTitles = webTitleList.GetRange(55, 20);
            //log
#if DEBUG
            FileStream aFileStream = new FileStream("G:\\答题助手数据\\2015log题目.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFileStream, Encoding.GetEncoding("GB2312"));
            int i = 1;
            foreach (string s in webTitleList)
            {
                sw.WriteLine(i + "题:" + s);
                i++;
            }
            sw.Close();
            aFileStream.Close(); 
#endif
        } 
        #endregion

        #region 辅助方法
        /// <summary>
        /// 得到标准题目的答案
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static String[] GetAnswers(string[] strings)
        {
            List<string> result = new List<string>();
            if (strings != null)
            {
                foreach (string s in strings)
                {
                    int j = s.IndexOf(':');
                    string s2 = s.Substring(j + 1, s.Length - j - 1);
                    result.Add(s2);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// 对得到的题目进行处理
        /// </summary>
        /// <param name="title">题目</param>
        /// <returns></returns>
        public static string HandleString(string title)
        {
            string reslut = null;
            if (title != null)
            {
                string s = title;
                s = s.Replace("（", "");
                s = s.Replace("。", "");
                s = s.Replace("）", "");
                s = s.Replace("，", "");
                s = s.Replace("：", "");
                s = s.Replace("？", "");
                s = s.Replace("?", "");
                s = s.Replace("“", "");
                s = s.Replace("”", "");
                s = s.Replace("√", "");
                s = s.Replace("×", "");
                s = s.Replace("A", "");
                s = s.Replace("B", "");
                s = s.Replace("C", "");
                s = s.Replace("D", "");
                s = s.Replace("1", "");
                s = s.Replace("2", "");
                s = s.Replace("3", "");
                s = s.Replace("4", "");
                s = s.Replace("5", "");
                s = s.Replace("6", "");
                s = s.Replace("7", "");
                s = s.Replace("9", "");
                s = s.Replace("0", "");
                s = s.Replace("8", "");
                s = s.Replace(".", "");
                s = s.Replace("、", "");
                s = s.Replace(" ", "");
                s = s.Replace(",", "");
                s = s.Replace("问题", "");
                s = s.Replace("；", "");
                s = s.Replace("(", "");
                s = s.Replace(")", "");
                s = s.Trim();
                reslut = s;
            }
            return reslut;
        }


        /// <summary>
        /// 单选题：题目的答案和编号得到对应需要勾选的ID
        /// </summary>
        /// <param name="s">答案</param>
        /// <param name="i">题目编号</param>
        /// <returns>正确答案的ID</returns>
        public static string GetSingleID(String s, int i)
        {
            string result=null;
            if (i<=9)
            {
                switch (s)
                {
                    case "A":
                        result = "uSimpleSelection_dlSimpleSelection_ctl0" + i + "_rblSelection_0";
                        break;
                    case "B":
                        result = "uSimpleSelection_dlSimpleSelection_ctl0" + i + "_rblSelection_1";
                        break;
                    case "C":
                        result = "uSimpleSelection_dlSimpleSelection_ctl0" + i + "_rblSelection_2";
                        break;
                    case "D":
                        result = "uSimpleSelection_dlSimpleSelection_ctl0" + i + "_rblSelection_3";
                        break;
                   }
            }
            else
            {
                switch (s)
                {
                    case "A":
                        result = "uSimpleSelection_dlSimpleSelection_ctl" + i + "_rblSelection_0";
                        break;
                    case "B":
                        result = "uSimpleSelection_dlSimpleSelection_ctl" + i + "_rblSelection_1";
                        break;
                    case "C":
                        result = "uSimpleSelection_dlSimpleSelection_ctl" + i + "_rblSelection_2";
                        break;
                    case "D":
                        result = "uSimpleSelection_dlSimpleSelection_ctl" + i + "_rblSelection_3";
                        break;
                   
                }
            }
            return result;
        }
        /// <summary>
        /// 得到多选的ID
        /// </summary>
        /// <param name="c">答案</param>
        /// <param name="i">题目编号</param>
        /// <returns>需要勾选的ID</returns>
        public static string GetMulitpleID(char c, int i)
        {
            string result=null;
            if (i <= 9)
            {
                switch (c)
                {
                    case 'A':
                        result = "uMultiSelection_dlMultiSelection_ctl0" + i + "_cblSelection_0";
                        break;
                    case 'B':
                        result = "uMultiSelection_dlMultiSelection_ctl0" + i + "_cblSelection_1";
                        break;
                    case 'C':
                        result = "uMultiSelection_dlMultiSelection_ctl0" + i + "_cblSelection_2";
                        break;
                    case 'D':
                        result = "uMultiSelection_dlMultiSelection_ctl0" + i + "_cblSelection_3";
                        break;
                  
                }
            }
            else
            {
                switch (c)
                {
                    case 'A':
                        result = "uMultiSelection_dlMultiSelection_ctl" + i + "_cblSelection_0";
                        break;
                    case 'B':
                        result = "uMultiSelection_dlMultiSelection_ctl" + i + "_cblSelection_1";
                        break;
                    case 'C':
                        result = "uMultiSelection_dlMultiSelection_ctl" + i + "_cblSelection_2";
                        break;
                    case 'D':
                        result = "uMultiSelection_dlMultiSelection_ctl" + i + "_cblSelection_3";
                        break;
                   
                }
            }
            return result;
        }
        /// <summary>
        /// 得到判断题ID
        /// </summary>
        /// <param name="s">答案</param>
        /// <param name="i">题目编号</param>
        /// <returns>勾选的ID</returns>
        public static string GetJudgeID(String s, int i)
        {
            string result=null;
            if (i <= 9)
            {
                switch (s)
                {
                    case "√":
                        result = "uJudge_dlJudge_ctl0" + i + "_rblSelection_0";
                        break;
                    case "×":
                        result = "uJudge_dlJudge_ctl0" + i + "_rblSelection_1";
                        break;
                  
                }
            }
            else
            {
                switch (s)
                {
                    case "√":
                        result = "uJudge_dlJudge_ctl" + i + "_rblSelection_0";
                        break;
                    case "×":
                        result = "uJudge_dlJudge_ctl" + i + "_rblSelection_1";
                        break;
                   
                }
            }
            return result;
        }

        #endregion

        public static List<string> singleID = new List<string>();
        public static List<string> multipleID = new List<string>();
        public static List<string> judgeID = new List<string>();
        public static void DoWrok()
        {
#if DEBUG
            FileStream aFileStream = new FileStream("G:\\答题助手数据\\2015log答案.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFileStream, Encoding.GetEncoding("GB2312")); 
#endif
          
           

            for (int i = 0; i < webSigleTitles.Count; i++)
            {
                bool isFind = false;
                for (int j = 0; j < singleChoice.Length; j++)
                {
                    if (singleChoice[j].Contains(webSigleTitles[i]))
                    {
                        string answer = singleAnswers[j];
#if DEBUG
                        sw.WriteLine(i + ":" + answer); 
#endif
                        //ij++;
                        string id = GetSingleID(answer, i);
                        singleID.Add(id);
                        isFind = true;
                    }
                }
#if DEBUG
                if (!isFind)
                {
                    sw.WriteLine("未能找到:" + webSigleTitles[i]);
                } 
#endif
            }

            for (int i = 0; i < webJudgeTitles.Count; i++)
            {
                bool isFind = false;
                for (int j = 0; j < judgeChoice.Length; j++)
                {
                    if (judgeChoice[j].Contains(webJudgeTitles[i]))
                    {
                        string answer = judgeAnswers[j];
#if DEBUG
                        sw.WriteLine(i + ":" + answer); 
#endif
                        //ij++;
                        string id = GetJudgeID(answer, i);
                        judgeID.Add(id);
                        isFind = true;
                    }
                   
                }
#if DEBUG
                if (!isFind)
                {
                    sw.WriteLine("未能找到:" + webJudgeTitles[i]);
                } 
#endif
            }

            for (int i = 0; i < webMulitpleTitles.Count; i++)
            {
                bool isFind = false;
                for (int j = 0; j < mulitpleChoice.Length; j++)
                {
                    if (mulitpleChoice[j].Contains(webMulitpleTitles[i]))
                    {
                        string answer = mulitpleAnsers[j];
                        char[] ch = answer.ToArray<char>();
#if DEBUG
                        sw.WriteLine(i + ":" + answer); 
#endif
                       // ij++;
                        foreach (char c in ch)
                        {
                            string id = GetMulitpleID(c, i);
                            multipleID.Add(id);
                        }
                        isFind = true;
                    }
                }
#if DEBUG
                if (!isFind)
                {
                    sw.WriteLine("未能找到:" + webMulitpleTitles[i]);
                } 
#endif
            }
#if DEBUG
            sw.Close();
            aFileStream.Close(); 
#endif

        }

    }

}
