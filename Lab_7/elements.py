from enum import Enum
from random import uniform

HIGH_DELTA = 5 / 100


class Type(Enum):
    # Terminals
    VERTICAL = 'v-line'
    HORIZONTAL = 'h-line'
    DIAGONAL_LEFT = 'dl-line'
    DIAGONAL_RIGHT = 'dr-line'

    # NonTerminals
    HOUSE = 'house'
    BASE = 'base'
    RECT = 'rect'
    WALLS = 'walls'
    ROOF = 'roof'

    @staticmethod
    def get_type(start, stop):
        if start[0] == stop[0]:
            result = Type.VERTICAL
        elif start[1] == stop[1]:
            result = Type.HORIZONTAL
        else:
            left = min([start, stop], key=lambda x: x[0])
            top = max([start, stop], key=lambda x: x[1])
            if top == left:
                result = Type.DIAGONAL_LEFT
            else:
                result = Type.DIAGONAL_RIGHT
        return result


class Terminal:
    def __init__(self, start, stop):
        self.start = start
        self.stop = stop
        self.left = min([start[0], stop[0]])
        self.right = max([start[0], stop[0]])
        self.top = max([start[1], stop[1]])
        self.bottom = min([start[1], stop[1]])
        self.type = Type.get_type(start, stop)

    @staticmethod
    def create(my_type, rect):
        result = False
        width = rect.snd[0] - rect.fst[0]
        height = rect.fst[1] - rect.snd[1]
        if my_type == Type.VERTICAL:
            x_common = uniform(rect.fst[0], rect.snd[0])
            y_start = rect.fst[1] - uniform(0, HIGH_DELTA * height)
            y_stop = rect.snd[1] + uniform(0, HIGH_DELTA * height)
            result = Terminal([x_common, y_start], [x_common, y_stop])
        elif my_type == Type.HORIZONTAL:
            y_common = uniform(rect.fst[1], rect.snd[1])
            x_start = rect.fst[0] + uniform(0, HIGH_DELTA * width)
            x_stop = rect.snd[0] - uniform(0, HIGH_DELTA * width)
            result = Terminal([x_start, y_common], [x_stop, y_common])
        elif my_type == Type.DIAGONAL_LEFT:
            x_start = rect.fst[0] + uniform(0, HIGH_DELTA * width)
            x_stop = rect.snd[0] - uniform(0, HIGH_DELTA * width)
            y_start = rect.fst[1] - uniform(0, HIGH_DELTA * height)
            y_stop = rect.snd[1] + uniform(0, HIGH_DELTA * height)
            result = Terminal([x_start, y_start], [x_stop, y_stop])
        elif my_type == Type.DIAGONAL_RIGHT:
            x_start = rect.fst[0] + uniform(0, HIGH_DELTA * width)
            x_stop = rect.snd[0] - uniform(0, HIGH_DELTA * width)
            y_start = rect.snd[1] + uniform(0, HIGH_DELTA * height)
            y_stop = rect.fst[1] - uniform(0, HIGH_DELTA * height)
            result = Terminal([x_start, y_start], [x_stop, y_stop])
        return result


class NonTerminal:
    items = []
    left = None
    right = None
    top = None
    bottom = None

    def __init__(self, element_type, items=None):
        if items is None:
            items = []
        self.type = element_type
        self.items = items
        if len(items) > 0:
            self.left = min(i.left for i in items)
            self.right = max(i.right for i in items)
            self.top = max(i.top for i in items)
            self.bottom = min(i.bottom for i in items)
