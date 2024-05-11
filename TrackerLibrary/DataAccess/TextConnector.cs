namespace TrackerLibrary.DataAccess;

public class TextConnector : IDataConnection
{
    public void CreatePrize(
            PrizeModel model)
    {
        // 1. Load the text file unto program
        // 2. Convert the text to List<PrizeModel> i.e. a list of models
        List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

        // 3. Find the max ID
        // N.B. OrderByDesceding takes in a List of objects
        // which we can order based on a property
        int currentId = 1;
        if (prizes.Count > 0)
        {
            currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
        }
        model.Id = currentId;

        // 4. Add the new record with the new ID (maxx + 1) to the list of models
        prizes.Add(model);

        // 5. Convert the prizes from list<model> to List<string> 
        // 6. Save the List<String> to the text file
        prizes.SaveToPrizeFile();
    }

    public void CreatePerson(
            PersonModel model)
    {
        List<PersonModel> persons = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        int currentId = 1;
        if(persons.Count > 0)
            currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;

        model.Id = currentId;
        persons.Add(model);
        persons.SaveToPeopleFile();
    }

    public void CreateTeam(
            TeamModel model)
    {
        List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        int currentId = 1;
        if (teams.Count > 0)
            currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;

        model.Id = currentId;
        teams.Add(model);
        teams.SaveToTeamFile(GlobalConfig.TeamFile);
    }

    public void CreateTournament(
            TournamentModel model)
    {
        List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

        int currentId = 1;

        if (tournaments.Count > 0)
            currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;

        model.Id = currentId;
        model.SaveRoundsToFile();
        tournaments.Add(model);
        tournaments.SaveToTournamentFile();

        // since byes have been determined, update the tournament.
        TournamentLogic.UpdateTournamentResults(model);
    }

    public List<PersonModel> GetPerson_All()
    {
        return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
    }

    public List<TeamModel> GetTeam_All()
    {
        List < TeamModel > teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        return teams;
    }

    public List<TournamentModel> GetTournament_All()
    {
        return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();
    }

    public List<PrizeModel> GetPrize_All()
    {
        return GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
    }

    public void UpdateMatchup(
            MatchupModel Matchup)
    {
        Matchup.UpdateMatchupToFile();
    }

    public void CompleteTournament(
            TournamentModel model)
    {
        List<TournamentModel> tournaments = GlobalConfig.TournamentFile
                                            .FullFilePath()
                                            .LoadFile()
                                            .ConvertToTournamentModels();

        tournaments.Remove(model);
        tournaments.SaveToTournamentFile();

        // since byes have been determined, update the tournament.
        TournamentLogic.UpdateTournamentResults(model);
    }
}
