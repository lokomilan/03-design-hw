import math
eps = 5e-5


def f(x):
    return x - 1.4 * math.cos(x) * math.cos(x)


def der_f(x):
    return 1.4 * math.sin(2 * x) + 1


def print_stats(x, y):
    for i in range(len(x)):
        print("x{} = {}; y{} = {}"
        	.format(i, "%.5f" % x[i], i, "%.5f" % y[i]))
    print('______________________________________________________________')


def binary_search():
    l = 0
    r = math.pi / 4 - eps
    x, y = [l, r], [f(l), f(r)]
    while r - l >= eps:
        m = (l + r) / 2
        fm = f(m)
        x.append(m)
        y.append(f(m))
        if fm > 0:
            r = m
        else:
            l = m
    print_stats(x, y)


def newton_mod():
    x, y = [math.pi / 4 - eps], [f(math.pi / 4 - eps)]
    while len(x) < 2 or abs(x[len(x) - 1] - x[len(x) - 2]) >= eps:
        xn = x[len(x) - 1]
        x.append(xn - f(xn) / der_f(x[0]))
        y.append(f(x[len(x) - 1]))
    print_stats(x, y)


def chord():
    x, y = [math.pi / 4 - eps, 0], [f(math.pi / 4 - eps), f(0)]
    while abs(x[len(x) - 1] - x[len(x) - 2]) >= eps:
        xn = x[len(x) - 1]
        x.append(xn - f(xn) * (xn - x[0]) / (f(xn) - f(x[0])))
        y.append(f(x[len(x) - 1]))
    print_stats(x, y)


binary_search()
newton_mod()
chord()
