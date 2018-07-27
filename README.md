# B.O.T.W. Search



A silly little ASP.net core &amp; elasticsearch app to help with recipes and items for breath of the wild.
This is just a little playground, and not really code I would write for a production application. Testing / good commit messages
are lacking.

![BOTW](screenshot.png?raw=true "BOTW")

### To run:

* clone the repo
* `cd botw && dotnet restore`
* docker-compose up (wait for elasticsearch)
* open another shell
* `cd importer && dotent run && cd -`
* `cd frontend/ClientApp && yarn install && cd -`
* `cd frontend && ASPNETCORE_ENVIRONMENT=Development dotnet run`
* visit http://localhost:5000
