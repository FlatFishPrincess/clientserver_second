using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab02SportsLeague
{
    #region Sport enum
    // enum for sport 
    public enum Sport
    {
        HOCKEY,
        BASKETBALL,
        SOCCER
    }
    #endregion
    
    #region Participant Class
    public abstract class Participant
    {
        private static int nParticipants = 0;
        private int age;
        private string firstName;
        private string lastName;

        // constructor 
        public Participant(int age, string firstName, string lastName){
            this.age = age;
            this.firstName = firstName;
            this.lastName = lastName;
            nParticipants++;
        }
        
        // returns the number of participlants
        public static int GetNumberOfParticipants()
        {
            return nParticipants;
        }
    }
    #endregion

    #region Athlete Class
    public class Athlete : Participant
    {
        private int age;
        private string firstName;
        private string lastName;
        private string position;
        
        // constructor 
        public Athlete(string firstName, string lastName, string position, int age)
            : base(age, firstName, lastName)
           
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.position = position;
        }
        
        public string Position {
            get { return position; }
            set { position = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    #endregion

    #region Coach Class
    public class Coach: Participant
    {
        // fields 
        private int age;
        private string firstName;
        private string lastName;
        private Sport sport;

        // hockeyTeams[1].AddCoach(new Coach("Mickey", "Mouse", 70, Sport.BASKETBALL));
        public Coach(string firstName, string lastName, int age, Sport sport)
            : base(age, firstName, lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.sport = sport;
        }
        
        // property
        public Sport CanCoachSport {
            get { return sport; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    #endregion

    #region Team Class
    public class Team
    {
        private string name;
        private Sport sport;
        private int maxTeamSize;
        private Athlete[] athletes;
        private int teamSize = 0;
        private Coach coach;
        // constructor
        public Team() { }
        public Team(string name, Sport sport, int maxTeamSize)
        {
            athletes = new Athlete[maxTeamSize];
            this.name = name;
            this.sport = sport;
            this.maxTeamSize = maxTeamSize;
        }

        #region Team Properties
        // properties 
        // not sure if I use string or Coach class
        public Coach TeamCoach {
            get { return coach; }
            set { coach = value; }
        }

        public Sport TeamSport {
            get { return sport; }
            set { sport = value; }
        }

        public string TeamName {
            get { return name; }
            set { name = value; }
        }
        public int TeamSize {
            get { return teamSize; }
            set
            {
                if (value > maxTeamSize)
                    Console.WriteLine("team size cannot exceed the maximum size (" + maxTeamSize + ")");
                else
                    teamSize = value;
            }
        }
        public int MaxTeamSize
        {
            get { return maxTeamSize; }
            set { maxTeamSize = value;  }
        }
        #endregion

        #region Team Class Methods
        public void AddAthlete(Athlete a)
        {
            // check if teamsize is greater than max size, no add to a athletes team
            if(teamSize < maxTeamSize)
            {
                // athletes[teamSize] = (new Athlete(a.FirstName, a.LastName, a.Position, a.Age));
                athletes[teamSize] = a;
                teamSize++;
            } 
        }

        // Adds coach to the team, coach must be qualified to coach the sport
        public void AddCoach(Coach c)
        {
            // identify which sport a coach is qualified for
            if (c.CanCoachSport == sport)
            {
                coach = c;
            }
        }
        public void DisplayTeam()
        {
            Console.WriteLine("");
            Console.WriteLine("========= " + sport + " Team ==========");
            Console.WriteLine("Team Name: {0} - {1,-2:d} players ({2,-2:d} max)", name, teamSize, maxTeamSize);
            if (coach != null)
            {
                Console.WriteLine("Coach: {0,-8}{1,-8:d}(age: {2,-2:d})(CanCoach {3})",
                                  coach.FirstName, coach.LastName, coach.Age, coach.CanCoachSport);
            } else
            {
                Console.WriteLine("Coach: None");
            }
            Console.WriteLine("\nTeam Roaster \n");

            for (int i = 0; i < athletes.Length; i++)
            {
                if (athletes[i] != null)
                {
                    Console.WriteLine("{0} {1} {2} (age: {3,-2:d})",
                    athletes[i].Position, athletes[i].FirstName, athletes[i].LastName, athletes[i].Age);
                } else
                {
                    break;
                }
            }
        }
       
        #endregion
    }
    #endregion
}

