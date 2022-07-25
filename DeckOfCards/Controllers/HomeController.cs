using DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CardsDAL cardsDAL = new CardsDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Draw()
        {
            return View();
        }

        public IActionResult CardsDisplay(int numOfCardsToDraw)
        {
            //if(cardsInDeck == 0)
            //{
            //    cardsDAL.ShuffleCards();
            //}
            CardsModel result1 = cardsDAL.DrawCards(numOfCardsToDraw);
            return View(result1);
        }

        [HttpPost]
        public IActionResult CardsDisplay(List<Card> cards, int numOfCardsToDraw,List<int> keptcards)
        {
            //cardsDAL.ShuffleCards();
            CardsModel result2 = cardsDAL.DrawCards(numOfCardsToDraw-keptcards.Count());
            List<Card> cardList = new List<Card>();
            cardList.AddRange(result2.cards);
            foreach (int number in keptcards)
            {
                cardList.Add(cards[number]);
            }
            result2.cards = cardList.ToArray();
            return View(result2);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}