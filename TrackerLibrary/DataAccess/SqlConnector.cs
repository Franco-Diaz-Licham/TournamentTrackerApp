
using System.Text.RegularExpressions;
using TrackerLibrary.AppLogic;

namespace TrackerLibrary.DataAccess;

public class SqlConnector : IDataConnection
{
    public void CreatePrize(PrizeModel model)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            var p = new DynamicParameters();
            p.Add("@PlaceNumber", model.PlaceNumber);
            p.Add("@PlaceName", model.PlaceName);
            p.Add("@PrizeAmount", model.PrizeAmount);
            p.Add("@PrizePercentage", model.PrizePercentage);
            p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("TOURNAMENT_TRACKER.spPrizes_Insert",
                       param: p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("Id");
        }
    }

    public void CreatePerson(PersonModel model)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            var p = new DynamicParameters();
            p.Add("@FirstName", model.FirstName);
            p.Add("@LastName", model.LastName);
            p.Add("@EmailAddress", model.EmailAddress);
            p.Add("@CellPhoneNumber", model.CellphoneNumber);
            p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("TOURNAMENT_TRACKER.spPerson_Insert",
                       param: p, commandType: CommandType.StoredProcedure);
            model.Id = p.Get<int>("Id");
        }
    }

    public void CreateTeam(TeamModel model)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            // create team
            var p = new DynamicParameters();
            p.Add("@TeamName", model.TeamName);
            p.Add("Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            connection.Execute("TOURNAMENT_TRACKER.spTeam_Insert",
                       param: p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("Id");

            // create team members
            foreach (PersonModel tm in model.TeamMembers)
            {
                p = new DynamicParameters();
                p.Add("@TeamId", model.Id);
                p.Add("@PersonId", tm.Id);
                connection.Execute("TOURNAMENT_TRACKER.spTeamMembers_Insert",
                           param: p, commandType: CommandType.StoredProcedure);
            }
        }
    }

    public void CreateTournament(TournamentModel model)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            SaveTournament(connection, model);
            SaveTournamentPrizes(connection, model);
            SaveTournamentEntries(connection, model);
            SaveTournamentRounds(connection, model);
            // since byes have been determined, update the tournament.
            TournamentLogic.UpdateTournamentResults(model);
        }
    }

    private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
    {
        // loop through the rounds
        foreach (List<MatchupModel> round in model.Rounds)
        {
            foreach (MatchupModel matchup in round)
            {
                // loop through the matchups and save them
                var t = new DynamicParameters();
                t.Add("@TournamentId", model.Id);
                t.Add("@MatchupRound", matchup.MatchupRound);
                t.Add("Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("TOURNAMENT_TRACKER.spMatchups_Insert",
                           param: t, commandType: CommandType.StoredProcedure);

                matchup.Id = t.Get<int>("Id");

                // loop through the entries and save them
                foreach (MatchupEntryModel entry in matchup.Entries)
                {
                    t = new DynamicParameters();
                    t.Add("@MatchupId", matchup.Id);

                    if (entry.TeamCompeting == null)
                    {
                        t.Add("@TeamCompetingId", null);
                    }
                    else
                    {
                        t.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                    }
                    if (entry.ParentMatchup == null)
                    {
                        t.Add("@ParentMatchupId", null);
                    }
                    else
                    {
                        t.Add("@ParentMatchupId", entry.ParentMatchup.Id);
                    }
                    t.Add("Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("TOURNAMENT_TRACKER.spMatchupEntries",
                               param: t, commandType: CommandType.StoredProcedure);

                    entry.Id = t.Get<int>("Id");
                }
            }
        }
    }

    private void SaveTournamentEntries(IDbConnection connection, TournamentModel model)
    {
        // create TournamentEntries
        foreach (TeamModel team in model.EnteredTeams)
        {
            var t = new DynamicParameters();
            t.Add("@TournamentId", model.Id);
            t.Add("@TeamId", team.Id);
            t.Add("Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("TOURNAMENT_TRACKER.spTournamentEntries_Insert",
                       param: t, commandType: CommandType.StoredProcedure);
        }
    }

    private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model)
    {
        // create TournamentPrizes
        foreach (PrizeModel pr in model.Prizes)
        {
            var t = new DynamicParameters();
            t.Add("@TournamentId", model.Id);
            t.Add("@PrizeId", pr.Id);
            t.Add("Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("TOURNAMENT_TRACKER.spTournamentPrizes_Insert",
                       param: t, commandType: CommandType.StoredProcedure);
        }
    }

    private void SaveTournament(IDbConnection connection, TournamentModel model)
    {
        // create Tournament
        var t = new DynamicParameters();
        t.Add("@TournamentName", model.TournamentName);
        t.Add("@EntryFee", model.EntryFee);
        t.Add("Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

        connection.Execute("TOURNAMENT_TRACKER.spTournament_Insert",
                   param: t, commandType: CommandType.StoredProcedure);

        model.Id = t.Get<int>("Id");
    }

    public List<PersonModel> GetPerson_All()
    {
        List<PersonModel> output;
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            output = connection.Query<PersonModel>("TOURNAMENT_TRACKER.spPeople_GetAll").ToList();
        }
        return output;
    }

    public List<TeamModel> GetTeam_All()
    {
        List<TeamModel> output;
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            output = connection.Query<TeamModel>("TOURNAMENT_TRACKER.spTeam_GetAll").ToList();

            foreach (TeamModel team in output)
            {
                var t = new DynamicParameters();
                t.Add("@TeamId", team.Id);
                team.TeamMembers = connection.Query<PersonModel>("TOURNAMENT_TRACKER.spTeamMembers_GetByTeam",
                                   t, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        return output;
    }

    public List<TournamentModel> GetTournament_All()
    {
        List<TournamentModel> output;
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            output = connection.Query<TournamentModel>("TOURNAMENT_TRACKER.spTournament_GetAll").ToList();

            foreach (TournamentModel tm in output)
            {
                // populate teams
                var t = new DynamicParameters();
                t.Add("@TournamentId", tm.Id);
                tm.EnteredTeams = connection.Query<TeamModel>("TOURNAMENT_TRACKER.spTeams_GetByTournament",
                                  t, commandType: CommandType.StoredProcedure).ToList();

                foreach (TeamModel team in tm.EnteredTeams)
                {
                    t = new DynamicParameters();
                    t.Add("@TeamId", team.Id);
                    team.TeamMembers = connection.Query<PersonModel>("TOURNAMENT_TRACKER.spTeamMembers_GetByTeam",
                                       t, commandType: CommandType.StoredProcedure).ToList();
                }

                // populate prizes
                t = new DynamicParameters();
                t.Add("@TournamentId", tm.Id);
                tm.Prizes = connection.Query<PrizeModel>("TOURNAMENT_TRACKER.spPrizes_GetByTournament",
                            t, commandType: CommandType.StoredProcedure).ToList();

                // populate rounds
                t = new DynamicParameters();
                t.Add("@TournamentId", tm.Id);
                List<MatchupModel> matchups = connection.Query<MatchupModel>("TOURNAMENT_TRACKER.spMatchup_GetByTournament",
                                   t, commandType: CommandType.StoredProcedure).ToList();

                foreach (MatchupModel matchup in matchups)
                {
                    t = new DynamicParameters();
                    t.Add("@MatchupId", matchup.Id);
                    matchup.Entries = connection.Query<MatchupEntryModel>("TOURNAMENT_TRACKER.spMatchupEntries_GetByTournament",
                                      t, commandType: CommandType.StoredProcedure).ToList();

                    List<TeamModel> allTeams = GetTeam_All();

                    foreach (MatchupEntryModel me in matchup.Entries)
                    {
                        if (me.TeamCompetingId > 0)
                        {
                            me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                        }

                        if (me.ParentMatchupId > 0)
                        {
                            me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupId).First();
                        }
                    }

                    if (matchup.WinnerId > 0)
                    {
                        matchup.Winner = allTeams.Where(x => x.Id == matchup.WinnerId).First();
                    }

                }

                List<MatchupModel> currRow = new List<MatchupModel>();
                int currRound = 1;
                foreach (MatchupModel matchup in matchups)
                {
                    if (matchup.MatchupRound > currRound)
                    {
                        tm.Rounds.Add(currRow);
                        currRow = new List<MatchupModel>();
                        currRound += 1;
                    }
                    currRow.Add(matchup);
                }

                tm.Rounds.Add(currRow);
            }
        }
        return output;
    }

    public List<PrizeModel> GetPrize_All()
    {
        throw new NotImplementedException();
    }

    public void UpdateMatchup(MatchupModel Matchup)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {

            if (Matchup.Winner != null)
            {
                var t = new DynamicParameters();
                t.Add("@Id", Matchup.Id);
                t.Add("@WinnerId", Matchup.Winner.Id);
                connection.Execute("TOURNAMENT_TRACKER.spMatchup_Update",
                param: t, commandType: CommandType.StoredProcedure);
            }

            foreach (MatchupEntryModel Entry in Matchup.Entries)
            {
                if (Entry.TeamCompeting != null)
                {
                    var t = new DynamicParameters();
                    t = new DynamicParameters();
                    t.Add("@Id", Entry.Id);
                    t.Add("@TeamCompetingId", Entry.TeamCompeting.Id);
                    t.Add("@Score", Entry.Score);
                    connection.Execute("TOURNAMENT_TRACKER.spMatchupEntry_Update",
                                        param: t, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }

    public void CompleteTournament(TournamentModel model)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
        {
            var t = new DynamicParameters();
            t.Add("@Id", model.Id);
            t.Add("@Complete", 0);
            connection.Execute("TOURNAMENT_TRACKER.spTournament_Update",
            param: t, commandType: CommandType.StoredProcedure);
        }
    }
}
