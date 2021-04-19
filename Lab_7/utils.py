from random import getrandbits


def random_change(x, delta):
    if bool(getrandbits(1)):
        result = x + delta
    else:
        result = x - delta
    return result


class Rect:
    def __init__(self, fst, snd):
        left = min([fst[0], snd[0]])
        right = max([fst[0], snd[0]])
        top = max([fst[1], snd[1]])
        bottom = min([fst[1], snd[1]])
        self.fst = [left, top]
        self.snd = [right, bottom]
