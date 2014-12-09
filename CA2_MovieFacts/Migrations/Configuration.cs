namespace CA2_MovieFacts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CA2_MovieFacts.Models;//Add
    using System.Collections.Generic;//Add

    internal sealed class Configuration : DbMigrationsConfiguration<CA2_MovieFacts.Models.MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CA2_MovieFacts.Models.MoviesDbContext context)
        {
            context.Movies.AddOrUpdate(
                m => m.MovieTitle,
                new Movie { MovieId = 18,  MovieTitle = "The Intouchables", MovieYear = 2011, MovieFacts = "An unlikely friendship develops between a wealthy quadriplegic (François Cluzet) and his caretaker (Omar Sy), just released from prison." },
                new Movie { MovieId = 19, MovieTitle = "The Secret Life of Walter Mitty", MovieYear = 2013, MovieFacts = "Walter Mitty (Ben Stiller), an employee at Life magazine, spends day after monotonous day developing photos for the publication. To escape the tedium, Walter inhabits a world of exciting daydreams in which he is the undeniable hero. Walter fancies a fellow employee named Cheryl (Kristen Wiig) and would love to date her, but he feels unworthy. However, he gets a chance to have a real adventure when Life's new owners send him on a mission to obtain the perfect photo for the final print issue." },
                new Movie { MovieId = 20, MovieTitle = "Life is beautiful", MovieYear = 1997, MovieFacts = "A gentle Jewish-Italian waiter, Guido Orefice (Roberto Benigni), meets Dora (Nicoletta Braschi), a pretty schoolteacher, and wins her over with his charm and humor. Eventually they marry and have a son, Giosue (Giorgio Cantarini). Their happiness is abruptly halted, however, when Guido and Giosue are separated from Dora and taken to a concentration camp. Determined to shelter his son from the horrors of his surroundings, Guido convinces Giosue that their time in the camp is merely a game." },
                new Movie { MovieId = 21, MovieTitle = "Johnny Stecchino", MovieYear = 1991, MovieFacts = "Dante (Roberto Benigni) is a sweet, bumbling school bus driver in Rome, beloved by all, but unlucky in love. That is, until he meets the gorgeous Maria (Nicoletta Braschi), who lures him to Palermo, Italy, with the promise of passion. But Maria is already married to a mob boss who looks just like Dante: Johnny Stecchino (also Benigni). With the Mafia after Johnny for turning snitch, Maria hopes they'll mistakenly whack Dante instead, so she and Johnny can disappear forever." },
                new Movie { MovieId = 22, MovieTitle = "Paul", MovieYear = 2011, MovieFacts = "For the past 60 years, a wisecracking alien named Paul (Seth Rogen) has resided at a top-secret military base in America's UFO heartland. When Paul decides he has had enough of Earth, he escapes from the compound and hops on the first handy vehicle -- a rented RV manned by two British sci-fi nerds named Graeme (Simon Pegg) and Clive (Nick Frost). With federal agents and the father of an accidental kidnap victim on their tail, the two hatch a crazy plan to help Paul return to his spaceship." },
                new Movie { MovieId = 23, MovieTitle = "Apocalypto", MovieYear = 2006, MovieFacts = "The Mayan kingdom is at the height of its opulence and power but the foundations of the empire are beginning to crumble. The leaders believe they must build more temples and sacrifice more people or their crops and citizens will die. Jaguar Paw (Rudy Youngblood), a peaceful hunter in a remote tribe, is captured along with his entire village in a raid. He is scheduled for a ritual sacrifice until he makes a daring escape and tries to make it back to his pregnant wife and son." },
                new Movie { MovieId = 24, MovieTitle = "Into the Wild", MovieYear = 2007, MovieFacts = "Christopher McCandless (Emile Hirsch), son of wealthy parents (Marcia Gay Harden, William Hurt), graduates from Emory University as a top student and athlete. However, instead of embarking on a prestigious and profitable career, he chooses to give his savings to charity, rid himself of his possessions, and set out on a journey to the Alaskan wilderness." },
                new Movie { MovieId = 25, MovieTitle = "Gran Torino", MovieYear = 2008, MovieFacts = "Retired auto worker and Korean War vet Walt Kowalski (Clint Eastwood) fills emptiness in his life with beer and home repair, despising the many Asian, Latino and black families in his neighborhood. Walt becomes a reluctant hero when he stands up to the gangbangers who tried to force an Asian teen to steel Walt's treasured car. An unlikely friendship develops between Walt and the teen, as he learns he has more in common with his neighbors than he thought." },
                new Movie { MovieId = 26, MovieTitle = "Whithnail & I", MovieYear = 1987, MovieFacts = "London 1969 - two 'resting' (unemployed and unemployable) actors, Withnail and Marwood, fed up with damp, cold, piles of washing-up, mad drug dealers and psychotic Irishmen, decide to leave their squalid Camden flat for an idyllic holiday in the countryside, courtesy of Withnail's uncle Monty's country cottage. But when they get there, it rains non-stop, there's no food, and their basic survival skills turn out to be somewhat limited. Matters are not helped by the arrival of Uncle Monty, who shows an uncomfortably keen interest in Marwood..." }
            );//end 

            context.Actors.AddOrUpdate(
                a => a.ActorName,
                new Actor { ActorId = 13, ActorName = "Francois Cluzet", Biography = "François Cluzet (born September 21, 1955) is a French film and theatre actor, best known for playing the wealthy quadraplegic in the international hit The Intouchables (2011). In 2007 Cluzet won a French César Award after starring as a doctor suspected of double homicide in thriller Tell No One." },
                new Actor {ActorId = 14, ActorName = "Nicoletta Braschi", Biography = "Nicoletta Braschi (born April 19, 1960) is an Italian actress and producer, best known for her work with her husband, actor and director Roberto Benigni."},
                new Actor { ActorId = 15, ActorName = "Ben Stiller", Biography = "Benjamin Edward Stiller (born November 30, 1965) is an American actor, comedian, and filmmaker. He is the son of veteran comedians and actors Jerry Stiller and Anne Meara." },
                new Actor { ActorId = 16, ActorName = "Roberto Beigni", Biography = "Roberto Remigio Benigni, (born October 27, 1952) is an Italian actor, comedian, screenwriter and director of film, theatre and television." },
                new Actor { ActorId = 17, ActorName = "Simon Pegg", Biography = "Simon John Pegg (born February 14, 1970) is an English actor, comedian, screenwriter, and film producer. He is best known for having co-written and starred in the Three Flavours Cornetto trilogy of films, consisting of Shaun of the Dead (2004), Hot Fuzz (2007), and The World's End (2013), and the comedy series Spaced (1999–2001), all of them directed by his friend Edgar Wright." },
                new Actor { ActorId = 18, ActorName = "Rudy Youngblood", Biography = "Rudy Youngblood (born on September 21, 1982) is a Native American actor, musician, dancer and artist. He was born in Belton, Texas. Youngblood is of Comanche, Cree, and Yaqui ancestry." },
                new Actor { ActorId = 19, ActorName = "Emile Hirsch", Biography = "Emile Davenport Hirsch (born March 13, 1985) is an American actor. He began performing in the late 1990s, appearing in several television films and series, and became known as a film actor after roles in Lords of Dogtown, The Emperor's Club, The Girl Next Door, Alpha Dog, and the Sean Penn-directed film Into the Wild. Next up, along with Miles Teller and Ellen Page, Hirsch will star in the long awaited Steven Conrad directed and still yet to be titled John Belushi biopic." },
                new Actor { ActorId = 20, ActorName = "Clint Eastwood", Biography = "Clinton Eastwood, Jr. (born May 31, 1930) is an American actor, filmmaker, musician, and politician. He rose to international fame with his role as the Man with No Name in Sergio Leone's Dollars trilogy of spaghetti Westerns during the 1960s, and as Harry Callahan in the five Dirty Harry films throughout the 1970s and 1980s. These roles, among others, have made him an enduring cultural icon of masculinity." },
                new Actor { ActorId = 21, ActorName = "Richard E Grant", Biography = "Richard E. Grant (born May 5, 1957) is a British actor, screenwriter, and director. He came to public attention in 1987 for playing Withnail in the film Withnail and I, and achieved international recognition as John Seward in the 1992 blockbuster Bram Stoker's Dracula." },
                new Actor { ActorId = 22, ActorName = "Omas Sy", Biography = "Omar Sy (born January 20, 1978) is a French film actor, best known for his duo with Fred Testot, Omar et Fred, and for his role in The Intouchables, which became the second highest grossing French film of all time in the French box office. He appeared on Fort Boyard in 2006. He received the Cesar Award for Best Actor on 24 February 2012 for his role in The Intouchables and in doing so also became the first black actor to win the honorary French award. The role also earned him a nomination for a Satellite Award for Best Actor. Sy was born in Trappes, France." },
                new Actor { ActorId = 23, ActorName = "Kirsten Wiig", Biography = "Kristen Carroll Wiig (born August 22, 1973) is an American actress, comedian, writer, and filmmaker, well known for her work on the NBC sketch comedy series Saturday Night Live (2005–12), and such films as Knocked Up (2007), Walk Hard: The Dewey Cox Story (2007), Paul and Bridesmaids (both 2011), Girl Most Likely (2013), The Secret Life of Walter Mitty (2013), the animated Despicable Me film series, and The Skeleton Twins (2014)." }
                );//end

            context.ScreenNames.AddOrUpdate(
                s => s.ActorScreenName,
                new ScreenName { ActorId = 13, MovieId = 20, ActorScreenName = "Phillippe" },
                new ScreenName { ActorId = 14, MovieId = 22, ActorScreenName = "Dora" },
                new ScreenName { ActorId = 14, MovieId = 23, ActorScreenName = "Maria" },
                new ScreenName { ActorId = 15, MovieId = 21, ActorScreenName = " Walter Mitty" },
                new ScreenName { ActorId = 16, MovieId = 22, ActorScreenName = "Guido" },
                new ScreenName { ActorId = 16, MovieId = 23, ActorScreenName = "Dante" },
                new ScreenName { ActorId = 17, MovieId = 24, ActorScreenName = "Graeme Willy" },
              
                new ScreenName { ActorId = 21, MovieId = 26, ActorScreenName = "Whithnaill" },
                new ScreenName { ActorId = 22, MovieId = 20, ActorScreenName = "Driss" },
                new ScreenName { ActorId = 23, MovieId = 24, ActorScreenName = "Cheryl Melhoff" },
                new ScreenName { ActorId = 18, MovieId = 18, ActorScreenName = "Jaguar Paw" },
                new ScreenName { ActorId = 19, MovieId = 25, ActorScreenName = "Chris McCandless" },
                new ScreenName { ActorId = 20, MovieId = 19, ActorScreenName = "Walt Kowalski" }
                );//end

              //new ScreenName { ActorId = 6, MovieId = 6, ActorScreenName = "Jaguar Paw" },
              //  new ScreenName { ActorId = 7, MovieId = 7, ActorScreenName = "Chris McCandless" },
              //  new ScreenName { ActorId = 8, MovieId = 8, ActorScreenName = "Walt Kowalski" },
        }
    }
}