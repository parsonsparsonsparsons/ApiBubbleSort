using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace APIBubbleSort
{
    //Api object 1:1 mirror json object
    public class DataObject
    {
        public string page { get; set; }

        public string per_page { get; set; }

        public string total { get; set; }
        public string total_pages { get; set; }

        public List<data> data { get; set; }
    }

    //User properties 1:1 mirror of json object
    public class data
    {
        public string id { get; set; }

        public string email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string avatar { get; set; }
    }

    class Program
    {
        //Big list of names to test bubble sort
        public static List<string> ListOfTestStrings
        {
            get
            {
                return new List<string>
            {
                "Michael"
,"Christopher"
,"Jessica"
,"Matthew"
,"Ashley"
,"Jennifer"
,"Joshua"
,"Amanda"
,"Daniel"
,"David"
,"James"
,"Robert"
,"John"
,"Joseph"
,"Andrew"
,"Ryan"
,"Brandon"
,"Jason"
,"Justin"
,"Sarah"
,"William"
,"Jonathan"
,"Stephanie"
,"Brian"
,"Nicole"
,"Nicholas"
,"Anthony"
,"Heather"
,"Eric"
,"Elizabeth"
,"Adam"
,"Megan"
,"Melissa"
,"Kevin"
,"Steven"
,"Thomas"
,"Timothy"
,"Christina"
,"Kyle"
,"Rachel"
,"Laura"
,"Lauren"
,"Amber"
,"Brittany"
,"Danielle"
,"Richard"
,"Kimberly"
,"Jeffrey"
,"Amy"
,"Crystal"
,"Michelle"
,"Tiffany"
,"Jeremy"
,"Benjamin"
,"Mark"
,"Emily"
,"Aaron"
,"Charles"
,"Rebecca"
,"Jacob"
,"Stephen"
,"Patrick"
,"Sean"
,"Erin"
,"Zachary"
,"Jamie"
,"Kelly"
,"Samantha"
,"Nathan"
,"Sara"
,"Dustin"
,"Paul"
,"Angela"
,"Tyler"
,"Scott"
,"Katherine"
,"Andrea"
,"Gregory"
,"Erica"
,"Mary"
,"Travis"
,"Lisa"
,"Kenneth"
,"Bryan"
,"Lindsey"
,"Kristen"
,"Jose"
,"Alexander"
,"Jesse"
,"Katie"
,"Lindsay"
,"Shannon"
,"Vanessa"
,"Courtney"
,"Christine"
,"Alicia"
,"Cody"
,"Allison"
,"Bradley"
,"Samuel"
,"Shawn"
,"April"
,"Derek"
,"Kathryn"
,"Kristin"
,"Chad"
,"Jenna"
,"Tara"
,"Maria"
,"Krystal"
,"Jared"
,"Anna"
,"Edward"
,"Julie"
,"Peter"
,"Holly"
,"Marcus"
,"Kristina"
,"Natalie"
,"Jordan"
,"Victoria"
,"Jacqueline"
,"Corey"
,"Keith"
,"Monica"
,"Juan"
,"Donald"
,"Cassandra"
,"Meghan"
,"Joel"
,"Shane"
,"Phillip"
,"Patricia"
,"Brett"
,"Ronald"
,"Catherine"
,"George"
,"Antonio"
,"Cynthia"
,"Stacy"
,"Kathleen"
,"Raymond"
,"Carlos"
,"Brandi"
,"Douglas"
,"Nathaniel"
,"Ian"
,"Craig"
,"Brandy"
,"Alex"
,"Valerie"
,"Veronica"
,"Cory"
,"Whitney"
,"Gary"
,"Derrick"
,"Philip"
,"Luis"
,"Diana"
,"Chelsea"
,"Leslie"
,"Caitlin"
,"Leah"
,"Natasha"
,"Erika"
,"Casey"
,"Latoya"
,"Erik"
,"Dana"
,"Victor"
,"Brent"
,"Dominique"
,"Frank"
,"Brittney"
,"Evan"
,"Gabriel"
,"Julia"
,"Candice"
,"Karen"
,"Melanie"
,"Adrian"
,"Stacey"
,"Margaret"
,"Sheena"
,"Wesley"
,"Vincent"
,"Alexandra"
,"Katrina"
,"Bethany"
,"Nichole"
,"Larry"
,"Jeffery"
,"Curtis"
,"Carrie"
,"Todd"
,"Blake"
,"Christian"
,"Randy"
,"Dennis"
,"Alison"
            };
            }
        }


        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            string url = "https://reqres.in/api/users";
            string urlParameters = "?page=2";

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            List<string> ListOfStringToSort = new List<string>();

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<DataObject>().Result;

                foreach (var item in dataObjects.data)
                {
                    ListOfStringToSort.Add(item.first_name);
                }

                Console.WriteLine("Unsorted:");

                foreach (var item in ListOfStringToSort)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n\nSorted:");

                //Big list of names to test string sort:
                //List<string> result = alphaBubbleSort(ListOfTestStrings);

                List<string> result = alphaBubbleSort(ListOfStringToSort);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


            client.Dispose();


        }

        public static int compareStrings(string s, string t)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (i >= s.Length)
                {
                    return -1;
                }
                else if (i >= t.Length)
                {
                    return 1;
                }
                else if (s[i] < t[i])
                {
                    return -1;
                }
                else if (s[i] > t[i])
                {
                    return 1;
                }
                else if (s[i] == t[i])
                {
                    continue;
                }
            }

            return 0;
        }

        public static List<string> alphaBubbleSort(List<string> ListOfStringToSort)
        {
            List<string> result = new List<string>();
            int move = 0;

            for (int i = 0; i < ListOfStringToSort.Count - 1; i++)
            {

                for (int j = 0; j < ListOfStringToSort.Count - i - 1; j++)
                {
                    move = compareStrings(ListOfStringToSort[j], ListOfStringToSort[j + 1]);

                    if (move == 1)
                    {
                        string swap = ListOfStringToSort[j + 1];
                        ListOfStringToSort[j + 1] = ListOfStringToSort[j];
                        ListOfStringToSort[j] = swap;
                    }
                    else if (move == -1)
                    {
                        continue;
                    }

                }

            }

            return ListOfStringToSort;

        }
    }
}