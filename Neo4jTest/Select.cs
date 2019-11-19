using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4jTest
{
    class Select
    {
            
            public void getMoviesOfActor(string name, string lastname) {

                var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "root"));
                var session = driver.Session();

                string statement = "MATCH(p:Person{name:'" + name + "', lastname:'" + lastname + "'})-[:ACTED_IN]->(m:Movie) return m";
                IStatementResult result = session.Run(statement);

                INode node = null;
                string title;
                string tagline;
                Console.WriteLine(name + " " + lastname + " Played in: ");
                foreach (var record in result)
                {
                    node = record["m"].As<INode>();
                    title = node["title"].As<string>();
                    tagline = node["tagline"].As<string>();
                Console.WriteLine(title + ": " + tagline);
                }

            }
            
            public void getActorsOfMovie(string title)
            {

                var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "root"));
                var session = driver.Session();

                string statement = "MATCH(m:Movie{title:'" + title + "'})<-[:ACTED_IN]-(p:Person) return p";

                IStatementResult result = session.Run(statement);

                INode node = null;
                string name;
                string nachname;
                int born;

            Console.WriteLine("The following actors play in " + title + " : ");
                foreach(var record in result)
                {
                    node = record["p"].As<INode>();
                    name = node["name"].As<string>();
                    nachname = node["lastname"].As<string>();
                    born = node["born"].As<int>();

                    Console.WriteLine(name + " " + nachname + ", " + born);
                }

            }
    }
}
