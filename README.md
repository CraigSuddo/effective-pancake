# Effective Pancake
Got to love Pancakes.

The About details are purposefully vague and the application name is intentionally non descript to prevent someone Googling my code as an answer. This work has been completed for BP.

## My Approach
I started this work with a rough idea as to how I had to do it; each word must link to the next. This immediately made me think of SQL joins as a possible solution. Whilst in bed on the night I was given this task I lay for hours trying to think of the best way to do it. Eventually it came to me; SPOT would become -POT, S-OT, SP-T and SPO-. Other words would do the same, so you could then join SPOT to SPIT, using the common SP-T template.

Whilst I have built it using TDD, there was obviously some initial set up which must take place initially. I set up the Console application and then set up all the required command line parameters as per the specification. I have utilised Command Line Parser as I believe this gives a much more quality feel to a Console application.

Once the initial project layout was created I then set about creating the unit test which would enable me to produce a solid working example of the logic. I set up the words so they could be externally provided to the class, and then used the example from the document as my initial model to work with. I achieved success with this fairly quickly and I was thrilled. I then continued to look at making the application a little better and began to think about utilising the whole dictionary which had been provided.

My confidence was short lived; the huge dictionary made my application go down very, very long rabbit holes. This meant that at one point I found a solution to a problem with 1170 steps. This was not a good approach because I would then find huge solutions before finding the more simple ones. The answer to this was to introduce the searchDepth variable. This enabled me to start searching at a depth of 1 move, then 2 moves, then 3, etc. This means that it will stop when it finds the level with the fewest steps, preventing a lot of lost cycles. It would still continue to search this depth which means it would have come up with multiple solutions. A little pointless, because they'll never become shorter. At the end of the development I have changed this so that it will automatically stop now when it finds a solution.

The way I work through the words is pretty simple; I have a method which is self referencing. It passes down it's current progress (so it can prevent it going into an infinite loop) and it looks at the current words connected words, which have been joined based on the templates they must share. I then traverse each tree until I run out of connecting words at the current depth. I will then allow the software to attempt going down another layer.

## Conclusion
I have thoroughly enjoyed doing this task. At first I thought it was a little daunting as I have not spent enough time recently dealing with complex logical problems and my coding skills definitely needed a little dusting off however I have relished the opportunity to get my brain going, to be challenged by something and it has been a very rewarding process.
