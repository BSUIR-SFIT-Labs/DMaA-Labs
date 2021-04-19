import matplotlib.pyplot as plt


def draw_sample(sample, text=''):
    for i in sample:
        plt.plot([i.start[0], i.stop[0]], [i.start[1], i.stop[1]], c='black', linewidth=1)
    axis = plt.axes()
    ys = axis.get_ylim()
    text_y = ys[1] - 0.2 * (ys[1] + ys[0])
    axis.text(axis.get_xlim()[0], text_y, text, style='italic', fontsize=12)
    plt.show()
