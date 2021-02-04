def knap_sack(potential_loot, limit):
    '''
    This is a 0/1 Knapsack problem
    We solve it by using bottom up dynamic programming approach
    '''
    item_weights = [item["weight"] for item in potential_loot]
    item_values = [item["value"] for item in potential_loot]

    n  = len(potential_loot)
    tracker = [[0 for _ in range(limit + 1)] for _ in range(n + 1)]

    for i in range(n + 1):
        for w in range(limit + 1):
            if i == 0 or w == 0:
                tracker[i][w] = 0
            elif item_weights[i-1] <= w:
                tracker[i][w] = max(item_values[i-1] + tracker[i-1][w-item_weights[i-1]], tracker[i-1][w])
            else:
                tracker[i][w] = tracker[i-1][w]

    return tracker[n][limit]

if __name__ == "__main__":

    potential_loot = [ { "weight": 5, "value": 10 }, { "weight": 4, "value": 40 }, { "weight": 6, "value": 30 }, { "weight": 4, "value": 50 } ]

    bag_limit  = 10
    print(knap_sack(potential_loot, bag_limit))
