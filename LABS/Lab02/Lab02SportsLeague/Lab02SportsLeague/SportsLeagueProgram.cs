using System;
using System.Collections;
using System.Collections.Generic;


namespace Lab02SportsLeague
{
    // SportsLeague - Driver code for demonstrating inherited classes 
    class SportsLeagueProgram
    {
        static void Main(string[] args)
        {
            // create four teams

            Team mySoccerTeam = new Team("Kickers", Sport.SOCCER, 7);

            Team[] hockeyTeams = new Team[2];

            hockeyTeams[0] = new Team("Skaters", Sport.HOCKEY, 5);
            hockeyTeams[1] = new Team("Shooters", Sport.HOCKEY, 5);


            Team myBasketballTeam = new Team("Dribblers", Sport.BASKETBALL, 3);

            // add 11 athletes and one coach to the soccer team, note it only has room for 7

            mySoccerTeam.AddAthlete(new Athlete("Haspreet", "Kaur", "MidFielder", 19));
            mySoccerTeam.AddAthlete(new Athlete("Kamaljeet", "Singh", "Forward", 22));
            mySoccerTeam.AddAthlete(new Athlete("Mary", "Jones", "Goalkeeper", 23));
            mySoccerTeam.AddAthlete(new Athlete("Jen", "Loi", "MidFielder", 19));
            mySoccerTeam.AddAthlete(new Athlete("Dar", "Singh", "Forward", 22));
            mySoccerTeam.AddAthlete(new Athlete("Sim", "Baker", "Defense", 23));
            mySoccerTeam.AddAthlete(new Athlete("Tim", "Rauk", "MidFielder", 19));
            mySoccerTeam.AddAthlete(new Athlete("Red", "Nites", "Forward", 22));
            mySoccerTeam.AddAthlete(new Athlete("Mary", "Tines", "Goalkeeper", 23));
            mySoccerTeam.AddAthlete(new Athlete("Maury", "Siguras", "Defense", 30));
            mySoccerTeam.AddAthlete(new Athlete("Syd", "Calumphy", "Forward", 25));

            mySoccerTeam.AddCoach(new Coach("Sonny", "Rooster", 41, Sport.SOCCER));

            // add athletes and a coach to the first hockey team

            hockeyTeams[0].AddAthlete(new Athlete("Jack", "Gretzky", "Centre", 19));
            hockeyTeams[0].AddAthlete(new Athlete("John", "Crosby", "Forward", 22));
            hockeyTeams[0].AddAthlete(new Athlete("Jim", "Luongo", "Goalie", 23));

            hockeyTeams[0].AddCoach(new Coach("Alain", "Vineault", 50, Sport.HOCKEY));

            // add an unqualified coach and no players to the second hockey team

            hockeyTeams[1].AddCoach(new Coach("Mickey", "Mouse", 70, Sport.BASKETBALL));

            // add athletes and a coach to the basketball team

            myBasketballTeam.AddAthlete(new Athlete("Steph", "Curry", "Guard", 19));
            myBasketballTeam.AddAthlete(new Athlete("Koby", "Jones", "Centre", 23));
            myBasketballTeam.AddAthlete(new Athlete("Ken", "Bryant", "Forward", 22));

            myBasketballTeam.AddCoach(new Coach("Jerry", "West", 72, Sport.BASKETBALL));

            // show the number of participants in all sports

            Console.WriteLine("All Sports: {0} participants\n", Participant.GetNumberOfParticipants());

            // display each team

            mySoccerTeam.DisplayTeam();
            hockeyTeams[0].DisplayTeam();
            hockeyTeams[1].DisplayTeam();
            myBasketballTeam.DisplayTeam();

            Console.ReadLine();

        }
    }
}

