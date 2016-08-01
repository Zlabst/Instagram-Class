using System;

using static System.Console;

namespace InstabotExamples
{
    class Examples
    {
        /// <summary>
        /// API By @teh_distance
        /// These are examples on how to use the Instagram Class
        /// These examples will not be used for botting (which means no proxies at all)
        /// If you want to add botting you can just loop the proxies and run the function multiple times (with an int) or whatever.
        /// </summary>
        public static InstaBot.InstagramClass InstagramAPI = new InstaBot.InstagramClass();

        public static void Register()
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            string username = $"MyUsername{new Random().Next(0, 100000)}";
            string password = "PaSsWoRd12345";
            string email = $"MyEmail{new Random().Next(0, 100000)}@gmail.com";
            string fullname = "suh dude";

            //since were using no proxy... it will be set as string.empty
            string proxy = string.Empty;

            InstagramAPI.Register(username, password, email, fullname, proxy, InstaBot.InstagramClass.ProxySettings.NoProxy);

            Read();
        }

        public static void Follow(string UserToFollow)
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            //since were using no proxy... it will be set as string.empty
            string proxy = string.Empty;

            InstagramAPI.Follow(UserToFollow, proxy, InstaBot.InstagramClass.ProxySettings.NoProxy);

            Read();
        }

        public static void Like(string PhotoURL)
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            //since were using no proxy... it will be set as string.empty
            string proxy = string.Empty;

            InstagramAPI.Like(PhotoURL, proxy, InstaBot.InstagramClass.ProxySettings.NoProxy);

            Read();
        }

        public static void Comment(string PhotoURL, string CommentText)
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            //since were using no proxy... it will be set as string.empty
            string proxy = string.Empty;

            InstagramAPI.Comment(PhotoURL, CommentText, proxy, InstaBot.InstagramClass.ProxySettings.NoProxy);

            Read();
        }

        public static void Report(string PhotoURL)
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            //since were using no proxy... it will be set as string.empty
            string proxy = string.Empty;

            InstagramAPI.Report(PhotoURL, InstaBot.InstagramClass.ReportType.DrugUse, proxy, InstaBot.InstagramClass.ProxySettings.NoProxy);

            Read();
        }

        public static void Turbo(string Username, string Password, string UsernameToTake)
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            //since were using no proxy... it will be set as string.empty
            string proxy = string.Empty;

            InstagramAPI.Turbo(Username, Password, UsernameToTake, proxy, InstaBot.InstagramClass.ProxySettings.NoProxy);

            Read();
        }

        public static void CheckUsername(string user)
        {
            //We set debugging to be enabled so we can see the output of our functions
            InstagramAPI._debug = true;

            InstagramAPI.CheckUsername(user);

            Read();
        }

        public static void GrabProfileInfo(string user)
        {
            string FollowerCount = InstagramAPI.GetFollowerCount(user);
            string FollowingCount = InstagramAPI.GetFollowingCount(user);
            string Bio = InstagramAPI.GetBio(user);
            string IsUserPrivate = InstagramAPI.UserIsPrivate(user).ToString();
            string UserID = InstagramAPI.GetUserID(user);
            string ProfilePic = InstagramAPI.GetProfilePic(user);
            string FullName = InstagramAPI.GetFullName(user);

            Write($"{FollowerCount}\n{FollowingCount}\n{FullName}\n{Bio}\n{IsUserPrivate}\n{UserID}\n{ProfilePic}");
        }

        /// <summary>
        /// Heres an example to check proxies using method types
        /// </summary>
        public static bool CheckProxy(string proxy)
        {
            //Method types include: register, follow, like, comment, report, turbo
            return InstagramAPI.CheckProxy(proxy, InstaBot.InstagramClass.MethodType.Follow);
        }
    }
}
