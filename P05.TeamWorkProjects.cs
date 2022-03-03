using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.TeamWorkProjects
{
    class Teams
    {
        public string CreatorTeam { get; set; }

        public string TeamName { get; set; }

        public List<string> MembersTeam { get; set; }

        public Teams(string creator, string teamName)   // Constructor input data
        {
            this.CreatorTeam = creator;
            this.TeamName = teamName;

            this.MembersTeam = new List<string>();
        }

        public void AddMember(string member)
        {
            this.MembersTeam.Add(member);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Teams> teamList = new List<Teams>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] inputTeamData = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string creator = inputTeamData[0];
                string teamName = inputTeamData[1];

                if (teamList.Any(s => s.CreatorTeam == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }
                else if (teamList.Any(s => s.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                Teams team = new Teams(creator, teamName);
                teamList.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string[] commandArray = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string member = commandArray[0];
                string team = commandArray[1];

                if (!teamList.Any(x => x.TeamName == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    command = Console.ReadLine();
                    continue;
                }

                if (teamList.Any(s => s.MembersTeam.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                    command = Console.ReadLine();
                    continue;
                }

                if (teamList.Any(s => s.CreatorTeam == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                    command = Console.ReadLine();
                    continue;
                }

                Teams currentTeam = teamList.FirstOrDefault(x => x.TeamName == team);
                currentTeam.AddMember(member);

                command = Console.ReadLine();
            }

            List<Teams> teamsZeroMembers = teamList
                .Where(t =>t.MembersTeam.Count == 0)
                .OrderByDescending(t => t.MembersTeam.Count)
                .ThenBy(t => t.TeamName)
                .ToList();
            List<Teams> teamsMoreMembers = teamList
                .Where(t => t.MembersTeam.Count > 0)
                .OrderByDescending(t => t.MembersTeam.Count)
                .ThenBy(m => m.MembersTeam)
                .ToList();


            foreach (Teams item in teamsMoreMembers)
            {
                Console.WriteLine($"{item.TeamName}");
                Console.WriteLine($"- {item.CreatorTeam}");

                foreach (string members in item.MembersTeam.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {members}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Teams item in teamsZeroMembers)
            {
                Console.WriteLine(item.TeamName);
            }
        }
    }
}
