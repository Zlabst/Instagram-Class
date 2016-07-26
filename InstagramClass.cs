using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Linq;
using System.Text;
namespace InstaBot
{
    //(っ◔◡◔)っ ♥ InstaBot ♥ - ˜”*°•.˜”*°• Instagram Class •°*”˜.•°*”˜
    //Made by @XeDev_Chris & @Sdkayyyy
    //Please don't leech (put credits)
    //github.com/XeDevChris
    public class InstagramClass
    {

        internal string GetFollowCSRF;
        internal string GetLoginCSRF;
        internal string GetRegisterCSRF;
        internal string SessionIDFromLogin;
        internal string DSUserID;
        internal string ToFollowID;
        internal string GetAccountsFile;
        internal string GetPhotoID;
        internal string GetLikeCSRF;
        internal string CheckingCSRF;
        internal string TurboCSRF;
        public WebClient client = new WebClient();

        public string[] UAs()
        {
            return client.DownloadString("http://pastebin.com/raw/mcfXxS5v").Split('\n');
        }

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
                "Fighter"
            };
        }

        public void GetToFollowID(string toFollow)
        {
            string pattern = "\"id\": \"(.*)\"";
            string link = "https://www.instagram.com/" + toFollow + "/";
            string source = client.DownloadString(link);

            ToFollowID = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];

        }

        public void GetDSUserID(string currentUser)
        {
            string pattern = "\"id\": \"(.*)\"";
            string link = "https://www.instagram.com/" + currentUser + "/";
            string source = client.DownloadString(link);

            DSUserID = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }

        public string GetCSRF(string page)
        {
            string pattern = "\"csrf_token\": \"(.*)\"";
            string source = client.DownloadString(page);

            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
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
                    GetRegisterCSRF = GetCSRF("http://www.instagram.com/");

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
            int Select = new Random().Next(0, UAs().Length - 1);
            string UserAgent = UAs()[Select];
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
            GetLoginCSRF = GetCSRF("http://www.instagram.com/accounts/login");
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
                    GetFollowCSRF = GetCSRF(toFollow);
                    string csrf = GetFollowCSRF;
                    Console.WriteLine(DSUserID);
                    Console.WriteLine(ToFollowID);
                    Console.WriteLine(GetFollowCSRF);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/web/friendships/" + ToFollowID + "/follow/");
                    if (proxy != string.Empty)
                    {
                        string IP = proxy.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                        int Port = Int32.Parse(proxy.Split(new string[] { ":" }, StringSplitOptions.None)[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        request.Proxy = myProxy;
                    }
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    request.Accept = "*/*";
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                    request.Headers.Add("X-CSRFToken", csrf);
                    request.Referer = toFollow;
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
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
            string source = client.DownloadString(post);
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
            string source = client.DownloadString(link);

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
                    GetLikeCSRF = GetCSRF(photoURL);
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
                    GetLikeCSRF = GetCSRF(photoURL);
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

        public enum ReportType
        {
            Spam = 1,
            Harm = 2,
            Drugs = 3,
            Nudity = 4,
            Violence = 5,
            Hate = 6,
            Bullying = 7
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
                        case ReportType.Drugs:
                            report = 3;
                            break;
                        case ReportType.Violence:
                            report = 5;
                            break;
                        case ReportType.Bullying:
                            report = 7;
                            break;
                        case ReportType.Hate:
                            report = 6;
                            break;
                        case ReportType.Nudity:
                            report = 4;
                            break;
                        case ReportType.Harm:
                            report = 2;
                            break;
                        case ReportType.Spam:
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

        public bool CheckUsername(string user)
        {
            string post = "email=abc%40gmail.com&password=123&username=" + user + "&first_name=john+doe";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/attempt/");
            CheckingCSRF = GetCSRF("https://www.instagram.com/");
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

        public bool TurboUsername(string usernameToTake, string currentUser, string currentPass)
        {
            if (Login(currentUser, currentPass))
            {
                TurboCSRF = GetCSRF("https://www.instagram.com/accounts/edit/");
                GetDSUserID(currentUser);
                string post = $"first_name={usernameToTake}&email=turboed{new Random().Next(0, 1000)}%40gmail.com&username={usernameToTake}&phone_number=&gender=3&biography=&external_url=&chaining_enabled=on";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/edit/");
                request.Method = "POST";
                request.Accept = "*/*";
                request.Host = "www.instagram.com";
                request.Headers.Add("Origin", "https://www.instagram.com");
                request.Headers.Add("X-Instagram-AJAX", "1");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("X-CSRFToken", TurboCSRF);
                request.KeepAlive = true;
                request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={TurboCSRF}");
                request.ProtocolVersion = HttpVersion.Version10;
                request.Referer = "https://www.instagram.com/accounts/edit/?wo=1";
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}%3AVg99013lSewwdHbgutSa9193NbUuE9pV%3A%7B%22_token_ver%22%3A2%2C%22_auth_user_id%22%3A3455245393%2C%22_token%22%3A%223455245393%3Afw4QzyCRWEMCINbv0bMZTngjyPyxXKDk%3A8a1297388f0919512f629d76e15c15000479f8bc787a8a4389f1d89e2557781a%22%2C%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466832736%7D%2C%22_auth_user_backend%22%3A%22accounts.backends.CaseInsensitiveModelBackend%22%2C%22last_refreshed%22%3A1466833145.817771%2C%22_platform%22%3A4%7D; s_network=; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={TurboCSRF}; ds_user_id={DSUserID}");
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
            else throw new Exception("failed to login");
        }

        public bool UserIsPrivate(string user)
        {
            string pattern = "\"is_private\": (.*)";
            string source = client.DownloadString("http://www.instagram.com/" + user);
            string isPrivate = Regex.Matches(source, pattern)[0].Groups[1].Value.Split(',')[0];

            return isPrivate.Contains("true");
        }

        public string GetFollowerCount(string user)
        {
            string pattern = "\"followed_by\": {\"count\": (.*)}";
            string source = client.DownloadString("https://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('}')[0];
        }

        public string GetUserID(string user)
        {
            string pattern = "\"id\": \"(.*)\"";
            string source = client.DownloadString("http://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }

        public string GetFollowingCount(string user)
        {
            string pattern = "{\"count\": (.*)}";
            string source = client.DownloadString("https://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('}')[0];
        }

        public string GetBio(string user)
        {
            string pattern = "\"biography\": \"(.*)\"";
            string source = client.DownloadString("http://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }

        public string GetProfilePic(string user)
        {
            string pattern = "\"profile_pic_url\": \"(.*)\"";
            string source = client.DownloadString("http://www.instagram.com/" + user);
            return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }

        public string GetFullName(string user)
        {
            string pattern = "\"full_name\": \"(.*)\"";
            string source = client.DownloadString("http://www.instagram.com/" + user);
            if (Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0] != null)
            {
                return Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
            } else
            {
                return "Empty";
            }
        }


    }
}
 