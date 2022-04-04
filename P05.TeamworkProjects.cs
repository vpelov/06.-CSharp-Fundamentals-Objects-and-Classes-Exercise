using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.TeamworkProjects
{
    class Team
    {
        public Team(string teamName, string creator, List<string> memberList)
        {
            this.TeamName = teamName;
            this.Creator = creator;
            this.MemberList = memberList; 
        }

        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> MemberList { get; set; }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

            List<Team> teamList = new List<Team>();
            int numberTeam = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberTeam; i++)
            {
                string[] teamCreator = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string creator = teamCreator[0];
                string teamName = teamCreator[1];
                if (teamList.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");                   
                }
                else if (teamList.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");                  
                }
                else
                {
                    List<string> memberList = new List<string>();
                    Team currentTeam = new Team(teamName, creator, memberList);
                    teamList.Add(currentTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (command[0] == "end of assignment")
                {
                    break;
                }

                string member = command[0];
                string teamName = command[1];

                if (!teamList.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teamList.Any(x => x.MemberList.Contains(member)) || teamList.Any(x => x.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }

                Team currentTeam = teamList.First(x => x.TeamName == teamName);
                currentTeam.MemberList.Add(member);

            }

            List<Team> printTeam = teamList.OrderByDescending(x => x.TeamName).ToList();

            foreach (Team item in printTeam)
            {
                if (item.MemberList.Count > 0)
                {
                    Console.WriteLine($"{item.TeamName}");
                    Console.WriteLine($"- {item.Creator}");
                    for (int i = 0; i < item.MemberList.Count; i++)
                    {
                        Console.WriteLine($"-- {item.MemberList[i]}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team item in printTeam)
            {
                if (item.MemberList.Count == 0)
                {
                    Console.WriteLine($"{item.TeamName}");
                }
            }
        }
    }
}
