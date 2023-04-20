public class Game
{
    private Team _team1;
    private Team _team2;
    private Board _board;
    private Display _display;

    public Game()
    {
        _team1 = new Team();
        _team2 = new Team("Black");

        _board = new Board();
        _board.SetTeams(_team1, _team2);

        _display = new Display(_board);
    }

    public Team PlayGame()
    {
        // let one team take a turn and then the other one, loop
        // stop loop when the game is over and return winning team.
        Team winningTeam = new Team();

        bool playing = true;
        while (playing)
        {
            bool validTurn = false;
            while (!validTurn && playing)
            {
                // Team 1's turn
                Console.Clear();
                _display.DisplayBoard();
                validTurn = TakeTurn(_team1);

                // check winner:
                if (!_team2.KingAlive())
                {
                    winningTeam = _team1;
                    playing = false;
                }

            }
            
            validTurn = false;
            while (!validTurn && playing)
            {
                Console.Clear();
                _display.DisplayBoard();
                validTurn = TakeTurn(_team2);

                // check winner:
                if (!_team1.KingAlive())
                {
                    winningTeam = _team2;
                    playing = false;
                }
            }
            
            
        }
        return winningTeam;

        
    }
    private bool TakeTurn(Team team)
    {
        // returns true if the turn was successfully completed. 
        // setup
        Console.WriteLine();
        Team opposingTeam;
        if (team == _team1)
        {
            opposingTeam = _team2;
        }
        else
        {
            opposingTeam = _team1;

        }

        // User inputs which piece they want to move. Checks if it's a valid piece on their own team.
        Piece movingPiece;
        bool validPiece = false;
        List<int> coord = new List<int>();

        while (!validPiece)
        {
            string input = _display.GetMovingPiece(team);
            coord = InputToCoordinate(input);
            if (TileInRange(coord) && PieceOnTile(coord,team))
            {
                // get the piece
                movingPiece = _board.GetPiece(coord);
                validPiece = true;
            }
            else
            {
                _display.InvalidPiece();
            }
        }

        // get the piece
        movingPiece = _board.GetPiece(coord);

        // Defining moveOptions list.
        List<List<int>> moveOptions = new List<List<int>>();
        moveOptions = movingPiece.GetWhereCanMove();

        // now translate the coordinates to where the piece is.
        foreach(List<int> l in moveOptions)
        {
            l[0] += movingPiece.GetPosition()[0];
            l[1] += movingPiece.GetPosition()[1];
        }

        // now moveOptions contains the basic places the piece can move.
        // narrow down moveOptions even more by running it through the function:
        moveOptions = WherePieceCanMove(moveOptions, team, movingPiece.GetPosition());

        // extra options for pon:
        if (movingPiece.GetPieceType() == "Pon")
        {
            moveOptions = ApplyPonRules(team, movingPiece.GetPosition(), moveOptions, opposingTeam);
        }

        // if the piece literally can't move, return false.
        if (moveOptions.Count == 0)
        {
            _display.PieceCantMove();
            return false;
        }

        // User inputs where they want to move TO. checks if it's a valid move. 
        bool validMove = false;
        List<int> coord2 = new List<int>();

        while (!validMove)
        {
            string input = _display.GetWhereToMove();
            coord2 = InputToCoordinate(input);

            foreach(List<int> l in moveOptions)
            {
                if (l.SequenceEqual(coord2))
                {
                    // the coordinate is a place the piece can move!
                    validMove = true;

                    // if there is a piece there, kill it. 
                    if (_board.CheckTile(coord2))
                    {
                        Piece killedPiece = opposingTeam.GetPiece(coord2);
                        killedPiece.KillPiece();
                        opposingTeam.UpdateTeam();
                    }

                    movingPiece.Move(coord2);
                    movingPiece.CompleteFirstMove(); // this is really just for the pon.
                }
            }
            if (!validMove)
            {
                _display.InvalidMove();   
            }
        }


        return true;

    }

    /* SETTING UP CHECKMATE RULES:
    private List<List<int>> FindDangerSpots(Team opposingTeam)
    {
        //returns a list of coordinates where an opposing team piece could kill.
        List<List<int>> dangerList = new List<List<int>>();
        foreach(Piece p in opposingTeam.GetTeamPieces())
        {
            // different rules for pon...
            if (p.GetPieceType() == "Pon")
            {
                // do something different
            }
            else
            {
                foreach (List<int> coord in p.GetWhereCanMove())
                {
                    dangerList.Add(coord);
                }
            }
            
        }

    }

    private bool Check(Team teamOfInterest)
    {
        Team opposingTeam;
        if (teamOfInterest == _team1)
        {
            opposingTeam = _team2;
        }
        else
        {
            opposingTeam = _team1;
        }

        // see where the king can move on teamOfInterest
        Piece king;
        foreach (Piece p in teamOfInterest.GetTeamPieces())
        {
            if (p.GetPieceType() == "King")
            {
                king = p;
            }
        }
    }

    private bool CheckMate()
    {

    }

    private void TestList(List<List<int>> list)
    {
        foreach(List<int> l in list)
            {
                Console.Write($"({l[0]},{l[1]})");
            }
            Console.WriteLine();
    }
    */

    private List<List<int>> ApplyPonRules(Team ponTeam, List<int> ponPosition, List<List<int>> whereCanMove, Team opposingTeam)
    {
        // step 1: if an opposing team piece is directly in front of the pon, delete that coord from whereCanMove.
        List<List<int>> opposingPieceCoords = GetOccupiedTiles(opposingTeam);
        List<List<int>> updatedList = new List<List<int>>();
        foreach(List<int> option in whereCanMove)
        {
            bool block = false;

            foreach(List<int> pieceCoord in opposingPieceCoords)
            {
                if (option.SequenceEqual(pieceCoord))
                {
                    block = true;
                }
            }

            if (!block)
            {
                updatedList.Add(option);
            }
        }

        // step 2: if there is a piece to the left or right of the pon, add it to the updatedList.
        if (ponTeam.GetColor() == "White")
        {
            // we're dealing with up and left and right
            List<int> left = new List<int>{ponPosition[0]-1,ponPosition[1]-1};
            List<int> right = new List<int>{ponPosition[0]-1,ponPosition[1]+1};

            foreach(List<int> pieceCoord in opposingPieceCoords)
            {
                if (left.SequenceEqual(pieceCoord))
                {
                    updatedList.Add(left);
                }
                else if (right.SequenceEqual(pieceCoord))
                {
                    updatedList.Add(right);
                }
            }
        }
        else
        {
            // down and left and right. 
            List<int> left = new List<int>{ponPosition[0]+1,ponPosition[1]-1};
            List<int> right = new List<int>{ponPosition[0]+1,ponPosition[1]+1};

            foreach(List<int> pieceCoord in opposingPieceCoords)
            {
                if (left.SequenceEqual(pieceCoord))
                {
                    updatedList.Add(left);
                }
                else if (right.SequenceEqual(pieceCoord))
                {
                    updatedList.Add(right);
                }
            }
            
        }

        whereCanMove = updatedList;



        return whereCanMove;
    }



    private List<List<int>> WherePieceCanMove(List<List<int>> whereCanMove, Team team, List<int> pieceLocation)
    {
        // returns a list of coordinates where the piece can move WITHOUT same-team pieces blocking it.

        
        // Step 1: get rid of of all options off the board.
        List<List<int>> outputList = new List<List<int>>();
        foreach(List<int> subList in whereCanMove)
        {
            bool outOfRange = false;
            foreach(int number in subList)
            {
                if(number < 0)
                {
                    outOfRange = true;
                    break;
                }
                else if (number > 7)
                {
                    outOfRange = true;
                    break;
                }
            }

            if(!outOfRange)
            {
                outputList.Add(subList);
            }
        }

        whereCanMove = outputList;


        // Step 2: delete all moveOptions that are occupied by same-team pieces
        List<List<int>> teamPieces = GetOccupiedTiles(team);
        List<List<int>> updatedList = new List<List<int>>();
        List<List<int>> blockers = new List<List<int>>();
        foreach(List<int> option in whereCanMove)
        {
            bool block = false;

            foreach(List<int> pieceCoord in teamPieces)
            {
                if (option.SequenceEqual(pieceCoord))
                {
                    block = true;
                    // Save the index of the piece and the teampieces that are blocking it's movement.
                    blockers.Add(pieceCoord);

                }
            }

            if (!block)
            {
                updatedList.Add(option);
            }
        }

        whereCanMove = updatedList;

        // Step 3: delete all moveOptions that are blocked by the pieces that were there...(HARDEST PART)
        foreach(List<int> blockCoord in blockers)
        {
            whereCanMove = GetStraightBlockedList(whereCanMove, pieceLocation, blockCoord);
            whereCanMove = GetDiagonalBlockedList(whereCanMove, pieceLocation, blockCoord);
        }

        // Step 4: keep all CLOSEST moveOptions that contain opposing team pieces, but
        // those pieces count as blockers as well...

        Team opposingTeam;
        if (team == _team1)
        {
            opposingTeam = _team2;
        }
        else
        {
            opposingTeam = _team1;
        }

        List<List<int>> oTeamCoords = GetOccupiedTiles(opposingTeam);
        List<List<int>> oUpdatedList = new List<List<int>>();
        List<List<int>> oBlockers = new List<List<int>>();
        foreach(List<int> option in whereCanMove)
        {

            foreach(List<int> pieceCoord in oTeamCoords)
            {
                if (option.SequenceEqual(pieceCoord))
                {
                    // Save the index of the piece and the teampieces that are blocking it's movement.
                    oBlockers.Add(pieceCoord);

                }
            }

        }
        // now that we have the blockers list, perform the Block list functions
        // hopefully this means we CAN move to an enemy piece, but not PAST it.
        foreach(List<int> b in oBlockers)
        {
            whereCanMove = GetStraightBlockedList(whereCanMove, pieceLocation, b);
            whereCanMove = GetDiagonalBlockedList(whereCanMove, pieceLocation, b);
        }
        
        return whereCanMove;

    }

    // BLOCKED LIST FUNCTIONS:==========================================================================
    private List<List<int>> GetStraightBlockedList (
        List<List<int>> moveOptions,
        List<int> pieceLocation, 
        List<int> blockerLocation)
    {
        // idea: focus on the blocker piece. check all horizontal and vertical lists.
        // if the piece is in a direction, skip. otherwise, delete the coordinates opposite.

        // direction bools:
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        List<List<int>> upList = new List<List<int>>();
        List<List<int>> downList = new List<List<int>>();
        List<List<int>> leftList = new List<List<int>>();
        List<List<int>> rightList = new List<List<int>>();


        // check which of the paths the piece location is in.

        // up:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0]-i,blockerLocation[1]};
            upList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                up = true;
            }
        }

        // down:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0]+i,blockerLocation[1]};
            downList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                down = true;
            }
        }

        // left:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0],blockerLocation[1]-i};
            leftList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                left = true;
            }
        }

        // right:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0],blockerLocation[1]+i};
            rightList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                right = true;
            }
        }

        // now whichever path the pieceLocation is in, clear the other path. 
        if (up)
        {
            // delete everything down.
            foreach(List<int> d in downList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(d);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        if (down)
        {
            // delete everything up.
            foreach(List<int> u in upList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(u);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        if (left)
        {
            // delete everything right.
            foreach(List<int> r in rightList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(r);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        if (right)
        {
            // delete everything left.
            foreach(List<int> l in leftList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(l);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        // finally return moveOptions.
        return moveOptions;


    }


    private List<List<int>> GetDiagonalBlockedList (
        List<List<int>> moveOptions,
        List<int> pieceLocation, 
        List<int> blockerLocation)
    {
        // idea: focus on the blocker piece. check all diagonal.
        // if the piece is in a direction, skip. otherwise, delete the coordinates opposite.

        // direction bools:
        bool upLeft = false;
        bool upRight = false;
        bool downLeft = false;
        bool downRight = false;

        List<List<int>> upLeftList = new List<List<int>>();
        List<List<int>> upRightList = new List<List<int>>();
        List<List<int>> downLeftList = new List<List<int>>();
        List<List<int>> downRightList = new List<List<int>>();


        // check which of the paths the piece location is in.

        // upLeft:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0]-i,blockerLocation[1]-i};
            upLeftList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                upLeft = true;
            }
        }

        // upRight:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0]-i,blockerLocation[1]+i};
            upRightList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                upRight = true;
            }
        }

        // downLeft:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0]+i,blockerLocation[1]-i};
            downLeftList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                downLeft = true;
            }
        }

        // downRight:
        for (int i=1; i<7; i++)
        {
            List<int> possibility = new List<int>{blockerLocation[0]+i,blockerLocation[1]+i};
            downRightList.Add(possibility);
            if (possibility.SequenceEqual(pieceLocation))
            {
                downRight = true;
            }
        }

        // now whichever path the pieceLocation is in, clear the other path. 
        if (upLeft)
        {
            // delete everything down.
            foreach(List<int> dr in downRightList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(dr);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        if (upRight)
        {
            // delete everything up.
            foreach(List<int> dl in downLeftList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(dl);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        if (downLeft)
        {
            // delete everything right.
            foreach(List<int> ur in upRightList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(ur);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        if (downRight)
        {
            // delete everything left.
            foreach(List<int> ul in upLeftList)
            {
                // Iterate over each sub-list in moveOptions
                for (int i = moveOptions.Count - 1; i >= 0; i--)
                {
                    List<int> sublist = moveOptions[i];

                    // Check if the sublist is equal to the comparison list
                    bool shouldRemove = sublist.SequenceEqual(ul);

                    // If it should be removed, delete it from the moveOptions list
                    if (shouldRemove)
                    {
                        moveOptions.RemoveAt(i);
                    }
                }
            }
        }

        // finally return moveOptions.
        return moveOptions;
    }
    //==============================================================================

    private List<List<int>> DeleteIdenticalEntries(List<List<int>> list1, List<List<int>> list2)
    {
        // returns an updated list1 with only the entries that are NOT in list2. 
        List<List<int>> updatedList = new List<List<int>>();
        foreach(List<int> l1 in list1)
        {
            bool foundInList2 = false;

            foreach(List<int> l2 in list2)
            {
                if (!l1.SequenceEqual(l2))
                {
                    foundInList2 = true;
                }
            }

            if (!foundInList2)
            {
                updatedList.Add(l1);
            }
        }

        return updatedList;

    }

    private List<List<int>> GetOccupiedTiles(Team team)
    {
        // returns a list of coordinates occupied by tiles in the team.
        List<List<int>> occupiedTiles = new List<List<int>>();
        foreach(Piece p in team.GetTeamPieces())
        {
            occupiedTiles.Add(p.GetPosition());
        }
        return occupiedTiles;
    }

    private bool TileInRange(List<int> coordinate)
    {
        if (coordinate[0] == -1||coordinate[1] == -1)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }


    private bool PieceOnTile(List<int> coordinate, Team team)
    {
        // Check if there is a team piece on that coordinate
        bool existsPiece = false;
        foreach(Piece p in team.GetTeamPieces())
        {
            if (p.GetPosition().SequenceEqual(coordinate))
            {
                existsPiece = true;
            }
        }
        return existsPiece;
    }

    

    private List<int> InputToCoordinate(string input)
    {
        // takes in users input (e.g. A1) and returns coordinate (e.g. [0,0])
        input.Split();
        try
        {
            string letter = input[0].ToString();
            string number = input[1].ToString();
            List<string> letters = new List<string>{"A","B","C","D","E","F","G","H"};
            List<string> numbers = new List<string>{"1","2","3","4","5","6","7","8"};

            int letterIndex = letters.FindIndex(a => a.Contains(letter));
            int numberIndex = numbers.FindIndex(a => a.Contains(number));
            return new List<int>{letterIndex,numberIndex};
        }
        catch (IndexOutOfRangeException)
        {
            return new List<int>{-1,-1};
        }
        

    }

}