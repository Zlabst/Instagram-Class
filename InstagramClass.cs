#region usings
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Linq;
using System.Text;
using System.Collections.Generic;
#endregion
namespace InstaBot
{
    //(っ◔◡◔)っ ♥ InstaBot ♥ - ˜”*°•.˜”*°• Instagram Class •°*”˜.•°*”˜
    //Made by @XeDev_Chris & @Sdkayyyy
    //Please don't leech (put credits)
    public class InstagramClass
    {
        #region variables
        public string GetFollowCSRF { get; set; }
        public string GetLoginCSRF { get; set; }
        public string GetRegisterCSRF { get; set; }
        public string SessionIDFromLogin { get; set; }
        public string DSUserID { get; set; }
        public string ToFollowID { get; set; }
        public string GetAccountsFile { get; set; }
        public string GetPhotoID { get; set; }
        public string GetLikeCSRF { get; set; }
        public string CheckingCSRF { get; set; }
        public string TurboCSRF { get; set; }
        #endregion

        #region Random UserAgents
        public string[] UAs =
        {
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X; fi-fi) AppleWebKit/420+ (KHTML, like Gecko) Safari/419.3",
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X; de-de) AppleWebKit/125.2 (KHTML, like Gecko) Safari/125.7",
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en-us) AppleWebKit/312.8 (KHTML, like Gecko) Safari/312.6",
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/523.15 (KHTML, like Gecko) Version/3.0 Safari/523.15",
            "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16",
            "Mozilla/5.0 (Macintosh; U; PPC Mac OS X 10_5_6; it-it) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-HK) AppleWebKit/533.18.1 (KHTML, like Gecko) Version/5.0.2 Safari/533.18.5",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; sv-SE) AppleWebKit/533.19.4 (KHTML, like Gecko) Version/5.0.3 Safari/533.19.4",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_3) AppleWebKit/534.55.3 (KHTML, like Gecko) Version/5.1.3 Safari/534.53.10",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_2) AppleWebKit/536.26.17 (KHTML, like Gecko) Version/6.0.2 Safari/536.26.17",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_5) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/6.1.3 Safari/537.75.14",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_0) AppleWebKit/600.3.10 (KHTML, like Gecko) Version/8.0.3 Safari/600.3.10",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11) AppleWebKit/601.1.39 (KHTML, like Gecko) Version/9.0 Safari/601.1.39",
            "Mozilla/5.0 (Linux; U; Android 1.5; de-de; HTC Magic Build/CRB17) AppleWebKit/528.5+ (KHTML, like Gecko) Version/3.1.2 Mobile Safari/525.20.1",
            "Mozilla/5.0 (Linux; U; Android 2.1-update1; en-au; HTC_Desire_A8183 V1.16.841.1 Build/ERE27) AppleWebKit/530.17 (KHTML, like Gecko) Version/4.0 Mobile Safari/530.17",
            "Mozilla/5.0 (Linux; U; Android 4.2; en-us; Nexus 10 Build/JVP15I) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android-4.0.3; en-us; Galaxy Nexus Build/IML74K) AppleWebKit/535.7 (KHTML, like Gecko) CrMo/16.0.912.75 Mobile Safari/535.7",
            "Mozilla/5.0 (Linux; U; Android-4.0.3; en-us; Xoom Build/IML77) AppleWebKit/535.7 (KHTML, like Gecko) CrMo/16.0.912.75 Safari/535.7",
            "Mozilla/5.0 (Linux; Android 4.0.4; SGH-I777 Build/Task650 & Ktoonsez AOKP) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Mobile Safari/535.19",
            "Mozilla/5.0 (Linux; Android 4.1; Galaxy Nexus Build/JRN84D) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Mobile Safari/535.19",
            "Mozilla/5.0 (iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3",
            "Mozilla/5.0 (iPad; U; CPU OS 5_1_1 like Mac OS X; en-us) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Ubuntu/10.10 Chromium/8.0.552.237 Chrome/8.0.552.237 Safari/534.10",
            "Mozilla/5.0 (X11; Linux i686) AppleWebKit/535.7 (KHTML, like Gecko) Ubuntu/11.10 Chromium/16.0.912.21 Chrome/16.0.912.21 Safari/535.7",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/535.2 (KHTML, like Gecko) Ubuntu/11.04 Chromium/15.0.871.0 Chrome/15.0.871.0 Safari/535.2",
            "Mozilla/5.0 (X11; Linux i686) AppleWebKit/535.1 (KHTML, like Gecko) Ubuntu/10.04 Chromium/14.0.813.0 Chrome/14.0.813.0 Safari/535.1",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/534.30 (KHTML, like Gecko) Ubuntu/10.10 Chromium/12.0.742.112 Chrome/12.0.742.112 Safari/534.30",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Ubuntu/10.10 Chromium/8.0.552.237 Chrome/8.0.552.237 Safari/534.10",
            "Mozilla/5.0 (Windows; U; Windows NT 5.0; it-IT; rv:1.7.12) Gecko/20050915",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.0.1) Gecko/20020919",
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1b2pre) Gecko/20081015 Fennec/1.0a1",
            "Mozilla/5.0 (X11; U; Linux armv7l; en-US; rv:1.9.2a1pre) Gecko/20090322 Fennec/1.0b2pre",
            "Mozilla/5.0 (Android; Linux armv7l; rv:9.0) Gecko/20111216 Firefox/9.0 Fennec/9.0",
            "Mozilla/5.0 (Android; Mobile; rv:12.0) Gecko/12.0 Firefox/12.0",
            "Mozilla/5.0 (Android; Mobile; rv:14.0) Gecko/14.0 Firefox/14.0",
            "Mozilla/5.0 (Mobile; rv:14.0) Gecko/14.0 Firefox/14.0",
            "Mozilla/5.0 (Mobile; rv:17.0) Gecko/17.0 Firefox/17.0",
            "Mozilla/5.0 (Tablet; rv:18.1) Gecko/18.1 Firefox/18.1",
            "Mozilla/5.0 (Android; Mobile; rv:28.0) Gecko/28.0 Firefox/28.0",
            "Mozilla/5.0 (Android; Tablet; rv:29.0) Gecko/29.0 Firefox/29.0",
            "Mozilla/5.0 (Android; Mobile; rv:40.0) Gecko/40.0 Firefox/40.0",
            "Mozilla/5.0 (iPad; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) FxiOS/1.0 Mobile/12F69 Safari/600.1.4",
            "Mozilla/5.0 (Windows; U; Win98; en-US; rv:1.5) Gecko/20031007 Firebird/0.7",
            "Mozilla/5.0 (Windows; U; Win95; en-US; rv:1.5) Gecko/20031007 Firebird/0.7",
            "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; en-US; rv:1.9.1b3) Gecko/20090305 Firefox/3.1b3 GTB5",
            "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; ko; rv:1.9.1b2) Gecko/20081201 Firefox/3.1b2",
            "Mozilla/5.0 (X11; U; SunOS sun4u; en-US; rv:1.9b5) Gecko/2008032620 Firefox/3.0b5",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1.12) Gecko/20080214 Firefox/2.0.0.12",
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; cs; rv:1.9.0.8) Gecko/2009032609 Firefox/3.0.8",
            "Mozilla/5.0 (X11; U; OpenBSD i386; en-US; rv:1.8.0.5) Gecko/20060819 Firefox/1.5.0.5",
            "Mozilla/5.0 (Windows; U; Windows NT 5.0; es-ES; rv:1.8.0.3) Gecko/20060426 Firefox/1.5.0.3",
            "Mozilla/5.0 (Windows; U; WinNT4.0; en-US; rv:1.7.9) Gecko/20050711 Firefox/1.0.5",
            "Mozilla/5.0 (Windows; Windows NT 6.1; rv:2.0b2) Gecko/20100720 Firefox/4.0b2",
            "Mozilla/5.0 (X11; Linux x86_64; rv:2.0b4) Gecko/20100818 Firefox/4.0b4",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.2) Gecko/20100308 Ubuntu/10.04 (lucid) Firefox/3.6 GTB7.1",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0b7) Gecko/20101111 Firefox/4.0b7",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0b8pre) Gecko/20101114 Firefox/4.0b8pre",
            "Mozilla/5.0 (X11; Linux x86_64; rv:2.0b9pre) Gecko/20110111 Firefox/4.0b9pre",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:2.0b9pre) Gecko/20101228 Firefox/4.0b9pre",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:2.2a1pre) Gecko/20110324 Firefox/4.2a1pre",
            "Mozilla/5.0 (X11; U; Linux amd64; rv:5.0) Gecko/20100101 Firefox/5.0 (Debian)",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0a2) Gecko/20110613 Firefox/6.0a2",
            "Mozilla/5.0 (X11; Linux i686 on x86_64; rv:12.0) Gecko/20100101 Firefox/12.0",
            "Mozilla/5.0 (Windows NT 6.1; rv:15.0) Gecko/20120716 Firefox/15.0a2",
            "Mozilla/5.0 (X11; Ubuntu; Linux armv7l; rv:17.0) Gecko/20100101 Firefox/17.0",
            "Mozilla/5.0 (Windows NT 6.1; rv:21.0) Gecko/20130328 Firefox/21.0",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:22.0) Gecko/20130328 Firefox/22.0",
            "Mozilla/5.0 (Windows NT 5.1; rv:25.0) Gecko/20100101 Firefox/25.0",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:25.0) Gecko/20100101 Firefox/25.0",
            "Mozilla/5.0 (Windows NT 6.1; rv:28.0) Gecko/20100101 Firefox/28.0",
            "Mozilla/5.0 (X11; Linux i686; rv:30.0) Gecko/20100101 Firefox/30.0",
            "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0",
            "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0",
            "Mozilla/5.0 (BeOS; U; Haiku BePC; en-US; rv:1.8.1.21pre) Gecko/20090227 BonEcho/2.0.0.21pre",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.9) Gecko/20071113 BonEcho/2.0.0.9",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1) Gecko/20061026 BonEcho/2.0",
            "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.8) Gecko/2009033017 GranParadiso/3.0.8",
            "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.6; en-US; rv:1.9.2) Gecko/20100411 Lorentz/3.6.3 GTB7.0",
            "Mozilla/5.0 (X11; U; Linux i686; it; rv:1.9.3a1pre) Gecko/20091019 Minefield/3.7a1pre",
            "Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.9.3a4pre) Gecko/20100402 Minefield/3.7a4pre",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.2a2pre) Gecko/20090901 Ubuntu/9.10 (karmic) Namoroka/3.6a2pre",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2a1) Gecko/20090806 Namoroka/3.6a1",
            "Mozilla/5.0 (Windows; U; Windows NT 6.1; cs; rv:1.9.2a2pre) Gecko/20090912 Namoroka/3.6a2pre (.NET CLR 3.5.30729)",
            "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.1b3pre) Gecko/20090109 Shiretoko/3.1b3pre",
            "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1b4pre) Gecko/20090311 Shiretoko/3.1b4pre",
            "Opera/5.11 (Windows 98; U) [en]",
            "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98) Opera 5.12 [en]",
            "Opera/6.0 (Windows 2000; U) [fr]",
            "Mozilla/4.0 (compatible; MSIE 5.0; Windows NT 4.0) Opera 6.01 [en]",
            "Opera/7.03 (Windows NT 5.0; U) [en]",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1) Opera 7.10 [en]",
            "Opera/9.02 (Windows XP; U; ru)",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.24",
            "Opera/9.51 (Macintosh; Intel Mac OS X; U; en)",
            "Opera/9.70 (Linux i686 ; U; en) Presto/2.2.1",
            "Opera/9.80 (Windows NT 5.1; U; cs) Presto/2.2.15 Version/10.00",
            "Opera/9.80 (Windows NT 6.1; U; sv) Presto/2.7.62 Version/11.01",
            "Opera/9.80 (Windows NT 6.1; U; en-GB) Presto/2.7.62 Version/11.00",
            "Opera/9.80 (Windows NT 6.1; U; zh-tw) Presto/2.7.62 Version/11.01",
            "Opera/9.80 (Windows NT 6.0; U; en) Presto/2.8.99 Version/11.10",
            "Opera/9.80 (X11; Linux i686; U; ru) Presto/2.8.131 Version/11.11",
            "Opera/9.80 (Windows NT 5.1) Presto/2.12.388 Version/12.14",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.12 Safari/537.36 OPR/14.0.1116.4",
            "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.29 Safari/537.36 OPR/15.0.1147.24 (Edition Next)",
            "Opera/9.80 (Linux armv6l ; U; CE-HTML/1.0 NETTV/3.0.1;; en) Presto/2.6.33 Version/10.60",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36 OPR/20.0.1387.91",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Oupeng/10.2.1.86910 Safari/534.30",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 OPR/26.0.1656.60",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2376.0 Safari/537.36 OPR/31.0.1857.0",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.85 Safari/537.36 OPR/32.0.1948.25"

        };
        #endregion

        #region NameGenerator
        public string[] Prefixes()
        {
            return new string[]
            {
                "Wild",
                "Happy",
                "Amazing",
                "Majestic",
                "Frantic",
                "Sad",
                "Poor",
                "Tectonic",
                "Tasty",
                "Sweet",
                "Delicious",
                "Bitter",
                "Fruity",
                "Technical",
                "Sour",
                "Salty"
            };
        }
        public string[] Suffixes()
        {
            return new string[]
            {
                "Runner",
                "Swimmer",
                "Dancer",
                "Gamer",
                "Streamer",
                "Hexur",
                "Player",
                "Fighter",
                ""
            };
        }
        #endregion

        #region functions
        public void RegisterCSRF()
        {
            string pattern = "\"csrf_token\": \"(.*)\"";
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com");

            string csrf = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                csrf = item.Groups[1].Value.Split('"')[0];
            }

            GetRegisterCSRF = csrf;
        }
        public void CSRFLogon()
        {
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/accounts/login/");
            string pattern = "\"csrf_token\": \"(.*)\"";
            string CSRF = string.Empty;
            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                CSRF = item.Groups[1].Value.Split('"')[0];
            }

            GetLoginCSRF = CSRF;
        }
        public void GetToFollowID(string toFollow)
        {
            string pattern = "\"id\": \"(.*)\"";
            string link = "https://www.instagram.com/" + toFollow + "/";
            string source = new System.Net.WebClient().DownloadString(link);

            ToFollowID = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];

        }
        public void GetDSUserID(string currentUser)
        {
            string pattern = "\"id\": \"(.*)\"";
            string link = "https://www.instagram.com/" + currentUser + "/";
            string source = new System.Net.WebClient().DownloadString(link);

            DSUserID = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }
        public void GetCSRF(string toFollow)
        {
            string pattern = "\"csrf_token\": \"(.*)\"";
            string link = "https://www.instagram.com/" + toFollow + "/";
            string source = new System.Net.WebClient().DownloadString(link);

            GetFollowCSRF = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }
        public string GenerateInfo()
        {
            string prefix = Prefixes()[new Random().Next(0, Prefixes().Length - 1)];
            string suffix = Suffixes()[new Random().Next(0, Suffixes().Length - 1)];

            return $"{prefix}_{suffix}{new Random().Next(0, 50000000)}\n{prefix}{new Random().Next(0, 500000)}@gmail.com\npassword123456";
        }
        public bool RegisterToInsta(string name, string email, string pass, string fullname, string proxy)
        {
            string MyUsername = name;
            string MyEmail = email;
            string MyPassword = pass;
            string MyFullName = fullname;

            if (name != string.Empty && email.Contains("@") && pass != string.Empty)
            {
                try
                {


                    System.Threading.Thread.Sleep(1000);
                    RegisterCSRF();

                    MyFullName = fullname.Replace(" ", "+");
                    MyEmail = MyEmail.Replace("@", "%40");
                    string post = $"email={MyEmail}&password={MyPassword}&username={MyUsername}&first_name={MyFullName}&cb=AQC3WwEvnx3J5gerVDsFBvtZcbvFg1a7QTcoW3hOFij3WWT_Xh8wO8TWg3kQY2RzDf2t9Vzhy13xmJZQA7AdLPDqGrJt6ySjgV8O-s-cDNRWqGXZ4b3O21MsfEuqG0POmFYM45jBa8h-GvZp6ZLghErhFgQDkGgi8TQzHLUHyz6Y5gxCNoOzaR6BR-hRKil4EtvOUdpFpn7GWV7jMFoMcNk7EkhF_gjZmsWyqGFjasDH-A&qs=0%2C15%2C16%2C31%2C107%2C110%2C155%2C157%2C172%2C174%2C185%2C227%2C228%2C233%2C268%2C272%2C287%2C303%2C336%2C337%2C368%2C404%2C419%2C442%2C447%2C473%2C477%2C488%2C491%2C492%2C502%2C513%2C517%2C530%2C531%2C532%2C560%2C599%2C601%2C602%2C659%2C674%7C4%2C11%2C30%2C31%2C37%2C55%2C58%2C64%2C82%2C88%2C98%2C111%2C112%2C122%2C143%2C190%2C205%2C206%2C224%2C253%2C280%2C288%2C293%2C341%2C350%2C361%2C371%2C373%2C390%2C402%2C435%2C445%2C471%2C500%2C510%2C556%2C560%2C561%2C596%2C623%2C657%2C822%7C38%2C79%2C86%2C94%2C96%2C99%2C125%2C136%2C142%2C151%2C157%2C172%2C176%2C197%2C228%2C251%2C257%2C267%2C268%2C284%2C290%2C296%2C327%2C361%2C394%2C396%2C397%2C432%2C450%2C451%2C454%2C460%2C514%2C547%2C548%2C554%2C568%2C575%2C613%2C738%2C758%2C790%7C7%2C15%2C26%2C32%2C39%2C56%2C59%2C65%2C81%2C95%2C96%2C130%2C193%2C197%2C208%2C234%2C286%2C297%2C369%2C376%2C389%2C396%2C409%2C452%2C465%2C466%2C487%2C504%2C550%2C551%2C560%2C563%2C565%2C567%2C576%2C583%2C596%2C613%2C619%2C626%2C659%2C757%7C4%2C14%2C27%2C70%2C89%2C96%2C109%2C119%2C160%2C161%2C162%2C192%2C193%2C222%2C223%2C246%2C269%2C278%2C284%2C297%2C317%2C329%2C342%2C346%2C354%2C413%2C434%2C465%2C490%2C498%2C516%2C545%2C555%2C560%2C564%2C590%2C594%2C596%2C604%2C639%2C718%2C819%7C2%2C29%2C52%2C60%2C80%2C82%2C112%2C116%2C118%2C121%2C122%2C124%2C140%2C201%2C230%2C233%2C236%2C281%2C301%2C313%2C324%2C334%2C373%2C392%2C428%2C431%2C471%2C475%2C480%2C499%2C508%2C529%2C532%2C533%2C536%2C546%2C556%2C591%2C599%2C615%2C624%2C737%7C50%2C52%2C58%2C84%2C85%2C95%2C100%2C140%2C147%2C152%2C185%2C192%2C197%2C221%2C226%2C230%2C250%2C262%2C344%2C354%2C356%2C380%2C423%2C428%2C436%2C437%2C451%2C463%2C476%2C483%2C491%2C496%2C514%2C516%2C522%2C528%2C568%2C577%2C655%2C703%2C726%2C798&guid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/");
                    request.Method = "POST";
                    request.Accept = "*/*";
                    if (proxy != string.Empty)
                    {
                        string IP = proxy.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                        int Port = Int32.Parse(proxy.Split(new string[] { ":" }, StringSplitOptions.None)[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        request.Proxy = myProxy;
                    }
                    request.KeepAlive = true;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    SetRandomUA(request);
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetRegisterCSRF);
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid=IGSCcc9720afdb44b0edb6a99082a45278a5ed788ad9a048ef7a9d8ac225f4e8de5e%3A3gQYCw5bUmzqRoOLprHVAXtFCGMBbT6L%3A%7B%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1467167986%7D%7D; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetRegisterCSRF}");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    //if (html.Contains("\"account_created\": true")) { Console.WriteLine($"{MyEmail}:{MyPassword}"); }
                    if (html.Contains("\"account_created\": true"))
                    {
                        Console.WriteLine($"{html} || {MyUsername}:{MyPassword}");
                        File.AppendAllText(GetAccountsFile, $"{MyUsername}:{MyPassword}{Environment.NewLine}");
                        int count = File.ReadAllLines(GetAccountsFile).Length;
                        Console.WriteLine("count: " + count);
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(60));
                    Console.WriteLine("Exception Thrown");
                    return false;
                }
            }
            else return false;
        }
        public void SetRandomUA(HttpWebRequest request)
        {
            int Select = new Random().Next(0, UAs.Length - 1);
            string UserAgent = UAs[Select];
            request.UserAgent = UserAgent;
        }
        public void SetSessionID(HttpWebResponse response)
        {
            var cookieTitle = "sessionid";
            var cookie = response.Headers.GetValues("Set-Cookie").First(x => x.StartsWith(cookieTitle));
            SessionIDFromLogin = cookie.Split(new string[] { "sessionid=" }, StringSplitOptions.None)[1];
        }
        public enum BottingType
        {
            RegisterFirst, Premade
        }
        public bool Login(string user, string pass)
        {
            CSRFLogon();
            string post = $"username={user}&password={pass}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/login/ajax/");
            request.KeepAlive = true;
            request.Host = "www.instagram.com";
            SetRandomUA(request);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            request.Accept = "*/*";
            request.Referer = "https://www.instagram.com/accounts/login/";
            request.ProtocolVersion = HttpVersion.Version10;
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetLoginCSRF}");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", GetLoginCSRF);
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.Headers.Add("Origin", "https://www.instagram.com");
            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

            if (html.Contains("\"authenticated\": true"))
            {
                SetSessionID(response);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Follow(string user, int amount, BottingType type, string proxy)
        {
            for (int i = 0; i < amount; i++)
            {
                string currentUser = string.Empty;
                string currentPass = string.Empty;

                if (type == BottingType.Premade)
                {
                    if (GetAccountsFile != string.Empty)
                    {
                        if (!(File.ReadAllLines(GetAccountsFile).Length >= amount))
                        {
                            return;
                        }

                        currentUser = File.ReadAllLines(GetAccountsFile)[i].Split(':')[0];
                        currentPass = File.ReadAllLines(GetAccountsFile)[i].Split(':')[1];

                    }
                }
                else
                {
                    currentUser = GenerateInfo().Split('\n')[0];
                    string currentEmail = GenerateInfo().Split('\n')[1];
                    currentPass = GenerateInfo().Split('\n')[2];
                    string currentFullName = "Hello There";

                    if (!RegisterToInsta(currentUser, currentEmail, currentPass, currentFullName, proxy))
                    {
                        return;
                    }
                }

                if (Login(currentUser, currentPass))
                {

                    System.Threading.Thread.Sleep(1000);
                    string toFollow = "https://www.instagram.com/" + user + "/";
                    GetDSUserID(currentUser);
                    GetToFollowID(user);
                    GetCSRF(user);
                    string csrf = GetFollowCSRF;
                    Console.WriteLine(DSUserID);
                    Console.WriteLine(ToFollowID);
                    Console.WriteLine(GetFollowCSRF);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/friendships/" + ToFollowID + "/follow/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    if (proxy != string.Empty)
                    {
                        string IP = proxy.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                        int Port = Int32.Parse(proxy.Split(new string[] { ":" }, StringSplitOptions.None)[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        request.Proxy = myProxy;
                    }
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    request.Accept = "*/*";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    SetRandomUA(request);
                    request.Headers.Add("X-CSRFToken", GetFollowCSRF);
                    request.Referer = "https://www.instagram.com/" + user + "/";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    Console.WriteLine(SessionIDFromLogin);
                    request.Headers.Add("Cookie", $"sessionid={SessionIDFromLogin}; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetFollowCSRF}; ds_user_id={DSUserID}");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Console.WriteLine(html);
                }
                else
                {
                    throw new Exception($"Login for {currentUser}:{currentPass} failed");
                }
            }
        }
        public string GetID(string post)
        {
            string source = new System.Net.WebClient().DownloadString(post);
            string ID = string.Empty;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            var content = doc.DocumentNode
            .Descendants("meta")
            .Where(n => n.Attributes["property"] != null && n.Attributes["property"].Value == "al:ios:url")
            .Select(n => n.Attributes["content"].Value)
            .First();
            StringBuilder sb = new StringBuilder();
            for (int i = 21, n = content.Length; i < n; i++)
            {
                sb.Append(content[i]);
            }
            ID = sb.ToString();
            return ID;
        }
        public string GetLikeCSRFToken(string photoUrl)
        {
            string pattern = "\"csrf_token\": \"(.*)\"";
            string link = photoUrl;
            string source = new System.Net.WebClient().DownloadString(link);

            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }
        public void LikePhotos(string photoURL, int amountOfLikes, BottingType type, string proxy)
        {
            for (int i = 0; i < amountOfLikes; i++)
            {
                string currentUser = string.Empty;
                string currentPass = string.Empty;

                if (type == BottingType.Premade)
                {
                    if (GetAccountsFile != string.Empty)
                    {
                        if (!(File.ReadAllLines(GetAccountsFile).Length >= amountOfLikes))
                        {
                            return;
                        }

                        currentUser = File.ReadAllLines(GetAccountsFile)[i].Split(':')[0];
                        currentPass = File.ReadAllLines(GetAccountsFile)[i].Split(':')[1];

                    }
                }
                else
                {
                    currentUser = GenerateInfo().Split('\n')[0];
                    string currentEmail = GenerateInfo().Split('\n')[1];
                    currentPass = GenerateInfo().Split('\n')[2];
                    string currentFullName = "Hello There";

                    if (!RegisterToInsta(currentUser, currentEmail, currentPass, currentFullName, proxy))
                    {
                        return;
                    }
                }

                if (Login(currentUser, currentPass))
                {
                    System.Threading.Thread.Sleep(1000);
                    GetDSUserID(currentUser);
                    GetLikeCSRF = GetLikeCSRFToken(photoURL);
                    GetPhotoID = GetID(photoURL);
                    // Console.WriteLine("PHOTOID: " + GetPhotoID);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/likes/{GetPhotoID}/like/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    if (proxy != string.Empty)
                    {
                        string IP = proxy.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                        int Port = Int32.Parse(proxy.Split(new string[] { ":" }, StringSplitOptions.None)[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        request.Proxy = myProxy;
                    }
                    request.KeepAlive = true;
                    SetRandomUA(request);
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = photoURL;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetLikeCSRF);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={SessionIDFromLogin}; csrftoken={GetLikeCSRF}; ig_pr=1; ig_vw=1160");

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(html);
                    if (html.Contains("{\"status\": \"ok\"}"))
                    {
                        Console.WriteLine("Like given");
                    }
                    else Console.WriteLine("Not given, you dun fucked up!");
                }
                else throw new Exception($"Login failed for {currentUser}:{currentPass}");
            }
        }
        public void Comment(string photoURL, int Amount, string Comment, BottingType type, string proxy)
        {
            for (int i = 0; i < Amount; i++)
            {
                string currentUser = string.Empty;
                string currentPass = string.Empty;

                if (type == BottingType.Premade)
                {
                    if (GetAccountsFile != string.Empty)
                    {
                        if (!(File.ReadAllLines(GetAccountsFile).Length >= Amount))
                        {
                            return;
                        }

                        currentUser = File.ReadAllLines(GetAccountsFile)[i].Split(':')[0];
                        currentPass = File.ReadAllLines(GetAccountsFile)[i].Split(':')[1];

                    }
                }
                else
                {
                    currentUser = GenerateInfo().Split('\n')[0];
                    string currentEmail = GenerateInfo().Split('\n')[1];
                    currentPass = GenerateInfo().Split('\n')[2];
                    string currentFullName = "Hello There";

                    if (!RegisterToInsta(currentUser, currentEmail, currentPass, currentFullName, proxy))
                    {
                        return;
                    }
                }

                if (Login(currentUser, currentPass))
                {

                    if (proxy == string.Empty)
                    {
                        return;
                    }

                    Comment = Comment.Replace(" ", "+");
                    System.Threading.Thread.Sleep(1000);
                    string post = $"comment_text={Comment}";
                    GetDSUserID(currentUser);
                    GetLikeCSRF = GetLikeCSRFToken(photoURL);
                    GetPhotoID = GetID(photoURL);
                    Console.WriteLine("PHOTOID: " + GetPhotoID);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/comments/{GetPhotoID}/add/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    string IP = proxy.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                    int Port = Int32.Parse(proxy.Split(new string[] { ":" }, StringSplitOptions.None)[1]);
                    WebProxy myProxy = new WebProxy(IP, Port);
                    myProxy.BypassProxyOnLocal = true;
                    request.Proxy = myProxy;
                    request.KeepAlive = true;
                    SetRandomUA(request);
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.Accept = "*/*";
                    request.Referer = photoURL;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetLikeCSRF);
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=VlW1MgAEAAEgkDVr8Pa-nokWXqCF; sessionid={SessionIDFromLogin}; csrftoken={GetLikeCSRF}; ig_pr=1; ig_vw=1160");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(html);
                    if (html.Contains("{\"status\": \"ok\"}"))
                    {
                        Console.WriteLine("Like given");
                    }
                    else Console.WriteLine("Not given, you dun fucked up!");
                }
                else throw new Exception($"Login failed for {currentUser}:{currentPass}");
            }
        }
        public enum ReportType : int
        {
            SpamOrScam, HarrasmentOrBullying, SelfHarm, DrugUse, Nudity, GraphicViolence, HateSpeech
        }
        public void Report(string photoURL, int Amount, BottingType type, ReportType reportType, string proxy)
        {
            for (int i = 0; i < Amount; i++)
            {
                string currentUser = string.Empty;
                string currentPass = string.Empty;

                if (type == BottingType.Premade)
                {
                    if (GetAccountsFile != string.Empty)
                    {
                        if (!(File.ReadAllLines(GetAccountsFile).Length >= Amount))
                        {
                            return;
                        }

                        currentUser = File.ReadAllLines(GetAccountsFile)[i].Split(':')[0];
                        currentPass = File.ReadAllLines(GetAccountsFile)[i].Split(':')[1];

                    }
                }
                else
                {
                    currentUser = GenerateInfo().Split('\n')[0];
                    string currentEmail = GenerateInfo().Split('\n')[1];
                    currentPass = GenerateInfo().Split('\n')[2];
                    string currentFullName = "Hello There";

                    if (!RegisterToInsta(currentUser, currentEmail, currentPass, currentFullName, proxy))
                    {
                        return;
                    }
                }

                if (Login(currentUser, currentPass))
                {

                    int report = 0;

                    switch (reportType)
                    {
                        case ReportType.DrugUse:
                            report = 3;
                            break;
                        case ReportType.GraphicViolence:
                            report = 5;
                            break;
                        case ReportType.HarrasmentOrBullying:
                            report = 7;
                            break;
                        case ReportType.HateSpeech:
                            report = 6;
                            break;
                        case ReportType.Nudity:
                            report = 4;
                            break;
                        case ReportType.SelfHarm:
                            report = 2;
                            break;
                        case ReportType.SpamOrScam:
                            report = 1;
                            break;
                    }
                    GetDSUserID(currentUser);
                    GetLikeCSRF = GetLikeCSRFToken(photoURL);
                    GetPhotoID = GetID(photoURL);

                    string post = $"reason_id={report}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/media/{GetPhotoID}/flag/");
                    request.Method = "POST";
                    request.Accept = "*/*";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    SetRandomUA(request);
                    if (proxy != string.Empty)
                    {
                        string IP = proxy.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                        int Port = Int32.Parse(proxy.Split(new string[] { ":" }, StringSplitOptions.None)[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        request.Proxy = myProxy;
                    }
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetLikeCSRF);
                    request.Referer = photoURL;
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={GetLikeCSRF}; ds_user_id={DSUserID}");
                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;
                    Stream requestStream = request.GetRequestStream();

                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(html);
                }
                else throw new Exception($"Login Failed For {currentUser}:{currentPass}");
            }
        }
        public string CheckCSRF(string webPage)
        {
            string source = new System.Net.WebClient().DownloadString(webPage);
            string pattern = "\"csrf_token\": \"(.*)\"";

            string csrf = string.Empty;

            foreach (Match item in (new Regex(pattern).Matches(source)))
            {
                csrf = item.Groups[1].Value.Split('"')[0];
            }

            return csrf;
        }
        public bool CheckUsername(string user)
        {
            string post = "email=abc%40gmail.com&password=123&username=" + user + "&first_name=john+doe";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/attempt/");
            CheckingCSRF = CheckCSRF("https://www.instagram.com/");
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "*/*";
            request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", CheckingCSRF);
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid=IGSC65ec3226d0e4e12dfcba7be6cc5b75e818daa339e7cdf167a54fc1d1196d4096%3AWtMcnzQLD6RRRtPiLrlYlrWXkyZQmey6%3A%7B%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466768354%7D%7D; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={CheckingCSRF}");

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return !html.Contains("\"errors\": {\"username\":");
        }
        public bool TurboUsername(string usernameToTake, string currentUser, string newName, string newEmail, string newPhoneNumber)
        {


            TurboCSRF = CheckCSRF("https://www.instagram.com/accounts/edit/");
            GetDSUserID(currentUser);
            newEmail = newEmail.Replace("@", "%40");
            newName = newName.Replace(" ", "+");
            Console.WriteLine(currentUser);
            Console.WriteLine(newEmail);
            Console.WriteLine(newName);
            string post = $"first_name={newName}&email={newEmail}&username={usernameToTake}&phone_number={newPhoneNumber}&gender=3&biography=&external_url=&chaining_enabled=on";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/edit/");
            request.Method = "POST";
            request.Accept = "*/*";
            request.Host = "www.instagram.com";
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", TurboCSRF);
            request.KeepAlive = true;
            request.Referer = "https://www.instagram.com/accounts/edit/";
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            Console.WriteLine(SessionIDFromLogin);
            Console.WriteLine(DSUserID);
            Console.WriteLine(TurboCSRF);
            request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={TurboCSRF}; ds_user_id={DSUserID}");

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (html.Contains("ok"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region AccountScraper
        public bool UserIsPrivate(string user)
        {
            string pattern = "\"is_private\": (.*)";
            string source = new System.Net.WebClient().DownloadString("http://www.instagram.com/" + user);
            string isPrivate = Regex.Matches(source, pattern)[0].Groups[1].Value.Split(',')[0];

            return isPrivate.Contains("true");
        }
        public string GetFollowerCount(string user)
        {
            string pattern = "\"followed_by\": {\"count\": (.*)}";
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('}')[0];
        }
        public string GetUserID(string user)
        {
            string pattern = "\"id\": \"(.*)\"";
            string source = new System.Net.WebClient().DownloadString("http://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }
        public string GetFollowingCount(string user)
        {
            string pattern = "{\"count\": (.*)}";
            string source = new System.Net.WebClient().DownloadString("https://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('}')[0];
        }
        public string GetBio(string user)
        {
            string pattern = "\"biography\": \"(.*)\"";
            string source = new System.Net.WebClient().DownloadString("http://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }
        public string GetProfilePic(string user)
        {
            string pattern = "\"profile_pic_url\": \"(.*)\"";
            string source = new System.Net.WebClient().DownloadString("http://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }
        public string GetFullName(string user)
        {
            string pattern = "\"full_name\": \"(.*)\"";
            string source = new System.Net.WebClient().DownloadString("http://www.instagram.com/" + user);
            if (Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0] != null)
            {
                return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
            } else
            {
                return "Empty";
            }
        }
        #endregion


    }
}
 