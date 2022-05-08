# Behaviors of players

## DjangoPlayer

Follows player. If + or any boost is in the radius, then collects it.

## TangoPlayer

Walks randomly and Collescts +. Prioritizes reset boost over speed bonus. If reset is closer than +, collect reset.

## MangoPlayer

first 15 secs collects only +. after collects everything which is close. prioritizes boosts over +.



    // TODO: To complete this assignment, you will need to write 
    //       a fair amount of code. It is recommended to create
    //       custom classes/functions to decouple the computations.

    //       The method EvaluateDecisions should be the place where the final decision
    //       should be computed. The bot automatically follows the path which is
    //       described in the "pathTilesQueue" variable. All neighboring values inside
    //       this queue must be 4-neighbors, i.e., the bot can walk only
    //       up/down/left/right with a step of one.
    //      
    //       You do not have to use all arguments of this function 
    //       and you can add even more parameters if you would like to do so.
    //       Tiles of the maze can be accessed via maze.MazeTiles.
    //       Human player is the first player in the "players" list.
    //       CollectibleItem class contains TileLocation property providing information about collectible's position
    //       and Type property retrieving its type.
    //       Good luck. May your bots remain unbeaten by a human player. :)