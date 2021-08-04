# Effective Pancake
Got to love Pancakes.

The About details are purposefully vague and the application name is intentionally non descript to prevent someone Googling my code as an answer. This work has been completed for BP.

## My Approach
I started this work with a rough idea as to how I had to do it; each word must link to the next. This immediately made me think of SQL joins as a possible solution.

Whilst I have built it using TDD, there was obviously some initial set up which must take place initially. I set up the Console application and then set up all the required command line parameters as per the specification. I have utilised Command Line Parser as I believe this gives a much more quality feel to a Console application.

Once the initial project layout was created I then set about creating the unit test which would enable me to produce a solid working example of the logic. I set up the words so they could be externally provided to the class, and then used the example from the document as my initial model to work with. I achieved success with this fairly quickly and I was thrilled. I then continued to look at making the application a little better and began to think about utilising the whole dictionary which had been provided.

My confidence was short lived; the huge dictionary made my application go down very, very long rabbit holes. This meant that at one point I found a solution to a problem with 1170 steps. This was not a good approach because I would then find huge solutions before finding the more simple ones. The answer to this was to introduce the searchDepth variable. This enabled me to start searching at a depth of 1 move, then 2 moves, then 3, etc. This means that it will stop when it finds the level with the fewest steps, preventing a lot of lost cycles.

