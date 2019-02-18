using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cards.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Cards.Security;

namespace Cards.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new ApplicationUserManager(userStore);

            var card1 = new Card()
            {
                Front = "What colour is the sky?",
                Back = "Yellow",
                Hint = "Card1H"
            };
            var card2 = new Card()
            {
                Front = "How many fingers am I holding up?",
                Back = "11",
                Hint = "Card2H"
            };
            var card3 = new Card()
            {
                Front = "What's the capital of Kyrgyzstan?",
                Back = "Swansea",
                Hint = "Card3H"
            };
            var card4 = new Card()
            {
                Front = "What is 1+1",
                Back = "-1",
                Hint = "Card4H"
            };
            var card5 = new Card()
            {
                Front = "What is love?",
                Back = "Baby don't hurt me",
                Hint = "No more"
            };
            var card6 = new Card()
            {
                Front = "What year was NATO formed?",
                Back = "3000BC",
                Hint = "Card6H"
            };
            var card7 = new Card()
            {
                Front = "What is smallest known subatomic particle?",
                Back = "Cabbage",
                Hint = "Card7H"
            };
            var card8 = new Card()
            {
                Front = "What song did I sing into my hairbrush every morning?",
                Back = "I'm Every Woman - Chaka Khan",
                Hint = "Card8H"
            };

            var card9 = new Card()
            {
                Front = "What's the plural of mongoose?",
                Back = "Manygoose",
                Hint = "Card9H"
            };

            var card10 = new Card()
            {
                Front = "What's the main ingredient of anti-aging cream?",
                Back = "Unicorn blood",
                Hint = "Card10H"
            };

            var card11 = new Card()
            {
                Front = "What caused the 2008 Financial Crisis?",
                Back = "Laughing when babies fall over",
                Hint = "Card11H"
            };

            var card12 = new Card()
            {
                Front = "How are there so many Fast and Furious movies?",
                Back = "I genuinely have no idea",
                Hint = "Card12H"
            };

            var card13 = new Card()
            {
                Front = "What is the main postulate in quantum mechanics?",
                Back = "Something something dead cat",
                Hint = "Card13H"
            };

            var card14 = new Card()
            {
                Front = "I'm running out of card ideas",
                Back = "Oh nooooooo",
                Hint = "Card14H"
            };

            var card15 = new Card()
            {
                Front = "What's the shape of a DNA molecule?",
                Back = "Double Hendrix",
                Hint = "Card15H"
            };

            var card16 = new Card()
            {
                Front = "How do you say skyscraper in Icelandic?",
                Back = "riðjkriðjkjkiðjkjðkðkavic",
                Hint = "Card16H"
            };

            var card17 = new Card()
            {
                Front = "How is nuclear fission made possible?",
                Back = "Really small scissors",
                Hint = "Card17H"
            };

            var card18 = new Card()
            {
                Front = "How can I train my dog?",
                Back = "Force it to sign a legally binding contract.",
                Hint = "Card18H"
            };

            


            var cardList1 = new List<Card>()
            {
                card1,
                card2,
                card3,
                card4
            };

            var cardList2 = new List<Card>()
            {
                card5,
                card6,
                card7,
                card8
            };

            var cardList3 = new List<Card>()
            {
                card9,
                card10,
                card11,
                card12
            };

            var cardList4 = new List<Card>()
            {
                card13,
                card14,
                card15,
                card16
            };

            var cardList5 = new List<Card>()
            {
                card17,
                card18
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

            var user1 = new User()
            {
                UserName = "Mr-Blobby",
                Email = "wasd@aol.com"
            };

            userManager.Create(user1, user1.UserName);

            var user2 = new User()
            {
                UserName = "CardMaster3000",
                Email = "jeremy@steve.gov.uk"
            };

            userManager.Create(user2, user2.UserName);

            var user3 = new User()
            {
                UserName = "FrogMan2112",
                Email = "amphibian@pond.com"
            };

            userManager.Create(user3, user3.UserName);

            var user4 = new User()
            {
                UserName = "SteveWondersGlasses",
                Email = "HappyBirthdayToYou@hotmail.co.uk"
            };

            userManager.Create(user4, user4.UserName);

            var george = new User()
            {
                UserName = "gs274",
                Email = "gs274@outlook.com"
            };

            userManager.Create(george, "wasdwasd");

            var set1 = new Set()
            {
                Name = "How to tie my shoelaces",
                Description = "It a set",
                Cards = cardList1,
                Subject = subject1,
                User = user1
            };

            var set2 = new Set()
            {
                Name = "Extreme Frisbee Revision",
                Description = "It another set",
                Cards = cardList2,
                Subject = subject2,
                User = user2
            };

            var set3 = new Set()
            {
                Name = "States of Uruguay",
                Description = "It yet another set",
                Cards = cardList3,
                Subject = subject3,
                User = user3
            };

            var set4 = new Set()
            {
                Name = "Difference between affect and effect",
                Description = "Surprise, it a set",
                Cards = cardList4,
                Subject = subject4,
                User = user4
            };

            context.Sets.Add(set1);
            context.Sets.Add(set2);
            context.Sets.Add(set3);
            context.Sets.Add(set4);

            context.SaveChanges();
        }
    }
}