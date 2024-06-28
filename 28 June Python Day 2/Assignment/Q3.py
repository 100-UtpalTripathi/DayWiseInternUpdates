
# Write a Python function to sort the players based on their scores in descending order. If two players have the same score, sort them based on their names in ascending order. The function should return the top 10 players.
def sort_players(players):

    # Sort the players based on their scores in descending order. If two players have the same score, sort them based on their names in ascending order
    sorted_players = sorted(players, key=lambda x: (-x[1], x[0]))

    # Return the top 10 players
    return sorted_players[:10]

# Example
players = [
    ("Alice", 95),
    ("Bob", 80),
    ("Charlie", 85),
    ("David", 95),
    ("Eve", 70),
    ("Frank", 90),
    ("Grace", 85),
    ("Hank", 60),
    ("Ivy", 75),
    ("Jack", 85),
    ("Ken", 90),
    ("Liam", 80),
    ("Mona", 85)
]

top_10_players = sort_players(players)
print("Top 10 Players:")
for player in top_10_players:
    print(player)
