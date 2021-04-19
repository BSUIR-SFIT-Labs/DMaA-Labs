from utils import *


HIGH_ASYMMETRY = 10 / 100


class Operator:
    def can_apply(self, items_list):
        raise NotImplementedError()

    def split(self, rect):
        raise NotImplementedError()


class Left(Operator):
    def can_apply(self, items_list):
        assert len(items_list) == 2
        return items_list[0].right <= items_list[1].left

    def split(self, rect):
        width = rect.snd[0] - rect.fst[0]
        x_center = (rect.fst[0] + rect.snd[0]) / 2
        x_center = random_change(x_center, HIGH_ASYMMETRY * width)
        left_rect = Rect(rect.fst, [x_center, rect.snd[1]])
        right_rect = Rect([x_center, rect.fst[1]], rect.snd)
        return left_rect, right_rect


class Above(Operator):
    def can_apply(self, items_list):
        assert len(items_list) == 2
        return items_list[0].bottom >= items_list[1].top

    def split(self, rect, prop=1):
        height = rect.fst[1] - rect.snd[1]
        h_low = prop*height/(1+prop)
        y_split = rect.snd[1] + h_low
        y_split = random_change(y_split, HIGH_ASYMMETRY * height)
        top_rect = Rect(rect.fst, [rect.snd[0], y_split])
        bottom_rect = Rect([rect.fst[0], y_split], rect.snd)
        return top_rect, bottom_rect


class Inside(Operator):
    def can_apply(self, items_list):
        assert len(items_list) == 2
        inner = items_list[0]
        outer = items_list[1]
        return inner.top < outer.top \
            and inner.bottom > outer.bottom \
            and inner.left > outer.left \
            and inner.right < outer.right

    def split(self, rect):
        pass    # return inner rectangle
