(function () {
    const collapseBtn = document.getElementById('sidebarCollapseBtn');
    const bodyEl = document.body;
    const COLLAPSED_CLASS = 'sidebar-collapsed';

    function updateCollapseIcon(btn) {
        if (!btn) return;
        const icon = btn.querySelector('span[aria-hidden="true"]');
        if (!icon) return;
        const collapsed = bodyEl.classList.contains(COLLAPSED_CLASS);
        icon.textContent = collapsed ? '⮞' : '⮜';
    }

    if (collapseBtn) {

        if (localStorage.getItem('sidebar-pref') === 'true') {
            bodyEl.classList.add(COLLAPSED_CLASS);
            updateCollapseIcon(collapseBtn);
        }
        collapseBtn.addEventListener('click', function (e) {
            e.preventDefault();
            bodyEl.classList.toggle(COLLAPSED_CLASS);
            updateCollapseIcon(this);

            const isCollapsed = bodyEl.classList.contains(COLLAPSED_CLASS);
            localStorage.setItem('sidebar-pref', isCollapsed);
        });
    }

    // Mobile Offcanvas handling
    const offcanvasEl = document.getElementById('sidebarOffcanvas');
    const openFixedBtn = document.querySelector('.sidebar-toggle-fixed');

    if (offcanvasEl && openFixedBtn) {
        offcanvasEl.addEventListener('show.bs.offcanvas', () => openFixedBtn.style.display = 'none');
        offcanvasEl.addEventListener('hidden.bs.offcanvas', () => openFixedBtn.style.display = '');
    }
})();