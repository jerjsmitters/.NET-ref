using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cards.Models;

namespace Cards.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {

            var card1 = new Card()
            {
                Front = "Card1F",
                Back = "Card1B",
                Hint = "Card1H"
            };
            var card2 = new Card()
            {
                Front = "Card2F",
                Back = "Card2B",
                Hint = "Card2H"
            };
            var card3 = new Card()
            {
                Front = "Card3F",
                Back = "Card3B",
                Hint = "Card3H"
            };
            var card4 = new Card()
            {
                Front = "Card4F",
                Back = "Card4B",
                Hint = "Card4H"
            };
            var card5 = new Card()
            {
                Front = "Card5F",
                Back = "Card5B",
                Hint = "Card5H"
            };
            var card6 = new Card()
            {
                Front = "Card6F",
                Back = "Card6B",
                Hint = "Card6H"
            };
            var card7 = new Card()
            {
                Front = "Card7F",
                Back = "Card7B",
                Hint = "Card7H"
            };
            var card8 = new Card()
            {
                Front = "Card8F",
                Back = "Card8B",
                Hint = "Card8H"
            };

            var cardList1 = new List<Card>()
            {
                card1,
                card2
            };

            var cardList2 = new List<Card>()
            {
                card3,
                card4
            };

            var cardList3 = new List<Card>()
            {
                card5,
                card6
            };

            var cardList4 = new List<Card>()
            {
                card7,
                card8
            };

            var subject1 = new Subject()
            {
                Name = "Maths"
            };

            var subject2 = new Subject()
            {
                Name = "English"
            };

            var subject3 = new Subject()
            {
                Name = "Philosophy"
            };

            var subject4 = new Subject()
            {
                Name = "History"
            };


            var set1 = new Set()
            {
                Name = "Set1",
                Description = "It a set",
                Cards = cardList1,
                Subject = subject1
            };

            var set2 = new Set()
            {
                Name = "Set2",
                Description = "It another set",
                Cards = cardList2,
                Subject = subject2
            };

            var set3 = new Set()
            {
                Name = "Set3",
                Description = "It yet another set",
                Cards = cardList3,
                Subject = subject3
            };

            var set4 = new Set()
            {
                Name = "Set4",
                Description = "Surprise, it a set",
                Cards = cardList4,
                Subject = subject4
            };

            context.Sets.Add(set1);
            context.Sets.Add(set2);
            context.Sets.Add(set3);
            context.Sets.Add(set4);

            context.SaveChanges();
        }
    }
}