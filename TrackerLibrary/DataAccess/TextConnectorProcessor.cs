﻿namespace TrackerLibrary.DataAccess.TextHelpers;

public static class TextConnectorProcessor
{
    public static string FullFilePath(
            this string filename)
    {
        return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ filename }";
    }

    /// <summary>
    /// Load file if found, otherwise create an empty list of strings
    /// </summary>
    /// <param name="file"> </param>
    /// <returns></returns>
    public static List<string> LoadFile(
            this string file)
    {
        if (File.Exists(file) == false)
            return new List<string>();

        return File.ReadAllLines(file).ToList();
    }

    /// <summary>
    /// Converts the lines loaded from the file and split the values in the ',' and 
    /// append to the list<PrizeModel>, when the project grows this will contain all
    /// the prizes as objects, the list will be big
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static List<PrizeModel> ConvertToPrizeModels(
            this List<string> lines)
    {
        List<PrizeModel> output = new();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');

            PrizeModel p = new()
            {
                Id = int.Parse(cols[0]),
                PlaceNumber = int.Parse(cols[1]),
                PlaceName = cols[2],
                PrizeAmount = decimal.Parse(cols[3]),
                PrizePercentage = double.Parse(cols[4])
            };

            output.Add(p);
        }

        return output;
    }

    public static List<PersonModel> ConvertToPersonModels(
            this List<string> lines)
    {
        List<PersonModel> output = new();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');

            PersonModel p = new()
            {
                Id = int.Parse(cols[0]),
                FirstName = cols[1],
                LastName = cols[2],
                EmailAddress = cols[3],
                CellphoneNumber = cols[4]
            };

            output.Add(p);
        }
        return output;
    }

    public static List<TeamModel> ConvertToTeamModels(
            this List<string> lines)
    {
        // id, team name, list of ids separated by the pipe,
        // e.g. 3, Tim's Team, 1|3|5
        List<TeamModel> output = new();
        List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            TeamModel team = new TeamModel
            {
                Id = int.Parse(cols[0]),
                TeamName = cols[1]
            };

            string[] personIds = cols[2].Split('|');

            foreach (string id in personIds)
                team.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());

            output.Add(team);
        }
        return output;
    }

    /// <summary>
    /// Method that returns the Matchup Entries that are recorded in Matchups. Only load matchups passed
    /// and not the entire list in the csv.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(
            string input)
    {
        string[] ids = input.Split('|');

        List<MatchupEntryModel> output = new();
        List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
        List<string> matchingEntries = new();

        foreach (string id in ids)
        {
            foreach (string entry in entries)
            {
                string[] cols = entry.Split(',');

                if (cols[0] == id)
                    matchingEntries.Add(entry);
            }
        }

        output = matchingEntries.ConvertToMatchupEntryModels();

        return output;
    }

    public static List<MatchupEntryModel> ConvertToMatchupEntryModels(
            this List<string> lines)
    {
        // id = 0, TeamCompeting = 1, Score = 2, ParentMatchup = 3
        List<MatchupEntryModel> output = new();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');

            MatchupEntryModel me = new()
            {
                Id = int.Parse(cols[0])
            };

            if (cols[1].Length == 0)
                me.TeamCompeting = null;
            else
                me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));

            me.Score = double.Parse(cols[2]);

            if (int.TryParse(cols[3], out var parentId))
                me.ParentMatchup = LookupMatchupById(parentId);
            else
                me.ParentMatchup = null;

            output.Add(me);
        }

        return output;
    }

    public static List<TournamentModel> ConvertToTournamentModels(
            this List<string> lines)
    {
        // id, TournamentName, EntryFee, (id|id|id - Entered Teams), (id|id|id - Prizes), (Rounds - id^id^id|id^id^id|id^id^id)
        List<TournamentModel> output = new();
        List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
        List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            TournamentModel tm = new()
            {
                Id = int.Parse(cols[0]),
                TournamentName = cols[1],
                EntryFee = decimal.Parse(cols[2])
            };

            string[] teamsId = cols[3].Split('|');

            foreach (string id in teamsId)
                tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());

            if (cols[4].Length > 0)
            {
                string[] prizeIds = cols[4].Split('|');

                foreach (string id in prizeIds)
                    tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
            }

            string[] rounds = cols[5].Split('|');

            foreach (string round in rounds)
            {
                string[] msText = round.Split('^');
                List<MatchupModel> ms = new();

                foreach (string matchupModelTextId in msText)
                    ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());

                tm.Rounds.Add(ms);
            }
            output.Add(tm);
        }

        return output;
    }

    public static List<MatchupModel> ConvertToMatchupModels(
            this List<string> lines)
    {
        //id=0,entries=1(pipe delimited by id), winner=2, matchupRound=3
        List<MatchupModel> output = new();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');

            MatchupModel p = new()
            {
                Id = int.Parse(cols[0]),
                Entries = ConvertStringToMatchupEntryModels(cols[1])
            };

            if (cols[2].Length == 0)
                p.Winner = null;
            else
                p.Winner = LookupTeamById(int.Parse(cols[2]));

            p.MatchupRound = int.Parse(cols[3]);
            output.Add(p);
        }

        return output;
    }

    private static string ConvertRoundListToString(
            List<List<MatchupModel>> rounds)
    {
        // (Rounds - id^id^id|id^id^id|id^id^id)
        string output = "";

        if (rounds.Count == 0)
            return "";

        foreach (List<MatchupModel> r in rounds)
            output += $"{ConvertMatchupListToString(r)}|";

        output = output.Substring(0, output.Length - 1);

        return output;
    }

    private static string ConvertMatchupListToString(
            List<MatchupModel> matchups)
    {
        string output = "";

        if (matchups.Count == 0)
            return "";

        foreach (MatchupModel m in matchups)
            output += $"{m.Id}^";

        output = output.Substring(0, output.Length - 1);

        return output;
    }

    private static string ConvertTeamListToString(
            List<TeamModel> teams)
    {
        string output = "";
        foreach (TeamModel t in teams)
        {
            if (teams.Count >= 0)
                output += $"{t.Id}|";
            else
                return "";
        }

        output = output.Substring(0, output.Length - 1);
        return output;
    }

    private static string ConvertMatchupEntriesListToString(
            List<MatchupEntryModel> matchupsEntries)
    {
        string output = "";

        if (matchupsEntries.Count == 0)
            return "";

        foreach (MatchupEntryModel e in matchupsEntries)
            output += $"{e.Id}|";

        output = output.Substring(0, output.Length - 1);
        return output;

    }

    private static string ConvertPrizeListToString(
            List<PrizeModel> prizes)
    {
        string output = "";

        foreach (PrizeModel p in prizes)
        {
            if (prizes.Count >= 0)
                output += $"{p.Id}|";
            else
                return "";
        }

        output = output.Substring(0, output.Length - 1);
        return output;
    }

    private static string ConvertPeopleListToString(
            List<PersonModel> people)
    {
        string output = "";
        foreach (PersonModel p in people)
        {
            if (people.Count >= 0)
                output += $"{p.Id}|";
            else
                return "";
        }

        output = output.Substring(0, output.Length - 1);
        return output;
    }

    public static void SaveToPrizeFile(
            this List<PrizeModel> models)
    {
        List<string> lines = new();

        foreach (PrizeModel p in models)
            lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");

        File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
    }

    public static void SaveToPeopleFile(
            this List<PersonModel> models)
    {
        List<string> lines = new();

        foreach (PersonModel p in models)
            lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");

        File.WriteAllLines(GlobalConfig.PeopleFile.FullFilePath(), lines);
    }

    public static void SaveToTeamFile(
            this List<TeamModel> models, 
            string fileName)
    {
        List<string> lines = new();

        foreach (TeamModel t in models)
            lines.Add($"{t.Id},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");

        File.WriteAllLines(fileName.FullFilePath(), lines);
    }

    public static void SaveToTournamentFile(
            this List<TournamentModel> model)
    {
        List<string> lines = new();

        foreach (TournamentModel t in model)
            lines.Add($@"{t.Id},{t.TournamentName},{t.EntryFee},{ConvertTeamListToString(t.EnteredTeams)},{ConvertPrizeListToString(t.Prizes)},{ConvertRoundListToString(t.Rounds)}");

        File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
    }

    public static void SaveRoundsToFile(
            this TournamentModel model)
    {
        // loop through each round
        // loop through each matchup
        // get the id for the new matchup and save the record
        // loop through each entry, get the id, and save it
        foreach (List<MatchupModel> round in model.Rounds)
        {
            foreach(MatchupModel matchup in round)
            {
                // load all the matchups from file
                // Get the top id and add one
                // store the id
                // save the matchup record
                matchup.SaveMatchupToFile();
            }
        }
    }

    public static void SaveMatchupToFile(
            this MatchupModel matchup)
    {
        List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

        int currentId = 1;

        if(matchups.Count > 0)
            currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;

        matchup.Id = currentId;
        matchups.Add(matchup);

        foreach (MatchupEntryModel entry in matchup.Entries)
            entry.SaveMatchupEntryToFile();

        List<string> lines = new ();

        foreach (MatchupModel mu in matchups)
        {
            string winner = "";
            if (mu.Winner != null)
                winner = mu.Winner.Id.ToString();

            // id = 0, entries (pipe delimited by id), winner = 2, matchupRound = 3
            lines.Add($"{ mu.Id },{ConvertMatchupEntriesListToString(mu.Entries) },{ winner },{ mu.MatchupRound }");
        }

        File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
    }

    public static void SaveMatchupEntryToFile(
            this MatchupEntryModel matchupEntry) 
    {
        List<MatchupEntryModel> matchupEntries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
        int currentId = 1;

        if (matchupEntries.Count > 0)
            currentId = matchupEntries.OrderByDescending(x => x.Id).First().Id + 1;

        matchupEntry.Id = currentId;
        matchupEntries.Add(matchupEntry);

        List<string> lines = new();

        foreach(MatchupEntryModel me in matchupEntries)
        {
            string parent = "";
            string team = "";

            if(me.ParentMatchup != null)
                parent = me.ParentMatchup.Id.ToString();
            if (me.TeamCompeting != null)
                team = me.TeamCompeting.Id.ToString();

            // id = 0, TeamCompeting = 1, score = 2, parentMatchup = 3
            lines.Add($"{me.Id},{team},{me.Score},{parent}");
        }

        File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
    }

    public static void UpdateMatchupToFile(
            this MatchupModel matchup)
    {
        List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
        MatchupModel matchupModel = new();

        foreach (MatchupModel mu in matchups)
            if (mu.Id == matchup.Id)
                matchupModel = mu;

        // remove old matchup 
        // replace with new matchup
        matchups.Remove(matchupModel);
        matchups.Add(matchup);

        foreach (MatchupEntryModel entry in matchup.Entries)
            entry.UpdateMatchupEntryToFile();

        List<string> lines = new();

        foreach (MatchupModel mu in matchups)
        {
            string winner = "";

            if (mu.Winner != null)
                winner = mu.Winner.Id.ToString();

            // id = 0, entries (pipe delimited by id), winner = 2, matchupRound = 3
            lines.Add($"{mu.Id},{ConvertMatchupEntriesListToString(mu.Entries)},{winner},{mu.MatchupRound}");
        }

        File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
    }

    public static void UpdateMatchupEntryToFile(
            this MatchupEntryModel matchupEntry)
    {
        List<MatchupEntryModel> MatchupEntries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
        MatchupEntryModel OldEntry = new();

        foreach (MatchupEntryModel MatchupEntry in MatchupEntries)
            if (MatchupEntry.Id == matchupEntry.Id)
                OldEntry = MatchupEntry;

        MatchupEntries.Remove(OldEntry);
        MatchupEntries.Add(matchupEntry);

        List<string> Lines = new ();

        foreach (MatchupEntryModel me in MatchupEntries)
        {
            string parent = "";
            string team = "";

            if (me.ParentMatchup != null)
                parent = me.ParentMatchup.Id.ToString();
            if (me.TeamCompeting != null)
                team = me.TeamCompeting.Id.ToString();

            // id = 0, TeamCompeting = 1, score = 2, parentMatchup = 3
            Lines.Add($"{me.Id},{team},{me.Score},{parent}");
        }
        File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), Lines);
    }

    private static TeamModel LookupTeamById(
            int id)
    {
        List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();

        foreach(string team in teams)
        {
            string[] cols = team.Split(',');

            if (cols[0] == id.ToString())
            {
                List<string> matchingTeams = new();
                matchingTeams.Add(team);
                return matchingTeams.ConvertToTeamModels().First();
            }
        }

        return null;
    }

    private static MatchupModel LookupMatchupById(
            int id)
    {
        List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

        foreach(string matchup in matchups)
        {
            string[] cols = matchup.Split(',');

            // only look if id is found in the matchup file
            if (cols[0] == id.ToString())
            {
                List<string> matchingMatchups = new();
                matchingMatchups.Add(matchup);
                return matchingMatchups.ConvertToMatchupModels().First();
            }
        }

        return null;
    }
}
