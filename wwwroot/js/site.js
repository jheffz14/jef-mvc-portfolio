// ── MOBILE MENU ──────────────────────────────────────────────────────────
function toggleMenu() {
    document.getElementById('navLinks').classList.toggle('open');
}

// Close menu when a link is clicked
document.querySelectorAll('.nav-links a').forEach(link => {
    link.addEventListener('click', () => {
        document.getElementById('navLinks').classList.remove('open');
    });
});

// ── SCROLL REVEAL ─────────────────────────────────────────────────────────
// Watches elements and adds the 'visible' class when they scroll into view
const revealObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('visible');
            revealObserver.unobserve(entry.target); // Only animate once
        }
    });
}, { threshold: 0.15 });

// Watch all sections and project cards
document.querySelectorAll('.reveal, .project-card').forEach(el => {
    revealObserver.observe(el);
});

// ── SKILL BAR ANIMATION ──────────────────────────────────────────────────
// Animates skill bars when they scroll into view
const skillObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.querySelectorAll('.skill-fill').forEach((bar, i) => {
                const level = bar.getAttribute('data-level');
                setTimeout(() => {
                    bar.style.width = level + '%';
                }, i * 80); // Stagger each bar by 80ms
            });
            skillObserver.unobserve(entry.target);
        }
    });
}, { threshold: 0.2 });

const skillsGrid = document.getElementById('skillsGrid');
if (skillsGrid) skillObserver.observe(skillsGrid);

// ── SKILL FILTER ─────────────────────────────────────────────────────────
function filterSkills(category, btn) {
    // Update active button
    document.querySelectorAll('.filter-btn').forEach(b => b.classList.remove('active'));
    btn.classList.add('active');

    // Show/hide skill items
    document.querySelectorAll('.skill-item').forEach(item => {
        const match = category === 'All' || item.dataset.category === category;
        item.style.display = match ? 'block' : 'none';
    });
}

// ── ACTIVE NAV LINK ON SCROLL ────────────────────────────────────────────
const sections = document.querySelectorAll('section[id]');
const navLinks = document.querySelectorAll('.nav-links a');

const navObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            navLinks.forEach(link => {
                link.classList.remove('nav-active');
                if (link.getAttribute('href') === '#' + entry.target.id) {
                    link.classList.add('nav-active');
                }
            });
        }
    });
}, { threshold: 0.4 });

sections.forEach(s => navObserver.observe(s));
