Welcome to the Cat API

To start launch and run the WebAPI project - data should already be seeded.

API links
/facts
/facts/{id} - try /facts/9f77dfa5-21a7-4510-903f-8ab541e30730
/facts/csv - this will download a CSV in the format mentioned


Units tests are provided

Architecture used 
 - CQRS see pattern image
 - DDD - Onion pattern - see https://code-maze.com/onion-architecture-in-aspnetcore/

 Underneath at the repository layer it is using Entity Framework Core