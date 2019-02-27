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

            var card19 = new Card()
            {
                Front = "What's the capital of pakistan?",
                Back = "wasdwasdwasd",
                Hint = "Card18H"
            };

            var card20 = new Card()
            {
                Front = "what's the capital of Namibia?",
                Back = "wasdwasdwasdwasd",
                Hint = "Card18H"
            };

            var card21 = new Card()
            {
                Front = "Question?",
                Back = "Answer",
                Hint = "Card18H"
            };

            var card22 = new Card()
            {
                Front = "Another question?",
                Back = "Another answer",
                Hint = "Card18H"
            };

            var card23 = new Card()
            {
                Front = "Question",
                Back = "Answer",
                Hint = "Card18H"

            };

            var card24 = new Card()
            {
                Front = "Question",
                Back = "Aaaanswer",
                Hint = "Card18H"
            };

            var card25 = new Card()
            {
                Front = "Quuuuuestion",
                Back = "aaaanssssssweeeer",
                Hint = "Card18H"
            };

            var card26 = new Card()
            {
                Front = "question question",
                Back = "answer answer",
                Hint = "Card18H"
            };

            var card27 = new Card()
            {
                Front = "question question question",
                Back = "answer answer answer",
                Hint = "Card18H"
            };

            var card28 = new Card()
            {
                Front = "qwerty",
                Back = "ytrewq",
                Hint = "Card18H"
            };
            var card29 = new Card()
            {
                Front = "pineapple",
                Back = "applepine",
                Hint = "Card18H"
            };
            var card30 = new Card()
            {
                Front = "mango",
                Back = "go man!",
                Hint = "Card18H"
            };
            var card31 = new Card()
            {
                Front = "what's my favourite skyscraper?",
                Back = "I don't have one",
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

            var cardList6 = new List<Card>()
            {
                card19,
                card20,
                card21,
                card22,
                card23
            };

            var cardList7 = new List<Card>()
            {
                card24,
                card25,
                card26,
                card27
            };

            var cardList8 = new List<Card>()
            {
                card28,
                card29,
                card30,
                card31
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

            var subject5 = new Subject()
            {
                Name = "Computer Science"
            };

            var subject6 = new Subject()
            {
                Name = "Politics"
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

            var peter = new User()
            {
                UserName = "petey02894",
                Email = "petermld201@aol.com"
            };

            userManager.Create(peter, "wasdwasd");

            var claire = new User()
            {
                UserName = "clairebear",
                Email = "rabbitchicken42@outlook.com"
            };

            userManager.Create(claire, "wasdwasd");

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

            var set5 = new Set()
            {
                Name = "Look at this set",
                Description = "",
                Cards = cardList5,
                Subject = subject5,
                User = george
            };

            var set6 = new Set()
            {
                Name = "seeeeeeeet",
                Description = "",
                Cards = cardList6,
                Subject = subject3,
                User = claire
            };

            var set7 = new Set()
            {
                Name = "How to lick your elbow",
                Description = "set description",
                Cards = cardList7,
                Subject = subject6,
                User = peter
            };

            var set8 = new Set()
            {
                Name = "Lamppost facts",
                Description = "Surprise, it a set",
                Cards = cardList8,
                Subject = subject4,
                User = claire
            };
            var set9 = new Set()
            {
                Name = "Dummy Set 9",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 9" },
                User = claire
            };

            var set10 = new Set()
            {
                Name = "Dummy Set 10",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 10" },
                User = claire
            };

            var set11 = new Set()
            {
                Name = "Dummy Set 11",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 11" },
                User = claire
            };

            var set12 = new Set()
            {
                Name = "Dummy Set 12",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 12" },
                User = claire
            };

            var set13 = new Set()
            {
                Name = "Dummy Set 13",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 13" },
                User = claire
            };

            var set14 = new Set()
            {
                Name = "Dummy Set 14",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 14" },
                User = claire
            };

            var set15 = new Set()
            {
                Name = "Dummy Set 15",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 15" },
                User = claire
            };
            var set16 = new Set()
            {
                Name = "Dummy Set 16",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 16" },
                User = claire
            };

            var set17 = new Set()
            {
                Name = "Dummy Set 17",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 17" },
                User = claire
            };

            var set18 = new Set()
            {
                Name = "Dummy Set 18",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 18" },
                User = claire
            };

            var set19 = new Set()
            {
                Name = "Dummy Set 19",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 19" },
                User = claire
            };

            var set20 = new Set()
            {
                Name = "Dummy Set 20",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 20" },
                User = claire
            };

            var set21 = new Set()
            {
                Name = "Dummy Set 21",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 21" },
                User = claire
            };

            var set22 = new Set()
            {
                Name = "Dummy Set 22",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 22" },
                User = claire
            };

            var set23 = new Set()
            {
                Name = "Dummy Set 23",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 23" },
                User = claire
            };

            var set24 = new Set()
            {
                Name = "Dummy Set 24",
                Description = "",
                Cards = null,
                Subject = new Subject { Name = "Dummy Subject 24" },
                User = claire
            };

            context.Sets.Add(set1);
            context.Sets.Add(set2);
            context.Sets.Add(set3);
            context.Sets.Add(set4);
            context.Sets.Add(set5);
            context.Sets.Add(set6);
            context.Sets.Add(set7);
            context.Sets.Add(set8);
            context.Sets.Add(set9);
            context.Sets.Add(set10);
            context.Sets.Add(set11);
            context.Sets.Add(set12);
            context.Sets.Add(set13);
            context.Sets.Add(set14);
            context.Sets.Add(set15);
            context.Sets.Add(set16);
            context.Sets.Add(set17);
            context.Sets.Add(set18);
            context.Sets.Add(set19);
            context.Sets.Add(set20);
            context.Sets.Add(set21);
            context.Sets.Add(set22);
            context.Sets.Add(set23);
            context.Sets.Add(set24);

            context.SaveChanges();
        }
    }
}