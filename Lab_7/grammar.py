from rules import *

ROOF_GRAMMAR = [
    RoofRule()
]

RECT_GRAMMAR = [
    WallsRule(), BaseRule(), RectRule()
]

HOUSE_GRAMMAR = [
    RoofRule(), WallsRule(), BaseRule(), RectRule(), HouseRule()
]
