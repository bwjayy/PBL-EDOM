import sys


def mf_trapezoid(x, a, b, c, d):
    if b <= x <= c:
        return 1.0
    if a < x < b:
        return (x - a) / (b - a)
    if c < x < d:
        return (d - x) / (d - c)
    return 0.0


def mf_triangle(x, a, b, c):
    if x == b:
        return 1.0
    if a < x < b:
        return (x - a) / (b - a)
    if b < x < c:
        return (c - x) / (c - b)
    return 0.0


def fuzzify_input(x):
    # Normalized [1.0, 3.0] scale stays invariant when question counts change via CRUD.
    return [
        mf_trapezoid(x, 1.0, 1.0, 4.0 / 3.0, 2.0),
        mf_triangle(x, 4.0 / 3.0, 2.0, 8.0 / 3.0),
        mf_trapezoid(x, 2.0, 8.0 / 3.0, 3.0, 3.0),
    ]


def rule_output(ped_idx, pro_idx, kep_idx, sos_idx):
    # Any single "Kurang" caps the outcome at "Cukup"; two or more force "Kurang".
    kurang_count = (ped_idx == 0) + (pro_idx == 0) + (kep_idx == 0) + (sos_idx == 0)
    total = ped_idx + pro_idx + kep_idx + sos_idx
    if kurang_count >= 2 or total <= 2:
        return 0
    if total >= 6 and kurang_count == 0:
        return 2
    return 1


def mu_output(z, mk, mc, mb):
    return max(
        min(mf_trapezoid(z, 0.0, 0.0, 25.0, 50.0), mk),
        min(mf_triangle(z, 25.0, 50.0, 75.0), mc),
        min(mf_trapezoid(z, 50.0, 75.0, 100.0, 100.0), mb),
    )


def defuzzify_centroid_integral(mk, mc, mb):
    # Breakpoints cover all knots, clip heights, and ramp intersections on [0, 100].
    # shortcut: hardcoded to output MF knots [0, 25, 50, 75, 100], update if output MFs change.
    pts = {
        0.0, 25.0, 37.5, 50.0, 62.5, 75.0, 100.0,
        50.0 - 25.0 * mk, 25.0 + 25.0 * mk,
        25.0 + 25.0 * mc, 50.0 - 25.0 * mc, 75.0 - 25.0 * mc, 50.0 + 25.0 * mc,
        50.0 + 25.0 * mb, 75.0 - 25.0 * mb,
    }
    xs = sorted(p for p in pts if 0.0 <= p <= 100.0)

    total_area = 0.0
    total_moment = 0.0
    for i in range(len(xs) - 1):
        p, q = xs[i], xs[i + 1]
        if q - p < 1e-12:
            continue
        y1 = mu_output(p, mk, mc, mb)
        y2 = mu_output(q, mk, mc, mb)
        total_area += 0.5 * (y1 + y2) * (q - p)
        total_moment += ((q - p) / 6.0) * (p * (2.0 * y1 + y2) + q * (y1 + 2.0 * y2))

    return (total_moment / total_area) if total_area > 0.0 else 0.0


def infer(ped, pro, kep, sos):
    for name, val in (("pedagogik", ped), ("profesional", pro), ("kepribadian", kep), ("sosial", sos)):
        if not (1.0 <= val <= 3.0):
            raise ValueError(f"Input {name} harus berada pada rentang [1.0, 3.0], diterima: {val}")

    mp = fuzzify_input(ped)
    mr = fuzzify_input(pro)
    mk = fuzzify_input(kep)
    ms = fuzzify_input(sos)

    out_mu = [0.0, 0.0, 0.0]
    for i in range(3):
        for j in range(3):
            for k in range(3):
                for l in range(3):
                    alpha = min(mp[i], mr[j], mk[k], ms[l])
                    if alpha > 0.0:
                        cls = rule_output(i, j, k, l)
                        if alpha > out_mu[cls]:
                            out_mu[cls] = alpha

    skor = defuzzify_centroid_integral(out_mu[0], out_mu[1], out_mu[2])
    if skor < 40.0:
        predikat = "Kurang"
    elif skor <= 65.0:
        predikat = "Cukup"
    else:
        predikat = "Baik"

    return skor, predikat, out_mu


def run_self_tests():
    s, p, om = infer(112.0 / 45.0, 96.0 / 40.0, 76.0 / 30.0, 45.0 / 20.0)
    assert abs(s - 70.7168) < 0.01 and p == "Baik", (s, p, om)

    s, p, _ = infer(1.0, 1.0, 1.0, 1.0)
    assert abs(s - 19.4444) < 0.01 and p == "Kurang", (s, p)

    s, p, _ = infer(2.0, 2.0, 2.0, 2.0)
    assert abs(s - 50.0) < 0.01 and p == "Cukup", (s, p)

    s, p, _ = infer(3.0, 3.0, 3.0, 3.0)
    assert abs(s - 80.5556) < 0.01 and p == "Baik", (s, p)

    s, p, _ = infer(2.8, 2.8, 2.8, 1.2)
    assert abs(s - 50.0) < 0.01 and p == "Cukup", (s, p)

    s, p, _ = infer(1.2, 2.8, 1.2, 2.8)
    assert p == "Kurang", (s, p)

    try:
        infer(0.5, 2.0, 2.0, 2.0)
        raise AssertionError("Out-of-range input should fail")
    except ValueError:
        pass


def main():
    if len(sys.argv) == 2 and sys.argv[1] == "--test":
        run_self_tests()
        print("OK")
        return

    if len(sys.argv) != 5:
        sys.stderr.write("Penggunaan: python fuzzy_edom.py <ped> <pro> <kep> <sos>\n")
        sys.exit(1)

    try:
        ped = float(sys.argv[1])
        pro = float(sys.argv[2])
        kep = float(sys.argv[3])
        sos = float(sys.argv[4])
        skor, predikat, out_mu = infer(ped, pro, kep, sos)
    except ValueError as err:
        sys.stderr.write(str(err) + "\n")
        sys.exit(1)

    print(
        f'{{"skor": {skor:.2f}, "predikat": "{predikat}", '
        f'"agregasi": {{"kurang": {out_mu[0]:.4f}, "cukup": {out_mu[1]:.4f}, "baik": {out_mu[2]:.4f}}}}}'
    )


if __name__ == "__main__":
    main()
