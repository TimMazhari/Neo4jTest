using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neo4jTest
{
    public class Yeet
    {
        static void Main(string[] args)
        {
            Select select = new Select();
            //select.getMoviesOfActor("Tom", "Hanks");
            select.getActorsOfMovie("The Da Vinci Code");

        }
    }
}
