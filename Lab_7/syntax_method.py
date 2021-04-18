def analyze(items_list, grammar):
    items_list = items_list[:]  # copy for in-place processing blah-blah-blah...
    error = False
    for rule in grammar:
        applied = False
        i = 0
        while not applied and i < len(items_list) - 1:
            applied = rule.apply(items_list[i:i + 2])
            if applied:
                items_list[i] = applied
                del items_list[i + 1]
            i += 1
        error = not applied
    return not error and len(items_list) == 1 and items_list[0].type == grammar[-1].type


def synthesize():
    pass
