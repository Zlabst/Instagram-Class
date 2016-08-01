using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace InstaBot
{

    public class InstagramClass
    {
        /// <summary>
        /// Instagram Class By @teh_distance || TehDevelopment
        /// You Need Private Proxies
        /// Don't be a leecher like @xex.servicess, give credits :)
        /// https://github.com/tehdistance/Instagram-Class
        /// If you make something with this and post about it, please tag me! (@teh_distance)
        /// </summary>

        #region variables
        private string GetFollowCSRF = string.Empty;
        private string GetLoginCSRF = string.Empty;
        private string GetRegisterCSRF = string.Empty;
        private string SessionIDFromLogin = string.Empty;
        private string DSUserID = string.Empty;
        private string ToFollowID = string.Empty;
        private string GetAccountsFile = string.Empty;
        private string GetPhotoID = string.Empty;
        private string GetLikeCSRF = string.Empty;
        private string GetCommentCSRF = string.Empty;
        private string CheckCSRF = string.Empty;
        private string TurboCSRF = string.Empty;
        private string GetReportCSRF = string.Empty;
        private WebClient client = new WebClient();
        public bool _debug = false;
        #endregion

        #region Random UserAgents

        private string[] UserAgents()
        {
            return client.DownloadString("http://pastebin.com/raw/mcfXxS5v").Split('\n');
        }
        #endregion

        #region NameGenerator
        private string[] Prefixes()
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
        private string[] Suffixes()
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

        #region Generate Info 
        private string GenerateUsername()
        {
            int prefixIndex = new Random().Next(0, Prefixes().Length);
            int suffixIndex = new Random().Next(0, Suffixes().Length);

            string prefix = Prefixes()[prefixIndex];
            string suffix = Suffixes()[suffixIndex];

            return $"{prefix}{suffix}{new Random().Next(0, 50000000)}";
        }

        private string GeneratePassword()
        {
            return $"PaSsWoRd{new Random().Next(0, 500000000)}";
        }

        private string GenerateEmail()
        {
            int index = new Random().Next(0, Prefixes().Length);
            return $"{Prefixes()[index]}{new Random().Next(0, 1000000)}@gmail.com";
        }

        private string GenerateFullName()
        {
            return "suh dudddddeeeee";
        }

        #endregion

        #region functions
        public enum ProxySettings
        {
            CheckProxy, DontCheck, NoProxy
        }

        private void GetToFollowID(string toFollow, string proxy, ProxySettings settings)
        {
            string source = string.Empty;
            string pattern = "\"id\": \"(.*)\"";
            string link = "https://www.instagram.com/" + toFollow + "/";

            if (settings == ProxySettings.NoProxy || proxy == string.Empty)
            {
                source = client.DownloadString(link);
            } else
            {
                if (settings == ProxySettings.DontCheck)
                {
                    WebClient myClient = new WebClient();
                    string[] splitter = proxy.Split(':');
                    string IP = splitter[0];
                    Int32 Port = Int32.Parse(splitter[1]);
                    WebProxy myProxy = new WebProxy(IP, Port);
                    myProxy.BypassProxyOnLocal = true;
                    myClient.Proxy = myProxy;
                    source = myClient.DownloadString(link);
                } else if (settings == ProxySettings.CheckProxy)
                {
                    if (CheckProxy(proxy, MethodType.None))
                    {
                        WebClient myClient = new WebClient();
                        string[] splitter = proxy.Split(':');
                        string IP = splitter[0];
                        Int32 Port = Int32.Parse(splitter[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        myClient.Proxy = myProxy;
                        source = myClient.DownloadString(link);
                    }
                }
            }

            ToFollowID = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];

        }

        private void GetDSUserID(string currentUser, string proxy, ProxySettings settings)
        {
            string pattern = "\"id\": \"(.*)\"";
            string link = "https://www.instagram.com/" + currentUser + "/";
            string source = string.Empty;

            if (proxy == string.Empty || settings == ProxySettings.NoProxy)
            {
                source = client.DownloadString(link);
            } else
            {
                if (settings == ProxySettings.DontCheck)
                {
                    WebClient myClient = new WebClient();
                    string[] splitter = proxy.Split(':');
                    string IP = splitter[0];
                    Int32 Port = Int32.Parse(splitter[1]);
                    WebProxy myProxy = new WebProxy(IP, Port);
                    myProxy.BypassProxyOnLocal = true;
                    myClient.Proxy = myProxy;
                    source = myClient.DownloadString(link);
                } else if (settings == ProxySettings.CheckProxy)
                {
                    if (CheckProxy(proxy, MethodType.None))
                    {
                        WebClient myClient = new WebClient();
                        string[] splitter = proxy.Split(':');
                        string IP = splitter[0];
                        Int32 Port = Int32.Parse(splitter[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        myClient.Proxy = myProxy;
                        source = myClient.DownloadString(link);
                    }
                }
            }

            DSUserID = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
        }

        private void SetSessionID(HttpWebResponse response)
        {
            var cookieTitle = "sessionid";
            var cookie = response.Headers.GetValues("Set-Cookie").First(x => x.StartsWith(cookieTitle));
            SessionIDFromLogin = cookie.Split(new string[] { "sessionid=" }, StringSplitOptions.None)[1];
        }

        public string GetID(string post, string proxy, ProxySettings settings)
        {
            string source = string.Empty;

            if (settings == ProxySettings.NoProxy || proxy == string.Empty)
            {
                source = client.DownloadString(post);
            } else
            {
                if (settings == ProxySettings.DontCheck)
                {
                    WebClient myClient = new WebClient();
                    string[] splitter = proxy.Split(':');
                    string IP = splitter[0];
                    Int32 Port = Int32.Parse(splitter[1]);
                    WebProxy myProxy = new WebProxy(IP, Port);
                    myProxy.BypassProxyOnLocal = true;
                    myClient.Proxy = myProxy;
                    source = myClient.DownloadString(post);
                } else if (settings == ProxySettings.CheckProxy)
                {
                    if (CheckProxy(proxy, MethodType.None))
                    {
                        WebClient myClient = new WebClient();
                        string[] splitter = proxy.Split(':');
                        string IP = splitter[0];
                        Int32 Port = Int32.Parse(splitter[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        myClient.Proxy = myProxy;
                        source = myClient.DownloadString(post);
                    }
                }
            }

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

        public enum ReportType : int
        {
            SpamOrScam, HarrasmentOrBullying, SelfHarm, DrugUse, Nudity, GraphicViolence, HateSpeech
        }

        private int GetReportType(ReportType type)
        {
            if (type == ReportType.SpamOrScam)
                return 1;
            else if (type == ReportType.SelfHarm)
                return 2;
            else if (type == ReportType.DrugUse)
                return 3;
            else if (type == ReportType.Nudity)
                return 4;
            else if (type == ReportType.GraphicViolence)
                return 5;
            else if (type == ReportType.HateSpeech)
                return 6;
            else if (type == ReportType.HarrasmentOrBullying)
                return 7;
            else return 0;
        }

        private void Write(string text)
        {
            if (_debug)
            {
                Console.WriteLine(text);
            }
            else Console.WriteLine("Debugging is not enabled, please set value \"_debug\" -> true");
        }

        private string GetCSRF(string url, string proxy, ProxySettings settings)
        {
            string csrf = string.Empty;
            if (proxy == string.Empty || settings == ProxySettings.NoProxy)
            {
                string pattern = "\"csrf_token\": \"(.*)\"";
                string source = client.DownloadString(url);

                csrf = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
            } else
            {
                if (settings == ProxySettings.DontCheck)
                {
                    WebClient myClient = new WebClient();
                    string[] splitter = proxy.Split(':');
                    string IP = splitter[0];
                    Int32 Port = Int32.Parse(splitter[1]);
                    WebProxy myProxy = new WebProxy(IP, Port);
                    myProxy.BypassProxyOnLocal = true;
                    myClient.Proxy = myProxy;
                    string pattern = "\"csrf_token\": \"(.*)\"";
                    string source = myClient.DownloadString(url);

                    csrf = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
                } else if (settings == ProxySettings.CheckProxy)
                {
                    if (CheckProxy(proxy, MethodType.None))
                    {
                        WebClient myClient = new WebClient();
                        string[] splitter = proxy.Split(':');
                        string IP = splitter[0];
                        Int32 Port = Int32.Parse(splitter[1]);
                        WebProxy myProxy = new WebProxy(IP, Port);
                        myProxy.BypassProxyOnLocal = true;
                        myClient.Proxy = myProxy;
                        string pattern = "\"csrf_token\": \"(.*)\"";
                        string source = myClient.DownloadString(url);

                        csrf = Regex.Matches(source, pattern)[0].Groups[1].Value.Split('"')[0];
                    }
                }
            }

            return csrf;
        }

        #region ProxyChecker
        public enum MethodType
        {
            Register, Follow, Comment, Like, Report, None
        }

        //this is used for checking proxies (didn't add login as login would require a real user and pass (i didn't want to make one and for someone to change it so it would stop working)
        public bool CheckProxy(string proxy, MethodType method)
        {
            ProxySettings settings = ProxySettings.DontCheck;
            if (method == MethodType.Follow)
            {
                try
                {
                    if (Follow("teh_distance", proxy, settings))
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (method == MethodType.Like)
            {
                try
                {
                    if (Like("https://www.instagram.com/p/BIhDE8pghdy/?taken-by=teh_distance", proxy, settings))
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (method == MethodType.Comment)
            {
                try
                {
                    if (Comment("https://www.instagram.com/p/BIhDE8pghdy/?taken-by=teh_distance", "proxy test for ig bot", proxy, settings))
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (method == MethodType.Report)
            {
                try
                {
                    if (Report("https://www.instagram.com/p/BIhDE8pghdy/?taken-by=teh_distance", ReportType.HarrasmentOrBullying, proxy, settings))
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (method == MethodType.Register)
            {
                try
                {
                    string username = GenerateUsername();
                    string password = GeneratePassword();
                    string email = GenerateEmail();
                    string fullname = GenerateFullName();
                    if (Register(username, password, email, fullname, proxy, settings))
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (method == MethodType.None)
            {
                try
                {
                    WebClient myClient = new WebClient();
                    string[] splitter = proxy.Split(':');
                    string ip = splitter[0];
                    Int32 port = Int32.Parse(splitter[1]);
                    WebProxy myproxy = new WebProxy(ip, port);
                    myproxy.BypassProxyOnLocal = true;
                    myClient.Proxy = myproxy;
                    myClient.DownloadString("http://www.google.com/");
                    return true;
                } catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        public bool Register(string username, string password, string email, string fullname, string proxy, ProxySettings settings)
        {
            if (email.Contains("@"))
                email = email.Replace("@", "%40");
            else return false;

            if (username.Contains(" "))
                return false;

            if (password.Contains(" "))
                password = password.Replace(" ", "+");

            if (fullname.Contains(" "))
                fullname = fullname.Replace(" ", "+");

            string post = $"email={email}&password={password}&username={username}&first_name={fullname}";
            GetRegisterCSRF = GetCSRF("https://www.instagram.com/", proxy, settings);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/");
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            int Select = new Random().Next(0, UserAgents().Length);
            string UserAgent = UserAgents()[Select];
            request.UserAgent = UserAgent;

            if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
            {
                if (settings == ProxySettings.CheckProxy)
                {
                    if (CheckProxy(proxy, MethodType.Register))
                    {
                        string[] splitter = proxy.Split(':');
                        string ip = splitter[0];
                        Int32 port = Int32.Parse(splitter[1]);
                        WebProxy myproxy = new WebProxy(ip, port);
                        myproxy.BypassProxyOnLocal = true;
                        request.Proxy = myproxy;
                        Write($"{proxy} is set");
                    }
                    else
                    {
                        Write($"{proxy} is bad");
                        return false;
                    }
                } else if (settings == ProxySettings.DontCheck)
                {
                    string[] splitter = proxy.Split(':');
                    string ip = splitter[0];
                    Int32 port = Int32.Parse(splitter[1]);
                    WebProxy myproxy = new WebProxy(ip, port);
                    myproxy.BypassProxyOnLocal = true;
                    request.Proxy = myproxy;
                    Write($"{proxy} is set");
                }
            }

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", GetRegisterCSRF);
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
                Write($"{html} | {username}:{password}");
                return true;
            } else if (html.Contains("open proxy"))
            {
                Write($"{proxy} is a public proxy!");
                return false;
            } else
            {
                Write($"{html} | {username}:{password}");
                return false;
            }
        }

        public bool Login(string user, string password, string proxy, ProxySettings settings)
        {
            if (password.Contains(" "))
                password = password.Replace(" ", "+");

            string post = $"username={user}&password={password}";
            GetLoginCSRF = GetCSRF("https://www.instagram.com/accounts/login/", proxy, settings);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/login/ajax/");
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;
            if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
            {
                if (settings == ProxySettings.CheckProxy)
                {
                    if (CheckProxy(proxy, MethodType.None))
                    {
                        string[] splitter = proxy.Split(':');
                        string ip = splitter[0];
                        Int32 port = Int32.Parse(splitter[1]);
                        WebProxy myproxy = new WebProxy(ip, port);
                        myproxy.BypassProxyOnLocal = true;
                        request.Proxy = myproxy;
                        Write($"{proxy} is set");
                    }
                    else
                    {
                        Write($"{proxy} is bad");
                    }
                }
                else if (settings == ProxySettings.DontCheck)
                {
                    string[] splitter = proxy.Split(':');
                    string ip = splitter[0];
                    Int32 port = Int32.Parse(splitter[1]);
                    WebProxy myproxy = new WebProxy(ip, port);
                    myproxy.BypassProxyOnLocal = true;
                    request.Proxy = myproxy;
                    Write($"{proxy} is set");
                }
            }

            int Select = new Random().Next(0, UserAgents().Length);
            string UserAgent = UserAgents()[Select];
            request.UserAgent = UserAgent;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Referer = "https://www.instagram.com/accounts/login/";
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", GetLoginCSRF);
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={GetLoginCSRF}");

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentLength = postBytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Write(html);
            if (html.Contains("\"authenticated\": true"))
            {
                Write($"Login for {user}:{password} sucessful");
                SetSessionID(response);
                Write($"Session ID: {SessionIDFromLogin}");
                return true;
            }
            else if (html.Contains("open proxy"))
            {
                Write($"{proxy} is a public proxy!");
                return false;
            }
            else
            {
                Write($"{html} | Login failed for {user}:{password}");
                return false;
            }
        }

        public bool Follow(string user, string proxy, ProxySettings settings)
        {
            string currentUser = GenerateUsername();
            string currentPass = GeneratePassword();
            string currentEmail = GenerateEmail();
            string currentFullName = GenerateFullName();

            if (Register(currentUser, currentPass, currentEmail, currentFullName, proxy, settings))
            {
                Write($"Registered Account");
                if (Login(currentUser, currentPass, proxy, settings))
                {
                    Write("Logged In To Account");
                    GetFollowCSRF = GetCSRF($"http://www.instagram.com/{user}", proxy, settings);
                    GetToFollowID(user, proxy, settings);
                    GetDSUserID(currentUser, proxy, settings);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/friendships/{ToFollowID}/follow/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;
                    if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
                    {
                        if (settings == ProxySettings.CheckProxy)
                        {
                            if (CheckProxy(proxy, MethodType.Follow))
                            {
                                string[] splitter = proxy.Split(':');
                                string ip = splitter[0];
                                Int32 port = Int32.Parse(splitter[1]);
                                WebProxy myproxy = new WebProxy(ip, port);
                                myproxy.BypassProxyOnLocal = true;
                                request.Proxy = myproxy;
                                Write($"{proxy} is set");
                            }
                            else
                            {
                                Write($"{proxy} is bad");
                            }
                        }
                        else if (settings == ProxySettings.DontCheck)
                        {
                            string[] splitter = proxy.Split(':');
                            string ip = splitter[0];
                            Int32 port = Int32.Parse(splitter[1]);
                            WebProxy myproxy = new WebProxy(ip, port);
                            myproxy.BypassProxyOnLocal = true;
                            request.Proxy = myproxy;
                            Write($"{proxy} is set");
                        }
                    }

                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    int Select = new Random().Next(0, UserAgents().Length);
                    string UserAgent = UserAgents()[Select];
                    request.UserAgent = UserAgent;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "*/*";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetFollowCSRF);
                    request.Referer = $"https://www.instagram.com/{user}/";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={GetFollowCSRF}; ds_user_id={DSUserID}");

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Write(html);

                    if (html.Contains("\"result\": \"following\""))
                    {
                        Write("user followed");
                        return true;
                    }
                    else if (html.Contains("open proxy"))
                    {
                        Write($"{proxy} is a public proxy!");
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public bool Like(string photoURL, string proxy, ProxySettings settings)
        {
            string currentUser = GenerateUsername();
            string currentPass = GeneratePassword();
            string currentEmail = GenerateEmail();
            string currentFullName = GenerateFullName();

            if (Register(currentUser, currentPass, currentEmail, currentFullName, proxy, settings))
            {
                Write($"Registered Account");
                if (Login(currentUser, currentPass, proxy, settings))
                {
                    GetPhotoID = GetID(photoURL, proxy, settings);
                    GetDSUserID(currentUser, proxy, settings);
                    GetLikeCSRF = GetCSRF(photoURL, proxy, settings);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/likes/{GetPhotoID}/like/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;
                    request.ContentLength = 0;

                    if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
                    {
                        if (settings == ProxySettings.CheckProxy)
                        {
                            if (CheckProxy(proxy, MethodType.Like))
                            {
                                string[] splitter = proxy.Split(':');
                                string ip = splitter[0];
                                Int32 port = Int32.Parse(splitter[1]);
                                WebProxy myproxy = new WebProxy(ip, port);
                                myproxy.BypassProxyOnLocal = true;
                                request.Proxy = myproxy;
                                Write($"{proxy} is set");
                            }
                            else
                            {
                                Write($"{proxy} is bad");
                            }
                        }
                        else if (settings == ProxySettings.DontCheck)
                        {
                            string[] splitter = proxy.Split(':');
                            string ip = splitter[0];
                            Int32 port = Int32.Parse(splitter[1]);
                            WebProxy myproxy = new WebProxy(ip, port);
                            myproxy.BypassProxyOnLocal = true;
                            request.Proxy = myproxy;
                            Write($"{proxy} is set");
                        }
                    }

                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    int Select = new Random().Next(0, UserAgents().Length);
                    string UserAgent = UserAgents()[Select];
                    request.UserAgent = UserAgent;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "*/*";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetLikeCSRF);
                    request.Referer = photoURL;
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetLikeCSRF}; s_network=; ds_user_id={DSUserID}");

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Write(html);

                    if (html.Contains("{\"status\": \"ok\"}"))
                    {
                        Write("Liked Photo");
                        return true;
                    }
                    else if (html.Contains("open proxy"))
                    {
                        Write($"{proxy} is a public proxy!");
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
            else return false;
        }

        public bool Comment(string photoURL, string text, string proxy, ProxySettings settings)
        {
            string currentUser = GenerateUsername();
            string currentPass = GeneratePassword();
            string currentEmail = GenerateEmail();
            string currentFullName = GenerateFullName();

            if (Register(currentUser, currentPass, currentEmail, currentFullName, proxy, settings))
            {
                Write($"Registered Account");
                if (Login(currentUser, currentPass, proxy, settings))
                {
                    GetDSUserID(currentUser, proxy, settings);
                    GetPhotoID = GetID(photoURL, proxy, settings);
                    GetCommentCSRF = GetCSRF(photoURL, proxy, settings);

                    if (text.Contains(" "))
                        text = text.Replace(" ", "+");

                    if (text.Contains("@"))
                        text = text.Replace("@", "%40");

                    string post = $"comment_text={text}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/web/comments/{GetPhotoID}/add/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;

                    if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
                    {
                        if (settings == ProxySettings.CheckProxy)
                        {
                            if (CheckProxy(proxy, MethodType.Comment))
                            {
                                string[] splitter = proxy.Split(':');
                                string ip = splitter[0];
                                Int32 port = Int32.Parse(splitter[1]);
                                WebProxy myproxy = new WebProxy(ip, port);
                                myproxy.BypassProxyOnLocal = true;
                                request.Proxy = myproxy;
                                Write($"{proxy} is set");
                            }
                            else
                            {
                                Write($"{proxy} is bad");
                            }
                        }
                        else if (settings == ProxySettings.DontCheck)
                        {
                            string[] splitter = proxy.Split(':');
                            string ip = splitter[0];
                            Int32 port = Int32.Parse(splitter[1]);
                            WebProxy myproxy = new WebProxy(ip, port);
                            myproxy.BypassProxyOnLocal = true;
                            request.Proxy = myproxy;
                            Write($"{proxy} is set");
                        }
                    }

                    int Select = new Random().Next(0, UserAgents().Length);
                    string UserAgent = UserAgents()[Select];
                    request.UserAgent = UserAgent;
                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "*/*";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetCommentCSRF);
                    request.Referer = photoURL;
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; csrftoken={GetCommentCSRF}; s_network=; ds_user_id={DSUserID}");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Write(html);

                    if (html.Contains("\"status\": \"ok\""))
                    {
                        Write("comment given");
                        return true;
                    }
                    else if (html.Contains("open proxy"))
                    {
                        Write($"{proxy} is a public proxy!");
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
            else return false;
        }

        public bool Report(string photoURL, ReportType type, string proxy, ProxySettings settings)
        {
            string currentUser = GenerateUsername();
            string currentPass = GeneratePassword();
            string currentEmail = GenerateEmail();
            string currentFullName = GenerateFullName();

            if (Register(currentUser, currentPass, currentEmail, currentFullName, proxy, settings))
            {
                Write($"Registered Account");
                if (Login(currentUser, currentPass, proxy, settings))
                {
                    string post = $"reason_id={GetReportType(type)}";
                    GetPhotoID = GetID(photoURL, proxy, settings);
                    GetDSUserID(currentUser, proxy, settings);
                    GetReportCSRF = GetCSRF(photoURL, proxy, settings);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.instagram.com/media/{GetPhotoID}/flag/");
                    request.Method = "POST";
                    request.Host = "www.instagram.com";
                    request.KeepAlive = true;

                    if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
                    {
                        if (settings == ProxySettings.CheckProxy)
                        {
                            if (CheckProxy(proxy, MethodType.Report))
                            {
                                string[] splitter = proxy.Split(':');
                                string ip = splitter[0];
                                Int32 port = Int32.Parse(splitter[1]);
                                WebProxy myproxy = new WebProxy(ip, port);
                                myproxy.BypassProxyOnLocal = true;
                                request.Proxy = myproxy;
                                Write($"{proxy} is set");
                            }
                            else
                            {
                                Write($"{proxy} is bad");
                            }
                        }
                        else if (settings == ProxySettings.DontCheck)
                        {
                            string[] splitter = proxy.Split(':');
                            string ip = splitter[0];
                            Int32 port = Int32.Parse(splitter[1]);
                            WebProxy myproxy = new WebProxy(ip, port);
                            myproxy.BypassProxyOnLocal = true;
                            request.Proxy = myproxy;
                            Write($"{proxy} is set");
                        }
                    }

                    int Select = new Random().Next(0, UserAgents().Length);
                    string UserAgent = UserAgents()[Select];
                    request.UserAgent = UserAgent;

                    request.Headers.Add("Origin", "https://www.instagram.com");
                    request.Headers.Add("X-Instagram-AJAX", "1");
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "*/*";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-CSRFToken", GetReportCSRF);
                    request.Referer = photoURL;
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={GetReportCSRF}; ds_user_id={DSUserID}");

                    byte[] postBytes = Encoding.ASCII.GetBytes(post);
                    request.ContentLength = postBytes.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postBytes, 0, postBytes.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Write(html);

                    if (html.Contains("\"status\": \"ok\""))
                    {
                        Write("report given");
                        return true;
                    }
                    else if (html.Contains("open proxy"))
                    {
                        Write($"{proxy} is a public proxy!");
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
            else return false;
        }

        public bool Turbo(string currentUser, string currentPass, string userToTake, string proxy, ProxySettings settings)
        {
            if (Login(currentUser, currentPass, proxy, settings))
            {
                string email = GenerateEmail().Replace("@", "%40");
                string post = $"first_name=suh+dude&email={email}&username={userToTake}&phone_number=&gender=3&biography=&external_url=&chaining_enabled=on";
                GetDSUserID(currentUser, proxy, settings);
                TurboCSRF = GetCSRF("https://www.instagram.com/accounts/edit", proxy, settings);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/edit/");
                request.Method = "POST";
                request.Host = "www.instagram.com";
                request.KeepAlive = true;

                if (proxy != string.Empty && proxy.Contains(":") && settings != ProxySettings.NoProxy)
                {
                    if (settings == ProxySettings.CheckProxy)
                    {
                        if (CheckProxy(proxy, MethodType.None))
                        {
                            string[] splitter = proxy.Split(':');
                            string ip = splitter[0];
                            Int32 port = Int32.Parse(splitter[1]);
                            WebProxy myproxy = new WebProxy(ip, port);
                            myproxy.BypassProxyOnLocal = true;
                            request.Proxy = myproxy;
                            Write($"{proxy} is set");
                        }
                        else
                        {
                            Write($"{proxy} is bad");
                        }
                    }
                    else if (settings == ProxySettings.DontCheck)
                    {
                        string[] splitter = proxy.Split(':');
                        string ip = splitter[0];
                        Int32 port = Int32.Parse(splitter[1]);
                        WebProxy myproxy = new WebProxy(ip, port);
                        myproxy.BypassProxyOnLocal = true;
                        request.Proxy = myproxy;
                        Write($"{proxy} is set");
                    }
                }

                int Select = new Random().Next(0, UserAgents().Length);
                string UserAgent = UserAgents()[Select];
                request.UserAgent = UserAgent;

                request.Headers.Add("Origin", "https://www.instagram.com");
                request.Headers.Add("X-Instagram-AJAX", "1");
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("X-CSRFToken", TurboCSRF);
                request.Referer = "https://www.instagram.com/accounts/edit/";
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid={SessionIDFromLogin}; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={TurboCSRF}; ds_user_id={DSUserID}");

                byte[] postBytes = Encoding.ASCII.GetBytes(post);
                request.ContentLength = postBytes.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string html = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Write(html);

                if (html.Contains("\"status\": \"ok\""))
                {
                    Write("name turboed");
                    return true;
                }
                else if (html.Contains("open proxy"))
                {
                    Write($"{proxy} is a public proxy!");
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public bool CheckUsername(string user)
        {
            string proxy = string.Empty;
            ProxySettings settings = ProxySettings.NoProxy;
            CheckCSRF = GetCSRF("http://www.instagram.com", proxy, settings);
            string post = $"email=abc%40gmail.com&password=123&username={user}&first_name=john+doe";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/attempt/");
            request.Method = "POST";
            request.Host = "www.instagram.com";
            request.KeepAlive = true;

            int Select = new Random().Next(0, UserAgents().Length);
            string UserAgent = UserAgents()[Select];
            request.UserAgent = UserAgent;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "*/*";
            request.Referer = "https://www.instagram.com/accounts/login/?signupFirst=true";
            request.Headers.Add("Origin", "https://www.instagram.com");
            request.Headers.Add("X-Instagram-AJAX", "1");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("X-CSRFToken", CheckCSRF);
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cookie", $"mid=V2x4dAAEAAHd2oZIb2KmOAfz8JkS; sessionid=IGSC65ec3226d0e4e12dfcba7be6cc5b75e818daa339e7cdf167a54fc1d1196d4096%3AWtMcnzQLD6RRRtPiLrlYlrWXkyZQmey6%3A%7B%22asns%22%3A%7B%2268.135.173.248%22%3A5650%2C%22time%22%3A1466768354%7D%7D; ig_pr=0.8999999761581421; ig_vw=1517; s_network=; csrftoken={CheckCSRF}");

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string html = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Write(html);
            return !html.Contains("\"errors\": {\"username\":");
        }
        #endregion

        #region AccountScraper
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
            }
            else
            {
                return "Empty";
            }
        }
        #endregion

    }
}