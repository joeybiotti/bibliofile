using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bibliofile.Models;
using Bibliofile.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bibliofile.Data
{
    //Built on 9/12. Seeds DB with data for initial testing 
    public static class DBInitilzer
    {
        public static void Initilizer(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //check DB for any books
                if (context.Books.Any())
                {
                    return; //DB has been seeded
                }

                //Seeder data
                var book = new Books[]
                {
                    new Books{
                        Title = "Post Office", 
                        Author = "Charles Bukowski", 
                        Image = "https://images.gr-assets.com/books/1424999238l/51504.jpg",
                        Description = "'It began as a mistake.' By middle age, Henry Chinaski has lost more than twelve years of his life to the U.S. Postal Service. In a world where his three true, bitter pleasures are women, booze, and racetrack betting, he somehow drags his hangover out of bed every dawn to lug waterlogged mailbags up mud-soaked mountains, outsmart vicious guard dogs, and pray to survive the day-to-day trials of sadistic bosses and certifiable coworkers."
                    },
                    new Books{
                        Title="The Autobiography of Gucci Mane",
                        Author="Gucci Mane",
                        Image="https://images.gr-assets.com/books/1501538675m/34623128.jpg",
                        Description="For the first time Gucci Mane tells his story in his own words. It is the captivating life of an artist who forged an unlikely path to stardom and personal rebirth. Gucci Mane began writing his memoir in a maximum-security federal prison. Released in 2016, he emerged radically transformed. He was sober, smiling, focused, and positive—a far cry from the Gucci Mane of years past."
                    },
                    new Books{
                        Title="The Sun Also Rises", 
                        Author="Ernest Hemingway",
                        Image="https://images.gr-assets.com/books/1331828228l/3876.jpg", 
                        Description="The quintessential novel of the Lost Generation, The Sun Also Rises is one of Ernest Hemingway's masterpieces and a classic example of his spare but powerful writing style. A poignant look at the disillusionment and angst of the post-World War I generation, the novel introduces two of Hemingway's most unforgettable characters: Jake Barnes and Lady Brett Ashley. The story follows the flamboyant Brett and the hapless Jake as they journey from the wild nightlife of 1920s Paris to the brutal bullfighting rings of Spain with a motley group of expatriates. It is an age of moral bankruptcy, spiritual dissolution, unrealized love, and vanishing illusions. First published in 1926, The Sun Also Rises helped to establish Hemingway as one of the greatest writers of the twentieth century."
                    },
                    new Books{
                        Title= "The Great Gatsby", 
                        Author= "F. Scott Fitzgerald", 
                        Image= "https://images.gr-assets.com/books/1490528560l/4671.jpg", 
                        Description="THE GREAT GATSBY, F. Scott Fitzgerald’s third book, stands as the supreme achievement of his career. This exemplary novel of the Jazz Age has been acclaimed by generations of readers. The story of the fabulously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan, of lavish parties on Long Island at a time when The New York Times noted “gin was the national drink and sex the national obsession,” it is an exquisitely crafted tale of America in the 1920s."

                    }, 
                    new Books{
                        Title= "The Outsiders", 
                        Author="S.E. Hinton",
                        Image="https://images.gr-assets.com/books/1442129426l/231804.jpg",
                        Description="According to Ponyboy, there are two kinds of people in the world: greasers and socs. A soc (short for 'social') has money, can get away with just about anything, and has an attitude longer than a limousine. A greaser, on the other hand, always lives on the outside and needs to watch his back. Ponyboy is a greaser, and he's always been proud of it, even willing to rumble against a gang of socs for the sake of his fellow greasers--until one terrible night when his friend Johnny kills a soc. The murder gets under Ponyboy's skin, causing his bifurcated world to crumble and teaching him that pain feels the same whether a soc or a greaser."
                    },
                    new Books{
                        Title="In Cold Blood",
                        Author="Truman Capote",
                        Image="https://images.gr-assets.com/books/1388208531l/9920.jpg",
                        Description="On November 15, 1959, in the small town of Holcomb, Kansas, four members of the Clutter family were savagely murdered by blasts from a shotgun held a few inches from their faces. There was no apparent motive for the crime, and there were almost no clues. </n> As Truman Capote reconstructs the murder and the investigation that led to the capture, trial, and execution of the killers, he generates both mesmerizing suspense and astonishing empathy. In Cold Blood is a work that transcends its moment, yielding poignant insights into the nature of American violence"
                    },
                    new Books{
                        Title="On The Road",
                        Author="Jack Kerouac",
                        Image="https://images.gr-assets.com/books/1413588576l/70401.jpg", 
                        Description=" On the Road chronicles Jack Kerouac's years traveling the North American continent with his friend Neal Cassady, 'a sideburned hero of the snowy West.' As 'Sal Paradise' and 'Dean Moriarty,' the two roam the country in a quest for self-knowledge and experience. Kerouac's love of America, his compassion for humanity, and his sense of language as jazz combine to make On the Road an inspirational work of lasting importance. </n>Kerouac's classic novel of freedom and longing defined what it meant to be 'Beat' and has inspired every generation since its initial publication."
                    },
                    new Books{
                        Title="Hillbilly Elegy: A Memoir of a Family and Culture in Crisis",
                        Author="J.D. Vance",
                        Image="https://images.gr-assets.com/books/1463569814l/27161156.jpg", 
                        Description="From a former Marine and Yale Law School Graduate, a poignant account of growing up in a poor Appalachian town, that offers a broader, probing look at the struggles of America’s white working class. Part memoir, part historical and social analysis, J. D. Vance’s Hillbilly Elegy is a fascinating consideration of class, culture, and the American dream."
                    },
                    new Books{
                         Title="The Amazing Adventures of Kavalier & Clay",
                         Author="Michael Chabon",
                         Image="https://images.gr-assets.com/books/1333579505l/12679626.jpg",
                         Description="Joe Kavalier, a young Jewish artist who has also been trained in the art of Houdini-esque escape, has just smuggled himself out of Nazi-invaded Prague and landed in New York City. His Brooklyn cousin Sammy Clay is looking for a partner to create heroes, stories, and art for the latest novelty to hit America - the comic book. Drawing on their own fears and dreams, Kavalier and Clay create the Escapist, the Monitor, and Luna Moth, inspired by the beautiful Rosa Saks, who will become linked by powerful ties to both men. With exhilarating style and grace, Michael Chabon tells an unforgettable story about American romance and possibility."
                    },
                    new Books{
                         Title="The Catcher in the Rye",
                         Author="J.D. Salinger",
                         Image="https://images.gr-assets.com/books/1398034300l/5107.jpg", 
                         Description="J.D. Salinger's classic novel of teenage angst and rebellion was first published in 1951. The novel was included on Time's 2005 list of the 100 best English-language novels written since 1923. It was named by Modern Library and its readers as one of the 100 best English-language novels of the 20th century. It has been frequently challenged in the court for its liberal use of profanity and portrayal of sexuality and in the 1950's and 60's it was the novel that every teenage boy wants to read."
                    },
                    new Books{
                         Title="The Road",
                         Author="Cormac McCarthy",
                         Image="https://images.gr-assets.com/books/1439197219l/6288.jpg",
                         Description="A father and his son walk alone through burned America. Nothing moves in the ravaged landscape save the ash on the wind. It is cold enough to crack stones, and when the snow falls it is gray. The sky is dark. Their destination is the coast, although they don’t know what, if anything, awaits them there. They have nothing; just a pistol to defend themselves against the lawless bands that stalk the road, the clothes they are wearing, a cart of scavenged food—and each other."
                    },
                    new Books{
                         Title="Siddhartha",
                         Author="Hermann Hesse",
                         Image="https://images.gr-assets.com/books/1428715580l/52036.jpg",
                         Description="In the novel, Siddhartha, a young man, leaves his family for a contemplative life, then, restless, discards it for one of the flesh. He conceives a son, but bored and sickened by lust and greed, moves on again. Near despair, Siddhartha comes to a river where he hears a unique sound. This sound signals the true beginning of his life—the beginning of suffering, rejection, peace, and, finally, wisdom."
                    },
                    new Books{
                         Title="The Stranger",
                         Author="Albert Camus",
                         Image="https://images.gr-assets.com/books/1349927872l/49552.jpg",
                         Description="Since it was first published in English, in 1946, Albert Camus's first novel, THE STRANGER (L'etranger), has had a profound impact on millions of American readers. Through this story of an ordinary man who unwittingly gets drawn into a senseless murder on a sundrenched Algerian beach, Camus explored what he termed 'the nakedness of man faced with the absurd.'"
                    },
                    new Books{
                         Title="The Big Sleep",
                         Author="Raymond Chandler",
                         Image="https://images.gr-assets.com/books/1371584712l/2052.jpg", 
                         Description="The Big Sleep (1939) is a hardboiled crime novel by Raymond Chandler, the first to feature the detective Philip Marlowe. It has been adapted for film twice, in 1946 and again in 1978. The story is set in Los Angeles, California. "
                    },
                    new Books{
                         Title="The Killer Inside Me",
                         Author="Jim Thompson",
                         Image="https://images.gr-assets.com/books/1403187402l/298663.jpg", 
                         Description="In The Killer Inside Me, Thompson goes where few novelists have dared to go, giving us a pitch-black glimpse into the mind of the American Serial Killer years before Charles Manson, John Wayne Gacy, and Brett Easton Ellis's American Psycho, in the novel that will forever be known as the master performance of one of the greatest crime novelists of all time"
                    },
                    new Books{
                         Title="On Writing: A Memoir of the Craft",
                         Author="Stephen King",
                         Image="https://images.gr-assets.com/books/1348589692l/7143113.jpg", 
                         Description="Part memoir, part master class by one of the bestselling authors of all time, this superb volume is a revealing and practical view of the writer's craft, comprising the basic tools of the trade every writer must have. King's advice is grounded in his vivid memories from childhood through his emergence as a writer, from his struggling early career to his widely reported near-fatal accident in 1999—and how the inextricable link between writing and living spurred his recovery. Brilliantly structured, friendly and inspiring, On Writing will empower and entertain everyone who reads it—fans, writers, and anyone who loves a great story well told."
                    },
                    new Books{
                         Title="The Elements of Style",
                         Author="William Strunk Jr. and E.B. White",
                         Image="https://images.gr-assets.com/books/1347762378l/3721092.jpg",
                         Description="This style manual offers practical advice on improving writing skills. Throughout, the emphasis is on promoting a plain English style. This little book can help you communicate more effectively by showing you how to enliven your sentences"
                    },
                    new Books{
                        Title="Please Kill Me: The Uncensored Oral History of Punk",
                        Author="Legs McNeil, Gillian McCain",
                        Image="https://images.gr-assets.com/books/1436668905l/14595.jpg",
                        Description="A Time Out and Daily News Top Ten Book of the Year upon its initial release, Please Kill Me is the first oral history of the most nihilist of all pop movements. Iggy Pop, Danny Fields, Dee Dee and Joey Ramone, Malcom McLaren, Jim Carroll, and scores of other famous and infamous punk figures lend their voices to this definitive account of that outrageous, explosive era. From its origins in the twilight years of Andy Warhol's New York reign to its last gasps as eighties corporate rock, the phenomenon known as punk is scrutinized, eulogized, and idealized by the people who were there and who made it happen."
                    },
                    new Books{
                        Title="Naked Lunch", 
                        Author="William S. Burroughs",
                        Image="https://images.gr-assets.com/books/1407330990l/7437.jpg", 
                        Description="Naked Lunch (sometimes The Naked Lunch) is a novel by William S. Burroughs originally published in 1959. The book is structured as a series of loosely connected vignettes. Burroughs stated that the chapters are intended to be read in any order. The reader follows the narration of junkie William Lee, who takes on various aliases, from the US to Mexico, eventually to Tangier and the dreamlike Interzone."
                    },
                    new Books{
                        Title="Ham on Rye",
                        Author="Charles Bukowski",
                        Image="https://images.gr-assets.com/books/1296481494l/624821.jpg",
                        Description="In what is widely hailed as the best of his many novels, Charles Bukowski details the long, lonely years of his own hardscrabble youth in the raw voice of alter ego Henry Chinaski. From a harrowingly cheerless childhood in Germany through acne-riddled high school years and his adolescent discoveries of alcohol, women, and the Los Angeles Public Library's collection of D. H. Lawrence, Ham on Rye offers a crude, brutal, and savagely funny portrait of an outcast's coming-of-age during the desperate days of the Great Depression."
                    },
                    new Books{
                        Title="Beowulf", 
                        Author="Seamus Heaney (Translator)",
                        Image="https://images.gr-assets.com/books/1327878125l/52357.jpg",
                        Description="Composed toward the end of the first millennium, Beowulf is the classic Northern epic of a hero’s triumphs as a young warrior and his fated death as a defender of his people. The poem is about encountering the monstrous, defeating it, and then having to live on, physically and psychically exposed in the exhausted aftermath. It is not hard to draw parallels in this story to the historical curve of consciousness in the twentieth century, but the poem also transcends such considerations, telling us psychological and spiritual truths that are permanent and liberating."
                    },
                    new Books{
                        Title="A Farewell to Arms", 
                        Author="Ernest Hemingway",
                        Image="https://images.gr-assets.com/books/1369579147l/17978811.jpg",
                        Description="In 1918 Ernest Hemingway went to war, to the war to end all wars. He volunteered for ambulance service in Italy, was wounded, and twice decorated. Out of his experiences came A Farewell to Arms. Hemingway's description of war is unforgettable. He recreates the fear, the comradeship, the courage of his young American volunteer, and the men and women he meets in Italy with total conviction. But A Farewell to Arms is not only a novel of war. In it, Hemingway has also created a love story of immense drama and uncompromising passion."
                    },
                    new Books{
                        Title="The Maltese Falcon", 
                        Author="Dashiell Hammett",
                        Image="https://images.gr-assets.com/books/1306421260l/29999.jpg",
                        Description="Sam Spade is hired by the fragrant Miss Wonderley to track down her sister, who has eloped with a louse called Floyd Thursby. But Miss Wonderley is in fact the beautiful and treacherous Brigid O'Shaughnessy, and when Spade's partner Miles Archer is shot while on Thursby's trail, Spade finds himself both hunter and hunted: can he track down the jewel-encrusted bird, a treasure worth killing for, before the Fat Man finds him?"
                    },
                    new Books{
                        Title="The Birth and Death of Meaning: An Interdisciplinary Perspective on the Problem of Man", 
                        Author="Ernest Becker",
                        Image="https://images.gr-assets.com/books/1347637531l/162759.jpg",
                        Description="Uses the disciplines of psychology, anthropology, sociology and psychiatry to explain what makes people act the way they do."
                    },
                    new Books{
                        Title="The Demon-Haunted World: Science as a Candle in the Dark", 
                        Author="Carl Sagan",
                        Image="https://images.gr-assets.com/books/1405201597l/17349.jpg",
                        Description="How can we make intelligent decisions about our increasingly technology-driven lives if we don't understand the difference between the myths of pseudoscience and the testable hypotheses of science? Pulitzer Prize-winning author and distinguished astronomer Carl Sagan argues that scientific thinking is critical not only to the pursuit of truth but to the very well-being of our democratic institutions."
                    },
                    new Books{
                        Title="The Black Swan", 
                        Author="Nassim Nicholas Taleb",
                        Image="https://images.gr-assets.com/books/1386925471l/242472.jpg",
                        Description="Elegant, startling, and universal in its applications 'The Black Swan' will change the way you look at the world. Taleb is a vastly entertaining writer, with wit, irreverence, and unusual stories to tell. He has a polymathic command of subjects ranging from cognitive science to business to probability theory."
                    },
                    new Books{
                        Title="Life", 
                        Author="Keith Richards",
                        Image="https://images.gr-assets.com/books/1398913378l/17278308.jpg",
                        Description="With the Rolling Stones, Keith Richards created the riffs, the lyrics and the songs that roused the world, and over four decades he lived the original rock and roll life. Now, at last, the man himself tells us the story of life in the crossfire hurricane."
                    }
                };

                foreach(Books x in book)
                {
                     context.Add(x);
                     context.SaveChanges();
                }
                
                }
            }

        }
    }
