using Newtonsoft.Json;
using System.Net;

namespace DeckOfCards.Models
{
    public class CardsDAL
    {
        public CardsModel DrawCards(int numOfCardsToDraw) //adjust here
        {
            //sdjust here
            //api url
            //string key = "4b91848cccd9013de4ff5c0525b75e91";
            string url = $"https://deckofcardsapi.com/api/deck/ri6rybcyakh6/draw/?count={numOfCardsToDraw}";

            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //save response data
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Adjust return
            //Convert JSON to C# object
            CardsModel result = JsonConvert.DeserializeObject<CardsModel>(JSON);
            return result;
        }

        public void ShuffleCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/ri6rybcyakh6/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}
