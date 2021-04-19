from elements import *
from operators import *


class Rule:

    def __init__(self):
        self.type = None

    def can_apply(self, items_list):
        raise NotImplementedError()

    def apply(self, items_list):
        if self.can_apply(items_list):
            return NonTerminal(self.type, items_list)
        else:
            return False


class RoofRule(Rule):

    def __init__(self):
        super().__init__()
        self.type = Type.ROOF

    def can_apply(self, items_list):
        assert len(items_list) == 2
        if items_list[0].type != Type.DIAGONAL_RIGHT:
            list.reverse(items_list)
        return items_list[0].type == Type.DIAGONAL_RIGHT \
            and items_list[1].type == Type.DIAGONAL_LEFT \
            and Left().can_apply(items_list)

    @staticmethod
    def generate(rect):
        left, right = Left().split(rect)
        return [
            Terminal.create(Type.DIAGONAL_RIGHT, left),
            Terminal.create(Type.DIAGONAL_LEFT, right)
        ]


class WallsRule(Rule):

    def __init__(self):
        super().__init__()
        self.type = Type.WALLS

    def can_apply(self, items_list):
        assert len(items_list) == 2
        result = items_list[0].type == Type.VERTICAL \
            and items_list[1].type == Type.VERTICAL
        if not result:
            return False
        result = Left().can_apply(items_list)
        if not result:
            list.reverse(items_list)
            result = Left().can_apply(items_list)
        return result

    @staticmethod
    def generate(rect):
        left, right = Left().split(rect)
        return [
            Terminal.create(Type.VERTICAL, left),
            Terminal.create(Type.VERTICAL, right)
        ]


def generate(rect):
    top, bottom = Above().split(rect, 0.2)
    result = WallsRule().generate(top)
    result += [Terminal.create(Type.HORIZONTAL, bottom)]
    return result


class BaseRule(Rule):

    def __init__(self):
        super().__init__()
        self.type = Type.BASE

    def can_apply(self, items_list):
        assert len(items_list) == 2
        if items_list[0].type != Type.WALLS:
            list.reverse(items_list)
        return items_list[0].type == Type.WALLS \
            and items_list[1].type == Type.HORIZONTAL \
            and Above().can_apply(items_list)


class RectRule(Rule):

    def __init__(self):
        super().__init__()
        self.type = Type.RECT

    def can_apply(self, items_list):
        assert len(items_list) == 2
        if items_list[0].type != Type.HORIZONTAL:
            list.reverse(items_list)
        return items_list[0].type == Type.HORIZONTAL \
            and items_list[1].type == Type.BASE \
            and Above().can_apply(items_list)

    @staticmethod
    def generate(rect):
        top, bottom = Above().split(rect, 5)
        result = [Terminal.create(Type.HORIZONTAL, top)]
        result += generate(bottom)
        return result


class HouseRule(Rule):

    def __init__(self):
        super().__init__()
        self.type = Type.HOUSE

    def can_apply(self, items_list):
        assert len(items_list) == 2
        if items_list[0].type != Type.ROOF:
            list.reverse(items_list)
        return items_list[0].type == Type.ROOF \
            and items_list[1].type == Type.RECT \
            and Above().can_apply(items_list)

    @staticmethod
    def generate(rect):
        top, bottom = Above().split(rect, 2)
        return RoofRule().generate(top) + RectRule().generate(bottom)
