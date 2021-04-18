from input import *
from grammar import *
from utils import random_change
from syntax_method import analyze
from drawer import draw_sample

INPUT_COUNT = 5

START_X = 0
START_Y = 60
FINISH_X = 40
FINISH_Y = 0
DELTA_X = 10
DELTA_Y = 10


def generate_house():
    sx = random_change(START_X, DELTA_X)
    sy = random_change(START_Y, DELTA_Y)
    fx = random_change(FINISH_X, DELTA_X)
    fy = random_change(FINISH_Y, DELTA_Y)
    rect = Rect(
        [sx, sy],
        [fx, fy]
    )
    return HouseRule().generate(rect)


def draw_check_sample(sample):
    text = 'Incorrect !'
    if analyze(sample, HOUSE_GRAMMAR):
        text = 'Correct'
    draw_sample(sample, text)


def main():
    draw_check_sample(CORRECT_HOUSE)
    my_input = [None] * INPUT_COUNT
    for i in range(0, len(my_input)):
        my_input[i] = generate_house()
    for x in my_input:
        draw_check_sample(x)
    draw_check_sample(INCORRECT_HOUSE)
    draw_check_sample(ROOF)
    draw_check_sample(RECT)


if __name__ == '__main__':
    main()
