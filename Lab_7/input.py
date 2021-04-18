from elements import Terminal

CORRECT_HOUSE = [
    Terminal([0, 10], [5, 15]),
    Terminal([5, 15], [10, 10]),

    Terminal([0, 10], [10, 10]),
    Terminal([0, 0], [0, 10]),
    Terminal([10, 0], [10, 10]),
    Terminal([0, 0], [10, 0])
]

INCORRECT_HOUSE = [
    Terminal([0, 5], [5, 15]),
    Terminal([5, 15], [10, 10]),

    Terminal([0, 10], [10, 10]),
    Terminal([0, 0], [0, 10]),
    Terminal([10, 0], [10, 10]),
    Terminal([0, 0], [10, 0])
]

ROOF = [
    Terminal([0, 0], [10, 10]),
    Terminal([10, 10], [20, 0])
]

RECT = [
    Terminal([0, 0], [0, 10]),
    Terminal([10, 0], [10, 10]),
    Terminal([0, 0], [10, 0]),
    Terminal([0, 10], [10, 10])
]
