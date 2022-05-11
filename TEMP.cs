// Collect collectible


            // TODO draw manually and think about "Running" state - how to use it to reduce computations for theevery frame
            //string stat = (string)Tree.GetBlackboardData("runningTask");
            //if (stat == "CollectCollectibleItem")
            //    nodeState = NodeState.Running;
            //    return nodeState;

            List<CollectibleItem> spawnedCollectibles = (List<CollectibleItem>)Tree.GetBlackboardData("spawnedCollectibles");
            object lastItem = Tree.GetBlackboardData("lastItem");

            bool tileWithColectible = false;

            if (lastItem != null)
            {
                Vector2Int lastItemLocation = (Vector2Int)lastItem;
                for (int i = 0; i < spawnedCollectibles.Count; i++)
                {
                    if (lastItemLocation == spawnedCollectibles[i].TileLocation)
                    {
                        tileWithColectible = true;
                        break;
                    }
                }
            }

            if (tileWithColectible)
            {
                nodeState = NodeState.Running;
                return nodeState;
            } else
            {
                nodeState = NodeState.Failure;
                return nodeState;
            }

            Tree.Player.pathTilesQueue.Clear();
            List<Vector2Int> shortestPath = (List<Vector2Int>)Tree.GetBlackboardData("shortestPath");
            shortestPath.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
            // Tree.SetBlackboardData("alreadyDoingSmth", shortestPath);

            Debug.Log("Inside CollectCollectibleItem returned " + Tree.Player.pathTilesQueue.Count);

            Tree.SetBlackboardData("runningTask", "CollectCollectibleItem");

            nodeState = NodeState.Running;

            return nodeState;
			
			
			
			
			
// find closest

            List<CollectibleItem> spawnedCollectibles = (List<CollectibleItem>)Tree.GetBlackboardData("spawnedCollectibles");
            object lastItem = Tree.GetBlackboardData("lastItem");

            bool tileWithColectible = false;

            if (lastItem != null)
            {
                Vector2Int lastItemLocation = (Vector2Int)lastItem;
                for (int i = 0; i < spawnedCollectibles.Count; i++)
                {
                    if (lastItemLocation == spawnedCollectibles[i].TileLocation)
                    {
                        tileWithColectible = true;
                        break;
                    }
                }
            }

            if (tileWithColectible)
                nodeState = NodeState.Success;
            else
                nodeState = NodeState.Failure;

            if ((Tree.Player.pathTilesQueue.Count == 0 || !tileWithColectible) && spawnedCollectibles.Count > 0 && Tree.Player.MovementTransitionFinished())
            {
                List<Vector2Int> shortestPath = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, spawnedCollectibles[0].TileLocation);

                for (int i = 1; i < spawnedCollectibles.Count; i++)
                {
                    List<Vector2Int> path = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, spawnedCollectibles[i].TileLocation);

                    if (shortestPath.Count > path.Count)
                    {
                        shortestPath = path;
                    }
                }

                // shortestPath.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
                Tree.SetBlackboardData("shortestPath", shortestPath);
                Tree.SetBlackboardData("lastItem", shortestPath[shortestPath.Count - 1]);
                Tree.SetBlackboardData("currentItemPosition", shortestPath[shortestPath.Count - 1]);
            }

            
            Debug.Log("FindClosestItem returned " + nodeState);
            return nodeState;
			
			
			
			
			
			
			