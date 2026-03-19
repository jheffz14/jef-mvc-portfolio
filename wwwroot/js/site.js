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





// ── POS MODAL ─────────────────────────────────────────────────────────────
let posCurrentSlide = 0;
let posTotalSlides = 0;

function openPOSModal() {
    const modal = document.getElementById('posModal');
    if (!modal) return;
    posTotalSlides = document.querySelectorAll('#posSlides > div').length;
    posCurrentSlide = 0;
    updatePOSCarousel();
    modal.style.display = 'flex';
    document.body.style.overflow = 'hidden';
}

function closePOSModal() {
    const modal = document.getElementById('posModal');
    if (!modal) return;
    modal.style.display = 'none';
    document.body.style.overflow = '';
}

function posSlide(direction) {
    posCurrentSlide = (posCurrentSlide + direction + posTotalSlides) % posTotalSlides;
    updatePOSCarousel();
}

function posGoTo(index) {
    posCurrentSlide = index;
    updatePOSCarousel();
}

function updatePOSCarousel() {
    const track = document.getElementById('posSlides');
    const counter = document.getElementById('posCounter');
    if (!track || !counter) return;

    track.style.transform = `translateX(-${posCurrentSlide * 100}%)`;
    counter.textContent = posCurrentSlide + 1;

    // ✅ use .active class instead of inline background style
    document.querySelectorAll('.pos-dot').forEach((dot, i) => {
        dot.classList.toggle('active', i === posCurrentSlide);
    });
}

document.addEventListener('DOMContentLoaded', function () {

    const openBtn = document.getElementById('openPOSBtn');
    const prevBtn = document.getElementById('posPrevBtn');
    const nextBtn = document.getElementById('posNextBtn');
    const closeBtn = document.getElementById('posCloseBtn');
    const modal = document.getElementById('posModal');

    if (openBtn) openBtn.addEventListener('click', openPOSModal);
    if (prevBtn) prevBtn.addEventListener('click', () => posSlide(-1));
    if (nextBtn) nextBtn.addEventListener('click', () => posSlide(1));
    if (closeBtn) closeBtn.addEventListener('click', closePOSModal);

    if (modal) {
        modal.addEventListener('click', function (e) {
            if (e.target === modal) closePOSModal();
        });
    }

    document.querySelectorAll('.pos-dot').forEach(dot => {
        dot.addEventListener('click', function () {
            posGoTo(parseInt(this.dataset.index));
        });
    });
});



//for projhects section carousel
(function () {
    const MOBILE_BP = 768;

    const grid = document.getElementById('projectsGrid');
    const controls = document.getElementById('carouselControls');
    const dotsEl = document.getElementById('carouselDots');
    const prevBtn = document.getElementById('carouselPrev');
    const nextBtn = document.getElementById('carouselNext');

    if (!grid || !controls) return;

    let cards = [];
    let currentIndex = 0;
    let isMobile = false;
    let dots = [];

    function buildDots() {
        dotsEl.innerHTML = '';
        dots = [];
        cards.forEach((_, i) => {
            const dot = document.createElement('button');
            dot.className = 'carousel-dot' + (i === 0 ? ' active' : '');
            dot.setAttribute('aria-label', `Go to project ${i + 1}`);
            dot.addEventListener('click', () => goTo(i));
            dotsEl.appendChild(dot);
            dots.push(dot);
        });
    }

    function syncUI(index) {
        dots.forEach((d, i) => d.classList.toggle('active', i === index));
        prevBtn.disabled = index === 0;
        nextBtn.disabled = index === cards.length - 1;
        currentIndex = index;
    }

    function goTo(index) {
        const card = cards[index];
        if (!card) return;
        const scrollLeft = grid.scrollLeft + card.getBoundingClientRect().left - grid.getBoundingClientRect().left;
        grid.scrollTo({ left: scrollLeft, behavior: 'smooth' });
        syncUI(index);
    }

    function onScroll() {
        const gridLeft = grid.getBoundingClientRect().left;
        let closest = 0;
        let minDist = Infinity;
        cards.forEach((card, i) => {
            const dist = Math.abs(card.getBoundingClientRect().left - gridLeft);
            if (dist < minDist) { minDist = dist; closest = i; }
        });
        syncUI(closest);
    }

    function init() {
        cards = Array.from(grid.querySelectorAll('.project-card'));
        buildDots();
        syncUI(0);
        grid.addEventListener('scroll', onScroll, { passive: true });
        prevBtn.addEventListener('click', () => goTo(currentIndex - 1));
        nextBtn.addEventListener('click', () => goTo(currentIndex + 1));
    }

    function destroy() {
        grid.removeEventListener('scroll', onScroll);
        dotsEl.innerHTML = '';
        dots = [];
        currentIndex = 0;
    }

    function checkBreakpoint() {
        const nowMobile = window.innerWidth <= MOBILE_BP;
        if (nowMobile && !isMobile) { isMobile = true; init(); }
        if (!nowMobile && isMobile) { isMobile = false; destroy(); }
    }

    checkBreakpoint();
    window.addEventListener('resize', checkBreakpoint);

    // Touch swipe support
    let touchStartX = 0;
    grid.addEventListener('touchstart', e => {
        touchStartX = e.touches[0].clientX;
    }, { passive: true });

    grid.addEventListener('touchend', e => {
        if (!isMobile) return;
        const diff = touchStartX - e.changedTouches[0].clientX;
        if (Math.abs(diff) > 40) {
            diff > 0 ? goTo(currentIndex + 1) : goTo(currentIndex - 1);
        }
    }, { passive: true });

})();



// After page loads, if message was sent, scroll to contact section
window.addEventListener('load', function () {
    const successMsg = document.querySelector('.form-success');
    if (successMsg) {
        successMsg.scrollIntoView({ behavior: 'smooth' });
    }
});

// Auto hide success message after 5 seconds
const successMsg = document.querySelector('.form-success');
if (successMsg) {
    setTimeout(() => {
        successMsg.style.transition = 'opacity 1s ease';
        successMsg.style.opacity = '0';
        setTimeout(() => successMsg.style.display = 'none', 1000);
    }, 5000);
}



//ajax function for contact form submission
document.getElementById("contactForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const form = this;
    const formData = new FormData(form);

    const response = await fetch(form.action, {
        method: "POST",
        body: formData
    });

    const result = await response.json();

    // Remove old messages
    document.querySelectorAll(".form-msg").forEach(e => e.remove());

    if (result.success) {
        const msg = document.createElement("div");
        msg.className = "form-success form-msg";
        msg.innerText = "✅ Message sent! I'll get back to you soon.";
        form.prepend(msg);

        form.reset(); // clear fields
        // ✅ AUTO HIDE (move here)
        setTimeout(() => {
            msg.style.transition = 'opacity 1s ease';
            msg.style.opacity = '0';
            setTimeout(() => msg.remove(), 1000);
        }, 5000);
    } else {
        const msg = document.createElement("div");
        msg.className = "form-error form-msg";

        if (result.errors) {
            msg.innerHTML = result.errors.join("<br>");
        } else {
            msg.innerText = result.error || "Something went wrong.";
        }

        form.prepend(msg);
    }
});