function confirmRoadmap() {
    const modal = new bootstrap.Modal(document.getElementById('saveModal'));
    modal.show();
}

function finalSubmit() {
    document.getElementById('roadmapForm').submit();
}

// Surprise: Dynamic Auto-resize textareas as the user types
document.querySelectorAll('textarea').forEach(el => {
    el.style.height = el.scrollHeight + 'px';
    el.addEventListener('input', function () {
        this.style.height = 'auto';
        this.style.height = (this.scrollHeight) + 'px';
    });
});

// Surprise: Visual feedback on Action Cards
document.querySelectorAll('.action-card input').forEach(el => {
    el.addEventListener('focus', function () {
        this.closest('.action-card').style.borderTopColor = '#007bff';
    });
    el.addEventListener('blur', function () {
        this.closest('.action-card').style.borderTopColor = '#ffc107';
    });
});
