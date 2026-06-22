## Architectural Overview

The codebase is structured following the Model-View-ViewModel pattern:

- **Models**: Managegame logic, state simulation, grid layout, and etc.
- **ViewModels**: Connects game logic with UI.
- **Views**: Using commands from the ViewModel creates and updates UI.

## Model scheme

### 1. Symbol and Configuration (Symbol.cs, SymbolType.cs, Config.cs)

Every cell in the board grid holds an instance of `Symbol`.

**Properties:**
- **Type**: `SymbolType` (Enum values: Cherry, Lemon, Seven, Diamond, Multiplier)
- **Value**: Raw scoring weight (int)
- **Probability**: Probability of getting symbol (double, sums up to 1.0)
- **IsMultiplier**: Boolean flag of Multiplier
- **Image**: BitmapImage in order to Avalonia can upload it

## 2. Symbol Generation (SymbolFactory.cs)

Impleements a weighted distribution system using a cumulative probability algorithm.

```csharp
public static Symbol GetRandomSymbol()
{
    double diceRoll = _random.NextDouble(); // on this line it generates double between 0.0 and 1 
    double cumulative = 0.0;

    foreach(var symbol in _availableSymbols)
    {
        cumulative += symbol.Probability;

        if(diceRoll < cumulative) // here it checks the biggest symbol we can take with that probability
        {
            return symbol;
        }
    }

    return _availableSymbols[0];
}
```

## Core Algorithms (Board.cs)

### 1. Groups Finding (via DFS)

To identify winning groups of size ≥ 8, `FindWinningGroups()` iterates through every unvisited grid node and runs a recursive DFS function (`Search`) using 4 directions of adjacency.
This approach ensurs that all connected tiles of the same type are grouped into a single winning group.

### 2. Gravity Simulation (ApplyGravity function)

Makes vertical coloumn shifting after removals. The algorithm processes each column from bottom to top using a that moves non-null items downward.

```csharp
public void ApplyGravity()
{
    for (int c = 0; c < Columns; c++)
    {
        int emptyRow = Rows - 1;

        for (int r = Rows - 1; r >= 0; r--)
        {
            if (Grid[r, c] != null)
            {
                Grid[emptyRow, c] = Grid[r, c];

                if (emptyRow != r)
                    Grid[r, c] = null;

                emptyRow--;
            }
        }
    }
}
```
### 3. Game Loop Execution (GameSession.cs)

The core game execution logic runs inside `PlayRound()`. The entire round is processed within a `do-while` loop to support chained cascade reactions, where new matches may appear after gravity is applied.

<img width="1088" height="657" alt="image" src="https://github.com/user-attachments/assets/2c6f34c2-7ce2-4b99-854d-c3fa4bcf1cf2" />

## Multiplier Progression Quirks

Multipliers are calculated globally from the active board state during each cascade iteration. A `HashSet<Symbol>` is used to ensure that the same instantiated multiplier symbol is not counted more than once across consecutive cascade passes.

### State Logic Update Formula

If Current Multiplier = 1: Multiplier = Accumulated

If Current Multiplier > 1: Multiplier = Multiplier + Accumulated

## Unit tests

To run unit tests, run type `dotnet test` from your root directory
They are checking 4 things: 
- Initialization of the board.
- Whether the number of rounds is increasing.
- Whether the number of rounds <= 15.
- Whether multiplier >= 1.
