
import math

class EC_PMM_FiberAnalyticIntegration:
    """
    Flexible Eurocode 2 PMM Solver.
    Parameters are adjustable for different Concrete Classes and National Annexes.
    """
    def __init__(self, fc, fy, width, height, 
                 gamma_c=1.5, gamma_s=1.15, alpha_cc=0.85,
                 es=200000.0, eps_c2=0.002, eps_cu2=0.0035, n_exponent=2.0):
        # Material Strengths
        self.fc = fc
        self.fy = fy
        self.fcd = (alpha_cc * fc) / gamma_c
        self.fyd = fy / gamma_s
        
        # Section Geometry
        self.width = width
        self.height = height
        
        # Material Constants (Configurable)
        self.alpha_cc = alpha_cc
        self.es = es
        self.eps_c2 = eps_c2
        self.eps_cu2 = eps_cu2
        self.n_exponent = n_exponent # For C > C50/60, n changes
        
        self.bars = []

    def add_rebar(self, x, y, area):
        self.bars.append({'x': x, 'y': y, 'area': area})

    def _get_concrete_stress(self, strain):
        if strain <= 0: return 0
        eps = min(strain, self.eps_cu2)
        if eps < self.eps_c2:
            # Parabolic: fcd * [1 - (1 - eps/ec2)^n]
            return self.fcd * (1.0 - (1.0 - eps/self.eps_c2)**self.n_exponent)
        return self.fcd

    def _integ_stress_base(self, y, eps_bot, k, h):
        """Analytical integral (Supports n=2.0 case)."""
        e = eps_bot + k * (y + h/2)
        if e <= 0: return 0, 0
        e_limit = min(e, self.eps_cu2)
        y_limit = (e_limit - eps_bot)/k - h/2
        e_p = min(e_limit, self.eps_c2)
        y_p = (e_p - eps_bot)/k - h/2
        y_low = max(-h/2, (0 - eps_bot)/k - h/2)
        
        # Note: For n != 2.0, the analytical formula changes. 
        # Here we provide the exact solution for n=2.0 (Common for <= C50/60).
        def get_P_at(yi):
            ei = eps_bot + k * (yi + h/2)
            ui = 1 - ei/self.eps_c2
            return self.fcd * (yi + (self.eps_c2/k) * (ui**3)/3)
        def get_M_at(yi):
            ei = eps_bot + k * (yi + h/2)
            ui = 1 - ei/self.eps_c2
            return self.fcd * ( (yi**2)/2 + (self.eps_c2/k)*(yi*ui**3/3 + (self.eps_c2/k)*ui**4/12) )
            
        p_para = get_P_at(y_p) - get_P_at(y_low)
        m_para = get_M_at(y_p) - get_M_at(y_low)
        
        if e_limit > self.eps_c2:
            p_rect = self.fcd * (y_limit - y_p)
            m_rect = self.fcd * (y_limit**2 - y_p**2)/2
            return p_para + p_rect, m_para + m_rect
        return p_para, m_para

    def calculate_forces(self, eps_top, eps_bot, theta_deg, method='analytical'):
        h = self.height if theta_deg % 180 == 0 else self.width
        w = self.width if theta_deg % 180 == 0 else self.height
        theta_rad = math.radians(theta_deg)
        cos_t, sin_t = math.cos(theta_rad), math.sin(theta_rad)

        if method == 'fiber' or self.n_exponent != 2.0:
            # Use fiber for complex exponents or requested mesh
            num_fibers = 500
            dy = h / num_fibers
            p_conc, m_conc = 0, 0
            for i in range(num_fibers):
                y_f = -h/2 + (i + 0.5) * dy
                strain = eps_bot + (eps_top - eps_bot) * (y_f + h/2) / h
                stress = self._get_concrete_stress(strain)
                force = -stress * (w * dy)
                p_conc += force
                m_conc += force * y_f
        else:
            if abs(eps_top - eps_bot) < 1e-10:
                stress = self._get_concrete_stress(eps_top)
                p_conc = -stress * w * h
                m_conc = 0
            else:
                k = (eps_top - eps_bot) / h
                p_c, m_c = self._integ_stress_base(h/2, eps_bot, k, h)
                p_conc = -p_c * w
                m_conc = -m_c * w

        p_steel, m_steel = 0, 0
        for bar in self.bars:
            yp = -bar['x'] * sin_t + bar['y'] * cos_t
            strain = eps_bot + (eps_top - eps_bot) * (yp + h/2) / h
            f_s = max(-self.fyd, min(self.fyd, strain * self.es))
            f_c = self._get_concrete_stress(strain)
            force = -(f_s - f_c) * bar['area']
            p_steel += force
            m_steel += force * yp
            
        return (p_conc + p_steel) / 1000, abs((m_conc + m_steel) / 1e6)

    def solve_for_axial(self, target_p_kn, theta_deg, p_limit=None):
        # Adjustable Peak capacity clipping
        if p_limit and target_p_kn <= p_limit: return p_limit, 0.0
        
        sweep = []
        for e_bot in [x/5000.0 for x in range(-1250, 176)]:
            sweep.append(self.calculate_forces(self.eps_cu2, e_bot, theta_deg))
        pivot_y = self.height/2 - (1 - self.eps_c2/self.eps_cu2) * self.height
        ratio = (pivot_y + self.height/2) / self.height
        for e_top in [x/5000.0 for x in range(35, 19, -1)]:
            e_bot = (self.eps_c2 - e_top * ratio) / (1 - ratio)
            sweep.append(self.calculate_forces(e_top, e_bot, theta_deg))
            
        for i in range(len(sweep) - 1):
            p1, m1 = sweep[i]
            p2, m2 = sweep[i+1]
            if (p1 >= target_p_kn >= p2) or (p1 <= target_p_kn <= p2):
                if abs(p1 - p2) < 1e-10: return target_p_kn, m1
                t = (target_p_kn - p1) / (p2 - p1)
                return target_p_kn, m1 + t * (m2 - m1)
        return target_p_kn, 0.0
