# Game Short Description

The game is played on a **6 × 5 grid** filled with randomly generated reward symbols. The goal is to spin the board, create large groups of matching symbols, and earn as many points as possible.

## Gameplay

### Starting the game

* Open command line console on your device.
* In the root of the project write **dotnet run**.
* Wait until the application starts.

### Starting a Round

* Press the **Play** button to begin a round.
* A game session consists of up to **15 rounds**.
* At the start of each round, the board is filled with a new set of randomly generated symbols.

## Winning Conditions

The game uses a **cluster-pay system** instead of traditional paylines.

A **Winning Group** is created when:

* **8 or more identical symbols** are connected.
* Symbols must be connected **horizontally or vertically**.
* **Diagonal connections do not count**.

## Cascades and Gravity

When a Winning Group is found:

1. All symbols in the winning group are removed from the board.
2. The remaining symbols fall downward due to gravity.
3. New symbols are generated at the top to fill the empty spaces.
4. The board is checked again for additional Winning Groups.

This process repeats automatically until no more winning groups remain on the board.

## Scoring

Each winning group awards points based on its size and symbol value. Consecutive cascades can generate additional rewards, allowing players to achieve higher scores within a single round.

## Symbols & Payout Table

| Symbol     | Description |
|------------|-------------|
| Cherry     | 10 points |
| Lemon      | 20 points |
| Seven      | 50 points |
| Diamond    | 100 points |
| Multiplier | 0 points — Does not score directly, but permanently upgrades your round's total win. |

## The Multiplier Rule

Keep a special eye out for the Multiplier Symbol.

Every time a Multiplier symbol appears on the board during a round, it increases your active Game Multiplier by +2.

Multipliers carry over across cascades within the same round.

At the end of the round, the total accumulated score from all cascades is multiplied by the final multiplier value before being added to your Total Score.
