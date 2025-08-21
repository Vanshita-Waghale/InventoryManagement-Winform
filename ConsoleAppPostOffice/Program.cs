using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleAppUseWebApi

{

    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("Enter Pincode");

            string pincode = Console.ReadLine();



            string URL = "https://api.postalpincode.in/pincode/" + pincode;

            var client = new HttpClient();



            client.BaseAddress = new Uri(URL);



            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));



            var response = client.GetAsync(URL).Result;



            if (response.IsSuccessStatusCode)

            {

                var outputJson = response.Content.ReadAsStringAsync().Result;



                var res = JsonConvert.DeserializeObject<List<Root>>(outputJson);



                foreach (var item in res[0].PostOffice)

                {

                    Console.WriteLine(item.Name + " -- " + item.BranchType);

                }

            }

            else

            {

                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            }



            Console.ReadLine();

        }

    }

}

