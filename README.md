Tournament Tracker is a Windows forms desktop application that allows users to create and play through elimination-style tournaments (e.g. an indoor soccer tournament). 
It allows users to create team members, form teams and specify prizes. The application proceeds to randomize the rounds and matchups to create a tournament.

The application will allow the user to save data to both MSSQL and CSV. Data access for MSSQL uses Dapper via stored procedures for greater control of data querying
according to application needs.

The application consists of 5 different forms:

1. Tournament Dashboard Form: Will allow you to see all active tournaments that are currently taking place.

![TournamentDashboardForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/97ba1602-49a9-45a4-9cbc-5f5193486dd0)

2. Scoring Form: Will allow you to see all the current matchups and their respective scores.

![ScoreForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/c4af88dc-247d-41b3-ac43-6da0d6598c75)

3. Tournament Form: Will allow you to create tournaments by creating prizes, teams, etc...

![TournamentForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/3151cdb4-9e4a-414e-87e6-557cb44ac9bb)

4. Prize Form: Will allow you to create prizes for the tournaments.

![PrizeForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/970a178f-1e30-4388-b709-76ce99b56f07)

5. Team Form: Will allow you to create teams by creating members.

![TeamForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/c8346988-1c9c-4d7e-a728-9aa9f3a6b0b7)

This was completed as a practice project following along Tim Corey's course on C# Windows Forms application development.
