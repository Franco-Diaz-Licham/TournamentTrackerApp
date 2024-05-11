Tournament Tracker is a Windows forms desktop application that allows users to create and play through elimination-style tournaments (e.g. an indoor soccer tournament). 
It allows users to create team members, form teams and specify prizes. The application proceeds to randomize the rounds and matchups to create a tournament.

The application will allow the user to save data either to MSSQL and Text files. Data access for MSSQL uses Dapper via stored procedures for greater control of data querying
according to application needs. The application also send email notifying teams of their next round as well as SMS via Twilio Api Integration.

The application consists of 5 different forms:

1. Tournament Dashboard Form: Will allow you to see all active tournaments that are currently taking place.

![TournamentDashboardForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/82a2b42e-ea7d-4586-95cc-8974e467e060)

2. Scoring Form: Will allow you to see all the current matchups and their respective scores.

![ScoreForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/d70ce3c0-883f-4fea-872d-1d6f1c70b200)

3. Tournament Form: Will allow you to create tournaments by creating prizes, teams, etc...

![TournamentForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/3151cdb4-9e4a-414e-87e6-557cb44ac9bb)

4. Prize Form: Will allow you to create prizes for the tournaments.

![PrizeForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/970a178f-1e30-4388-b709-76ce99b56f07)

5. Team Form: Will allow you to create teams by creating members.

![TeamForm](https://github.com/Franco-Diaz-Licham/TournamentTracker/assets/138960498/c8346988-1c9c-4d7e-a728-9aa9f3a6b0b7)

This was completed as a practice project based on Tim Corey's course on C# Application Development.
