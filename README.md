# MovieAPI

MovieAPI is an ASP.NET Core web api for Movies,Actors and producers.

Entities
The core objects of this application are
  Movie
  Actor
  Producer

Relationships
The relationships among the entities are
  An actor can act in multiple movies
  A movie can have multiple actors 
  A movie has only one producer
  A producer can produce multiple movies
  
APIS:
Consists of IMovieRepository,MovieRepository,MovieController
MovieRepository: It implements methods in IMovieRepository and have connection to database.
MovieController: It  consists of API End points.

1.List of Movies:
https://localhost:44357/api/Movies

response:

![GETResponsepart1](https://user-images.githubusercontent.com/58428516/180643167-c63564af-a0c0-4db3-802b-1f1996ece173.JPG)
![GETResponsepart2](https://user-images.githubusercontent.com/58428516/180643189-2f17bf8c-5dde-4498-a34d-d612ab81fd39.JPG)
![GETResponsepart3](https://user-images.githubusercontent.com/58428516/180643198-5a32be92-dbd8-4bfb-a8b0-7ba4d91c98fe.JPG)

2.Create a Movie:
Response:
![PostResponse](https://user-images.githubusercontent.com/58428516/180643336-aab9279d-d736-4327-b984-576ef895cba5.JPG)


3.Edit Movie:
![Editresponse](https://user-images.githubusercontent.com/58428516/180643351-c1387874-ab16-46f4-b406-01758668d470.JPG)


SQL Queries:
Under Data/SqlScripts.txt contains queries


Used Repository Pattern to develop API and Dependency Injection is also used.

