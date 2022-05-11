# Behaviors of players

## DjangoPlayer

Follows Human player as supposes that human player is the best player in the maze. If any collectible is in the predefined radius (3 tiles), then collects it.

## TangoPlayer

Walks randomly and tries to Collect only +. After 30 secs walks randomly and tries to collect only ResetAll (tries to "spoil" paths for another players).

## MangoPlayer

First 15 secs collects everything. After collects everything except ResetAll collectibles (tries to avoid ResetAll if it's possible).
