using System;
using System.IO;
using System.Text;
using System.Net.Http;
using cn.bmob.api;

namespace ConfigTool
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        //private static string teammate, ability, config, enemy, inventory;
        public static BmobWindows Bmob { get; private set; }

        static void Main(string[] args)
        {
            Bmob = new BmobWindows();
            Bmob.initialize("aeb7d61665f9835103ecbf24fba9e359", "8a9e23950dce0d279e3b14fc5c605ee0");
            var config = new Config();
            Console.OutputEncoding = Encoding.GetEncoding(936);
            try
            {
                using (StreamReader sr = new StreamReader("Ability.csv"))
                    config.config1 = sr.ReadToEnd();

                using (StreamReader sr = new StreamReader("Config.csv"))
                    config.config2  = sr.ReadToEnd();

                using (StreamReader sr = new StreamReader("Enemy.csv"))
                    config.config3 = sr.ReadToEnd();

                using (StreamReader sr = new StreamReader("Inventory.csv"))
                    config.config4 = sr.ReadToEnd();

                using (StreamReader sr = new StreamReader("Teammate.csv"))
                    config.config5 = sr.ReadToEnd();
                using (StreamReader sr = new StreamReader("Troop.csv"))
                    config.config6 = sr.ReadToEnd();

                using (StreamReader sr = new StreamReader("Map.csv"))
                    config.config7 = sr.ReadToEnd();
                using (StreamReader sr = new StreamReader("Event.csv"))
                    config.config8 = sr.ReadToEnd();

                using (StreamReader sr = new StreamReader("Affair.csv"))
                    config.config9 = sr.ReadToEnd();
                Update(config);
            }
            catch (IOException e)
            {
                Console.WriteLine("文件读取失败:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("正在配置中...");
            Console.ReadKey();
        }

        static void Update(Config config)
        {
            Bmob.Update("Config", "WSxmRRRo", config, (resp, exception) =>
            {
                if (exception != null)
                {
                    Console.WriteLine("配置失败:" + exception.Message);
                    return;
                }

                Console.WriteLine("配置成功, @" + resp.updatedAt);
            });
        }
    }
}


#region draft
/*using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using Newtonsoft.Json;

namespace ConfigTool
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string teammate, ability, config, enemy, inventory;
        static void Main(string[] args)
        {
            //     client.DefaultRequestHeaders
            //.Accept
            //.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("X-Bmob-Application-Id", "aeb7d61665f9835103ecbf24fba9e359");
            client.DefaultRequestHeaders.Add("X-Bmob-REST-API-Key", "8a9e23950dce0d279e3b14fc5c605ee0");
            Console.OutputEncoding = Encoding.GetEncoding(936);
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Teammate.csv"))
                {
                    // Read the stream to a string, and write the string to the console.
                    teammate = sr.ReadToEnd();
                    //Console.WriteLine("Teammate");
                    // Console.WriteLine(teammate);
                }
                using (StreamReader sr = new StreamReader("Ability.csv"))
                {
                    // Read the stream to a string, and write the string to the console.
                    ability = sr.ReadToEnd();
                    //Console.WriteLine("Ability");
                    // Console.WriteLine(ability);
                }
                using (StreamReader sr = new StreamReader("Config.csv"))
                {
                    // Read the stream to a string, and write the string to the console.
                    config = sr.ReadToEnd();
                    // Console.WriteLine("Config");
                    //Console.WriteLine(config);
                }
                using (StreamReader sr = new StreamReader("Enemy.csv"))
                {
                    // Read the stream to a string, and write the string to the console.
                    enemy = sr.ReadToEnd();
                    //Console.WriteLine("Enemy");
                    // Console.WriteLine(enemy);
                }
                using (StreamReader sr = new StreamReader("Inventory.csv"))
                {
                    // Read the stream to a string, and write the string to the console.
                    inventory = sr.ReadToEnd();
                    //Console.WriteLine("Inventory");
                    // Console.WriteLine(inventory);
                }


            }
            catch (IOException e)
            {
                Console.WriteLine("文件读取失败:");
                Console.WriteLine(e.Message);
            }
            //Task t = new Task(Post);
            //t.Start();
            string json = @"{""config1"":""555""}";
            Console.WriteLine(json);
            // POSTData(json, "https://api2.bmob.cn/1/classes/Data/i7tFAAAE");
            Console.WriteLine("正在上传中");
            Console.ReadKey();
        }



      /*  public static bool POSTData(string json, string url)
        {
            using (var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = client.PostAsync(url, content).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Failed to POST data: ({result.StatusCode}): {returnValue}"+ result.RequestMessage+result.Headers);
                return false;
           */
#endregion
          