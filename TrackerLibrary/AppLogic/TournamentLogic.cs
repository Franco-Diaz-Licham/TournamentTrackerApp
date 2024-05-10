namespace TrackerLibrary.AppLogic;

public static class TournamentLogic
{
    public static void CreateRounds(TournamentModel model)
    {
        // Order our lists randomly of teams
        List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);

        // Check if it is big enough - if not, add in byes - 2^n teams required
        int rounds = FindNumberOfRounds(randomizedTeams.Count);
        int byes = NumberOfByes(rounds, randomizedTeams.Count);

        // Create our first round of matchups
        model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

        // Create every round after that
        CreateOtherRounds(model, rounds);
    }

    public static void UpdateTournamentResults(TournamentModel tournament)
    {
        int startingRound = tournament.CheckCurrentRound();

        List<MatchupModel> ToScore = new();

        foreach (List<MatchupModel> Round in tournament.Rounds)
        {
            foreach (MatchupModel rm in Round)
            {
                // get any team that has a score, or any team with a bye
                if (rm.Winner == null && rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count() == 1)
                {
                    ToScore.Add(rm);
                }
            }
        }

        MarkWinner(ToScore);
        AdvanceWinner(ToScore, tournament);

        // update every matchup's score after a winner has been determined and advanced.
        ToScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

        int endingRound = tournament.CheckCurrentRound();

        if (endingRound > startingRound)
        {
            // alert user
            tournament.AlertUsersToNewRound();
        }
    }

    public static void AlertUsersToNewRound(this TournamentModel model)
    {
        int currentRoundNumb = model.CheckCurrentRound();
        List<string> users = new();

        List<MatchupModel> CurrentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumb).First();

        foreach (MatchupModel matchup in CurrentRound)
        {
            foreach (MatchupEntryModel me in matchup.Entries)
            {
                foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                {
                    AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting.Id != me.TeamCompeting.Id).FirstOrDefault());
                }
            }
        }
    }

    private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchupEntryModel? Competitor)
    {
        if (p.EmailAddress?.Length > 0)
        {
            string to = p.EmailAddress;
            string subject = $"";
            StringBuilder body = new();

            if (Competitor != null)
            {
                subject = $"You have a new matchup with {Competitor.TeamCompeting.TeamName}";

                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.Append(Competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a great time!");
                body.AppendLine("~Tournament Tracker~");
            }
            else
            {
                subject = "You have a bye week";
                body.AppendLine("Enjoy your week off");
                body.AppendLine("~Tournament Tracker~");
            }

            // TODO: Fix the sending email
            //EmailLogic.SendEmail(to, subject, body.ToString());
        }

        if(p.CellphoneNumber?.Length > 0)
        {
            // TODO: set up sms message
            //SMSLogic.SendSMSMessage(p.CellphoneNumber, $"You have a new matchup with {Competitor.TeamCompeting.TeamName}");
        }
    }

    private static void AdvanceWinner(List<MatchupModel> models, TournamentModel tournament)
    {
        // get the current matchup that has been scored.                 
        // iterate through every matchup and place the winner in a future matchup that has its parent 
        // the current matchup that has been scored.
        foreach (MatchupModel m in models)
        {
            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel rm in round)
                {
                    foreach (MatchupEntryModel me in rm.Entries)
                    {
                        if (me.ParentMatchup != null)
                        {
                            if (me.ParentMatchup.Id == m.Id)
                            {
                                me.TeamCompeting = m.Winner;

                                // update matchup based on this updated entry
                                GlobalConfig.Connection.UpdateMatchup(rm);
                            }
                        }
                    }
                }
            }
        }
    }

    private static void MarkWinner(List<MatchupModel> models)
    {
        string? greaterWins = ConfigurationManager.AppSettings["greaterWins"];

        foreach (MatchupModel m in models)
        {
            MatchupEntryModel teamOne = m.Entries[0];

            // bye week
            if (m.Entries.Count == 1)
            {
                m.Winner = teamOne.TeamCompeting;
                continue;
            }

            // if round has a second team
            MatchupEntryModel teamTwo = m.Entries[1];

            if (greaterWins == "0")
            {
                if (teamOne.Score > teamTwo.Score)
                {
                    m.Winner = teamOne.TeamCompeting;
                }
                else if (teamTwo.Score > teamOne.Score)
                {
                    m.Winner = teamTwo.TeamCompeting;
                }
                else
                {
                    throw new Exception("Tournament does not handle draws.");
                }
            }
            else
            {
                if (teamOne.Score < teamTwo.Score)
                {
                    m.Winner = teamOne.TeamCompeting;
                }
                else if (teamTwo.Score < teamOne.Score)
                {
                    m.Winner = teamTwo.TeamCompeting;
                }
                else
                {
                    throw new Exception("Tournament does not handle draws.");
                }
            }

        }
    }

    private static void CreateOtherRounds(TournamentModel model, int rounds)
    {
        int round = 2;
        List<MatchupModel> previousRound = model.Rounds[0];
        List<MatchupModel> currRound = new();
        MatchupModel currMatchup = new();

        while (round <= rounds)
        {
            foreach (MatchupModel match in previousRound)
            {
                currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                if (currMatchup.Entries.Count > 1)
                {
                    currMatchup.MatchupRound = round;
                    currRound.Add(currMatchup);
                    currMatchup = new MatchupModel();
                }
            }

            model.Rounds.Add(currRound);
            previousRound = currRound;
            currRound = new List<MatchupModel>();
            round += 1;
        }
    }

    private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
    {
        List<MatchupModel> output = new List<MatchupModel>();
        MatchupModel curr = new MatchupModel();

        foreach (TeamModel team in teams)
        {
            curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

            if (byes > 0 || curr.Entries.Count > 1)
            {
                curr.MatchupRound = 1;
                output.Add(curr);
                curr = new MatchupModel();

                if (byes > 0)
                {
                    byes -= 1;
                }
            }
        }

        return output;
    }

    private static int NumberOfByes(int rounds, int numberOfTeams)
    {
        int output = 0;
        int totalTeams = 1;

        for (int i = 1; i <= rounds; i++)
        {
            totalTeams *= 2;
        }

        output = totalTeams - numberOfTeams;
        return output;
    }

    private static int FindNumberOfRounds(int teamCount)
    {
        int output = 1;
        int val = 2;

        while (val < teamCount)
        {
            output += 1;
            val *= 2;
        }

        return output;
    }

    private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
    {
        return teams.OrderBy(x => Guid.NewGuid()).ToList();
    }

    public static int CheckCurrentRound(this TournamentModel model)
    {
        int output = 1;

        foreach (List<MatchupModel> round in model.Rounds)
        {
            // get current round were they are all winners.
            if (round.All(x => x.Winner != null) == true)
            {
                output += 1;
            }
            else
            {
                return output;
            }
        }

        // If there is a round without winners. Then we are at the end.
        model.CompleteTournament();

        return output - 1;
    }

    public static void CompleteTournament(this TournamentModel model)
    {
        GlobalConfig.Connection.CompleteTournament(model);

        TeamModel winners = model.Rounds.Last().First().Winner;
        TeamModel runnerUp = model.Rounds
                .Last()
                .First()
                .Entries.Where(x => x.TeamCompeting != winners)
                .First().TeamCompeting;

        decimal winnerPrize = 0;
        decimal runnerPrize = 0;

        if (model.Prizes.Count > 0)
        {
            decimal totalIncome = model.EnteredTeams.Count * model.EntryFee;

            PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
            PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

            if (firstPlacePrize != null)
            {
                winnerPrize = firstPlacePrize.CalculatePrizePayOut(totalIncome);
            }

            if (secondPlacePrize != null)
            {
                runnerPrize = secondPlacePrize.CalculatePrizePayOut(totalIncome);
            }
        }

        // Email to all tournament
        string subject = $"";
        StringBuilder body = new();

        subject = $"In {model.TournamentName}, {winners.TeamName} has won!";

        body.AppendLine("<h1>You have a WINNER!</h1>");
        body.AppendLine("<p>Congratulations to our winner on a great tournament</p>");
        body.AppendLine("<br/>");

        if (winnerPrize > 0)
        {
            body.AppendLine($"<p>{winners.TeamName} will revice ${winnerPrize}");
        }

        if (runnerPrize > 0)
        {
            body.AppendLine($"<p>{runnerUp.TeamName} will revice ${runnerPrize}");
        }

        body.AppendLine("Thanks for a great tournament everyone!");
        body.AppendLine("~Tournament Tracker~");

        List<string> bcc = new();

        foreach (TeamModel t in model.EnteredTeams)
        {
            foreach (PersonModel p in t.TeamMembers)
            {
                if (p.EmailAddress != null)
                {
                    bcc.Add(p.EmailAddress);
                }
            }
        }

        // TODO: set up email server
        //EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());

        model.HandleCompleteTournament();
    }

    private static decimal CalculatePrizePayOut(this PrizeModel prize, decimal totalIncome)
    {
        decimal output;

        if (prize.PrizeAmount > 0)
        {
            output = prize.PrizeAmount;
        }
        else
        {
            output = decimal.Multiply(totalIncome, Convert.ToDecimal(prize.PrizePercentage / 100));
        }

        return output;
    }
}
